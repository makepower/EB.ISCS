using EB.ISCS.DapperServices.Base;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.Repository.Sys
{
    /// <summary>
    /// 角色功能仓储
    /// </summary>
    public class RoleMenuRepository : BaseRepository<SysRoleMenu>
    {
        public RoleMenuRepository(SqlServerProvider provider, OperateInfo info)
            : base(provider, info)
        {

        }

        public bool DeleteByRoleId(SysRoleMenu roleMenu)
        {
            var result = TraceExecFunc<bool>(
                () => this.DeleteAll($"WHERE RoleId = {roleMenu.RoleId} AND BizType = {roleMenu.BizType}"));
            return result;
        }

        public bool DeleteRoleMenus(int roleId)
        {
            var sql = @"DELETE SysRoleMenu WHERE RoleId=@RoleId";
            var result = TraceExecFunc<bool>(
                () => this.Execute(sql, new { RoleId = roleId }) > 0);
            return result;
        }
    }
}
