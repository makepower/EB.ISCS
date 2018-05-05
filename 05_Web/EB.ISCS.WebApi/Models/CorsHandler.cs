using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EB.ISCS.FrameworkEntity.SystemEntity;
using EB.ISCS.FrameworkLog.LogModel;
using EB.ISCS.ToolService.LogService;

namespace EB.ISCS.WebApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class CorsHandler : DelegatingHandler
    {
        //跨域请求会带有这个头
        const string Origin = "Origin";
        const string AccessControlRequestMethod = "Access-Control-Request-Method";
        const string AccessControlRequestHeaders = "Access-Control-Request-Headers";
        const string AccessControlAllowOrigin = "Access-Control-Allow-Origin";
        const string AccessControlAllowMethods = "Access-Control-Allow-Methods";
        const string AccessControlAllowHeaders = "Access-Control-Allow-Headers";
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            bool isCorsRequest = request.Headers.Contains(Origin);
            //是否是检测请求
            bool isPreflightRequest = request.Method == HttpMethod.Options;
            var needApiLog = false;
            Boolean.TryParse(ConfigurationManager.AppSettings["NeedApiLog"], out needApiLog);
            if (isCorsRequest)
            {
                if (isPreflightRequest)
                {
                    return Task.Factory.StartNew<HttpResponseMessage>(() =>
                    {
                        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Headers.Add(AccessControlAllowOrigin, request.Headers.GetValues(Origin).First());
                        if (request.Headers.Contains(AccessControlRequestMethod))
                        {
                            string accessControlRequestMethod = request.Headers.GetValues(AccessControlRequestMethod).FirstOrDefault();
                            if (accessControlRequestMethod != null)
                            {
                                response.Headers.Add(AccessControlAllowMethods, accessControlRequestMethod);
                            }
                        }

                        if (request.Headers.Contains(AccessControlRequestHeaders))
                        {
                            string requestedHeaders = request.Headers.GetValues(AccessControlRequestHeaders).FirstOrDefault();
                            if (!string.IsNullOrEmpty(requestedHeaders))
                            {
                                response.Headers.Add(AccessControlAllowHeaders, requestedHeaders);
                            }
                        }
                        return response;
                    }, cancellationToken);
                }
                else
                {
                    //记录请求内容
                    if (request.Content != null)
                    {
                        if (needApiLog)
                        {
                            try
                            {
                                SysOperationLog model = new SysOperationLog();
                                model.MethodAction = request.RequestUri.LocalPath;
                                model.CustomData = request.Content.ReadAsStringAsync().Result;
                                model.RequestType = 0;

                                WriteLogService.WriteLogOperate(model);

                            }
                            catch (Exception e)
                            {
                                LogHelper.WriteErrorLog("记录请求内容出错：" + e.Message + e.StackTrace);

                            }
                        }
                    }
                    return base.SendAsync(request, cancellationToken).ContinueWith<HttpResponseMessage>
                     (t =>
                     {

                         HttpResponseMessage resp = t.Result;
                         resp.Headers.Add(AccessControlAllowOrigin, "*");
                         resp.Headers.Add(AccessControlAllowHeaders, "Authorization");
                         if (needApiLog)
                         {
                             try
                             {
                                 string res = t.Result.Content.ReadAsStringAsync().Result;

                                 SysOperationLog model = new SysOperationLog();
                                 model.MethodAction = request.RequestUri.LocalPath;
                                 model.CustomData = res;
                                 model.RequestType = 1;
                                 WriteLogService.WriteLogOperate(model);

                             }
                             catch (Exception e)
                             {
                                 LogHelper.WriteErrorLog("记录响应内容出错：" + request.RequestUri.LocalPath + e.Message + e.StackTrace);
                             }
                         }
                         return resp;
                     });
                }
            }
            else
            {
                if (request.Content != null)
                {
                    if (needApiLog)
                    {
                        try
                        {
                            SysOperationLog model = new SysOperationLog();
                            model.MethodAction = request.RequestUri.LocalPath;
                            model.CustomData = request.Content.ReadAsStringAsync().Result;
                            model.RequestType = 0;
                            WriteLogService.WriteLogOperate(model);
                        }
                        catch (Exception e)
                        {
                            LogHelper.WriteErrorLog("记录请求内容出错：" + e.Message + e.StackTrace);

                        }
                    }
                }
                return base.SendAsync(request, cancellationToken).ContinueWith<HttpResponseMessage>
                     (t =>
                     {

                         HttpResponseMessage resp = t.Result;
                         resp.Headers.Add(AccessControlAllowOrigin, "*");
                         resp.Headers.Add(AccessControlAllowHeaders, "Authorization");
                         if (needApiLog)
                         {
                             try
                             {
                                 string res = t.Result.Content.ReadAsStringAsync().Result;
                                 SysOperationLog model = new SysOperationLog();
                                 model.MethodAction = request.RequestUri.LocalPath;
                                 model.CustomData = res;
                                 model.RequestType = 1;
                                 WriteLogService.WriteLogOperate(model);
                             }
                             catch (Exception e)
                             {
                                 LogHelper.WriteErrorLog("记录响应内容出错：" + request.RequestUri.LocalPath + e.Message + e.StackTrace);
                             }
                         }
                         return resp;
                     });
            }
        }

    }
}
