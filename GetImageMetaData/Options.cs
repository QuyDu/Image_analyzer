using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using Microsoft.ProjectOxford.Vision;
using System.Threading.Tasks;
using MessageBox = System.Windows.Forms.MessageBox;

namespace GetImageMetaData
{
    // Update 03/09/2019 01:30 PM
    class Options
    {
        public string CSKey;
        public string CSEndpoint;
        public string VisionEndpoint;
        public string FaceEndpoint;
        public string ContainerEndpoint;
        public string TextAnalyticsKey;
        public string TextAnalyticsEndpoint;
        public string TextTransKey;
        public string TextTransEndpoint;
        public string PersonGroupId;
        public string groupID;
        public string PersonGroupName;
        public string Dvrip;
        public string Camoip;
        public string OtherCamera;
        public string DvrUserName;
        public string DvrPassword;
        public string CamoUserName;
        public string CamoPassword;
        public int Camoch;
        public int Dvrch;
        public int Camosubch;
        public int Dvrsubch;
        public string SelCameraNetwork;
        public string SelCamera;
        public int TimeDelay;
        public string _personGroupDisplayName;
        public bool personGroupFound;
        public bool ContainerMode;
        public bool Internet;

        public FrameGrabber<LiveCameraResult> _grabber = new FrameGrabber<LiveCameraResult>();
        //Clients
        public FaceServiceClient _faceServiceClient;

        public VisionServiceClient _visionServiceClient;

        public async Task UpdateMemberVarsFromProperties()
        {   // Cognitive Services API's
            Internet = GenLib.CheckForInternetConnection();
            ContainerMode = Properties.Settings.Default.useContainerMode;
            CSKey = Properties.Settings.Default.cognitiveServicesKey.Trim();
            CSEndpoint = Properties.Settings.Default.cognitiveServicesEndpoint.Trim();
            FaceEndpoint = $"{CSEndpoint}face/v1.0";
            //FaceEndpoint = "https://westus.api.cognitive.microsoft.com/face/v1.0";
            VisionEndpoint = $"{CSEndpoint}vision/v1.0";
            //VisionEndpoint = "https://westus.api.cognitive.microsoft.com/vision/v1.0";
            ContainerEndpoint = "https://localhost:5000";
            TextAnalyticsKey = Properties.Settings.Default.textKey;
            TextAnalyticsEndpoint = Properties.Settings.Default.textEndpoint;
            TextTransKey = Properties.Settings.Default.translatorKey;
            TextTransEndpoint = Properties.Settings.Default.translatorEndpoint;
            // Face API Profiles
            groupID = Properties.Settings.Default.personGroupID;
            // API Clients
            if (!string.IsNullOrWhiteSpace(CSKey) || !string.IsNullOrWhiteSpace(CSEndpoint))
            {
                personGroupFound = false;
                _faceServiceClient = new FaceServiceClient(CSKey, FaceEndpoint);
                _visionServiceClient = new VisionServiceClient(CSKey, VisionEndpoint);
                if (!ContainerMode)
                {
                    if (Internet)
                    {
                        try
                        {
                            PersonGroup personGroupInfo = await _faceServiceClient.GetPersonGroupAsync(groupID);
                            PersonGroupId = Properties.Settings.Default.personGroupID;
                            PersonGroupName = Properties.Settings.Default.personGroupName;
                            personGroupFound = true;
                        }
                        catch
                        {
                            try
                            {
                                PersonGroup[] personGroups = await _faceServiceClient.ListPersonGroupsAsync(CSKey);
                                PersonGroupId = personGroups[0].PersonGroupId;
                                PersonGroup personGroupInfo = await _faceServiceClient.GetPersonGroupAsync(PersonGroupId);
                                PersonGroupName = personGroupInfo.Name;
                                Properties.Settings.Default.personGroupID = PersonGroupId;
                                Properties.Settings.Default.personGroupName = PersonGroupName;
                                personGroupFound = true;
                            }
                            catch
                            {

                            }
                        }
                        _personGroupDisplayName = !string.IsNullOrWhiteSpace(PersonGroupName) ? PersonGroupName : PersonGroupId;
                    }
                    else
                    {
                        MessageBox.Show(GenLib.SetMessage("Internet", string.Empty, string.Empty, null));
                    }
                }
            }
            // Camera Information
            Camoip = Properties.Settings.Default.ipCameraIP;
            CamoUserName = Properties.Settings.Default.ipCameraUserName;
            CamoPassword = Properties.Settings.Default.ipCameraPassword;
            Camoch = Properties.Settings.Default.ipCameraChannels;
            Camosubch = Properties.Settings.Default.ipCameraSubChannel;
            Dvrip = Properties.Settings.Default.dvrIP;
            Dvrch = Properties.Settings.Default.dvrChannels;
            Dvrsubch = Properties.Settings.Default.dvrSubChannel;
            DvrUserName = Properties.Settings.Default.dvrUserName;
            DvrPassword = Properties.Settings.Default.dvrPassword;
            OtherCamera = Properties.Settings.Default.otherVideoSource;
            SelCameraNetwork = Properties.Settings.Default.selCameraNetwork;
            SelCamera = Properties.Settings.Default.selCamera;
            TimeDelay = Properties.Settings.Default.timeDelay* 1000;
        }
        //// add more options here
    }
}
