using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using EB.ISCS.Framework.Utilities.String;
using EB.ISCS.FrameworkEntity.SystemEntity;
using EB.ISCS.FrameworkHelp.Configuration;
using EB.ISCS.FrameworkHelp.Tools;
using EB.ISCS.ToolService.LogService;
using WebGrease;

namespace EB.ISCS.WebApi.Filters
{
    /// <summary>
    /// 操作日志
    /// </summary>
    public class OperateLogAttribute : ActionFilterAttribute
    {
        private static readonly string[] _emptyArray = new string[0];
        private string _permission;
        private string[] _permissions = _emptyArray;

        /// <summary>
        /// 
        /// </summary>
        public string Permission
        {
            get { return _permission ?? string.Empty; }
            set
            {
                _permission = value;
                _permissions = this.SplitString(value, ',');
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string[] Permissions
        {
            get { return _permissions ?? _emptyArray; }
            set
            {
                _permissions = value;
                _permission = string.Join(",", value ?? _emptyArray);
            }
        }
        /// <summary>
        /// 自定义参数
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public OperateLogAttribute()
        {

        }
        /// <summary>
        /// 初始化时填入类的说明
        /// </summary>
        /// <param name="message"></param>
        public OperateLogAttribute(string message)
        {
            msg = message;
        }

        /// <summary>
        /// 
        /// </summary>
        private static readonly string key = "enterTime";


        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {

            if (SkipLogging(actionContext))
            {
                return base.OnActionExecutingAsync(actionContext, cancellationToken);

            }
            //记录进入请求的时间
            actionContext.Request.Properties[key] = DateTime.Now.ToBinary();

            //var menuAction = actionContext.ActionDescriptor.GetCustomAttributes<MenuActionAttribute>().OfType<MenuActionAttribute>().FirstOrDefault();
            //var menu = actionContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<MenuAttribute>().OfType<MenuAttribute>().FirstOrDefault();


            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }

        /// <summary>
        /// 在请求执行完后 记录请求的数据以及返回数据
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            object beginTime = null;
            if (actionExecutedContext.Request.Properties.TryGetValue(key, out beginTime))
            {

                var menuAction = actionExecutedContext.ActionContext.ActionDescriptor.GetCustomAttributes<MenuAttribute>().OfType<MenuAttribute>().FirstOrDefault();
                var menuAction1 = actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<MenuAttribute>().OfType<MenuAttribute>().FirstOrDefault();

                HttpRequestBase request = CurrentHttpContext.Instance().Request;
                DateTime time = DateTime.FromBinary(Convert.ToInt64(beginTime));
                //var accessChannelInfo = ConfigurationHelper.AccessChannelSetting; // load AccessChannel.xml

                SysOperationLog apiActionLog = new SysOperationLog();

                //提取Identity
                var id = CurrentHttpContext.Instance().User.Identity as ClaimsIdentity;
                if (id != null)
                {
                    int accessChannelId = 0;
                    int.TryParse(id?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Actor)?.Value, out accessChannelId);

                    var appType = id?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.System)?.Value;
                    var token = id?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication)?.Value;
                    apiActionLog.SourceEquipment = appType;
                    apiActionLog.Token = token;
                    var data = id?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.UserData)?.Value;
                    if (data != null)
                    {
                        var user = JsonConvert.DeserializeObject<SysUser>(data);
                        if (user != null)
                        {
                            //获取用户token
                            apiActionLog.UserId = user.Id;
                        }
                    }
                }
                else
                {
                    apiActionLog.SourceEquipment = "未知";
                    //获取用户token
                    apiActionLog.UserId = 0;
                }

                //获取action名称
                apiActionLog.MethodAction = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
                //获取Controller 名称
                apiActionLog.FunctionController = actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                //获取action开始执行的时间
                apiActionLog.ExecutionTime = time;
                //获取执行action的耗时
                apiActionLog.ExecutionDuration = (DateTime.Now - time).Milliseconds;
                apiActionLog.Navigator = request.UserAgent;
                //获取访问的ip
                ExploreHelper eh = new ExploreHelper(request);

