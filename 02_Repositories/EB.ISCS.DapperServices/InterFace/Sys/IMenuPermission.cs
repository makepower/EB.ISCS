using System.Collections.Generic;
using System.Linq;
using Dapper;
using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.Base;
using EB.ISCS.DapperServices.Repository;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.InterFace.Sys
{
    interface IMenuPermission : IService
    {

        //public bool RemoveAll(DeleteModel model)
        //{
        //    var sql = @"UPDATE dbo.SysMenuPermission SET DelState = 1,DelDate = getDate(), DelUser = @DelUser WHERE Id = @Id";
        //    return this.Conn.Execute(sql, new { DelUser = model.UserId, Id = model.DelString }) > 0;
        //}

        List<SysMenuPermission> GetSysMenuPermissionsByMenu(SysMenu model);

        //public List<SysMenuPermission> GetUserPagePermissions(QueryUserPermissionModel queryModel)
        //{
        //    var sql = @"SELECT MenuActionId
        //              , MenuId
        //              , UserId
        //              , CompanyId
        //              , CheckBoxState
        //              , UserName
        //              , LoginName
        //              , ActionName
        //              , ActionKey
        //              , MenuName
        //              , MenuState
        //              , FatherId
        //              , MenuControllerKey
        //              , PageUrl
        //              , MenuSort
        //              , FatherIDPath
        //              , Target
        //              , IconCSS
        //              , ActionSort
        //              , ActionCode
        //          FROM dbo.VUserPermission  WHERE UserId = @UserId AND CompanyId = @CompanyId AND MenuId = @MenuId";
        //    return TraceExecFunc<List<SysMenuPermission>>(
        //       () => this.Conn.Query<SysMenuPermission>(sql, queryModel).ToList<SysMenuPermission>()
        //   );
        //}
        List<SysMenuPermission> GetMenuPermissionList(int menuId);
        bool UpdateMenuPermissionState(List<int> menuPermissionIdList);

    }
}
