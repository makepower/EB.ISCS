using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.InterFace.Sys
{
    public interface IRoleMenuService : IService
    {
        #region 基本方法(新增、更新、删除、查询) 

        /// <summary>
        ///  新增SysRoleMenu
        /// </summary>
        /// <param name="model">SysRoleMenu实体</param>
        /// <returns>bool</returns>
        int Add(SysRoleMenu model);

        /// <summary>
        /// 更新SysRoleMenu
        /// </summary>
        /// <param name="model">SysRoleMenu实体</param>
        /// <returns>bool</returns>
        bool Update(SysRoleMenu model);

        /// <summary>
        /// 根据主键，删除数据表SysRoleMenu中的一条记录
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>bool</returns>
        bool Delete(int id);

        /// <summary>
        /// 根据主键，查询数据表SysRoleMenu中的一条记录
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>SysRoleMenu</returns>
        SysRoleMenu GetModelById(int id);

        /// <summary>
        /// 删除指定站点、给定角色下的菜单权限(企业赋权使用)
        /// </summary>
        /// <param name="roleMenu"></param>
        /// <returns></returns>
        bool DeleteByRoleId(SysRoleMenu roleMenu);

        /// <summary>
        /// 删除指定角色下的菜单
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        bool DeleteRoleMenus(int roleId);

        #endregion
    }
}
