
namespace CosmoDBLogger
{
    public enum LogTarget
    {
        Binary,
        File,
        Database,
        EventLog
    }

    //base class that all loggers inherit from
    public abstract class LogBase
    {
        protected readonly object LockObj = new object();
        public abstract void Log(object message);
    }
}
