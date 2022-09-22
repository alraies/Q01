using NLog;

namespace Test5
{
    public static class DevLogger
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();


        public  static void Write(Exception ex)
        {
            Logger.Error(ex);
        }
        
        public  static void Write(Exception ex,string Msg)
        {
            Logger.Error(ex,Msg);
        }
    }
}
