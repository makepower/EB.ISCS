using Dapper;
using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.Base;
using EB.ISCS.FrameworkEntity.Base;
using Maticsoft.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace EB.ISCS.DapperServices.Repository
{
    /// <summary>
    ///店铺信息 ：仓储类
    /// </summary>		
    public partial class ShipInfoRepository : BaseRepository<ShipInfo>
    {

        #region 构造 
        public ShipInfoRepository(SqlServerProvider provider, OperateInfo oInfo = null) : base(provider, oInfo)
        {
        }
        #endregion

        #region Costom Function 
        /// <summary>
        ///  删除Maticsoft.Model.ShipInfo，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Delete(DeleteModel model, IDbTransaction transaction = null)
        {
            var sql = @"UPDATE  ShipInfo SET Status=0 WHERE Id=@Id ";
            return TraceExecFunc(() => this.Conn.Execute(sql, new { Id = model.Id }, transaction) > 0);
        }

        /// <summary>
        ///  删除Maticsoft.Model.ShipInfo，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool DeleteById(int modelId, IDbTransaction transaction = null)
        {
            var sql = $@"UPDATE  ShipInfo SET Status=0 WHERE Id={modelId} ";
            return TraceExecFunc(() => this.Conn.Execute(sql, transaction) > 0);
        }

        /// <summary>
        /// 获取所有的Maticsoft.Model.ShipInfo信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ShipInfo> GetAllList()
        {
            var sql = @" select *   FROM ShipInfo ";
            return TraceExecFunc(() => this.Conn.Query<ShipInfo>(sql));
        }

        /// <summary>
        /// 获取所有的Maticsoft.Model.ShipInfo信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ShipInfo> GetShipsByUserId(int userId)
        {
            var sql = $@" select * FROM ShipInfo where UserId={ userId} and Plat < 3 ";
            return TraceExecFunc(() => this.Conn.Query<ShipInfo>(sql));
        }

        /// <summary>
        /// 获取分页
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public PagedListData<List<ShipInfo>> GetPage(PageSearch query)
        {
            var model = new PageListModel()
            {
                WithColumn = @"Id
                              ,UserId
                              ,Code
                              ,Name
                              ,Plat
                              ,Description
                              ,AppKey
                              ,AppSecret
                              ,DeliveryAddress
                              ,InDate
                              ,Contract
                              ,Status
                              ,Remark",
                WithWhere = " Status=1 ",
                LeftColumn = " B.UserName",
                LeftJoin = @" LEFT JOIN SysUser B ON A.UserId=B.Id ",
            };
            return this.PagedListQuery(model, query);
        }

        #endregion
    }
}