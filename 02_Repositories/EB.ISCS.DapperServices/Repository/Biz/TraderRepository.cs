using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.Base;
using EB.ISCS.FrameworkEntity.Biz;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace EB.ISCS.DapperServices.Repository.Biz
{
    public partial class TraderRepository : BaseRepository<TraderInfo>
    {
        #region 构造 
        public TraderRepository(SqlServerProvider provider, OperateInfo oInfo = null) : base(provider, oInfo)
        {
        }
        #endregion

        #region Costom Function 
        /// <summary>
        ///  删除Maticsoft.Model.ComplaintInfo，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Delete(DeleteModel model, IDbTransaction transaction = null)
        {
            var sql = @"Delete from Trader WHERE Id=@Id ";
            return TraceExecFunc(() => this.Conn.Execute(sql, new { Id = model.Id }, transaction) > 0);
        }

        /// <summary>
        /// 获取所有的Maticsoft.Model.ComplaintInfo信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TraderInfo> GetAllList()
        {
            var sql = @" select *   FROM Trader ";
            return TraceExecFunc(() => this.Conn.Query<TraderInfo>(sql));
        }
        #endregion
    }
}
