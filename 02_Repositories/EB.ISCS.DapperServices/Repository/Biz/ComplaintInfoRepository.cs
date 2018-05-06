using EB.ISCS.Common.DataModel;
using Maticsoft.Model;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using EB.ISCS.DapperServices.Base;

namespace EB.ISCS.DapperServices.Repository
{
    /// <summary>
    ///投诉信息表 ：仓储类
    /// </summary>		
    public partial class ComplaintInfoRepository : BaseRepository<ComplaintInfo>
	{
   		
   		#region 构造 
   		public ComplaintInfoRepository(SqlServerProvider provider, OperateInfo oInfo = null) : base(provider, oInfo)
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
        public bool Delete(DeleteModel model,IDbTransaction transaction = null)
        {
            var sql = @"UPDATE  ComplaintInfo SET DelState=1,DelUser=@DelUser,DelDate=@DelDate WHERE Id=@Id ";
            return TraceExecFunc(() => this.Conn.Execute(sql, new { DelUser = model.UserId, DelDate = DateTime.Now, Id = model.Id },transaction) > 0);
        }

		/// <summary>
        /// 获取所有的Maticsoft.Model.ComplaintInfo信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ComplaintInfo> GetAllList()
        {
            var sql = @" select *   FROM ComplaintInfo ";
            return TraceExecFunc(() => this.Conn.Query<ComplaintInfo>(sql));
        }
        #endregion
	}
}