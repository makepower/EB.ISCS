using EB.ISCS.DapperServices.Base;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.Repository.Sys
{
    /// <summary>
    /// 角色操作权限仓储
    /// </summary>
    public class RolePermissionRepository : BaseRepository<SysRolePermission>
    {
        public RolePermissionRepository(SqlServerProvider provider, OperateInfo info)
            : base(provider, info)
        {

        }

        public bool DeleteByRoleId(SysRoleMenu roleMenu)
        {
            var result = TraceExecFunc<bool>(
                () => this.DeleteAll($"WHERE RoleId = {roleMenu.RoleId} AND BizType = {roleMenu.BizType}"));
            return result;
        }

        public bool DeleteRolePermissions(int roleId)
        {
            var sql = @"DELETE SysRolePermission WHERE RoleId=@RoleId";
            var result = TraceExecFunc<bool>(
                ()=> this.Execute(sql, new {RoleId=roleId})>0
                );
            return result;
        }
    }
}