                apiActionLog.ClientIpAddress = eh.ClientIP;
                //客户端名称
                apiActionLog.ClientName = eh.ClientMachineName;
                //Url来源
                apiActionLog.UrlReferrer = request.UrlReferrer != null ? request.UrlReferrer.AbsoluteUri : "";
                //浏览器信息
                apiActionLog.BrowserInfo = request.Browser.Browser + " - " + request.Browser.Version + " - " + request.Browser.Type;
                //获取request提交的参数
                apiActionLog.Parameters = GetRequestValues(actionExecutedContext) + " " + GetRequestActionValues(actionExecutedContext);

                //获取response响应的结果
                //apiActionLog.Exception = GetResponseValues(actionExecutedContext);
                // "",JsonConvert.SerializeObject(actionExecutedContext.Response.RequestMessage);
                try
                {
                    apiActionLog.IPNum = (int)StringHelper.IPToInt(eh.ClientIP);
                }
                catch
                {
                    apiActionLog.IPNum = 0;
                }
                apiActionLog.Description = msg;

                apiActionLog.RequestUri = request.Url.AbsoluteUri;
                apiActionLog.Enabled = 1;
                WriteLogService.WriteLogOperate(apiActionLog);

            }
            return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);

        }


        #region 自定义方法

        /// <summary>
        /// 读取request 的提交内容
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        /// <returns></returns>
        public string GetRequestValues(HttpActionExecutedContext actionExecutedContext)
        {

            Stream stream = actionExecutedContext.Request.Content.ReadAsStreamAsync().Result;


            Encoding encoding = Encoding.UTF8;
            /*
                这个StreamReader不能关闭，也不能dispose， 关了就傻逼了
                因为你关掉后，后面的管道  或拦截器就没办法读取了
            */
            var reader = new StreamReader(stream, encoding);
            string result = reader.ReadToEnd();
            /*
            这里也要注意：   stream.Position = 0;
            当你读取完之后必须把stream的位置设为开始
            因为request和response读取完以后Position到最后一个位置，交给下一个方法处理的时候就会读不到内容了。
            */
            stream.Position = 0;
            return result;
        }

        /// <summary>
        /// 读取request 的提交内容
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        /// <returns></returns>
        public string GetRequestActionValues(HttpActionExecutedContext actionExecutedContext)
        {

            try
            {
                //  string bb = JsonConvert.SerializeObject(actionExecutedContext.ActionContext.ActionDescriptor.GetParameters());

                Dictionary<string, object> actionargument = actionExecutedContext.ActionContext.ActionArguments;

                var options = new JsonSerializerSettings();
                return JsonConvert.SerializeObject(actionargument, options);
            }
            catch (Exception ex)
            {

                return "{}";
            }

        }

        /// <summary>
        /// 读取action返回的result
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        /// <returns></returns>
        public string GetResponseValues(HttpActionExecutedContext actionExecutedContext)
        {
            Stream stream = actionExecutedContext.Response.Content.ReadAsStreamAsync().Result;
            Encoding encoding = Encoding.UTF8;
            /*
            这个StreamReader不能关闭，也不能dispose， 关了就傻逼了
            因为你关掉后，后面的管道  或拦截器就没办法读取了
            */
            var reader = new StreamReader(stream, encoding);
            string result = reader.ReadToEnd();
            /*
            这里也要注意：   stream.Position = 0; 
            当你读取完之后必须把stream的位置设为开始
            因为request和response读取完以后Position到最后一个位置，交给下一个方法处理的时候就会读不到内容了。
            */
            stream.Position = 0;
            return result;
        }
        /// <summary>
        /// 判断类和方法头上的特性是否要进行Action拦截
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        private static bool SkipLogging(HttpActionContext actionContext)
        {
            return actionContext.ActionDescriptor.GetCustomAttributes<NoLogAttribute>().Any() || actionContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<NoLogAttribute>().Any();
        }

        #endregion
    }
}