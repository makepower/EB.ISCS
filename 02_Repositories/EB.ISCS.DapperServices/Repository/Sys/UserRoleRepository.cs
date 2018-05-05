using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using EB.ISCS.DapperServices.Base;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.Repository.Sys
{
    /// <summary>
    /// 用户角色仓储
    /// </summary>
    public class UserRoleRepository : BaseRepository<SysUserRole>
    {
        public UserRoleRepository(SqlServerProvider provider, OperateInfo info)
            : base(provider, info)
        {

        }

        public bool DeleteRolesByUserId(int userId)
        {
            return TraceExecFunc(() => this.DeleteAll($"WHERE UserId = {userId} "));
        }

        #region 角色用户

        /// <summary>
        /// 根据角色编号获取用户列表（已分配）
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public IEnumerable<SysUser> GetUserListByRoleId(int roleId)
        {
            var command = @" SELECT 
                                  A.Id,
                                  A.UserName 
                             FROM SysUser A,
                                  SysUserRole B 
                             WHERE A.Id=b.UserId
                                 AND B.Enabled=1 
                                 AND A.DelState=0
	                               AND B.RoleId=@RoleId";
            var dp = new DynamicParameters();
            dp.Add("@RoleId", roleId);
            return TraceExecFunc(() => this.Conn.Query<SysUser>(command, dp));
        }

        /// <summary>
        /// 根据角色编号获取用户列表(未分配)
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public IEnumerable<SysUser> GetNoUserListByRoleId(int roleId)
        {
            var command = @" SELECT 
                                 A.Id,
                                 A.UserName 
                                 FROM SysUser A
                                 WHERE A.Enabled=1 AND A.DelState=0 AND A.UserType=0
		                                AND A.Id NOT IN 
		                                (
		                                SELECT 
			                                UserId 
		                                FROM SysUserRole B 
		                                WHERE B.Enabled=1 
			                                 AND B.RoleId=@RoleId";
            var dp = new DynamicParameters();
            dp.Add("@RoleId", roleId);
            return TraceExecFunc(() => this.Conn.Query<SysUser>(command, dp));
        }

        /// <summary>
        /// 根据角色编号删除用户信息
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="transaction"></param>
        /// <returns>bool</returns>
        public bool DeleteUserByRoleId(string roleId, IDbTransaction transaction = null)
        {
            var command = @"DECLARE @Sql NVARCHAR(MAX);
                                  SET @Sql = N' DELETE FROM dbo.SysUserRole    
		                                WHERE 
				                                RoleId IN(' + @RoleId + ') ';
                                  EXEC sp_executesql @Sql, N' @RoleId  NVARCHAR(MAX) ', @RoleId";
            var dp = new DynamicParameters();
            dp.Add("@RoleId", roleId);
            return TraceExecFunc(() => this.Conn.ExecuteScalar<int>(command, dp, transaction) >= 0);
        }

        #endregion 

        #region 用户角色

        /// <summary>
        /// 根据用户编号获取角色列表（未分配）
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public List<SysRole> GetNoRoleListByUserId(int userId, IDbTransaction transaction = null)
        {
            var command = @" SELECT 
                                 A.Id,
                                 A.RoleName 
                             FROM SYsRole A
                             WHERE A.Enabled=1 AND A.DelState=0
		                                AND 1=1
		                                AND A.Id NOT IN 
		                                (
		                                SELECT 
			                                RoleId 
		                                FROM SysUserRole B 
		                                WHERE 1=1 
			                                  AND B.Enabled=1 
			                                 AND B.UserId=@UserId";
            var dp = new DynamicParameters();
            dp.Add("@UserId", userId);
            return TraceExecFunc(() => Conn.Query<SysRole>(command,
                new { UserId = userId },
                transaction)?.ToList());
        }

        /// <summary>
        /// 根据用户编号获取角色列表（已分配）
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public List<SysRole> GetRoleListByUserId(int userId, IDbTransaction transaction = null)
        {
            var command = @" SELECT 
                                  A.Id,
                                  A.RoleName 
                             FROM SysRole A,
                                  SysUserRole B 
                             WHERE A.Id=b.RoleId
                                 AND B.Enabled=1
                                 AND A.DelState=0
	                             AND 1=1
	                             AND B.UserId=@UserId";
            var dp = new DynamicParameters();
            dp.Add("@UserId", userId);
            return TraceExecFunc(() => Conn.Query<SysRole>(command, dp, transaction)?.ToList());
        }

        /// <summary>
        /// 根据用户编号删除角色信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool DeleteRoleByUserId(string userId, IDbTransaction transaction = null)
        {
            var command = @" DECLARE @Sql NVARCHAR(MAX);
                              SET @Sql = N' DELETE FROM dbo.SysUserRole    
		                            WHERE 
				                            UserId IN(' + @UserId + ')';
                              EXEC sp_executesql @Sql, N' @UserId  NVARCHAR(MAX)', @UserId";
            var dp = new DynamicParameters();
            dp.Add("@UserId", userId);
            return TraceExecFunc(() => this.Conn.ExecuteScalar<int>(command, dp, transaction) >= 0);
        }

        #endregion

    }
}
