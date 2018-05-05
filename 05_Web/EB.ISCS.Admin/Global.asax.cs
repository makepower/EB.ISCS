using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using EB.ISCS.Common.Models;
using EB.ISCS.FrameworkHelp.Tools;

namespace EB.ISCS.Admin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            MvcHandler.DisableMvcResponseHeader = true;
            
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            RegisterView();
            Application.Lock();
            Application["online"] = 0;
            Application.UnLock();

            Application["IsRegister"] = bool.FalseString;
        }

        protected void RegisterView()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new ViewEngineConfig());
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Application["IsRegister"].ToString().Equals(bool.FalseString))
            {
                Application["IsRegister"] = bool.TrueString;
            }
        }

        protected void Session_start(object sender, EventArgs e)
        {
            var flag = Context.Request.Params["flag"];
            if (flag == null || !flag.Equals("0"))
            {
                Application.Lock();
                Application["online"] = (int)Application["online"] + 1;
                Application.UnLock();
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Session.Abandon();
            if ((int)Application["online"] > 0)
            {
                Application["online"] = (int)Application["online"] - 1;
                Application.UnLock();
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();

            logExp(exception);

        }

        void logExp(Exception exception)
        {
            try
            {
                //log
                //ExceptionLogEntry exceptionLogEntry = new ExceptionLogEntry();
                //exceptionLogEntry.ExceptionSource = exception.Source;
                //exceptionLogEntry.ExceptionDescription = exception.Message;
                //exceptionLogEntry.ExceptionStackTrace = exception.StackTrace;
                //exceptionLogEntry.ExceptionTargetSite = exception.TargetSite.ToString();
                //exceptionLogEntry.ExceptionType = "2";
                //exceptionLogEntry.ExceptionTypeName = "Web异常";
                //exceptionLogEntry.AccessChannelId = 0;
               // exceptionLogEntry.MakeLogException(Context.Error, CurrentHttpContext.Instance().Request);
               // ServiceHelper.CallService(ServiceConst.ExceptionLogService.WriteLog, exceptionLogEntry);
                //WriteExceptionLog.WriteLogException(Context.Error, Context.Request, exceptionLogEntry);
            }
            catch (Exception)
            {
                //don't throw new exception if occurs
            }
        }
    }
}
