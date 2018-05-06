using EB.ISCS.Common.Enum;
using EB.ISCS.Common.Models;
using EB.ISCS.Common.ViewModel;
using EB.ISCS.DapperServices.Repository;
using EB.ISCS.WebApi.Filters;
using Maticsoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EB.ISCS.WebApi.Controllers.Biz
{
    /// <summary>
    /// 首页看板 客户端 缓存默认10分钟 服务器默认缓存2小时
    /// </summary>
    [OutputCache()]
    public class DashBoardController : BaseApiController
    {
        /// <summary>
        /// 今日实时运营指标
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<List<MonitorIndicator>> GetMonitorIndicator(int id)
        {
            try
            {
                ResultCode code = ResultCode.Success;
                var shipService = GetService<ShipInfoService>();
                var shipInfos = shipService.GetShipsByUserId(id);
                var monitorService = GetService<MonitorIndicatorService>();
                var ids = shipInfos.First(x => x.Plat == (int)ApiPlatform.Local).Id.ToString();
                var listResult = monitorService.GetTodayIndicator(ids);
                if (listResult == null)
                {
                    code = ResultCode.MissingData;
                    return ResponseResult<List<MonitorIndicator>>.GenFaildResponse(code);
                }
                return ResponseResult<List<MonitorIndicator>>.GenSuccessResponse(listResult);
            }
            catch (Exception ex)
            {
                return ResponseResult<List<MonitorIndicator>>.GenFaildResponse(ex.Message);
            }

        }


        /// <summary>
        /// 今日实时运营指标
        /// 订单数 成交额 商品数 访客数
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<List<MonitorIndicator>> GetTodayRealMonitorIndicator(int id)
        {
            var res = GetMonitorIndicator(id);
            if (res.Data != null && res.Data.Any())
            {
                res.Data = res.Data.FindAll(x => DashBoardIndicatorModel.DailyMonitor.Contains(x.ShortName));
            }
            return res;
        }


        /// <summary>
        /// 最近30天运营指标
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<List<GoodMonitorTopN>> GetMonitorStstisForThirtyDays(int id)
        {
            try
            {
                ResultCode code = ResultCode.Success;
                var shipService = GetService<ShipInfoService>();
                var shipInfos = shipService.GetShipsByUserId(id);
                var ids = shipInfos.First(x => x.Plat == (int)ApiPlatform.Local).Id.ToString();
                var monitorService = GetService<GoodMonitorTopNService>();
                var listResult = monitorService.GetMonitorStstisForThirtyDays(ids);
                if (listResult == null)
                {
                    code = ResultCode.Faild;
                    return ResponseResult<List<GoodMonitorTopN>>.GenFaildResponse(code);
                }

                return ResponseResult<List<GoodMonitorTopN>>.GenSuccessResponse(listResult);
            }
            catch (Exception ex)
            {
                return ResponseResult<List<GoodMonitorTopN>>.GenFaildResponse(ex.Message);
            }

        }

    }
}