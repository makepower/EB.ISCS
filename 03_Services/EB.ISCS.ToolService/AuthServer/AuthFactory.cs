using Maticsoft.Model;
using System;
using System.Collections.Generic;

namespace EB.ISCS.ToolService.AuthServer
{
    /// <summary>
    /// 认证工厂  
    /// 处理京东和阿里的认证与授权对接
    /// 自动刷新令牌
    /// </summary>
    public class AuthFactory
    {
        private static readonly object lockObj = new object();
        private static Dictionary<string, AuthModel> dictionary = null;
        private static Dictionary<string, BaseAuthServer> authDic = new Dictionary<string, BaseAuthServer>();

        public event Action<AuthModel> AuthHandleEvent;

        static AuthFactory()
        {
            dictionary = new Dictionary<string, AuthModel>();

            Hangfire.RecurringJob.AddOrUpdate(() => RefreshToken(), Hangfire.Cron.HourInterval(10));
        }

        public static AuthFactory Instance = new AuthFactory();

        /// <summary>
        /// 授权通知 以便进行令牌获取
        /// </summary>
        /// <param name="id"></param>
        /// <param name="code"></param>
        public void Notify(string id, string code)
        {
            if (authDic.ContainsKey(id))
            {

                var auth = authDic[id].RefreshAuthModel(code);

                if (string.IsNullOrEmpty(auth.AccessToken))
                    return;
                AuthHandleEvent?.Invoke(auth);

                lock (lockObj)
                {
                    if (dictionary.ContainsKey(id))
                    {
                        dictionary[id] = auth;
                    }
                    else
                    {
                        dictionary.Add(id, auth);
                    }
                }
            }
        }

        /// <summary>
        /// 注册店铺应用认证事件 请使用AuthHandleEvent 监听事件返回结果
        /// 请注意及时释放Event连接
        /// </summary>
        /// <param name="info"></param>
        public void RegisterShopAuth(ShipInfo info)
        {
            if (dictionary.ContainsKey(info.Id.ToString()))
            {
                AuthHandleEvent?.Invoke(dictionary[info.Id.ToString()]);
            }
            else
            {
                if (info.Plat < 2)
                    authDic.Add(info.Id.ToString(), new AliAuthServer(info.Id.ToString(), info.AppKey, info.AppSecret));
                else if (info.Plat == 2)
                    authDic.Add(info.Id.ToString(), new JdAuthServer(info.Id.ToString(), info.AppKey, info.AppSecret));

                authDic[info.Id.ToString()]?.QueryAuthCode();
            }
        }

        /// <summary>
        /// 刷新令牌
        /// </summary>
        private static void RefreshToken()
        {
            foreach (var item in authDic)
            {
                try
                {
                    dictionary[item.Key] = item.Value.RefreshAuthModel();
                }
                catch (Exception ex)
                {
                    FrameworkLog.LogModel.LogHelper.WriteErrorLog($"刷新令牌失效,店铺id：{item.Key}", ex);
                }
            }
        }
    }

    /// <summary>
    /// 认证模型
    /// </summary>
    public class AuthModel
    {
        public string Key { get; set; }

        public string Code { get; set; }

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }

}
