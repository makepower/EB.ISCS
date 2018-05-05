using System;
using System.Collections.Generic;
using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.Base;
using EB.ISCS.DapperServices.InterFace.Sys;
using EB.ISCS.DapperServices.Repository.Sys;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.Services.Sys
{
    public class MenuService : Service, IMenu
    {
        private MenuRepository _menuRepository;
        public MenuService() : this(string.Empty)
        {

        }
        public MenuService(string connString) : base(connString)
        {
            this._menuRepository = new MenuRepository(Provider, OInfo);
        }
        public MenuService(Service service) : base(service)
        {
            this._menuRepository = new MenuRepository(Provider, OInfo);
        }

        public int Add(SysMenu model)
        {
            /* 只需要保证MenuId唯一即可，MenuName不需要验证其是否重复 */
            return this._menuRepository.Add(model);
        }

        public bool Update(SysMenu model)
        {
            /* 只需要保证MenuId唯一即可，MenuName不需要验证其是否重复 */
            //if (_menuRepository.IsRepeatByName(model.Id, model.MenuName))
            //{
            //    throw new Exception("功能模块名称已经存在！");
            //}
            return this._menuRepository.Update(model);
        }

        public bool RemoveAll(DeleteModel model)
        {
            return _menuRepository.RemoveAll(model);
        }

        public List<SysMenu> GetMenuByUserId(int id)
        {
            return _menuRepository.GetMenuByUserId(id);
        }

        public IEnumerable<SysMenu> GetSysMenuList(QueryMenuModel query)
        {
            return _menuRepository.GetSysMenuList(query);
        }
        public bool Delete(DeleteModel model)
        {
            return this._menuRepository.RemoveAll(model);
        }

        public SysMenu GetModelById(int id)
        {
            return this._menuRepository.Get(id);
        }


        public bool IsRepeatById(string menuCode)
        {
            return _menuRepository.IsRepeatById(menuCode);
        }

        public bool IsRepeatByName(int id, string name)
        {
            return _menuRepository.IsRepeatByName(id, name);
        }

        public IEnumerable<SysMenu> GetUserMenus(int? userId)
        {
            return _menuRepository.GetUserMenus(userId);
        }

        public IEnumerable<SysMenu> GetRoleMenuList(SysRole roleModel)
        {
            return _menuRepository.GetRoleMenuList(roleModel);
        }

        public IEnumerable<SysMenu> GetRoleMenuListBySiteId(SysRole roleModel)
        {
            return _menuRepository.GetRoleMenuListBySiteId(roleModel);
        }

        public IEnumerable<SysMenu> GetMenuPermissionsListByUserId(int? userId)
        {
            return _menuRepository.GetMenuPermissionsListByUserId(userId);
        }

        public bool UpdateMenuState(List<int> menuIdList)
        {
            return _menuRepository.UpdateMenuState(menuIdList);
        }


        /// <summary> 
        /// 所有的菜单和动作
        /// 获取用户当前权限勾选项
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MenuAllTree> GetUserMenuById(int id)
        {
            return _menuRepository.GetUserMenuById(id);
        }
    }
}
