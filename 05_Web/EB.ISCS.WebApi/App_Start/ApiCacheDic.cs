using System;
using System.Runtime.Caching;

namespace EB.ISCS.WebApi
{
    /// <summary>
    /// Api级缓存
    /// </summary>
    public static class ApiCacheDic
    {
        static readonly object LockObj = new object();
        static MemoryCache memoryCache = MemoryCache.Default;

        static ApiCacheDic()
        {
            var url = System.Configuration.ConfigurationManager.AppSettings[RedirectUri];
            if (string.IsNullOrEmpty(url))
                Add(RedirectUri, url, DateTime.Now.AddHours(24));
        }

        /// <summary>
        /// 网站的对外地址
        /// </summary>
        public const string RedirectUri = "RedirectUri";

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object Get(string key)
        {
            return memoryCache.Get(key);
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="func">如果没有 则获取委托</param>
        /// <param name="expirateTime">过期时间</param>
        /// <returns></returns>
        public static object Get(string key, Func<string, object> func, DateTime expirateTime)
        {
            var obj = memoryCache.Get(key);
            if (obj != null)
                return obj;
            obj = func(key);
            if (obj == null)
                return null;
            memoryCache.Add(new CacheItem(key, obj), new CacheItemPolicy()
            {
                AbsoluteExpiration = expirateTime
            });
            return obj;
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="expirateTime"></param>
        /// <returns></returns>
        public static bool Add(string key, object obj, DateTime expirateTime)
        {
            return memoryCache.Add(new CacheItem(key, obj), new CacheItemPolicy()
            {
                AbsoluteExpiration = expirateTime
            });
        }
    }
}