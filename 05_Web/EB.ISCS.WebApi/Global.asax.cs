using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using EB.ISCS.FrameworkEntity.SystemEntity;
using EB.ISCS.FrameworkHelp.Tools;
using EB.ISCS.FrameworkLog.LogModel;
using EB.ISCS.ToolService.LogService;
using WebGrease;

namespace EB.ISCS.WebApi
{
    /// <summary>
    /// 
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// 
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            LogHelper.WriteInfoLog("系统启动");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {

            var exception = Server.GetLastError();
            LogException(exception);
        }

        protected void LogException(Exception exc)
        {
            if (exc == null)
                return;
            //ignore 404 HTTP errors
            var httpException = exc as HttpException;
            if (httpException != null && httpException.GetHttpCode() == 404)
            {
            }

            try
            {
                //log

                SysExceptionLog exceptionLogEntry = new SysExceptionLog();
                exceptionLogEntry.ExceptionSource = exc.Source;
                exceptionLogEntry.ExceptionDescription = exc.Message;
                exceptionLogEntry.ExceptionStackTrace = exc.StackTrace;
                exceptionLogEntry.ExceptionTargetSite = exc.TargetSite.ToString();
                exceptionLogEntry.ExceptionType = "1";
                exceptionLogEntry.ExceptionTypeName = "Api异常";

                WriteExceptionLog.WriteLogException(exceptionLogEntry);
                // var log = LogManager.GetLogger("api");
                LogHelper.WriteErrorLog(Context.Request.Url.ToString(), Context.Error);
            }
            catch (Exception)
            {
                //don't throw new exception if occurs
            }
        }
    }
}
