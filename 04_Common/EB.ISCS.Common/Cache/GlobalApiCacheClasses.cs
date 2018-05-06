using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace EB.ISCS.Common.Cache
{

    /// <summary>
    /// 全局缓存词典
    /// </summary>
    public class MemoryCacheDefault
    {
        private static readonly MemoryCache _cache = MemoryCache.Default;

        public void RemoveStartsWith(string key)
        {
            lock (_cache)
            {
                _cache.Remove(key);
            }
        }

        public T Get<T>(string key) where T : class
        {
            var o = _cache.Get(key) as T;
            return o;
        }



        [Obsolete("Use Get<T> instead")]
        public object Get(string key)
        {
            return _cache.Get(key);
        }





        public void Remove(string key)
        {
            lock (_cache)
            {
                _cache.Remove(key);
            }
        }

        public bool Contains(string key)
        {
            return _cache.Contains(key);
        }

        public void Add(string key, object o, DateTimeOffset expiration, string dependsOnKey = null)
        {
            var cachePolicy = new CacheItemPolicy
            {
                AbsoluteExpiration = expiration
            };

            if (!string.IsNullOrWhiteSpace(dependsOnKey))
            {
                cachePolicy.ChangeMonitors.Add(
                    _cache.CreateCacheEntryChangeMonitor(new[] { dependsOnKey })
                );
            }
            lock (_cache)
            {
                _cache.Add(key, o, cachePolicy);
            }
        }


        public IEnumerable<string> AllKeys
        {
            get
            {
                return _cache.Select(x => x.Key);
            }
        }
    }
}
