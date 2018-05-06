using EB.ISCS.Common.DataModel;
using EB.ISCS.Common.Enum;
using EB.ISCS.Common.Models;
using EB.ISCS.DapperServices.Repository;
using EB.ISCS.FrameworkEntity.Base;
using EB.ISCS.FrameworkHelp.Utilities;
using Maticsoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;


namespace EB.ISCS.WebApi.Controllers.Biz
{
    /// <summary>
    /// 店铺管理
    /// </summary>
    public class ShopManagerController : BaseApiController
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="ship"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<int> Insert(ShipInfo ship)
        {
            var service = GetService<ShipInfoService>();
            var result = service.Add(ship);
            return ResponseResult<int>.GenSuccessResponse(result);
        }


        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<ShipInfo> GetModelById(int id)
        {
            var service = GetService<ShipInfoService>();
            var result = service.GetModelById(id);
            result.PlatName = EnumHelper.GetEnumByValue<ApiPlatform>(result.Plat).GetDescription();
            return ResponseResult<ShipInfo>.GenSuccessResponse(result);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Delete(DeleteModel model)
        {
            try
            {
                var service = GetService<ShipInfoService>();
                var vIsSuess = service.DeleteById(model.Id);
                return ResponseResult<bool>.GenSuccessResponse(vIsSuess);
            }
            catch (Exception ex)
            {
                return ResponseResult<bool>.GenFaildResponse(ex.Message);
            }
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Update(ShipInfo model)
        {
            try
            {
                var service = GetService<ShipInfoService>();
                var vIsSuess = service.Update(model);
                return ResponseResult<bool>.GenSuccessResponse(vIsSuess);
            }
            catch (Exception ex)
            {
                return ResponseResult<bool>.GenFaildResponse(ex.Message);
            }
        }



        /// <summary>
        /// 获取用户下的所有店铺信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<List<ShipInfo>> GetAll(int id)
        {
            try
            {
                var service = GetService<ShipInfoService>();
                var result = service.GetShipsByUserId(id)?.ToList();
                foreach (var item in result)
                {
                    item.PlatName = EnumHelper.GetEnumByValue<ApiPlatform>(item.Plat).GetDescription();
                }
                return ResponseResult<List<ShipInfo>>.GenSuccessResponse(result);
            }
            catch (Exception ex)
            {
                return ResponseResult<List<ShipInfo>>.GenFaildResponse(ex.Message);
            }
        }

        /// <summary>
        /// Get Page
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<PagedListData<List<ShipInfo>>> GetPage(PageSearch page)
        {
            try
            {
                var service = GetService<ShipInfoService>();
                var result = service.GetPage(page);
                if (result.PagingData != null && result.PagingData.Any())
                {
                    foreach (var item in result.PagingData)
                    {
                        item.PlatName = EnumHelper.GetEnumByValue<ApiPlatform>(item.Plat).GetDescription();
                    }
                }
                return ResponseResult<PagedListData<List<ShipInfo>>>.GenSuccessResponse(result);
            }
            catch (Exception ex)
            {
                return ResponseResult<PagedListData<List<ShipInfo>>>.GenFaildResponse(ex.Message);
            }
        }
    }
}