using Newtonsoft.Json.Linq;
using System;
using Top.Api.Request;

namespace EB.ISCS.ToolService.AuthServer
{
    /// <summary>
    /// 阿里认证服务
    /// </summary>
    public class AliAuthServer : BaseAuthServer
    {

        public AliAuthServer(string objKey, string appkey, string appSecret) : base(objKey, appkey, appSecret)
        {

        }

        public override void QueryAuthCode()
        {
            string authCodeUri = "https://oauth.taobao.com/authorize?response_type=code&client_id={0}&redirect_uri={1}&state={2}&view=web";
            Top.Api.Util.WebUtils wu = new Top.Api.Util.WebUtils();
            var url = string.Format(authCodeUri, _appkey, RedirectUrl, _objKey);
            wu.DoGet(url, null);
        }

        public override void QueryAccessToken()
        {
            var accessTokenUri = "https://oauth.taobao.com/token";
            Top.Api.DefaultTopClient topClient = new Top.Api.DefaultTopClient(accessTokenUri, _appkey, _appSecret);
            var createRequest = new TopAuthTokenCreateRequest()
            {
                Code = _authModel?.Code,
                Uuid = Guid.NewGuid().ToString()
            };
            var response = topClient.Execute(createRequest);
            if (!response.IsError)
            {
                JObject res = JObject.Parse(response.Body);
                _authModel.AccessToken = res["access_token"].ToString();
                _authModel.RefreshToken = res["refresh_token"].ToString();
            }
            else
            {
                FrameworkLog.LogModel.LogHelper.WriteErrorLog($"获取令牌失败：{response.ErrCode}{response.ErrMsg}");
            }
        }

        public override void QueryRefreshToken()
        {
            var accessTokenUri = "https://oauth.taobao.com/token";
            Top.Api.DefaultTopClient topClient = new Top.Api.DefaultTopClient(accessTokenUri, _appkey, _appSecret);

            var createRequest = new TopAuthTokenRefreshRequest()
            {
                RefreshToken = _authModel.RefreshToken
            };
            var response = topClient.Execute(createRequest);
            if (!response.IsError)
            {
                JObject res = JObject.Parse(response.Body);
                _authModel.AccessToken = res["access_token"].ToString();
                _authModel.RefreshToken = res["refresh_token"].ToString();
            }
            else
            {
                FrameworkLog.LogModel.LogHelper.WriteErrorLog($"刷新令牌失败：{response.ErrCode}{response.ErrMsg}");
            }
        }
    }
}
