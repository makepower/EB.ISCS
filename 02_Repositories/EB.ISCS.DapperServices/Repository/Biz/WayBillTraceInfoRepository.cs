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
    ///物流跟踪信息 ：仓储类
    /// </summary>		
    public partial class WayBillTraceInfoRepository : BaseRepository<WayBillTraceInfo>
	{
   		
   		#region 构造 
   		public WayBillTraceInfoRepository(SqlServerProvider provider, OperateInfo oInfo = null) : base(provider, oInfo)
        {
        }
        #endregion
        
   		#region Costom Function 
        /// <summary>
        ///  删除Maticsoft.Model.WayBillTraceInfo，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Delete(DeleteModel model,IDbTransaction transaction = null)
        {
            var sql = @"UPDATE  WayBillTraceInfo SET DelState=1,DelUser=@DelUser,DelDate=@DelDate WHERE Id=@Id ";
            return TraceExecFunc(() => this.Conn.Execute(sql, new { DelUser = model.UserId, DelDate = DateTime.Now, Id = model.Id },transaction) > 0);
        }

		/// <summary>
        /// 获取所有的Maticsoft.Model.WayBillTraceInfo信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<WayBillTraceInfo> GetAllList()
        {
            var sql = @" select *   FROM WayBillTraceInfo ";
            return TraceExecFunc(() => this.Conn.Query<WayBillTraceInfo>(sql));
        }
        #endregion
	}
}