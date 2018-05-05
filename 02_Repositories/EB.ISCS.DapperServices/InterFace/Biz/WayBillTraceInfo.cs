﻿using EB.ISCS.Common.DataModel;
using Maticsoft.Model;
using System.Collections.Generic;
using System.Data;

namespace EB.ISCS.DapperServices.InterFace
{
    /// <summary>
	 	///物流跟踪信息 ：接口类
		/// </summary>		
	interface IWayBillTraceInfoService : IService
	{
		 /// <summary>
		 ///  新增
		 /// </summary>
         int Add(WayBillTraceInfo model,IDbTransaction transaction = null);
        
         /// <summary>
		 ///  根据Id获取模型
		 /// </summary>
         WayBillTraceInfo GetModelById(int id);
        
        /// <summary>
        ///  删除WayBillTraceInfo，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        bool Delete(DeleteModel model,IDbTransaction transaction = null);
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
	    bool Update(WayBillTraceInfo model,IDbTransaction transaction = null);
		
		/// <summary>
        /// 获取所有的WayBillTraceInfo信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<WayBillTraceInfo> GetAllList();
	}
}