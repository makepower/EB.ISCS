using System.Collections.Generic;
using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.InterFace.Sys;
using EB.ISCS.DapperServices.Repository.Sys;
using EB.ISCS.FrameworkEntity.Base;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.Services.Sys
{

    public class SysExceptionLogService :Service, ISysExceptionLogService
    {
        private SysExceptionLogRepository _exceptionTokenRepository;
       
        public SysExceptionLogService()
            : this(string.Empty)
        {

        }
        public SysExceptionLogService(string connString)  : base(connString)
        {
            this._exceptionTokenRepository = new SysExceptionLogRepository(Provider,OInfo);
        }
        public SysExceptionLogService(Service service)  : base(service)
        {
            this._exceptionTokenRepository = new SysExceptionLogRepository(Provider, OInfo);
        }

        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public long Add(SysExceptionLog model)
        {
            return this._exceptionTokenRepository.Insert(model);
        }

        public PagedListData<List<SysExceptionLog>> GetListByQuery(QueryExceptionLogModel query)
        {
            return this._exceptionTokenRepository.GetListByQuery(query);
        }
    }
}
