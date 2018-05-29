using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.InterFace;
using EB.ISCS.DapperServices.Services;
using Maticsoft.Model.ISSC;
using System.Collections.Generic;
using System.Data;

namespace EB.ISCS.DapperServices.Repository
{

    /// <summary>
    ///订单信息 ：服务类
    /// </summary>		
    public partial class OrderInfoService : Service, IOrderInfoService
	{
   		
   		#region 构造 
   		private OrderInfoRepository _OrderInfoRepository;
        public OrderInfoService()  : this(string.Empty)
        {

        }

        public OrderInfoService(string connString) : base(connString)
        {
            this._OrderInfoRepository = new OrderInfoRepository(Provider,  OInfo);
        }

        public OrderInfoService(Service service) : base(service)
        {
            this._OrderInfoRepository = new OrderInfoRepository(Provider, OInfo);
        }
        #endregion
        
		/// <summary>
		///  新增
		/// </summary>
        public int Add(OrderInfo model,IDbTransaction transaction = null)
        {
            return _OrderInfoRepository.Insert(model,transaction);
        }
        
        /// <summary>
		///  根据Id获取模型
		/// </summary>
        public OrderInfo GetModelById(int id)
        {
            return _OrderInfoRepository.Get(id);
        }
        
        /// <summary>
        ///  删除OrderInfo，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(DeleteModel model,IDbTransaction transaction = null)
        {
            return this._OrderInfoRepository.Delete(model,transaction);
        }
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(OrderInfo model,IDbTransaction transaction = null)
		{
            return  _OrderInfoRepository.Update(model,transaction);
		}
		
		/// <summary>
        /// 获取所有的Maticsoft.Model.OrderInfo信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OrderInfo> GetAllList()
        {
            return this._OrderInfoRepository.GetAllList();
        }
   
    }
}