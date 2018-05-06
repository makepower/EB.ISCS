using Dapper;
using EB.ISCS.DapperServices.Base;
using Maticsoft.Model;
using System.Collections.Generic;
using System.Data;

namespace EB.ISCS.DapperServices.Repository
{
    /// <summary>
    ///SynchronizationConfig ：仓储类
    /// </summary>		
    public partial class SynchronizationConfigRepository : BaseRepository<SynchronizationConfig>
    {

        #region 构造 
        public SynchronizationConfigRepository(SqlServerProvider provider, OperateInfo oInfo = null) : base(provider, oInfo)
        {
        }
        #endregion

        #region Costom Function 

        /// <summary>
        /// 获取所有的Maticsoft.Model.SynchronizationConfig信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SynchronizationConfig> GetAllList()
        {
            var sql = @" select *   FROM SynchronizationConfig ";
            return TraceExecFunc(() => this.Conn.Query<SynchronizationConfig>(sql));
        }

        /// <summary>
        /// 获取所有的Maticsoft.Model.SynchronizationConfig信息
        /// </summary>
        /// <returns></returns>
        public SynchronizationConfig GetByUserId(int id)
        {
            var sql = $@" select *   FROM SynchronizationConfig where UserId={id} ";
            return TraceExecFunc(() => this.Conn.QueryFirst<SynchronizationConfig>(sql));
        }

        /// <summary>
        /// 获取所有的Maticsoft.Model.SynchronizationConfig信息
        /// </summary>
        /// <returns></returns>
        public bool DeleteByKey(int key, IDbTransaction transaction = null)
        {
            var sql = $@" delete FROM SynchronizationConfig where Id={key}";
            return TraceExecFunc(() => this.Conn.Execute(sql, transaction)) > 0;
        }
        #endregion
    }
}