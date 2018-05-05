using EB.ISCS.Common.DataModel;
using Maticsoft.Model;
using System.Collections.Generic;
using System.Data;
namespace EB.ISCS.DapperServices.InterFace
{
    /// <summary>
	 	///首页监控指标信息 ：接口类
		/// </summary>		
	interface IMonitorIndicatorService : IService
	{
		 /// <summary>
		 ///  新增
		 /// </summary>
         int Add(MonitorIndicator model,IDbTransaction transaction = null);
        
         /// <summary>
		 ///  根据Id获取模型
		 /// </summary>
         MonitorIndicator GetModelById(int id);
        
        /// <summary>
        ///  删除MonitorIndicator，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        bool Delete(DeleteModel model,IDbTransaction transaction = null);
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
	    bool Update(MonitorIndicator model,IDbTransaction transaction = null);
		
		/// <summary>
        /// 获取所有的MonitorIndicator信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<MonitorIndicator> GetAllList();
	}
}