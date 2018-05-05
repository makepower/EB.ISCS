using System;
using System.Data;
using EB.ISCS.DapperServices.Base;

namespace EB.ISCS.DapperServices.InterFace
{
    public interface IService : IDisposable
    {
        /// <summary>
        /// 设置操作信息，以记录操作日志
        /// </summary>
        /// <param name="oInfo">
        /// </param>
        void SetOperateInfo(OperateInfo oInfo = null);

        /// <summary>
        /// 得到该服务下的数据连接提供者
        /// </summary>
        /// <returns></returns>
        SqlServerProvider GetProvider() ;

        /// <summary>
        /// 服务器时间 精确到秒
        /// </summary>
        DateTime ServerTime { get; }

        IDbTransaction BeginTrans();
    }
}
