using System.Collections.Generic;
using EB.ISCS.Common.DataModel;
using EB.ISCS.FrameworkEntity.Base;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.InterFace.Sys
{
    /// <summary>
    /// 系统异常错误日志
    /// </summary>
    public interface ISysExceptionLogService
    {
        #region 基本方法(新增、更新、删除、查询) 

        /// <summary>
        ///  新增SysExceptionLog
        /// </summary>
        /// <param name="model">SysExceptionLog实体</param>
        /// <returns>bool</returns>
        long Add(SysExceptionLog model);

        /// <summary>
        /// 根据查询条件返回异常日志列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        PagedListData<List<SysExceptionLog>> GetListByQuery(QueryExceptionLogModel query);
        #endregion
    }
}