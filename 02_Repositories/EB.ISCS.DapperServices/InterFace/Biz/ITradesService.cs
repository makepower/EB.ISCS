﻿using EB.ISCS.Common.DataModel;
using Maticsoft.Model.ISSC;
using System.Collections.Generic;
using System.Data;

namespace EB.ISCS.DapperServices.InterFace
{
    /// <summary>
	 	///交易信息 ：接口类
		/// </summary>		
	interface ITradesService : IService
	{
		 /// <summary>
		 ///  新增
		 /// </summary>
         int Add(Trades model,IDbTransaction transaction = null);
        
         /// <summary>
		 ///  根据Id获取模型
		 /// </summary>
         Trades GetModelById(int id);
        
        /// <summary>
        ///  删除Trades，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        bool Delete(DeleteModel model,IDbTransaction transaction = null);
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
	    bool Update(Trades model,IDbTransaction transaction = null);
		
		/// <summary>
        /// 获取所有的Trades信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<Trades> GetAllList();
	}
}