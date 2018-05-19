using EB.ISCS.ToolService.AuthServer;

namespace EB.ISCS.ToolService.Interface
{
    /// <summary>
    /// 签名接口
    /// </summary>
    interface IAuth
    {
        /// <summary>
        /// 请求授权 异步回调 无返回参数
        /// 由实现类维护请求结果
        /// </summary>
        void QueryAuthCode();

        /// <summary>
        /// 请求认证令牌 由实现类维护请求结果
        /// </summary>
        void QueryAccessToken();

        /// <summary>
        /// 请求刷新令牌 由实现类维护请求结果
        /// </summary>
        void QueryRefreshToken();

        /// <summary>
        /// 刷新认证模型
        /// </summary>
        /// <param name="authCode">不为空则重新构造认证 否则进行刷新</param>
        /// <returns></returns>
        AuthModel RefreshAuthModel(string authCode = null);
    }
}
