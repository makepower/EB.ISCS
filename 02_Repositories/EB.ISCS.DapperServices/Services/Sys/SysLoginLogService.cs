using System.Collections.Generic;
using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.InterFace.Sys;
using EB.ISCS.DapperServices.Repository.Sys;
using EB.ISCS.FrameworkEntity.Base;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.Services.Sys
{

    public class SysLoginLogService : Service, ISysLoginLogService
    {
        private SysLoginLogRepository _loginTokenRepository;

        public SysLoginLogService() : this(string.Empty)
        {

        }
        public SysLoginLogService(string connString) : base(connString)
        {
            this._loginTokenRepository = new SysLoginLogRepository(Provider, OInfo);
        }
        public SysLoginLogService(Service service) : base(service)
        {
            this._loginTokenRepository = new SysLoginLogRepository(Provider, OInfo);
        }

        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public long Add(SysLoginLog model)
        {
            return this._loginTokenRepository.Insert(model);
        }

        /// <summary>
        /// 登出操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int LoginOutByToken(string token, System.Data.IDbTransaction dbTransaction = null)
        {
            return this._loginTokenRepository.LoginOutByToken(token, dbTransaction);
        }


        public PagedListData<List<SysLoginLog>> GetListByQuery(QueryLoginLogModel query)
        {
            return this._loginTokenRepository.GetListByQuery(query);
        }
    }
}
