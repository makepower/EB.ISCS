using Microsoft.Practices.Unity;
using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.Base;
using EB.ISCS.DapperServices.Services;
using EB.ISCS.FrameworkEntity.SystemEntity;
using EB.ISCS.FrameworkHelp.Tools;
using EB.ISCS.WebApi.Filters;
using System.Web;
using System.Web.Http;

namespace EB.ISCS.WebApi
{
    /// <summary>
    /// 基础认证，进行权限验证
    /// </summary>
    //[ApiAuthorizeFilter]
    //[Menu]
    public class BaseApiController : BaseUnauthorizedApiController
    {
        /// <summary>
        /// 构造
        /// </summary>
        protected BaseApiController() : base()
        {
        }
    }


    /// <summary>
    /// 基础无鉴权认证
    /// </summary>
    public class BaseUnauthorizedApiController : ApiController
    {  /// <summary>
       /// 构造
       /// </summary>
        protected BaseUnauthorizedApiController() : base()
        {
            var container = UnityConfig.GetConfiguredContainer();
            _serviceProvider = container.Resolve<IEBServiceProvider>();
        }


        /// <summary>
        /// 服务提供商
        /// </summary>
        private IEBServiceProvider _serviceProvider;


        #region 对Provider的Service重新进行包装，以方便传递特别参数
        /// <summary>
        /// 得到指定类型的服务 不建议在api控制器构造里调用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected T GetService<T>() where T : Service
        {
            var service = _serviceProvider?.GetService<T>();
            service?.SetOperateInfo(GetInfo());
            return service;
        }
        /// <summary>
        /// 得到指定类型的服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connString">设定服务的连接字符串</param>
        /// <returns></returns>
        protected T GetService<T>(string connString) where T : Service
        {
            var service = _serviceProvider?.GetServiceSpec<T>(connString);
            service?.SetOperateInfo(GetInfo());
            return service;
        }
        /// <summary>
        /// 得到指定类型的服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="companyCode">设定公司编码</param>
        /// <returns></returns>
        protected T GetServiceSpec<T>(string companyCode) where T : Service
        {
            var service = _serviceProvider?.GetService<T>();
            service?.SetOperateInfo(GetInfo());
            return service;
        }
        /// <summary>
        /// 得到指定类型的服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="service">设定服务的连接字符串，从服务中获得</param>
        /// <returns></returns>
        protected T GetService<T>(Service service) where T : Service
        {
            var tmpService = _serviceProvider?.GetServiceSpec<T>(service);
            tmpService?.SetOperateInfo(GetInfo());
            return tmpService;
        }
        #endregion

        /// <summary>
        /// 得到操作信息
        /// </summary>
        /// <returns></returns>
        protected OperateInfo GetInfo()
        {
            return new OperateInfo()
            {
                UserId = "",
                UserName = "",
                ModuleName = this.ControllerContext.ControllerDescriptor.ControllerName,
                IpAddress = ""
            };
        }
        /// <summary>
        /// 当前上下文
        /// </summary>
        protected HttpContextBase Context => CurrentHttpContext.Instance();

        /// <summary>
        /// 基础信息
        /// </summary>
        public BaseModel BModel { get; set; }

        /// <summary>
        /// 根据token获取用户ID
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        protected int CheckUserToken(string token)
        {
            return BModel?.User?.Id ?? 0;
        }


    }


    public class BaseModel
    {

        /// <summary>
        /// 登录信息
        /// </summary>
        public SysLoginTokenModel SysLoginToken { get; set; }

        /// <summary>
        /// 用户信息
        /// </summary>
        public SysUser User { get; set; }
    }
}