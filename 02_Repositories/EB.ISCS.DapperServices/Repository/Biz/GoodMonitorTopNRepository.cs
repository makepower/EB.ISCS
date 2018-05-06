using Dapper;
using EB.ISCS.Common.DataModel;
using EB.ISCS.Common.Enum;
using EB.ISCS.DapperServices.Base;
using Maticsoft.Model;
using System;
using System.Collections.Generic;
using System.Data;


namespace EB.ISCS.DapperServices.Repository
{
    /// <summary>
    ///首页监控指标信息 ：仓储类
    /// </summary>		
    public partial class GoodMonitorTopNRepository : BaseRepository<GoodMonitorTopN>
    {

        #region 构造 
        public GoodMonitorTopNRepository(SqlServerProvider provider, OperateInfo oInfo = null) : base(provider, oInfo)
        {
        }
        #endregion

        #region Costom Function 
        /// <summary>
        ///  删除Maticsoft.Model.GoodMonitorTopN，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Delete(DeleteModel model, IDbTransaction transaction = null)
        {
            var sql = @"UPDATE  GoodMonitorTopN SET DelState=1,DelUser=@DelUser,DelDate=@DelDate WHERE Id=@Id ";
            return TraceExecFunc(() => this.Conn.Execute(sql, new { DelUser = model.UserId, DelDate = DateTime.Now, Id = model.Id }, transaction) > 0);
        }

        /// <summary>
        /// 获取所有的Maticsoft.Model.GoodMonitorTopN信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GoodMonitorTopN> GetAllList(string where = null)
        {
            var sql = @" select *   FROM GoodMonitorTopN where 1=1 ";
            if (!string.IsNullOrEmpty(where))
            {
                sql += where;
            }
            return TraceExecFunc(() => this.Conn.Query<GoodMonitorTopN>(sql));
        }


        /// <summary>
        /// 获取最近30天的汇总信息
        /// 统计截至时间默认为前一天
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GoodMonitorTopN> GetMonitorStstisForThirtyDays(string shipIds)
        {
            var sql = $@" select * FROM GoodMonitorTopN where StatisPeriodType ={(int)StatisPeriodType.LastMonth} and StatisDate ='{ DateTime.Now.Date.AddDays(-1).ToString("yyyy-MM-dd") }'";

            if (!string.IsNullOrEmpty(shipIds))
            {
                sql += $" and ShipInfoId int({shipIds})";
            }
            return TraceExecFunc(() => this.Conn.Query<GoodMonitorTopN>(sql));
        }
        #endregion
    }
}