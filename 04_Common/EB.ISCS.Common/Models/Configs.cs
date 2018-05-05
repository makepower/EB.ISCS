using System;
using System.Configuration;

namespace EB.ISCS.Common.Models
{
    public class Configs
    {

        public static string ApiUrl => getValue(Constants.ApiUrl);

        public static int CookieMaxAge => Convert.ToInt32(getValue(Constants.CookieMaxAge));


        public static string DefaultStorageVolume => getValue(Constants.DefaultStorageVolume);

        public static string SSOPassportDomainName => getValue(Constants.SSOPassport);

        public static string DBBackupDir => getValue(Constants.DBBackupDir);

        static string getValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }

    /// <summary>
    /// 常量集合
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// Api访问地址
        /// </summary>
        public static readonly string ApiUrl = "api_url";
        /// <summary>
        /// cookie最大有效期
        /// </summary>
        public static readonly string CookieMaxAge = "cookieMaxAge";
        /// <summary>
        /// 默认仓储大小
        /// </summary>
        public static readonly string DefaultStorageVolume = "DefaultStorageVolume";
        /// <summary>
        /// SSO单点登录主域
        /// </summary>
        public static readonly string SSOPassport = "SSOPassport";
        /// <summary>
        /// 数据库备份目录
        /// </summary>
        public static readonly string DBBackupDir = "DBBackupDir";

        /// <summary>
        /// 设备连接认证Id
        /// </summary>
        public static readonly string DevChannelAuthenticationKey = "1d99257a7fcf4e35aef4654dc0521220";
    }
}