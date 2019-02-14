using System;
using System.Diagnostics;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace CosmoDBLogger
{
    //public class DBLogger : LogBase
    public class DbLogger
    {
        //private const string CosmoDBName = "CognitiveServicesDemoDB";
        //private const string CosmoCollectionName = "CognitiveServicesDemoCollection";
        private const string
            PartitionKey =
                "/id"; // Must start with "/" for example if the vale you want to add for the Partition Key is "FaceID" than you would type"/FaceID"


        private readonly DocumentClient _client;
        //private Options _options = new Options();
        private readonly DocumentCollection _myCollection = new DocumentCollection();
        private string _connectionString;
        private string _cosmoCollection;
        private string _cosmoDb;
        private string _cosmoEndPoint;
        private string _cosmoPrimKey;
        private static void Main()
            {

            }

        //public DBLogger()
        public DbLogger(string cosmoEndPoint, string cosmoPrimKey, string cosmoDb, string cosmoCollection,
            string connectionString)
        {
            _connectionString = connectionString;
            try
            {
                //this.client = new DocumentClient(new Uri(CosmoEndpointUrl), CosmoPrimaryKey);
                _client = new DocumentClient(new Uri(cosmoEndPoint), cosmoPrimKey);
                //ComosLog lodfile1 = new ComosLog
                //{

                //};

                CreateCosmoDb(cosmoDb);
                CreateCosmoCollection(cosmoDb, cosmoCollection);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
            }
        }

        public DbLogger(string cosmoEndPoint, string cosmoPrimKey, string cosmoDb, string cosmoCollection)
        {
            _cosmoEndPoint = cosmoEndPoint;
            _cosmoPrimKey = cosmoPrimKey;
            _cosmoDb = cosmoDb;
            _cosmoCollection = cosmoCollection;
        }

        //public async void CreateCosmoDB()
        public async void CreateCosmoDb(string cosmoDb)
        {
            try
            {
                //await client.CreateDatabaseIfNotExistsAsync(new Database { Id = CosmoDBName });
                await _client.CreateDatabaseIfNotExistsAsync(new Database { Id = cosmoDb });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("createCosmoDB Exception: " + ex.Message);
            }
        }

        //public async void CreateCosmoCollection()
        public async void CreateCosmoCollection(string cosmoDb, string cosmoCollection)
        {
            try
            {
                //myCollection.Id = CosmoCollectionName;
                _myCollection.Id = cosmoCollection;
                //myCollection.PartitionKey.Paths.Add("/FaceId");
                //myCollection.PartitionKey.Paths.Add(PartitionKey);

                //await client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(CosmoDBName), new DocumentCollection { Id = CosmoCollectionName });
                await _client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(cosmoDb),
                    new DocumentCollection { Id = cosmoCollection });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("createCosmoCollection Exception: " + ex.Message);
            }
        }

        //public async void LogTest(CosmoLog entry)
        public async void LogTest(CosmoLog entry, string cosmoDb, string cosmoCollection)
        {
            try
            {
                //await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(CosmoDBName, CosmoCollectionName), entry);
                await _client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(cosmoDb, cosmoCollection),
                    entry);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("LogTest Exception: " + ex.Message);
            }
        }

        public class CosmoLog
        {
            [JsonProperty(PropertyName = "id")] public string Id;

            public string Message;

            public override string ToString()
            {
                return JsonConvert.SerializeObject(this);
            }
        }
    }
}
