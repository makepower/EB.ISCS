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
    ///商品信息 ：仓储类
    /// </summary>		
    public partial class GoodInfoRepository : BaseRepository<GoodInfo>
	{
   		
   		#region 构造 
   		public GoodInfoRepository(SqlServerProvider provider, OperateInfo oInfo = null) : base(provider, oInfo)
        {
        }
        #endregion
        
   		#region Costom Function 
        /// <summary>
        ///  删除Maticsoft.Model.GoodInfo，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Delete(DeleteModel model,IDbTransaction transaction = null)
        {
            var sql = @"UPDATE  GoodInfo SET DelState=1,DelUser=@DelUser,DelDate=@DelDate WHERE Id=@Id ";
            return TraceExecFunc(() => this.Conn.Execute(sql, new { DelUser = model.UserId, DelDate = DateTime.Now, Id = model.Id },transaction) > 0);
        }

		/// <summary>
        /// 获取所有的Maticsoft.Model.GoodInfo信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GoodInfo> GetAllList()
        {
            var sql = @" select *   FROM GoodInfo ";
            return TraceExecFunc(() => this.Conn.Query<GoodInfo>(sql));
        }
        #endregion
	}
}