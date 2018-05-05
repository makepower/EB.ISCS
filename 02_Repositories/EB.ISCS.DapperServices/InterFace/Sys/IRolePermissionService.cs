using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.InterFace.Sys
{
    public interface IRolePermissionService : IService
    {
        #region 基本方法(新增、更新、删除、查询) 

        /// <summary>
        ///  新增SysRolePermission
        /// </summary>
        /// <param name="model">SysRolePermission实体</param>
        /// <returns>bool</returns>
        int Add(SysRolePermission model);

        /// <summary>
        /// 更新SysRolePermission
        /// </summary>
        /// <param name="model">SysRolePermission实体</param>
        /// <returns>bool</returns>
        bool Update(SysRolePermission model);

        /// <summary>
        /// 根据主键，删除数据表SysRolePermission中的一条记录
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>bool</returns>
        bool Delete(int id);

        /// <summary>
        /// 根据主键，查询数据表SysRolePermission中的一条记录
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>SysRolePermission</returns>
        SysRolePermission GetModelById(int id);

        /// <summary>
        /// 删除指定站点、给定角色下的功能权限(企业赋权使用)
        /// </summary>
        /// <param name="roleMenu"></param>
        /// <returns></returns>
        bool DeleteByRoleId(SysRoleMenu roleMenu);

        /// <summary>
        /// 删除指定角色下的功能权限（角色权限分配使用）
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        bool DeleteRolePermissions(int roleId);

        #endregion
    }
}
