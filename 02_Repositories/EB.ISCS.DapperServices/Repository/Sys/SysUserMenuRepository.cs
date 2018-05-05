using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EB.ISCS.DapperServices.Base;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.Repository.Sys
{
    public class SysUserMenuRepository : BaseRepository<SysUserMenu>
    {
        public SysUserMenuRepository(SqlServerProvider provider, OperateInfo oInfo = null) : base(provider, oInfo)
        {
        }

        /// <summary>
        /// 根据主键，删除数据表SysUserMenu中的一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <returns>bool</returns>
        public new bool Delete(int id, IDbTransaction transaction = null)
        {
            var sql = @"DELETE FROM dbo.SysUserMenu WHERE Id = @Id";
            return TraceExecFunc(() => Conn.Execute(sql,
                new
                {
                    Id = id
                },
                transaction) >= 0);
        }

        /// <summary>
        /// 根据主键，查询数据表SysUserMenu中的一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <returns>SysUserMenu</returns>
        public SysUserMenu GetModelByPK(int id, IDbTransaction transaction = null)
        {
            var sql = @"SELECT 
			                    Id ,
			                    MenuId ,
			                    UserId ,
			                    CheckBoxState ,
			                    Enabled ,
			                    InUser ,
			                    InDate
	   	                    FROM dbo.SysUserMenu WHERE 
	                       Id = @Id";
            return TraceExecFunc(() => Conn.QueryFirstOrDefault<SysUserMenu>(sql,
                new
                {
                    Id = id
                }, transaction));
        }

        #region 自定义方法

        /// <summary>
        /// 根据主键，删除数据表SysUserMenu中的一条记录
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="transaction"></param>
        /// <returns>bool</returns>
        public bool DeleteSysUserMenuByUserId(int userId, IDbTransaction transaction = null)
        {
            var sql = @" DELETE FROM dbo.SysUserMenu WHERE UserId = @UserId";
            return TraceExecFunc(() => Conn.Execute(sql,
                new
                {
                    UserId = userId
                }, transaction) >= 0);
        }

        #endregion
    }
}
