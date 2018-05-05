using EB.ISCS.DapperServices.InterFace.Sys;
using EB.ISCS.DapperServices.Repository.Sys;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.Services.Sys
{
    public class RoleMenuService:Service, IRoleMenuService
    {
        private RoleMenuRepository _roleMenuRepository;

        public RoleMenuService() : this(string.Empty) { }
        public RoleMenuService(string connString) : base(connString)
        {
            _roleMenuRepository = new RoleMenuRepository(base.Provider, base.OInfo);
        }
        public RoleMenuService(Service service) : base(service)
        {
            this._roleMenuRepository = new RoleMenuRepository(Provider, OInfo);
        }

        
        public int Add(SysRoleMenu model)
        {
            return this._roleMenuRepository.Insert(model);
        }

        public bool Delete(int id)
        {
            return this._roleMenuRepository.Delete(id);
        }

        public SysRoleMenu GetModelById(int id)
        {
            return this._roleMenuRepository.Get(id);
        }

        public bool Update(SysRoleMenu model)
        {
            return this._roleMenuRepository.Update(model);
        }

        public bool DeleteByRoleId(SysRoleMenu roleMenu)
        {
            return this._roleMenuRepository.DeleteByRoleId(roleMenu);
        }

        public bool DeleteRoleMenus(int roleId)
        {
            return _roleMenuRepository.DeleteRoleMenus(roleId);
        }
    }
}
