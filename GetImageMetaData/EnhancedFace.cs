using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Face.Contract;

namespace GetImageMetaData
{
    public class EnhancedFace : Face
    {
        public EnhancedFace(Face baseFace, string candidateName)
        {
            this.FaceId = baseFace.FaceId;
            this.FaceRectangle = baseFace.FaceRectangle;
            this.FaceLandmarks = baseFace.FaceLandmarks;
            this.FaceAttributes = baseFace.FaceAttributes;
            
            this.CandidateName = candidateName;
        }

        public string CandidateName { get; set; }
    }
}
