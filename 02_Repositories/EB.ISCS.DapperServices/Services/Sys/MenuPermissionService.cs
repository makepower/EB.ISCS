using System.Collections.Generic;
using System.Linq;
using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.Base;
using EB.ISCS.DapperServices.InterFace.Sys;
using EB.ISCS.DapperServices.Repository.Sys;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.Services.Sys
{
    public class MenuPermissionService : Service, IMenuPermission
    {
        private MenuPermissionRepository _menuPermissionRepository;
        public MenuPermissionService() : this(string.Empty)
        {

        }
        public MenuPermissionService(string connString) : base(connString)
        {
            this._menuPermissionRepository = new MenuPermissionRepository(Provider, OInfo);
        }
        public MenuPermissionService(Service service) : base(service)
        {
            this._menuPermissionRepository = new MenuPermissionRepository(Provider, OInfo);
        }
        public bool RemoveAll(DeleteModel model)
        {
            return this._menuPermissionRepository.RemoveAll(model);
        }

        public List<SysMenuPermission> GetSysMenuPermissionsByMenu(SysMenu model)
        {
            return _menuPermissionRepository.GetSysMenuPermissionsByMenu(model);
        }

        public List<SysMenuPermission> GetUserPagePermissions(QueryUserPermissionModel queryModel)
        {
            return _menuPermissionRepository.GetUserPagePermissions(queryModel);
        }

        public List<SysMenuPermission> GetUserPermissionsByUserId(int userId)
        {
            return _menuPermissionRepository.GetUserPermissionsByUserId(userId);
        }


        public bool UpdateMenuPermissionState(List<int> menuPermissionIdList)
        {
            return _menuPermissionRepository.UpdateMenuPermissionState(menuPermissionIdList);
        }


        public int Add(SysMenuPermission model)
        {
            return this._menuPermissionRepository.Insert(model);
        }

        public bool Update(SysMenuPermission model)
        {
            return this._menuPermissionRepository.Update(model);
        }

        public bool Delete(DeleteModel model)
        {
            return this._menuPermissionRepository.RemoveAll(model);
        }

        public IEnumerable<SysMenuPermission> GetAllSysMenuPermissions()
        {
            return this._menuPermissionRepository.GetAll();
        }

        public SysMenuPermission GetModelById(int id)
        {
            return this._menuPermissionRepository.Get(id);
        }

        public List<SysMenuPermission> GetMenuPermissionList(int menuId)
        {
            return _menuPermissionRepository.GetMenuPermissionList(menuId);
        }
    }
}
