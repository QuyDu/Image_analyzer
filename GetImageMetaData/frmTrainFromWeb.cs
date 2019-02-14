using GetImageMetaData.Properties;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace GetImageMetaData
{
    public partial class FrmTrainFromWeb : Form
    {
        const string FBI_TOP10_GROUP_ID = "fbitopten";
        const string FBI_TOP10_GROUP_DISPLAY_NAME = "FBI Top Ten";
        const string FBI_FUGITIVE_GROUP_ID = "fugitives";
        const string FBI_FUGITIVE_GROUP_DISPLAY_NAME = "FBI Fugitives";
        const string FBI_TERRORIST_GROUP_ID = "terrorist";
        const string FBI_TERRORIST_GROUP_DISPLAY_NAME = "FBI Wanted Terrorist";

        private Options _options = new Options();

        public FrmTrainFromWeb()
        {
            InitializeComponent();
        }

        private List<ImageInfo> ScrapeImagesFromFbi(string category)
        {
            List<ImageInfo> imageList = new List<ImageInfo>();
            string errStr;

            using (WebClient client = new WebClient())
            {
                int pages = 15;
                for (int i = 1; i <= pages; i++)
                {
                    int page = i;
                    string siteUrl = $"https://api.fbi.gov/wanted?pageSize=100&page={page}";
                    //string json = client.DownloadString("https://api.fbi.gov/wanted?pageSize=50000");
                    string json = client.DownloadString(siteUrl);
                    dynamic obj = JsonConvert.DeserializeObject(json);

                    foreach (dynamic item in obj.items)
                    {
                        string name = item.title.Value;
                        string url = item.url.Value;
                        if (url.Contains(category))
                        {
                            if (item.images.Count > 0)
                            {
                                string picUrl = item.images[0].large.Value;
                                byte[] picBytes = getImageBytesFromURL(picUrl, out errStr);
                                if (picBytes != null)
                                {
                                    // we got the picture image bytes ok - add it to our list
                                    imageList.Add(new ImageInfo(name, picBytes));
                                    addStatus($"Added '{name}' and {picBytes.Length} bytes of image to list");
                                }
                                else
                                    addStatus($"Error obtaining image bytes from url {picUrl}: {errStr}");
                            }
                            else
                                addStatus($"No images found for name '{name}'");
                        }
                    }
                } 
            }
            return imageList;
        }

        private byte[] getImageBytesFromURL(string url, out string errStr)
        {
            byte[] bytes = null;
            errStr = "";

            try
            {
                using (var client = new WebClient())
                {
                    bytes = client.DownloadData(url);
                }
            }
            catch (Exception ex)
            {
                errStr = ex.Message;
            }

            return bytes;
        }

        private async Task<bool> TrainWithImages(List<ImageInfo> imageList, string groupId, string groupDisplayName)
        {
            foreach (ImageInfo imageInfo in imageList)
            {
                MemoryStream stream = new MemoryStream(imageInfo.ImageBytes);
                string statusStr = await GenLib.AddFace(stream, imageInfo.Name, groupId, groupDisplayName, false);
                addStatus(statusStr);
            }

            return true; // hack alert - really must return whether *all* images were trained
        }

        private async void cmdTrain_ClickAsync(object sender, EventArgs e)
        {
            // https://www.fbi.gov/wanted/topten/lamont-stephenson/@@images/image.jpg
            // https://api.fbi.gov/@wanted
            // https://api.fbi.gov/@wanted?pageSize=20&page=1&sort_on=modified&sort_order=desc

            if (!string.IsNullOrWhiteSpace(cmbWebSite.Text))
            {
                string webSiteGroupId = string.Empty;
                string websiteGroupDisplayName = string.Empty;
                List<ImageInfo> imagesToTrain = new List<ImageInfo>();

                switch (cmbWebSite.Text)
                {
                    case "FBI Top Ten Most Wanted":
                        webSiteGroupId = FBI_TOP10_GROUP_ID;
                        websiteGroupDisplayName = FBI_TOP10_GROUP_DISPLAY_NAME;
                        imagesToTrain = ScrapeImagesFromFbi("topten");
                        break;

                    case "FBI Fugitives":
                        webSiteGroupId = FBI_FUGITIVE_GROUP_ID;
                        websiteGroupDisplayName = FBI_FUGITIVE_GROUP_DISPLAY_NAME;
                        imagesToTrain = ScrapeImagesFromFbi("fugitive");
                        break;

                    case "FBI Most Wanted Terrorist":
                        webSiteGroupId = FBI_TERRORIST_GROUP_ID;
                        websiteGroupDisplayName = FBI_TERRORIST_GROUP_DISPLAY_NAME;
                        imagesToTrain = ScrapeImagesFromFbi("terrorist");
                        break;
                }

                if (MessageBox.Show($@"Are you sure you want to capture the images from '{cmbWebSite.Text}'?", @"Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    await TrainWithImages(imagesToTrain, webSiteGroupId, websiteGroupDisplayName);
                }  
            }
        }

        public static HttpWebRequest GenerateHttpWebRequest(Uri uri)
        {
            HttpWebRequest httpRequest = (HttpWebRequest) WebRequest.Create(uri);
            return httpRequest;
        }

        public static HttpWebRequest GenerateHttpWebRequest(Uri uri, string postData, string contentType)
        {
            HttpWebRequest httpRequest = GenerateHttpWebRequest(uri);
            byte[] bytes = Encoding.UTF8.GetBytes(postData);

            httpRequest.ContentType = contentType;

            httpRequest.ContentLength = postData.Length;
            using (Stream requestStream = httpRequest.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }

            return httpRequest;
        }


        private void addStatus(string msg)
        {
            lstStatus.Items.Add(msg);
            lstStatus.SelectedIndex = lstStatus.Items.Count - 1;
        }
    }
}


#region FBI API Reference 
//Implementation Notes
//  backward compatible aliases of this endpoint
//    https://api.fbi.gov/wanted 
//    https://api.fbi.gov/wanted/v1 
//    https://api.fbi.gov/wanted/v1/list 
//    https://api.fbi.gov/wanted/list
//
//  Response Class(Status 200)
//  List recent wanted
//  Model
//  Example Value
//  Wanted Result Set 
//  {
//      total(integer, optional),
//      page(integer, optional),
//      items(Array[Wanted Person], optional)
//  }

//  Wanted Person
//  {
//      @id (string, optional),
//      uid (string, optional),
//      title (string, optional),
//      description (string, optional),
//      images (Array [Wanted Image], optional),
//      files (Array [Wanted File], optional),
//      warning_message (string, optional),
//      remarks (string, optional),
//      details (string, optional),
//      additional_information (string, optional),
//      caution (string, optional),
//      reward_text (string, optional),
//      reward_min (integer, optional),
//      reward_max (integer, optional),
//      dates_of_birth_used (Array [string], optional),
//      place_of_birth (string, optional),
//      locations (Array [string], optional),
//      field_offices (Array [string], optional),
//      legat_names (Array [string], optional),
//      status (string, optional),
//      person_classification (string, optional),
//      ncic (string, optional),
//      age_min (integer, optional),
//      age_max (integer, optional),
//      weight_min (integer, optional),
//      weight_max (integer, optional),
//      height_min (integer, optional),
//      height_max (integer, optional),
//      eyes (string, optional),
//      hair (string, optional),
//      build (string, optional),
//      sex (string, optional),
//      race (string, optional),
//      nationality (string, optional),
//      scars_and_marks (string, optional),
//      complexion (string, optional),
//      occupations (string, optional),
//      possible_countries (Array [string], optional),
//      possible_states (Array [string], optional),
//      modified (string, optional),
//      publication (string, optional),
//      path (string, optional)
//  }
//
//  Wanted Image
//  {
//      caption (string, optional),
//      original (string, optional),
//      large (string, optional),
//      thumb (string, optional)
//  }
//
//  Wanted File
//  {
//      url (string, optional),
//      name (string, optional)
//  }
#endregion