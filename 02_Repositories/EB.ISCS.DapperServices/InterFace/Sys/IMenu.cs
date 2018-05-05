using System.Collections.Generic;
using EB.ISCS.Common.DataModel;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.InterFace.Sys
{
    interface IMenu : IService
     {

        int Add(SysMenu model);

        bool RemoveAll(DeleteModel model);
        List<SysMenu> GetMenuByUserId(int id);

        IEnumerable<SysMenu> GetSysMenuList(QueryMenuModel query);

        bool IsRepeatById(string menuCode);

        bool IsRepeatByName(int id, string name);

        IEnumerable<SysMenu> GetUserMenus(int? userId);

        //public IEnumerable<SysMenu> GetRoleMenuList(SysRole roleModel)
        //{
        //    var sql = @"SELECT  
        //                A.[CompanyId],
        //                A.[MenuId] AS Id,
        //                A.[MenuName],
        //                A.[FatherId],
        //                A.[MenuControllerKey],
        //                A.[MenuSort],
        //                A.[IsMenu] AS IsOperatingMenu, 
        //             [MenuIsEvent] = CASE WHEN B.MenuId IS NULL THEN 0 ELSE 1 END 
        //            FROM  dbo.VSysMenuPermission AS A
        //                LEFT JOIN dbo.VRoleMenuPermission AS B ON A.[MenuId] = B.[MenuId] 
        //                AND B.CheckBoxState = 1 
        //                AND B.RoleId=@RoleId 
        //                WHERE A.DelState=0
        //                ORDER BY IsOperatingMenu DESC ";
        //    return TraceExecFunc(
        //       () => this.Conn.Query<SysMenu>(sql, new { RoleId = roleModel.Id }).ToList()
        //    );
        //}

        //public IEnumerable<SysMenu> GetRoleMenuListBySiteId(SysRole roleModel)
        //{
        //    var sql = @"SELECT  
        //                A.[CompanyId],
        //                A.[MenuId] AS Id,
        //                A.[MenuName],
        //                A.[FatherId],
        //                A.[MenuControllerKey],
        //                A.[MenuSort],
        //                A.[IsMenu] AS IsOperatingMenu, 
        //             [MenuIsEvent] = CASE WHEN B.MenuId IS NULL THEN 0 ELSE 1 END 
        //            FROM  dbo.VSysMenuPermission AS A
        //                INNER JOIN dbo.VRoleMenuPermission AS B ON A.[MenuId] = B.[MenuId] 
        //                AND B.CheckBoxState = 1 
        //                AND B.RoleId=@RoleId 
        //                AND B.BizType=@BizType
        //                WHERE A.DelState=0 ";
        //    return TraceExecFunc(
        //       () => this.Conn.Query<SysMenu>(sql, new { RoleId = roleModel.Id, BizType = roleModel.BizType }).ToList()
        //    );
        //}

        IEnumerable<SysMenu> GetMenuPermissionsListByUserId(int? userId);

        bool UpdateMenuState(List<int> menuIdList);
    }
}
