using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.InterFace.Sys;
using EB.ISCS.DapperServices.Repository.Sys;
using EB.ISCS.FrameworkEntity.Base;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.Services.Sys
{

    public class SysOperationLogService : Service, ISysOperationLogService
    {
        private SysOperationLogRepository _loginTokenRepository;

        public SysOperationLogService() : this(string.Empty)
        {

        }
        public SysOperationLogService(string connString)   : base(connString)
        {
            this._loginTokenRepository = new SysOperationLogRepository(Provider, OInfo);
        }
        public SysOperationLogService(Service service)  : base(service)
        {
            this._loginTokenRepository = new SysOperationLogRepository(Provider, OInfo);
        }

        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public long Add(SysOperationLog model)
        {
            return this._loginTokenRepository.Insert(model);
        }

        public PagedListData<List<SysOperationLog>> GetListByQuery(QueryOperationLogModel query)
        {
            return this._loginTokenRepository.GetListByQuery(query);
        }
    }
}
