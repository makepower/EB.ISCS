using EB.ISCS.DapperServices.Base;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.ToolService.LogService
{
    /// <summary>
    /// 日志操作静态类， 写登录日志
    /// </summary>
    public static class WriteLoginLog
    {
        public static void WriteLogLogin(SysLoginLog logEntry)
        {
            LoginEmitter service = new LoginEmitter();
            service.EmitLog(logEntry);
        }

    }

    /// <summary>
    /// 日志操作静态类， 写操作日志
    /// </summary>
    public static class WriteLogService
    {
        public static void WriteLogOperate(SysOperationLog model)
        {
            LoginEmitter service = new LoginEmitter();
            service.EmitLog(model);
        }
    }

    /// <summary>
    /// 日志操作静态类， 写异常日志
    /// </summary>
    public static class WriteExceptionLog
    {
        public static void WriteLogException(SysExceptionLog model)
        {
            LoginEmitter service = new LoginEmitter();
            service.EmitLog(model);
        }
    }
}
