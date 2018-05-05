using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using EB.ISCS.WebApi.Filters;
using EB.ISCS.WebApi.Models;

namespace EB.ISCS.WebApi
{
    /// <summary>
    /// webapi配置
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Web API 配置和服务
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API 路由
            config.MapHttpAttributeRoutes();
            config.MessageHandlers.Add(new CorsHandler());
            config.Filters.Add(new OperateLogAttribute());//操作日志

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{namespace}/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            //命名空间控制器选择
            config.Services.Replace(typeof(IHttpControllerSelector), new NamespaceHttpControllerSelector(config));
            
            //设置默认序列化方式
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.None;
            settings.NullValueHandling = NullValueHandling.Ignore;
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            var serializerSettings = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            var contractResolver = (DefaultContractResolver)serializerSettings.ContractResolver;
            contractResolver.IgnoreSerializableAttribute = true;

            //增加过滤器：service层调用的垃圾回收
            config.Filters.Add(new WebApiDisposeFilter());
            config.EnableQuerySupport();
            config.EnableSystemDiagnosticsTracing();

        }
    }
}
