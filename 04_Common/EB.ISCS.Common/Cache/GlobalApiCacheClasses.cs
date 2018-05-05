using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace EB.ISCS.Common.Cache
{

    /// <summary>
    /// 全局缓存词典
    /// </summary>
    public class GlobalApiCacheClasses
    {
        private static MemoryCache cache = MemoryCache.Default;
        /// <summary>
        /// 得到缓存词典
        /// </summary>
        /// <typeparam name="T">词典存储的类型</typeparam>
        /// <param name="action">词典没有词时，取值的函数定义</param>
        /// <returns></returns>
        public static List<T> GetCacheList<T>(Func<List<T>> action ) where T :class
        {
            if (cache.Contains(typeof(T).Name))
            {
                return cache.Get(typeof(T).Name) as List<T>;
            }
            else
            {
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.Priority =CacheItemPriority.NotRemovable;
                var list = action();
                cache.Set(typeof(T).Name, list,policy);
                return list;
            }
        }

        /// <summary>
        /// 在缓存中缓存一个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="action"></param>
        /// <param name="absoluteExpiration"></param>
        /// <returns></returns>
        public static T GetCacheData<T>(string key,Func<string, T> action, DateTime absoluteExpiration) where T :class
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (cache.Contains(key))
            {
                return cache.Get(key) as T;
            }
            else
            {
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.Priority = CacheItemPriority.NotRemovable;
                policy.AbsoluteExpiration = absoluteExpiration;
                var entity = action(key);
                cache.Set(key, entity, policy);
                return entity;
            }
        }
        public static T GetCacheData<T>(string key,Func<string, Tuple<T,DateTime>> action) where T :class
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (cache.Contains(key))
            {
                return cache.Get(key) as T;
            }
            else
            {
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.Priority = CacheItemPriority.NotRemovable;
                var entity = action(key);
                if (entity != null)
                {
                    policy.AbsoluteExpiration = entity.Item2;
                    cache.Set(key, entity.Item1, policy);
                }
                return entity?.Item1;
            }
        }

        /// <summary>
        /// 移除所有缓存数据
        /// </summary>
        public static void ClearAll()
        {
            cache.Dispose();
        }

        /// <summary>
        /// 移除指定类型的缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Remove<T>()
        {
            cache.Remove(typeof(T).Name);

        }

        /// <summary>
        /// 移除指定的名称词典值
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
        {
            cache.Remove(key);
        }
    }
}
