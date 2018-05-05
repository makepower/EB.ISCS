using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EB.ISCS.Common.DataModel;
using EB.ISCS.FrameworkEntity.Base;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.InterFace.Sys
{
    interface ISysOperationLogService : IService
    {
        #region 基本方法(新增、更新、删除、查询) 

        /// <summary>
        ///  新增SysOperationLog
        /// </summary>
        /// <param name="model">SysOperationLog实体</param>
        /// <returns>bool</returns>
        long Add(SysOperationLog model);

        /// <summary>
        /// 根据查询条件返回操作日志列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        PagedListData<List<SysOperationLog>> GetListByQuery(QueryOperationLogModel query);


        #endregion
    }
}
