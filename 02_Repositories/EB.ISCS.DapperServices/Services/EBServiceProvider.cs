using EB.ISCS.DapperServices.InterFace;
using EB.ISCS.DapperServices.InterFace.Sys;
using EB.ISCS.DapperServices.Repository;
using EB.ISCS.DapperServices.Repository.Sys;
using EB.ISCS.DapperServices.Services.Sys;
using System;
using System.Collections.Generic;

namespace EB.ISCS.DapperServices.Services
{
    /// <summary>
    /// 服务集成提供商
    /// 在构造里增加注册,注册类需从Service继承，否则构造失败
    /// </summary>
    public class EBServiceProvider : ServiceProvider
    {
        public EBServiceProvider()
        {
            //注册服务
            #region 系统数据库级服务

            RegisterService<IMenu, MenuService>();
            RegisterService<IMenuPermission, MenuPermissionService>();
            RegisterService<IRoleMenuService, RoleMenuService>();
            RegisterService<IRolePermissionService, RolePermissionService>();
            RegisterService<ISysUser, SysUserService>();
            RegisterService<ISysLoginTokenService, SysLoginTokenService>();
            RegisterService<ISysUserMenuService, SysUserMenuService>();
            RegisterService<ISysLoginLogService, SysLoginLogService>();
            RegisterService<ISysOperationLogService, SysOperationLogService>();
            RegisterService<ISysExceptionLogService, SysExceptionLogService>();
            #endregion

            #region 业务级数据库服务
            RegisterService<IMonitorIndicatorService, MonitorIndicatorService>();
            RegisterService<IComplaintInfoService, ComplaintInfoService>();
            RegisterService<IGoodInfoService, GoodInfoService>();
            RegisterService<IMonitorIndicatorRecordService, MonitorIndicatorRecordService>();
            RegisterService<IOrderInfoService, OrderInfoService>();
            RegisterService<IShipInfoService, ShipInfoService>();
            RegisterService<ISynchronizationConfigService, SynchronizationConfigService>();
            RegisterService<IWayBillInfoService, WayBillInfoService>();
            RegisterService<IWayBillTraceInfoService, WayBillTraceInfoService>();
            RegisterService<IDataSyncRecordService, DataSyncRecordService>();

            #endregion
        }

    }

    /// <summary>
    /// 服务提供接口
    /// </summary>
    public interface IEBServiceProvider : IServiceProvider
    {
        Service GetService(string serviceName);
        Service GetServiceSpec(string serviceName);
        Service GetServiceSpec(string serviceName, Service service);

        T GetService<T>() where T : Service;
        T GetServiceSpec<T>(string connString) where T : Service;
        T GetServiceSpec<T>(Service service) where T : Service;

        IEnumerable<string> GetServiceNames();
        void RegisterService(Type typeInterface, Type typeClass, bool bSystem = false, bool bSingleton = false);
        void RegisterService<TInterface, TClass>(bool bSystem = false, bool bSingleton = false) where TClass : Service;
        void RegisterService<TClass>(bool bSystem = false, bool bSingleton = false) where TClass : Service;
    }
}
