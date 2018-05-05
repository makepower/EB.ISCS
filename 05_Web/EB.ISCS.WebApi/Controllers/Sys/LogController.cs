using EB.ISCS.Common.BaseController;
using EB.ISCS.Common.DataModel;
using EB.ISCS.Common.Models;
using EB.ISCS.DapperServices.Services.Sys;
using EB.ISCS.FrameworkEntity.Base;
using EB.ISCS.FrameworkEntity.SystemEntity;
using EB.ISCS.FrameworkHelp.BizException;
using EB.ISCS.WebApi.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EB.ISCS.WebApi.Controllers.Sys
{
    /// <summary>
    /// 
    /// </summary>
    public class LogController : BaseApiController
    {
        /// <summary>
        /// 获取分页
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<PagedListData<List<SysOperationLog>>> GetPage(QueryOperationLogModel pages)
        {
            try
            {
                var service = GetService<SysOperationLogService>();
                var result = service.GetListByQuery(pages);
                return ResponseResult<PagedListData<List<SysOperationLog>>>.GenSuccessResponse(result);
            }
            catch (Exception ex)
            {
                return ResponseResult<PagedListData<List<SysOperationLog>>>.GenFaildResponse(ex.Message);
            }
        }
    }
}