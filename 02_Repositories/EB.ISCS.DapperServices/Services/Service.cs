using System;
using System.Data;
using EB.ISCS.DapperServices.Base;
using EB.ISCS.DapperServices.InterFace;

namespace EB.ISCS.DapperServices.Services
{
    /// <summary>
    /// 服务基类
    /// 封装数据服务底层连接 默认连接者为 SQL server
    /// </summary>
    public abstract class Service : IService
    {
        protected OperateInfo OInfo;

        protected SqlServerProvider Provider;


        /// <summary>
        /// 链接字符串写在配置文件里
        /// 仅适用本项目WebApi，其他用途，请修改此处代码
        /// </summary>
        protected Service()
        {
            this.Provider = DapperProvider.GetProvider(DapperProvider.GetConnString());
        }
        protected Service(string connString)
        {
            this.Provider = DapperProvider.GetProvider(string.IsNullOrEmpty(connString) ? DapperProvider.GetConnString() : connString);
        }

        protected Service(Service service)
        {
            this.Provider = service?.GetProvider() ?? DapperProvider.GetProvider(DapperProvider.GetConnString());
        }

        /// <summary>
        /// 提供数据库连接
        /// </summary>
        /// <returns></returns>
        public SqlServerProvider GetProvider() => this.Provider;

        /// <summary>
        /// 设置操作信息，以记录操作日志
        /// </summary>
        /// <param name="oInfo"></param>
        public virtual void SetOperateInfo(OperateInfo oInfo = null)
        {
            this.OInfo = oInfo;
        }

        /// <summary>
        /// 服务器时间 精确到秒
        /// </summary>
        public DateTime ServerTime => DateTime.Now;

        public IDbTransaction BeginTrans()
        {
            return this.Provider?.Conn?.BeginTransaction();
        }

        public void Dispose()
        {
            Provider?.Close();
            Provider?.Dispose();
        }
    }
}
