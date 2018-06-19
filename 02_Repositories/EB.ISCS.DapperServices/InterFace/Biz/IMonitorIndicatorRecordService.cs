using EB.ISCS.Common.DataModel;
using Maticsoft.Model;
using System.Collections.Generic;
using System.Data;
namespace EB.ISCS.DapperServices.InterFace
{
    /// <summary>
	 	///首页监控指标信息 ：接口类
		/// </summary>		
	interface IMonitorIndicatorRecordService : IService
	{
		 /// <summary>
		 ///  新增
		 /// </summary>
         int Add(MonitorIndicatorRecord model,IDbTransaction transaction = null);
        
         /// <summary>
		 ///  根据Id获取模型
		 /// </summary>
         MonitorIndicatorRecord GetModelById(int id);
        
        /// <summary>
        ///  删除GoodMonitorTopN，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        bool Delete(DeleteModel model,IDbTransaction transaction = null);
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
	    bool Update(MonitorIndicatorRecord model,IDbTransaction transaction = null);
		
		/// <summary>
        /// 获取所有的GoodMonitorTopN信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<MonitorIndicatorRecord> GetAllList();
	}
}