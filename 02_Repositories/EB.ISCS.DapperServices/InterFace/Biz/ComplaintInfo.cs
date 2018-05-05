using EB.ISCS.Common.DataModel;
using Maticsoft.Model;
using System.Collections.Generic;
using System.Data;
namespace EB.ISCS.DapperServices.InterFace
{
    /// <summary>
	 	///投诉信息表 ：接口类
		/// </summary>		
	interface IComplaintInfoService : IService
	{
		 /// <summary>
		 ///  新增
		 /// </summary>
         int Add(ComplaintInfo model,IDbTransaction transaction = null);
        
         /// <summary>
		 ///  根据Id获取模型
		 /// </summary>
         ComplaintInfo GetModelById(int id);
        
        /// <summary>
        ///  删除ComplaintInfo，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        bool Delete(DeleteModel model,IDbTransaction transaction = null);
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
	    bool Update(ComplaintInfo model,IDbTransaction transaction = null);
		
		/// <summary>
        /// 获取所有的ComplaintInfo信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<ComplaintInfo> GetAllList();
	}
}