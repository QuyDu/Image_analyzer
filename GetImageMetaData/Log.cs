using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetImageMetaData
{
    internal class Log
    {
        //private readonly string _filePath;

        //public Log()
        //{
        //    _filePath = @"C:\temp\CogSvcLog.json";
        //}

        public bool CaptureLog { get; set; }

        //public void SaveData(LiveCameraResult AnalysisFunction)
        public void SaveData(LiveCameraResult analysisFunction, string cosmoEndPoint, string cosmoPrimKey,
            string cosmoDb, string cosmoCollection)
        {
            //LogHelper.Log(LogTarget.Binary, AnalysisFunction, filePath);
            //if (CaptureLog)
            //    LogHelper.Log(LogTarget.Database, analysisFunction, _filePath, cosmoEndPoint, cosmoPrimKey, cosmoDb,
            //        cosmoCollection);
        }

        public void FaceLogFormat<T>(T target)
        {
            var t = typeof(T);

            var timeStamp = DateTime.Now;
        }
    }
}
