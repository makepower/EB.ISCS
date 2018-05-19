using EB.ISCS.ToolService.Interface;
using System.Runtime.Caching;

namespace EB.ISCS.ToolService.AuthServer
{
    /// <summary>
    /// 认证接口抽象类
    /// </summary>
    public abstract class BaseAuthServer : IAuth
    {
        protected string _appkey;
        protected string _appSecret;
        protected string _objKey;
        protected AuthModel _authModel;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="appkey"></param>
        /// <param name="appSecret"></param>
        public BaseAuthServer(string objKey, string appkey, string appSecret)
        {
            this._appkey = appkey;
            this._appSecret = appSecret;
            this._objKey = objKey;
        }

        public abstract void QueryAuthCode();

        public abstract void QueryAccessToken();

        public abstract void QueryRefreshToken();

        public virtual AuthModel RefreshAuthModel(string authCode = null)
        {
            if (!string.IsNullOrEmpty(authCode))
            {
                _authModel = new AuthModel() { Code = authCode, Key = _objKey };
            }
            else
            {
                if (_authModel == null)
                    throw new System.Exception("认证信息丢失");
                else
                {
                    //刷新
                }
            }
            if (_authModel == null && string.IsNullOrEmpty(authCode))
                _authModel = new AuthModel() { Code = authCode, Key = _objKey };
            QueryAccessToken();
            return _authModel;
        }

        /// <summary>
        /// 认证回调url
        /// </summary>
        public string RedirectUrl
        {
            get
            {
                return MemoryCache.Default.Get("RedirectUri")?.ToString() ?? string.Empty;
            }
        }

    }
}
