// 
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license.
// 
// Microsoft Cognitive Services: http://www.microsoft.com/cognitive
// 
// Microsoft Cognitive Services Github:
// https://github.com/Microsoft/Cognitive
// 
// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// MIT License:
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 

using System;
using System.Collections.Generic;
using Microsoft.ProjectOxford.Common.Contract;
using Microsoft.ProjectOxford.Vision.Contract;
using Newtonsoft.Json;
using Face = Microsoft.ProjectOxford.Face.Contract.Face;

namespace GetImageMetaData
{
    // Class to hold all possible result types. 
    public class LiveCameraResult
    {
        public List<string> Identity = new List<string>();
        public DateTime TimeStamp { get; set; }
        public string SelectedCamera { get; set; } = null;
        public string[] TopEmotion { get; set; } = { };
        public string FirstIdentity { get; set; }
        public string[] Who { get; set; } = { };
        public string JpegImageName { get; set; }
        public Face[] Faces { get; set; } = null;
        public EmotionScores[] EmotionScores { get; set; } = null;
        public string[] CelebrityNames { get; set; } = null;
        public Tag[] Tags { get; set; } = null;
        public string[] Object { get; set; } = null;
        public string[] Animal { get; set; } = null;
        public string[] Building { get; set; } = null;
        public string[] Trans { get; set; } = null;

        public string[] People { get; set; } = null;

        //public string[] Object { get; set; } = null;
        public string[] Food { get; set; } = null;
        public string[] Text { get; set; } = null;
        public string[] Plant { get; set; } = null;
        public string[] Scene { get; set; } = null;
        public string[] Indoor { get; set; } = null;
        public string[] Dark { get; set; } = null;
        public string[] Sky { get; set; } = null;
        public string[] Outdoor { get; set; } = null;
        public string[] Abstract { get; set; } = null;
        public OcrResults[] Ocr { get; set; } = null;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
            //return JsonConvert.SerializeObject(this.Identity);
        }
    }
}