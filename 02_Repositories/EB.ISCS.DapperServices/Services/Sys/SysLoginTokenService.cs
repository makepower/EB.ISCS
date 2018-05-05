using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EB.ISCS.DapperServices.InterFace.Sys;
using EB.ISCS.DapperServices.Repository.Sys;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.Services.Sys
{
    public class SysLoginTokenService : Service, ISysLoginTokenService
    {
        private SysLoginTokenRepository _loginTokenRepository;

        public SysLoginTokenService() : this(string.Empty)
        {

        }
        public SysLoginTokenService(string connString) : base(connString)
        {
            this._loginTokenRepository = new SysLoginTokenRepository(Provider, OInfo);
        }
        public SysLoginTokenService(Service service) : base(service)
        {
            this._loginTokenRepository = new SysLoginTokenRepository(Provider, OInfo);
        }
        #region 基本方法(新增、更新、删除、查询) 

        /// <summary>
        ///  新增表SysLoginToken
        /// </summary>
        /// <param name="model">SysLoginToken实体</param>
        /// <returns>bool</returns>
        public bool Add(SysLoginToken model)
        {
            return _loginTokenRepository.Add(model);
        }

        /// <summary>
        /// 根据token获取用户
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public SysLoginToken GetByToken(string token)
        {
            return _loginTokenRepository.GetByToken(token);
        }

        /// <summary>
        /// 禁用token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public int DisableToken(string token,System.Data.IDbTransaction dbTransaction =null)
        {
            return _loginTokenRepository.DisableToken(token, dbTransaction);
        }
        #endregion
    }
}
