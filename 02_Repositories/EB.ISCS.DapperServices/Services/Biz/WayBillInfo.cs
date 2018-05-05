using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.InterFace;
using EB.ISCS.DapperServices.Services;
using Maticsoft.Model;
using System.Collections.Generic;
using System.Data;
namespace EB.ISCS.DapperServices.Repository
{

    /// <summary>
    ///运单信息 ：服务类
    /// </summary>		
    public partial class WayBillInfoService : Service, IWayBillInfoService
	{
   		
   		#region 构造 
   		private WayBillInfoRepository _WayBillInfoRepository;
        public WayBillInfoService()  : this(string.Empty)
        {

        }

        public WayBillInfoService(string connString) : base(connString)
        {
            this._WayBillInfoRepository = new WayBillInfoRepository(Provider,  OInfo);
        }

        public WayBillInfoService(Service service) : base(service)
        {
            this._WayBillInfoRepository = new WayBillInfoRepository(Provider, OInfo);
        }
        #endregion
        
		/// <summary>
		///  新增
		/// </summary>
        public int Add(WayBillInfo model,IDbTransaction transaction = null)
        {
            return _WayBillInfoRepository.Insert(model,transaction);
        }
        
        /// <summary>
		///  根据Id获取模型
		/// </summary>
        public WayBillInfo GetModelById(int id)
        {
            return _WayBillInfoRepository.Get(id);
        }
        
        /// <summary>
        ///  删除WayBillInfo，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(DeleteModel model,IDbTransaction transaction = null)
        {
            return this._WayBillInfoRepository.Delete(model,transaction);
        }
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WayBillInfo model,IDbTransaction transaction = null)
		{
            return  _WayBillInfoRepository.Update(model,transaction);
		}
		
		/// <summary>
        /// 获取所有的Maticsoft.Model.WayBillInfo信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<WayBillInfo> GetAllList()
        {
            return this._WayBillInfoRepository.GetAllList();
        }
	}
}