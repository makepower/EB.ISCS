using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.ToolService.Interface
{
    /// <summary>
    /// 系统日志接口
    /// </summary>
    public interface ILogEmitter
    {
        void EmitLog(SysLoginLog log);

        void EmitLog(SysOperationLog log);

        void EmitLog(SysExceptionLog log);
    }
}
