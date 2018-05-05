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
    ///OrderDetail ：仓储类
    /// </summary>		
    public partial class OrderDetailRepository : BaseRepository<OrderDetail>
	{
   		
   		#region 构造 
   		public OrderDetailRepository(SqlServerProvider provider, OperateInfo oInfo = null) : base(provider, oInfo)
        {
        }
        #endregion
        
   		#region Costom Function 
        /// <summary>
        ///  删除Maticsoft.Model.OrderDetail，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Delete(DeleteModel model,IDbTransaction transaction = null)
        {
            var sql = @"UPDATE  OrderDetail SET DelState=1,DelUser=@DelUser,DelDate=@DelDate WHERE Id=@Id ";
            return TraceExecFunc(() => this.Conn.Execute(sql, new { DelUser = model.UserId, DelDate = DateTime.Now, Id = model.Id },transaction) > 0);
        }

		/// <summary>
        /// 获取所有的Maticsoft.Model.OrderDetail信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OrderDetail> GetAllList()
        {
            var sql = @" select *   FROM OrderDetail ";
            return TraceExecFunc(() => this.Conn.Query<OrderDetail>(sql));
        }
        #endregion
	}
}