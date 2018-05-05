using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.Base;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.Repository.Sys
{
    public class MenuPermissionRepository : BaseRepository<SysMenuPermission>
    {
        public MenuPermissionRepository(SqlServerProvider provider, OperateInfo info) : base(provider, info) { }

        public bool RemoveAll(DeleteModel model)
        {
            var sql = @"UPDATE dbo.SysMenuPermission SET DelState = 1,DelDate = getDate(), DelUser = @DelUser WHERE Id = @Id";
            return this.Conn.Execute(sql, new { DelUser = model.UserId, Id = model.DelString }) > 0;
        }

        public List<SysMenuPermission> GetSysMenuPermissionsByMenu(SysMenu model)
        {
            var sql = "SELECT * FROM dbo.SysMenuPermission WHERE DelState = 0 AND Enabled = 1 AND MenuId = @MenuId";
            return TraceExecFunc<List<SysMenuPermission>>(
               () => this.Conn.Query<SysMenuPermission>(sql, model).ToList<SysMenuPermission>()
           );
        }

        public List<SysMenuPermission> GetUserPagePermissions(QueryUserPermissionModel queryModel)
        {
            var sql = @"SELECT S.Id,
                        S.MenuId,
                        S.ActionCode,
                        S.ActionName 
                        FROM SysUserPermission AS P 
                        INNER Join SysMenuPermission AS S 
                        ON 
                        S.Id=P.MenuActionId 
                        WHERE 
                        UserId=@UserId
                        AND S.MenuId=@MenuId";
            return TraceExecFunc(
               () => this.Conn.Query<SysMenuPermission>(sql, queryModel).ToList()
           );
        }


        public List<SysMenuPermission> GetUserPermissionsByUserId(int userId)
        {
            var sql = $@"SELECT S.Id,
                        S.Id,
                        S.MenuId,
                        S.ActionCode,
                        S.ActionName,
						S.ActionKey,
						S.ControllerKey
                        FROM SysUserPermission AS P 
                        INNER Join SysMenuPermission AS S 
                        ON 
                        S.Id=P.MenuActionId 
                        WHERE 
                        UserId={userId}";
            return TraceExecFunc(
               () => this.Conn.Query<SysMenuPermission>(sql, null).ToList()
           );
        }

        public bool UpdateMenuPermissionState(List<int> menuPermissionIdList)
        {
            var result = false;
            var sql = $@"UPDATE SysMenuPermission SET DelState=0 WHERE Id IN ({
                string.Join(",", menuPermissionIdList)}); UPDATE SysMenuPermission SET DelState=1 WHERE Id NOT IN ({
                    string.Join(",", menuPermissionIdList)
                })";
            result = TraceExecFunc(() => this.Conn.Execute(sql) > 0);
            return result;
        }

        public List<SysMenuPermission> GetMenuPermissionList(int menuId)
        {
            var sql = @"SELECT
			                A.Id ,
			                A.MenuId ,
			                A.ActionName ,
			                A.ActionKey ,
			                A.ControllerKey ,
			                A.ActionType ,
			                A.ActionCode ,
			                A.Description ,
			                A.ActionSort ,
			                A.InUser ,
			                A.InDate,
			                A.EditUser ,
			                A.EditDate,
			                A.DelUser ,
			                A.DelState ,
			                A.DelDate ,
						  B.UserName InUserName,
						  C.UserName EditUserName
                  FROM SysMenuPermission A LEFT JOIN  SysUser B
                  ON   A.InUser=B.Id
                  LEFT JOIN SysUser C
                  ON A.EditUser=C.Id
				  WHERE MenuId=@MenuId";
            return TraceExecFunc<List<SysMenuPermission>>(
                () => this.Conn.Query<SysMenuPermission>(sql, new
                {
                    MenuId = menuId
                }).ToList<SysMenuPermission>()
            );
        }

    }
}
