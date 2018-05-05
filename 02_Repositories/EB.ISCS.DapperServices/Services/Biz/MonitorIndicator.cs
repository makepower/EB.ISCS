using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.InterFace;
using EB.ISCS.DapperServices.Services;
using Maticsoft.Model;
using System.Collections.Generic;
using System.Data;
namespace EB.ISCS.DapperServices.Repository
{

    /// <summary>
    ///首页监控指标信息 ：服务类
    /// </summary>		
    public partial class MonitorIndicatorService : Service, IMonitorIndicatorService
	{
   		
   		#region 构造 
   		private MonitorIndicatorRepository _MonitorIndicatorRepository;
        public MonitorIndicatorService()  : this(string.Empty)
        {

        }

        public MonitorIndicatorService(string connString) : base(connString)
        {
            this._MonitorIndicatorRepository = new MonitorIndicatorRepository(Provider,  OInfo);
        }

        public MonitorIndicatorService(Service service) : base(service)
        {
            this._MonitorIndicatorRepository = new MonitorIndicatorRepository(Provider, OInfo);
        }
        #endregion
        
		/// <summary>
		///  新增
		/// </summary>
        public int Add(MonitorIndicator model,IDbTransaction transaction = null)
        {
            return _MonitorIndicatorRepository.Insert(model,transaction);
        }
        
        /// <summary>
		///  根据Id获取模型
		/// </summary>
        public MonitorIndicator GetModelById(int id)
        {
            return _MonitorIndicatorRepository.Get(id);
        }
        
        /// <summary>
        ///  删除MonitorIndicator，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(DeleteModel model,IDbTransaction transaction = null)
        {
            return this._MonitorIndicatorRepository.Delete(model,transaction);
        }
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(MonitorIndicator model,IDbTransaction transaction = null)
		{
            return  _MonitorIndicatorRepository.Update(model,transaction);
		}
		
		/// <summary>
        /// 获取所有的Maticsoft.Model.MonitorIndicator信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MonitorIndicator> GetAllList()
        {
            return this._MonitorIndicatorRepository.GetAllList();
        }
	}
}