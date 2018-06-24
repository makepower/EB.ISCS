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
    ///首页监控指标信息 ：仓储类
    /// </summary>		
    public partial class MonitorIndicatorRepository : BaseRepository<MonitorIndicator>
    {

        #region 构造 
        public MonitorIndicatorRepository(SqlServerProvider provider, OperateInfo oInfo = null) : base(provider, oInfo)
        {
        }
        #endregion

        #region Costom Function 
        /// <summary>
        ///  删除Maticsoft.Model.MonitorIndicator，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Delete(DeleteModel model, IDbTransaction transaction = null)
        {
            var sql = @"UPDATE  MonitorIndicator SET DelState=1,DelUser=@DelUser,DelDate=@DelDate WHERE Id=@Id ";
            return TraceExecFunc(() => this.Conn.Execute(sql, new { DelUser = model.UserId, DelDate = DateTime.Now, Id = model.Id }, transaction) > 0);
        }

        /// <summary>
        /// 获取所有的Maticsoft.Model.MonitorIndicator信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MonitorIndicator> GetAllList(string where = null)
        {
            var sql = @" select *   FROM MonitorIndicator where 1=1 ";
            if (!string.IsNullOrEmpty(where))
            {
                sql += where;
            }
            return TraceExecFunc(() => this.Conn.Query<MonitorIndicator>(sql));
        }

        /// <summary>
        /// 获取所有的Maticsoft.Model.MonitorIndicator信息
        /// </summary>
        /// <returns></returns>
        public MonitorIndicator GetByCode(string code)
        {
            var sql = $@" select *   FROM MonitorIndicator where Code={code} ";
            return TraceExecFunc(() => this.Conn.QueryFirst<MonitorIndicator>(sql));
        }
        #endregion
    }
}