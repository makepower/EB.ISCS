using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace EB.ISCS.ToolService.AuthServer
{
    public class JdAuthServer : BaseAuthServer
    {
        public JdAuthServer(string objKey, string appkey, string appSecret) : base(objKey, appkey, appSecret)
        {
        }

        public override void QueryAuthCode()
        {
            string authCodeUri = "https://oauth.jd.com/oauth/authorize?response_type=code&client_id={0}&redirect_uri={1}&state={2}";
            Jd.Api.Util.WebUtils wu = new Jd.Api.Util.WebUtils();
            var url = string.Format(authCodeUri, _appkey, RedirectUrl, _objKey);
            wu.DoGet(url, null);
        }

        public override void QueryAccessToken()
        {
            var accessTokenUri = "https://oauth.jd.com/token";
            Jd.Api.Util.WebUtils wu = new Jd.Api.Util.WebUtils();
            IDictionary<string, string> param = new Dictionary<string, string>();
            param.Add("grant_type", "authorization_code");
            param.Add("code", _authModel?.Code);
            param.Add("client_id", _appkey);
            param.Add("client_secret", _appSecret);
            param.Add("redirect_uri", RedirectUrl);
            param.Add("view", "web");

            try
            {
                var response = wu.DoPost(accessTokenUri, param);
                JObject res = JObject.Parse(response);
                _authModel.AccessToken = res["access_token"].ToString();
                _authModel.RefreshToken = res["refresh_token"].ToString();
            }
            catch (Exception ex)
            {
                FrameworkLog.LogModel.LogHelper.WriteErrorLog($"获取令牌失败,店铺id：{_objKey}", ex);
            }
        }

        public override void QueryRefreshToken()
        {
            var refreshTokenUrl = "https://oauth.jd.com/token";
            Jd.Api.Util.WebUtils wu = new Jd.Api.Util.WebUtils();
            IDictionary<string, string> param = new Dictionary<string, string>();
            param.Add("grant_type", "refresh_token");
            param.Add("refresh_token", _authModel.RefreshToken);
            param.Add("client_id", _appkey);
            param.Add("client_secret", _appSecret);
            param.Add("view", "web");

            try
            {
                string response = wu.DoPost(refreshTokenUrl, param);
                JObject res = JObject.Parse(response);
                _authModel.AccessToken = res["access_token"].ToString();
                _authModel.RefreshToken = res["refresh_token"].ToString();
            }
            catch (Exception ex)
            {
                FrameworkLog.LogModel.LogHelper.WriteErrorLog($"获取令牌失败,店铺id：{_objKey}", ex);
            }
        }
    }
}
