using EB.ISCS.Common.Cache;
using EB.ISCS.FrameworkEntity.SystemEntity;
using System;
using System.Collections.Generic;

namespace EB.ISCS.WebApi
{
    /// <summary>
    /// Api全局缓存业务数据
    /// </summary>
    public class ApiCacheDicts
    {
        const string MenuPermission = "-menupermission";
        /// <summary>
        /// 根据token，得到用户的信息
        /// </summary>
        /// <param name="token"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static SysLoginToken GetLoginToken(string token, Func<string, SysLoginToken> func)
        {
            return GlobalApiCacheClasses.GetCacheData(token, func, DateTime.Now.AddHours(24));
        }


        /// <summary>
        /// 根据token，得到用户的菜单权限信息
        /// </summary>
        /// <param name="token"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static List<SysMenuPermission> GetUserMenuPermissionByToken(string token, Func<string, List<SysMenuPermission>> func)
        {
            return GlobalApiCacheClasses.GetCacheData($"{token}{MenuPermission}", func, DateTime.Now.AddHours(24));
        }


        /// <summary>
        /// 移除用户token相关的业务数据缓存
        /// </summary>
        /// <param name="token"></param>
        public static void RemoveUserInfoByToken(string token)
        {
            GlobalApiCacheClasses.Remove(token);
            GlobalApiCacheClasses.Remove($"{token}{MenuPermission}");
        }
    }
}