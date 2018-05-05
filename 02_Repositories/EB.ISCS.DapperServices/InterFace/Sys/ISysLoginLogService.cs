using System.Collections.Generic;
using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.Services.Sys;
using EB.ISCS.FrameworkEntity.Base;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.InterFace.Sys
{
	/// <summary>
	/// 记录登录日志信息
	/// </summary>
	public interface ISysLoginLogService
	{
		#region 基本方法(新增、更新、删除、查询) 
        
		/// <summary>
		///  新增SysLoginLog
		/// </summary>
		/// <param name="model">SysLoginLog实体</param>
		/// <returns>bool</returns>
		long Add(SysLoginLog model);

        /// <summary>
        /// 根据查询条件返回操作日志列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        PagedListData<List<SysLoginLog>> GetListByQuery(QueryLoginLogModel query);
        #endregion
    }
}