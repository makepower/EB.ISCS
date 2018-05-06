using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.InterFace;
using EB.ISCS.DapperServices.Services;
using Maticsoft.Model;
using System.Collections.Generic;
using System.Data;
namespace EB.ISCS.DapperServices.Repository
{

    /// <summary>
    ///OrderDetail ：服务类
    /// </summary>		
    public partial class OrderDetailService : Service, IOrderDetailService
	{
   		
   		#region 构造 
   		private OrderDetailRepository _OrderDetailRepository;
        public OrderDetailService()  : this(string.Empty)
        {

        }

        public OrderDetailService(string connString) : base(connString)
        {
            this._OrderDetailRepository = new OrderDetailRepository(Provider,  OInfo);
        }

        public OrderDetailService(Service service) : base(service)
        {
            this._OrderDetailRepository = new OrderDetailRepository(Provider, OInfo);
        }
        #endregion
        
		/// <summary>
		///  新增
		/// </summary>
        public int Add(OrderDetail model,IDbTransaction transaction = null)
        {
            return _OrderDetailRepository.Insert(model,transaction);
        }
        
        /// <summary>
		///  根据Id获取模型
		/// </summary>
        public OrderDetail GetModelById(int id)
        {
            return _OrderDetailRepository.Get(id);
        }
        
        /// <summary>
        ///  删除OrderDetail，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(DeleteModel model,IDbTransaction transaction = null)
        {
            return this._OrderDetailRepository.Delete(model,transaction);
        }
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(OrderDetail model,IDbTransaction transaction = null)
		{
            return  _OrderDetailRepository.Update(model,transaction);
		}
		
		/// <summary>
        /// 获取所有的Maticsoft.Model.OrderDetail信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OrderDetail> GetAllList()
        {
            return this._OrderDetailRepository.GetAllList();
        }
	}
}