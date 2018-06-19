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
    public partial class MonitorIndicatorRecordRepository : BaseRepository<MonitorIndicatorRecord>
    {

        #region 构造 
        public MonitorIndicatorRecordRepository(SqlServerProvider provider, OperateInfo oInfo = null) : base(provider, oInfo)
        {
        }
        #endregion

        #region Costom Function 
        /// <summary>
        ///  删除Maticsoft.Model.MonitorIndicatorRecord，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Delete(DeleteModel model, IDbTransaction transaction = null)
        {
            var sql = @"UPDATE  MonitorIndicatorRecord SET DelState=1,DelUser=@DelUser,DelDate=@DelDate WHERE Id=@Id ";
            return TraceExecFunc(() => this.Conn.Execute(sql, new { DelUser = model.UserId, DelDate = DateTime.Now, Id = model.Id }, transaction) > 0);
        }

        /// <summary>
        /// 获取所有的Maticsoft.Model.MonitorIndicatorRecord信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MonitorIndicatorRecord> GetAllList(string where = null)
        {
            var sql = @" select * FROM MonitorIndicatorRecord where 1=1 ";
            if (!string.IsNullOrEmpty(where))
            {
                sql += where;
            }
            return TraceExecFunc(() => this.Conn.Query<MonitorIndicatorRecord>(sql));
        }

        /// <summary>
        /// 获取所有的Maticsoft.Model.MonitorIndicatorRecord信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MonitorIndicatorRecord> GetTodayIndicator(string where = null)
        {
            var sql = @" select * FROM MonitorIndicatorRecord a left join MonitorIndicator b where 1=1 ";
            if (!string.IsNullOrEmpty(where))
            {
                sql += where;
            }
            return TraceExecFunc(() => this.Conn.Query<MonitorIndicatorRecord>(sql));
        }



        #endregion
    }
}