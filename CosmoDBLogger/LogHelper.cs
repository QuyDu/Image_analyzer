using System;
using static CosmoDBLogger.DbLogger;

namespace CosmoDBLogger
{
    public static class LogHelper
    {
        private static DbLogger _dbLogger;
        private static LogBase _logger;


        //public static void Log(LogTarget target, object message, string fileName = null)
        public static void Log(LogTarget target, object message, string fileName = null, string cosmoEndPoint = "",
            string cosmoPrimKey = "", string cosmoDb = "", string cosmoCollection = "")
        {
            switch (target)
            {
                case LogTarget.Binary:
                    _logger = new BinaryLogger(fileName);
                    _logger.Log(message);
                    break;
                case LogTarget.File:
                    _logger = new FileLogger(fileName);
                    _logger.Log(message);
                    break;
                //SPEED

                case LogTarget.Database:
                    // create instance of dbLogger if necessary (this is a static instance)
                    //if (dbLogger == null) dbLogger = new DBLogger();
                    if (_dbLogger == null)
                        _dbLogger = new DbLogger(cosmoEndPoint, cosmoPrimKey, cosmoDb, cosmoCollection);
                    _dbLogger.LogTest(new CosmoLog { Id = Guid.NewGuid().ToString(), Message = message.ToString() },
                        cosmoDb, cosmoCollection);
                    //logger = new DBLogger();
                    //logger.Log(message);

                    break;

                case LogTarget.EventLog:
                    _logger = new EventLogger();
                    _logger.Log(message);
                    break;
                default:
                    return;
            }
        }
    }
}
