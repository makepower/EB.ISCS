using NLog;
using System;

namespace EB.ISCS.FrameworkLog.LogModel
{

    public class LogHelper
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        public static void WriteInfoLog(string content)
        {
            try
            {
                log.Info(content);
            }
            catch (Exception)
            { }
        }

        public static void WriteErrorLog(string url, Exception exception = null)
        {
            try
            {
                log.Error(exception, url);
            }
            catch (Exception)
            { }
        }


        public static void WriteFatalLog(string url, Exception exception = null)
        {
            try
            {
                log.Fatal(exception, url);
            }
            catch (Exception)
            { }
        }
    }
}
