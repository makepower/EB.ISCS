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
    public class SysUserPermissionRepository : BaseRepository<SysUserPermission>
    {
        public SysUserPermissionRepository(SqlServerProvider provider, OperateInfo oInfo = null) : base(provider, oInfo)
        {
        }

        /// <summary>
        /// 根据主键，删除数据表SysUserPermission中的一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <returns>bool</returns>
        public new bool Delete(int id, IDbTransaction transaction = null)
        {
            var sql = @"UPDATE dbo.SysUserPermission    
		                        SET DelState = 1
		                        WHERE 
				                        Id = @Id";
            return TraceExecFunc(() => Conn.Execute(sql,
                new
                {
                    UserId = id
                }, transaction) >= 0);
        }

        /// <summary>
        /// 根据主键，查询数据表SysUserPermission中的一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <returns>SysUserPermission</returns>
        public SysUserPermission GetModelByPK(int id, IDbTransaction transaction = null)
        {
            var sql = @"SELECT 
                                Id ,
                                MenuActionId ,
                                MenuId ,
                                UserId ,
                                Enabled ,
                                InUser ,
                                InDate
                            FROM dbo.SysUserPermission WHERE
                                Id = @Id";
            return TraceExecFunc(() => Conn.QueryFirstOrDefault<SysUserPermission>(sql,
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
        public bool DeleteSysUserPermissionByUserId(int userId, IDbTransaction transaction = null)
        {
            var sql = @"DELETE FROM dbo.SysUserPermission WHERE UserId = @UserId";
            return TraceExecFunc(() => Conn.Execute(sql,
                new
                {
                    UserId = userId
                }, transaction) >= 0);
        }
        #endregion
    }
}
