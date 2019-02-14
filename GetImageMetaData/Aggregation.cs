using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.ProjectOxford.Common.Contract;
using Microsoft.ProjectOxford.Face.Contract;

namespace GetImageMetaData
{
    public class Aggregation
    {
        public static Tuple<string, float> GetDominantEmotion(EmotionScores scores)
        {
            return scores.ToRankedList().Select(kv => new Tuple<string, float>(kv.Key, kv.Value)).First();
        }

        public static string SummarizeEmotion(EmotionScores scores)
        {
            var bestEmotion = GetDominantEmotion(scores);
            return $"{bestEmotion.Item1}: {bestEmotion.Item2:N1}";
        }

        public static string SummarizeFaceAttributes(FaceAttributes attr)
        {
            var attrs = new List<string>();
            if (attr.Gender != null) attrs.Add(attr.Gender);
            if (attr.Age > 0) attrs.Add(attr.Age.ToString(CultureInfo.InvariantCulture));
            if (attr.HeadPose == null) return string.Join(", ", attrs);
            // Simple rule to estimate whether person is facing camera. 
            var facing = Math.Abs(attr.HeadPose.Yaw) < 25;
            attrs.Add(facing ? "facing camera" : "not facing camera");

            return string.Join(", ", attrs);
        }
    }
}
