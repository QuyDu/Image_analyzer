using System.Diagnostics;

namespace CosmoDBLogger
{
    public class EventLogger : LogBase
    {
        public override void Log(object message)
        {
            lock (LockObj)
            {
                var m_EventLog = new EventLog("") { Source = "IDGEventLog" };
                m_EventLog.WriteEntry(message.ToString());
            }
        }
    }
}
