using System;
using EB.ISCS.DapperServices.Services;
using EB.ISCS.DapperServices.Services.Sys;
using EB.ISCS.FrameworkEntity.SystemEntity;
using EB.ISCS.ToolService.Interface;
using EB.ISCS.FrameworkLog.LogModel;
using EB.ISCS.FrameworkHelp.Tools;

namespace EB.ISCS.ToolService.LogService
{
    /// <summary>
    /// 添加登录日志
    /// </summary>
    public class LoginEmitter : ILogEmitter
    {
        #region 记录登陆日志
        /// <summary>
        /// 记录登陆日志
        /// </summary>
        /// <param name="log"></param>
        public void EmitLog(SysLoginLog log)
        {
            if (log != null)
            {
                log.Enabled = 1;
                log.DelDate = null;
                log.LogOutDate = null;
                ServiceProvider provider = new ServiceProvider();
                provider.RegisterService<SysLoginLogService>(true);
                using (var service = provider.GetService<SysLoginLogService>())
                {
                    LogHelper.WriteInfoLog($"login info:{JsonHelper.SerializeObject(log)}");
                    service.Add(log);
                }
            }
        }
        #endregion


        #region Add 新增操作数据
        /// <summary>
        ///  新增表SysOperationLog
        /// </summary>
        /// <param name="log">SysOperationLog实体</param>
        /// <returns>bool</returns>
        public void EmitLog(SysOperationLog log)
        {
            if (log != null)
            {
                log.Enabled = 1;
                log.DelDate = null;
                log.InDate = DateTime.Now;
                if (log.ExecutionTime == DateTime.MinValue)
                {
                    log.ExecutionTime = DateTime.Parse("2000/1/1 0:0:0");
                }
                ServiceProvider provider = new ServiceProvider();
                provider.RegisterService<SysOperationLogService>(true);
                using (var service = provider.GetService<SysOperationLogService>())
                {
                    LogHelper.WriteInfoLog($"operation info:{JsonHelper.SerializeObject(log)}");
                    service.Add(log);
                }
            }
        }
        #endregion

        #region 添加错误日志
        /// <summary>
        /// 添加错误日志
        /// </summary>
        /// <param name="log"></param>
        public void EmitLog(SysExceptionLog log)
        {
            if (log != null)
            {
                log.Enabled = 1;
                log.DeleteDate = null;
                log.ExceptionDate = DateTime.Now;
                log.InDate = DateTime.Now;

                ServiceProvider provider = new ServiceProvider();
                provider.RegisterService<SysExceptionLogService>(true);
                using (var service = provider.GetService<SysExceptionLogService>())
                {
                    LogHelper.WriteInfoLog($"exception info:{JsonHelper.SerializeObject(log)}");
                    service.Add(log);
                }
            }
        }
        #endregion

       

    }

}
