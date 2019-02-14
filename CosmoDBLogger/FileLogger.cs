using System.IO;

namespace CosmoDBLogger
{
    public class FileLogger : LogBase
    {
        public string FilePath;

        public FileLogger(string fileName)
        {
            FilePath = fileName;
        }

        public override void Log(object message)
        {
            lock (LockObj)
            {
                var fileStream = File.OpenWrite(FilePath);
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.WriteLine(message);
                }
            }
        }
    }
}
