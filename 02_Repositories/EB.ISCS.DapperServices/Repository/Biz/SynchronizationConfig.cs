using Dapper;
using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.Base;
using Maticsoft.Model;
using System;
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
        ///  删除Maticsoft.Model.SynchronizationConfig，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Delete(DeleteModel model,IDbTransaction transaction = null)
        {
            var sql = @"UPDATE  SynchronizationConfig SET DelState=1,DelUser=@DelUser,DelDate=@DelDate WHERE Id=@Id ";
            return TraceExecFunc(() => this.Conn.Execute(sql, new { DelUser = model.UserId, DelDate = DateTime.Now, Id = model.Id },transaction) > 0);
        }

		/// <summary>
        /// 获取所有的Maticsoft.Model.SynchronizationConfig信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SynchronizationConfig> GetAllList()
        {
            var sql = @" select *   FROM SynchronizationConfig ";
            return TraceExecFunc(() => this.Conn.Query<SynchronizationConfig>(sql));
        }
        #endregion
	}
}