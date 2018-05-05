using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.InterFace.Sys
{
    interface ISysUserMenuService
    {
        #region 基本方法(新增、更新、删除、查询) 

        /// <summary>
        ///  新增SysUserMenu
        /// </summary>
        /// <param name="model">SysUserMenu实体</param>
        /// <returns>bool</returns>
        int Add(SysUserMenu model);

        /// <summary>
        /// 更新SysUserMenu
        /// </summary>
        /// <param name="model">SysUserMenu实体</param>
        /// <returns>bool</returns>
        bool Update(SysUserMenu model);

        /// <summary>
        /// 根据主键，删除数据表SysUserMenu中的一条记录
        /// </summary>
        /// <param name="Id">Id</param>
        /// <param name="delUser">删除人</param>
        /// <returns>bool</returns>
        bool Delete(string id, int delUser);

        /// <summary>
        /// 根据主键，查询数据表SysUserMenu中的一条记录
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>SysUserMenu</returns>
        SysUserMenu GetModelById(int id);

        #endregion
    }
}
