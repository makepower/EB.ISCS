using EB.ISCS.Common.Cache;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http.Filters;

namespace EB.ISCS.WebApi.Filters
{
    /// <summary>
    /// api缓存
    /// </summary>
    public class OutputCacheAttribute : ActionFilterAttribute
    {

        MemoryCacheDefault _cache = new MemoryCacheDefault();



        /// <summary>
        /// 客户端缓存（用户代理）缓存相对过期时间
        /// </summary>
        public int ClientCacheExpiration { set; get; }


        /// <summary>
        /// 服务端缓存过期时间
        /// </summary>
        public int ServerCacheExpiration { set; get; }




        /// <summary>
        /// api缓存 缓存单位 秒
        /// </summary>
        /// <param name="clientCacheExpiration">客户端过期时间。单位为秒，默认为600秒(10分钟)</param>
        /// <param name="serverCacheExpiration">服务端过期时间。单位为秒，默认为7200秒(120分钟)</param>
        public OutputCacheAttribute(int clientCacheExpiration = 600, int serverCacheExpiration = 7200)
        {
            this.ClientCacheExpiration = clientCacheExpiration;
            this.ServerCacheExpiration = serverCacheExpiration;
        }



        /// <summary>
        /// 判定是否用缓存中的内容，还是执行action是去取内容
        /// 注：一旦给actionContext.Response赋值了，则会使用这个值来输出响应
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {

            // ****************************************   穿透缓存 *********************************************
            // 若无缓存,则直接返回
            string cacheKey = getCacheKey(actionContext);
            if (_cache.Contains(cacheKey) == false)
                return;
            if (_cache.Contains(cacheKey + ":etag") == false)
                return;

            // ****************************************   使用缓存  *********************************************
            // 获取缓存中的etag
            var etag = _cache.Get<string>(cacheKey + ":etag");
            // 若etag没有被改变，则返回304，
            if (actionContext.Request.Headers.IfNoneMatch.Any(x => x.Tag == etag))  //IfNoneMatch为空时，返回的是一个集合对象
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.NotModified); // 响应对象还没有生成，需要先生成 // 304 not modified
                actionContext.Response.Headers.CacheControl = GetDefaultCacheControl();
                actionContext.Response.Headers.ETag = new EntityTagHeaderValue(etag);
                return;
            }
            else //从缓存中返回响应
            {
                actionContext.Response = actionContext.Request.CreateResponse(); // 响应对象还没有生成，需要先生成
                // 设置协商缓存：etag
                actionContext.Response.Headers.ETag = new EntityTagHeaderValue(etag); //用缓存中的值（为最新的）更新它
                // 设置user agent的本地缓存
                actionContext.Response.Headers.CacheControl = GetDefaultCacheControl();

                // 从缓存中取中响应内容
                var content = _cache.Get<byte[]>(cacheKey);
                actionContext.Response.Content = new ByteArrayContent(content);
                return;
            }
        }






        /// <summary>
        ///  将输出保存在缓存中。
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async System.Threading.Tasks.Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, System.Threading.CancellationToken cancellationToken)
        {
            // 响应对象已经生成，可以直接调用   actionExecutedContext.Response

            // 设置协商缓存：etag
            EntityTagHeaderValue etag = new EntityTagHeaderValue("\"" + Guid.NewGuid().ToString() + "\"");  // 根据http协议， ETag的值必须用引号包含起来
            actionExecutedContext.Response.Headers.ETag = etag;
            // 设置user agent的本地缓存
            actionExecutedContext.Response.Headers.CacheControl = GetDefaultCacheControl();

            // actionExecutedContext.Response.Headers.Remove("Content-Length"); // 改变了值，它会发生变化。删除它的话，后续的程序会自动地再计算

            // 保存到缓存
            string cacheKey = getCacheKey(actionExecutedContext.ActionContext);
            var contentBytes = await actionExecutedContext.Response.Content.ReadAsByteArrayAsync();

            _cache.Add(cacheKey + ":etag", etag.Tag, DateTimeOffset.Now.AddSeconds(this.ServerCacheExpiration));
            _cache.Add(cacheKey, contentBytes, DateTimeOffset.Now.AddSeconds(this.ServerCacheExpiration));

        }





        /// <summary>
        /// 默认的用户代理本地缓存配置，10分钟的相对过期时间
        /// 对应响应header中的 Cache-Control
        /// 这里设置里面的子项max-age。如：Cache-Control: max-age=3600
        /// </summary>
        /// <returns></returns>
        CacheControlHeaderValue GetDefaultCacheControl()
        {
            CacheControlHeaderValue control = new CacheControlHeaderValue();
            control.MaxAge = TimeSpan.FromSeconds(this.ClientCacheExpiration);  // 它对应响应头中的 cacheControl :max-age=10项

            return control;
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        string getCacheKey(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            string cacheKey = null;

            cacheKey = actionContext.Request.RequestUri.PathAndQuery; // 路径和查询部分,如： /api/values/1?ee=33&oo=5

            // 对路径中的参数进行重排，升序排列

            //string controllerName = actionContext.ControllerContext.ControllerDescriptor.ControllerName;
            //string actionName = actionContext.ActionDescriptor.ActionName;

            //if (actionContext.ActionArguments.ContainsKey("id") == false)
            //{
            //    cacheKey = controllerName + "/" + actionName;
            //}
            //else
            //{
            //    string id = actionContext.ActionArguments["id"].ToString();
            //    cacheKey = controllerName + "/" + actionName + "/" + id;
            //}

            return cacheKey;
        }


    }
}