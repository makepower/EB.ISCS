using System.Collections.Generic;
using System.Linq;
using Dapper;
using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.Base;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.Repository.Sys
{
    public class MenuRepository : BaseRepository<SysMenu>
    {
        public MenuRepository(SqlServerProvider provider, OperateInfo info) : base(provider, info) { }

        public int Add(SysMenu model)
        {
            var sql = @"INSERT INTO dbo.SysMenu
                (      MenuName
                      ,MenuState
                      ,FatherId
                      ,PageUrl
                      ,MenuControllerKey
                      ,MenuActionKey
                      ,MenuDescription
                      ,MenuSort
                      ,IsShow
                      ,PictureUrl
                      ,NoteLevel
                      ,MenuIsEvent
                      ,IconCSS
                      ,InUser
                      ,InDate
                )
               VALUES
                (      @MenuName
                      ,@MenuState
                      ,@FatherId
                      ,@PageUrl
                      ,@MenuControllerKey
                      ,@MenuActionKey
                      ,@MenuDescription
                      ,@MenuSort
                      ,@IsShow
                      ,@PictureUrl
                      ,@NoteLevel
                      ,@MenuIsEvent
                      ,@IconCSS
                      ,@InUser
                      ,GetDate()
                )";
            return this.Conn.Execute(sql, model);
        }

        public bool RemoveAll(DeleteModel model)
        {
            var sql = @"UPDATE dbo.SysMenu    
		    SET DelState = 1,
            MenuState = 0,
            DelUser = @DelUser,
            DelDate = getDate()
		    WHERE Id=@Id OR FatherId=@Id";
            return this.Conn.Execute(sql, new { DelUser = model.UserId, Id = model.DelString }) > 0;
        }

        public List<SysMenu> GetMenuByUserId(int id)
        {
            var sql = "SELECT * FROM dbo.SysMenu WHERE MenuState=1 AND DelState=0";
            return TraceExecFunc<List<SysMenu>>(
               () => this.Conn.Query<SysMenu>(sql).ToList<SysMenu>()
           );
        }

        public IEnumerable<SysMenu> GetSysMenuList(QueryMenuModel query)
        {
            var sql = "SELECT * FROM dbo.SysMenu ";
            var where = " WHERE 1=1 AND DelState = 0 ";
            var orderBy = " ORDER BY MenuSort ";

            //模块管理页面需要用所有的菜单（包括可用的和禁用的都需要）
            if (query?.IsGetAllMenus == 1)
                where += " AND MenuState=1 ";

            //排序：默认按照 MenuSort 排序，否则按照新指定的排序字段排序
            if (query?.OrderBy != null)
                orderBy = $" ORDER BY {query?.OrderBy}";

            sql = $"{sql} {@where} {orderBy}";

            return TraceExecFunc(() => Conn.Query<SysMenu>(sql));
        }

        public bool IsRepeatById(string menuCode)
        {
            var sql = @"SELECT COUNT(1) FROM dbo.SysMenu WHERE MenuCode = @MenuCode";
            return this.Conn.ExecuteScalar<int>(sql, new { MenuCode = menuCode }) > 0;
        }

        public bool IsRepeatByName(int id, string name)
        {
            var sql = @"SELECT COUNT(1) FROM dbo.SysMenu WHERE DelState=0 AND MenuState=1 AND ID<>@Id AND MenuName=@MenuName";
            return this.Conn.ExecuteScalar<int>(sql, new { Id = id, MenuName = name }) > 0;
        }

        public IEnumerable<SysMenu> GetUserMenus(int? userId)
        {
            var sql = @"SELECT u.* FROM SysMenu u inner join SysUserMenu s on s.MenuId=u.Id and s.UserId=@UserId AND u.DelState=0 AND u.MenuState=1 Order by MenuSort  ";
            return TraceExecFunc<List<SysMenu>>(
               () => this.Conn.Query<SysMenu>(sql, new { UserId = userId }).ToList<SysMenu>()
            );
        }

        public IEnumerable<SysMenu> GetRoleMenuList(SysRole roleModel)
        {
            var sql = @"SELECT  
                        A.[MenuId] AS Id,
                        A.[MenuName],
                        A.[FatherId],
                        A.[MenuControllerKey],
                        A.[MenuSort],
                        A.[IsMenu] AS IsOperatingMenu, 
	                    [MenuIsEvent] = CASE WHEN B.MenuId IS NULL THEN 0 ELSE 1 END 
                    FROM  dbo.VSysMenuPermission AS A
                        LEFT JOIN dbo.VRoleMenuPermission AS B ON A.[MenuId] = B.[MenuId] 
                        AND B.CheckBoxState = 1 
                        AND B.RoleId=@RoleId 
                        WHERE A.DelState=0
                        ORDER BY IsOperatingMenu DESC ";
            return TraceExecFunc(
               () => this.Conn.Query<SysMenu>(sql, new { RoleId = roleModel.Id }).ToList()
            );
        }

        public IEnumerable<SysMenu> GetRoleMenuListBySiteId(SysRole roleModel)
        {
            var sql = @"SELECT  
                        A.[MenuId] AS Id,
                        A.[MenuName],
                        A.[FatherId],
                        A.[MenuControllerKey],
                        A.[MenuSort],
                        A.[IsMenu] AS IsOperatingMenu, 
                     [MenuIsEvent] = CASE WHEN B.MenuId IS NULL THEN 0 ELSE 1 END 
                    FROM  dbo.VSysMenuPermission AS A
                        INNER JOIN dbo.VRoleMenuPermission AS B ON A.[MenuId] = B.[MenuId] 
                        AND B.CheckBoxState = 1 
                        AND B.RoleId=@RoleId 
                        AND B.BizType=@BizType
                        WHERE A.DelState=0 ";
            return TraceExecFunc(
               () => this.Conn.Query<SysMenu>(sql, new { RoleId = roleModel.Id, BizType = 0 }).ToList()
            );
        }

        public IEnumerable<SysMenu> GetMenuPermissionsListByUserId(int? userId)
        {
            var sql = @"SELECT  
                       A.[MenuId] AS Id,
                       A.[MenuName],
                       A.[FatherId],
                       A.[MenuControllerKey],
                       A.[MenuSort],
                       A.[IsMenu] AS IsOperatingMenu, 
	                   [MenuIsEvent] = CASE WHEN B.MenuId IS NULL THEN 0 ELSE 1 END 
                    FROM  dbo.VSysMenuPermission AS A
                        LEFT JOIN dbo.VSysUserMenuPermission AS B ON A.[MenuId] = B.[MenuId] 
                        AND B.CheckBoxState = 1
                        AND B.UserId=@UserId 
                        WHERE A.DelState=0 ";
            return TraceExecFunc(
                   () => this.Conn.Query<SysMenu>(sql, new { UserId = userId }).ToList()
                );
        }

        public bool UpdateMenuState(List<int> menuIdList)
        {
            var result = false;
            var sql = $@"UPDATE SysMenu SET DelState=0 WHERE Id IN ({string.Join(",", menuIdList)});
                                      UPDATE SysMenu SET DelState=1 WHERE Id NOT IN ({string.Join(",", menuIdList)})";
            result = TraceExecFunc(() => this.Conn.Execute(sql) > 0);
            return result;
        }


        #region 自定义

        /// <summary>
        /// 所有的菜单和动作
        /// 获取用户当前权限勾选项
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MenuAllTree> GetUserMenuById(int id)
        {
            var sql = @"WITH MenuAllTree AS
                        (
                            SELECT M.ID AS Id,M.MenuName AS Name,M.FatherId AS FId,1 AS IsMenu,
                            CASE WHEN P.Id > 0 THEN 1
                               WHEN P.Id IS NULL   THEN 0
                            END CheckState
                            FROM SysMenu AS M LEFT JOIN SysUserMenu AS P ON P.MenuId = M.Id AND P.UserId=@Id WHERE M.DelState=0
                            UNION ALL
                            SELECT M.ID AS Id,M.ActionName AS Name,M.MenuId AS FId,0 AS IsMenu,
                            CASE WHEN P.Id > 0 THEN 1
                               WHEN P.Id IS NULL THEN 0
                            END CheckState
                            FROM SysMenuPermission AS M LEFT JOIN SysUserPermission AS P ON P.MenuActionId = M.Id 
                            AND P.MenuId = M.MenuId AND P.UserId=@Id WHERE M.MenuId NOT IN (select id from SysMenu where DelState=1)
                        )
                        SELECT Id,Name,FId,IsMenu,CheckState FROM MenuAllTree";
            return TraceExecFunc(() => this.Conn.Query<MenuAllTree>(sql,
                new
                {
                    Id = id
                })).ToList();
        }


        #endregion
    }
}
