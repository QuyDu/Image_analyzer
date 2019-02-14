using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetImageMetaData
{
    class ImageInfo
    {
        public string Name;
        public byte[] ImageBytes;

        public ImageInfo(string name, byte[] imageBytes)
        {
            Name = name;
            ImageBytes = imageBytes;
        }
    }
}
