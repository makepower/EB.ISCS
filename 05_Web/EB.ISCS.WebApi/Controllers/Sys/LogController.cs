using EB.ISCS.Common.DataModel;
using EB.ISCS.Common.Models;
using EB.ISCS.DapperServices.Services.Sys;
using EB.ISCS.FrameworkEntity.Base;
using EB.ISCS.FrameworkEntity.SystemEntity;
using System;
using System.Collections.Generic;
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
        public ResponseResult<PagedListData<List<SysLoginLog>>> GetLoginLogPageList(QueryLoginLogModel pages)
        {
            try
            {
                pages.PageSize = pages.PageSize == 0 ? 15 : pages.PageSize;
                pages.PageIndex = pages.PageIndex < 1 ? 1 : pages.PageIndex;
                var service = GetService<SysLoginLogService>();
                var result = service.GetListByQuery(pages);
                return ResponseResult<PagedListData<List<SysLoginLog>>>.GenSuccessResponse(result);
            }
            catch (Exception ex)
            {
                return ResponseResult<PagedListData<List<SysLoginLog>>>.GenFaildResponse(ex.Message);
            }
        }

        /// <summary>
        /// 获取分页
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<PagedListData<List<SysOperationLog>>> GetOperaterLogPageList(QueryOperationLogModel pages)
        {
            try
            {
                pages.PageSize = pages.PageSize == 0 ? 15 : pages.PageSize;
                pages.PageIndex = pages.PageIndex < 1 ? 1 : pages.PageIndex;
                var service = GetService<SysOperationLogService>();
                var result = service.GetListByQuery(pages);
                return ResponseResult<PagedListData<List<SysOperationLog>>>.GenSuccessResponse(result);
            }
            catch (Exception ex)
            {
                return ResponseResult<PagedListData<List<SysOperationLog>>>.GenFaildResponse(ex.Message);
            }
        }

        /// <summary>
        /// 获取分页
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<PagedListData<List<SysExceptionLog>>> GetExceptionLogPageList(QueryExceptionLogModel pages)
        {
            try
            {
                pages.PageSize = pages.PageSize == 0 ? 15 : pages.PageSize;
                pages.PageIndex = pages.PageIndex < 1 ? 1 : pages.PageIndex;
                var service = GetService<SysExceptionLogService>();
                var result = service.GetListByQuery(pages);
                return ResponseResult<PagedListData<List<SysExceptionLog>>>.GenSuccessResponse(result);
            }
            catch (Exception ex)
            {
                return ResponseResult<PagedListData<List<SysExceptionLog>>>.GenFaildResponse(ex.Message);
            }
        }
    }
}