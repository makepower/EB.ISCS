using EB.ISCS.DapperServices.InterFace.Sys;
using EB.ISCS.DapperServices.Repository.Sys;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.Services.Sys
{
    public class RolePermissionService : Service, IRolePermissionService
    {
        private RolePermissionRepository _rolePermissionRepository;

        /// <summary>
        /// 因为此服务被webUI调用，此处没有配置，因此需要
        /// </summary>
        /// <param name="connString"></param>
        public RolePermissionService(string connString) : base(connString)
        {
            _rolePermissionRepository = new RolePermissionRepository(base.Provider, base.OInfo);
        }

        public RolePermissionService()
        {
            _rolePermissionRepository = new RolePermissionRepository(base.Provider, base.OInfo);
        }

        public int Add(SysRolePermission model)
        {
            return this._rolePermissionRepository.Insert(model);
        }

        public bool Delete(int id)
        {
            return this._rolePermissionRepository.Delete(id);
        }

        public SysRolePermission GetModelById(int id)
        {
            return this._rolePermissionRepository.Get(id);
        }

        public bool Update(SysRolePermission model)
        {
            return this._rolePermissionRepository.Update(model);
        }

        public bool DeleteByRoleId(SysRoleMenu roleMenu)
        {
            return this._rolePermissionRepository.DeleteByRoleId(roleMenu);
        }

        public bool DeleteRolePermissions(int roleId)
        {
            return this._rolePermissionRepository.DeleteRolePermissions(roleId);
        }
    }
}
