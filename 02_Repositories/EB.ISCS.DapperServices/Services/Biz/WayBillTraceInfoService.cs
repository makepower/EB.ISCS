using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.InterFace;
using EB.ISCS.DapperServices.Services;
using Maticsoft.Model;
using System.Collections.Generic;
using System.Data;

namespace EB.ISCS.DapperServices.Repository
{

    /// <summary>
    ///物流跟踪信息 ：服务类
    /// </summary>		
    public partial class WayBillTraceInfoService : Service, IWayBillTraceInfoService
	{
   		
   		#region 构造 
   		private WayBillTraceInfoRepository _WayBillTraceInfoRepository;
        public WayBillTraceInfoService()  : this(string.Empty)
        {

        }

        public WayBillTraceInfoService(string connString) : base(connString)
        {
            this._WayBillTraceInfoRepository = new WayBillTraceInfoRepository(Provider,  OInfo);
        }

        public WayBillTraceInfoService(Service service) : base(service)
        {
            this._WayBillTraceInfoRepository = new WayBillTraceInfoRepository(Provider, OInfo);
        }
        #endregion
        
		/// <summary>
		///  新增
		/// </summary>
        public int Add(WayBillTraceInfo model,IDbTransaction transaction = null)
        {
            return _WayBillTraceInfoRepository.Insert(model,transaction);
        }
        
        /// <summary>
		///  根据Id获取模型
		/// </summary>
        public WayBillTraceInfo GetModelById(int id)
        {
            return _WayBillTraceInfoRepository.Get(id);
        }
        
        /// <summary>
        ///  删除WayBillTraceInfo，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(DeleteModel model,IDbTransaction transaction = null)
        {
            return this._WayBillTraceInfoRepository.Delete(model,transaction);
        }
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WayBillTraceInfo model,IDbTransaction transaction = null)
		{
            return  _WayBillTraceInfoRepository.Update(model,transaction);
		}
		
		/// <summary>
        /// 获取所有的Maticsoft.Model.WayBillTraceInfo信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<WayBillTraceInfo> GetAllList()
        {
            return this._WayBillTraceInfoRepository.GetAllList();
        }
	}
}