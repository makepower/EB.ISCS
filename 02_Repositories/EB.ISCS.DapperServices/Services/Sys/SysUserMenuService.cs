using EB.ISCS.DapperServices.InterFace.Sys;
using EB.ISCS.DapperServices.Repository.Sys;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.Services.Sys
{
    public class SysUserMenuService : Service, ISysUserMenuService
    {

        private SysUserMenuRepository _sysUserMenuRepository;
        public SysUserMenuService() : this(string.Empty)
        {

        }
        public SysUserMenuService(string connString) : base(connString)
        {
            this._sysUserMenuRepository = new SysUserMenuRepository(Provider, OInfo);
        }
        public SysUserMenuService(Service service) : base(service)
        {
            this._sysUserMenuRepository = new SysUserMenuRepository(Provider, OInfo);
        }

        public int Add(SysUserMenu model)
        {
           return this._sysUserMenuRepository.Insert(model);
        }

        public bool Delete(string id, int delUser)
        {
            return this._sysUserMenuRepository.Delete(id);
        }

        public SysUserMenu GetModelById(int id)
        {
            return _sysUserMenuRepository.Get(id);
        }

        public bool Update(SysUserMenu model)
        {
            return _sysUserMenuRepository.Update(model);
        }
    }
}
