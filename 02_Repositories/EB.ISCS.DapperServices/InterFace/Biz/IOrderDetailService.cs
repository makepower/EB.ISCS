using EB.ISCS.Common.DataModel;
using Maticsoft.Model;
using System.Collections.Generic;
using System.Data;
namespace EB.ISCS.DapperServices.InterFace
{
    /// <summary>
	 	///OrderDetail ：接口类
		/// </summary>		
	interface IOrderDetailService : IService
	{
		 /// <summary>
		 ///  新增
		 /// </summary>
         int Add(OrderDetail model,IDbTransaction transaction = null);
        
         /// <summary>
		 ///  根据Id获取模型
		 /// </summary>
         OrderDetail GetModelById(int id);
        
        /// <summary>
        ///  删除OrderDetail，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        bool Delete(DeleteModel model,IDbTransaction transaction = null);
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
	    bool Update(OrderDetail model,IDbTransaction transaction = null);
		
		/// <summary>
        /// 获取所有的OrderDetail信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<OrderDetail> GetAllList();
	}
}