using System.IO;
using Newtonsoft.Json;

namespace CosmoDBLogger
{
    internal class BinaryLogger : LogBase
    {
        public string FilePath;

        public BinaryLogger(string fileName)
        {
            FilePath = fileName;
        }

        public override void Log(object message)
        {
            lock (LockObj)
            {
                var jsonRepresentation = JsonConvert.SerializeObject(message);
                File.AppendAllText(FilePath, jsonRepresentation);
            }
        }
    }
}
