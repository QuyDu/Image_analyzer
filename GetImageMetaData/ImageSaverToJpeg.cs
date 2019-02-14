using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetImageMetaData
{
    internal class ImageSaverToJpeg
    {
        public ImageSaverToJpeg(MemoryStream ms, string fileName)
        {
            var _videoFrameCapture = ms;
            var _fileToSave = fileName;
            SaveFileOnDisk(_videoFrameCapture, _fileToSave);
        }

        public void SaveFileOnDisk(MemoryStream ms, string fileName)
        {
            try
            {
                //these 5 lines will create C:\temp and C:\temp\Images folders if they dont exist
                const string strpath = @"C:\temp\Images";
                const string workingDirectory = strpath;
                var wholePath = workingDirectory + "\\" + fileName + ".jpg";
                var directory = new FileInfo(wholePath);
                directory.Directory.Create(); // If the directory already exists, this method does nothing.

                //saves an image from a data stream to a variable
                var imgSave = Image.FromStream(ms);
                //creates a bitmap from the saved image
                var bmSave = new Bitmap(imgSave);
                var bmTemp = new Bitmap(bmSave);
                //saves image to a jpg file with the same dimensions
                var grSave = Graphics.FromImage(bmTemp);
                grSave.DrawImage(imgSave, 0, 0, imgSave.Width, imgSave.Height);

                bmTemp.Save(workingDirectory + "\\" + fileName + ".jpg");

                //disposes of all images in memory to free up memory space
                imgSave.Dispose();
                bmSave.Dispose();
                bmTemp.Dispose();
                grSave.Dispose();
            }
            //used for troubleshooting since stepping in won't work.
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}
