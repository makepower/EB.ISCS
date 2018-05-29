using Dapper;
using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.Base;
using Maticsoft.Model.ISSC;
using System;
using System.Collections.Generic;
using System.Data;

namespace EB.ISCS.DapperServices.Repository
{
    /// <summary>
    ///订单信息 ：仓储类
    /// </summary>		
    public partial class OrderInfoRepository : BaseRepository<OrderInfo>
	{
   		
   		#region 构造 
   		public OrderInfoRepository(SqlServerProvider provider, OperateInfo oInfo = null) : base(provider, oInfo)
        {
        }
        #endregion
        
   		#region Costom Function 
        /// <summary>
        ///  删除Maticsoft.Model.OrderInfo，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Delete(DeleteModel model,IDbTransaction transaction = null)
        {
            var sql = @"UPDATE  OrderInfo SET DelState=1,DelUser=@DelUser,DelDate=@DelDate WHERE Id=@Id ";
            return TraceExecFunc(() => this.Conn.Execute(sql, new { DelUser = model.UserId, DelDate = DateTime.Now, Id = model.Id },transaction) > 0);
        }

		/// <summary>
        /// 获取所有的Maticsoft.Model.OrderInfo信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OrderInfo> GetAllList()
        {
            var sql = @" select *   FROM OrderInfo ";
            return TraceExecFunc(() => this.Conn.Query<OrderInfo>(sql));
        }
        #endregion
	}
}