using EB.ISCS.Common.DataModel;
using EB.ISCS.Common.Enum;
using EB.ISCS.DapperServices.Repository;
using EB.ISCS.DapperServices.Repository.Sys;
using EB.ISCS.FrameworkEntity.Base;
using EB.ISCS.FrameworkEntity.SystemEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EB.ISCS.DapperServices.Services.Sys
{
    public class SysUserService : Service
    {
        private readonly SysUserRepository _sysUserRepository;
        private readonly UserRoleRepository _userRoleRepository;
        private readonly SysUserMenuRepository _sysUserMenuRepository;
        private readonly SysUserPermissionRepository _sysUserPermissionRepository;
        private readonly ShipInfoRepository _shipInfoRepository;

        public SysUserService() : this(string.Empty)
        {

        }

        public SysUserService(Service service) : base(service)
        {

        }

        public SysUserService(string connString) : base(connString)
        {
            this._sysUserMenuRepository = new SysUserMenuRepository(Provider, OInfo);
            this._sysUserPermissionRepository = new SysUserPermissionRepository(Provider, OInfo);
            this._sysUserRepository = new SysUserRepository(Provider, OInfo);
            this._userRoleRepository = new UserRoleRepository(Provider, OInfo);
            this._shipInfoRepository = new ShipInfoRepository(Provider, OInfo);
        }

        #region 基本增删改查

        /// <summary>
        /// 根据主键，查询数据表SysUser中的一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns>SysUser</returns>
        public SysUser GetModelById(int id)
        {
            SysUser model = _sysUserRepository.GetModelByPk(id);
            return model;
        }

        public int Add(SysUser entity)
        {
            if (_sysUserRepository.GetLoginNameIsRepeat(entity.Id, entity.LoginName))
            {
                throw new Exception("登录名称已存在，请重新输入！");
            }
            using (var ts = Provider.Conn.BeginTransaction())
            {
                try
                {
                    var maxId = _sysUserRepository.Insert(entity, ts);
                    _shipInfoRepository.Insert(new Maticsoft.Model.ShipInfo()
                    {
                        InDate = DateTime.Now,
                        Name = $"shop-{entity.LoginName}",
                        Code = Guid.NewGuid().ToString(),
                        Plat = (int)ApiPlatform.Local,
                        Status = 1,
                        UserId = maxId,
                        Description = "virtual-shop for statistis"
                    }, ts);
                    ts.Commit();
                    return maxId;
                }
                catch (Exception ex)
                {
                    ts.Rollback();
                }
                return 0;
            }
        }

        public bool Update(SysUser entity)
        {
            if (_sysUserRepository.GetLoginNameIsRepeat(entity.Id, entity.LoginName))
            {
                throw new Exception("登录名称已存在，请重新输入！");
            }
            using (var ts = Provider.Conn.BeginTransaction())
            {
                try
                {
                    var results = _sysUserRepository.Update(entity, ts);

                    ts.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    ts.Rollback();
                }
                return false;
            }
        }

        public bool Delete(DeleteModel delModel)
        {
            var user = this._sysUserRepository.Get(delModel.Id);
            if (user != null)
            {
                user.DelDate = ServerTime;
                user.DelUser = delModel.UserId;
                user.DelState = 1;
                return this._sysUserRepository.Update(user);
            }
            else
            {
                throw new InvalidOperationException("用户不存在");
            }
        }
        #endregion

        #region 各种登录    
        public SysUser Login(string loginName, string password)
        {
            return _sysUserRepository.Login(loginName, password);
        }

        public SysUser SuperLogin(string loginName, string password)
        {
            return _sysUserRepository.SuperLogin(loginName, password);
        }
        #endregion


        #region 角色用户（给角色挂用户）

        /// <summary>
        /// 根据角色编号获取用户列表（已分配）
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public IEnumerable<SysUser> GetUserListByRoleId(int roleId)
        {
            return _userRoleRepository.GetUserListByRoleId(roleId);
        }

        /// <summary>
        /// 根据角色编号获取用户列表(未分配)
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public IEnumerable<SysUser> GetNoUserListByRoleId(int roleId)
        {
            return _userRoleRepository.GetNoUserListByRoleId(roleId);
        }

        /// <summary>
        /// 根据角色编号删除用户信息
        /// </summary>
        /// <param name="roleId">roleId</param>
        /// <returns>bool</returns>
        public bool DeleteUserByRoleId(string roleId)
        {
            return _userRoleRepository.DeleteUserByRoleId(roleId);
        }

        /// <summary>
        /// 给角色分配用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddUserRoleForRole(SysUserRole model)
        {
            using (var transaction = Provider.GetConn().BeginTransaction())
            {
                try
                {
                    if (model.RoleId > 0)
                    {
                        _userRoleRepository.DeleteUserByRoleId(model.RoleId.ToString(), transaction);
                    }
                    if (!string.IsNullOrWhiteSpace(model.UserIds))
                    {
                        var userIds = model.UserIds.Split(',');
                        if (userIds.Length > 0)
                        {
                            foreach (var Id in userIds)
                            {
                                var id = 0;
                                int.TryParse(Id, out id);
                                model.UserId = id;
                                model.InDate = ServerTime;
                                _userRoleRepository.Insert(model, transaction);
                            }
                        }
                    }
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
                return false;
            }
        }
        #endregion

        #region 用户/角色权限

        /// <summary>
        /// 保存用户权限
        /// </summary>
        /// <param name="userMenuPermission"></param>
        /// <returns></returns>
        public bool SaveUserPermission(UserMenuPermission userMenuPermission)
        {
            var userMenuList = userMenuPermission.UserMenuViewModel;
            var userPermissionList = userMenuPermission.UserPermissionViewModel;
            if ((userMenuList == null || userMenuList.Count <= 0) && (userPermissionList == null || userPermissionList.Count <= 0))
            {
                return false;
            }
            var userId = userMenuList.FirstOrDefault().UserId;
            if (userId <= 0)
            {
                return false;
            }

            using (var ts = Provider.Conn.BeginTransaction())
            {
                try
                {
                    //先删除用户菜单记录，再添加新的
                    if (userId != null)
                    {
                        _sysUserMenuRepository.DeleteSysUserMenuByUserId((int)userId, ts);
                        foreach (var userMenu in userMenuList)
                        {
                            _sysUserMenuRepository.Insert(userMenu, ts);
                        }

                        //先删除用户操作记录，在添加新的
                        _sysUserPermissionRepository.DeleteSysUserPermissionByUserId((int)userId, ts);
                        foreach (var rolePermission in userPermissionList)
                        {
                            _sysUserPermissionRepository.Insert(rolePermission, ts);
                        }
                    }

                    ts.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    ts.Rollback();
                }
                return false;

            }
        }

        /// <summary>
        /// 返回用户角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserRoles GetUserRoles(int userId)
        {
            var ur = _sysUserRepository.GetUserRoles(userId);
            return ur;
        }

        public int AddUserRole(SysUserRole userRole)
        {
            return this._userRoleRepository.Insert(userRole);
        }

        #endregion

        #region 扩展方法

        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdatePassWord(SysUser model)
        {
            bool result = _sysUserRepository.UpdatePassWord(model);
            return result;
        }

        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ChangePassword(SysUser model)
        {
            bool result = _sysUserRepository.ChangePassword(model);
            return result;
        }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="companyCode"></param>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public bool Exists(string companyCode, string loginName)
        {
            bool modelList = _sysUserRepository.Exists(companyCode, loginName);
            return modelList;
        }

        /// <summary>
        /// 查询用户信息列表（分页）
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <returns></returns>
        public PagedListData<List<SysUser>> GetUserListByQuery(QueryUserModel query)
        {
            return _sysUserRepository.GetUserListByQuery(query);
        }

        /// <summary>
        /// 查询下拉用户列表
        /// </summary>
        /// <returns></returns>
        public List<SysUser> GetList()
        {
            return _sysUserRepository.GetList();
        }

        #endregion

        /// <summary>
        /// 获取所有的SysUser信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SysUser> GetAllList(IDbTransaction transaction = null)
        {
            return this._sysUserRepository.GetAllList(transaction);
        }
    }
}
