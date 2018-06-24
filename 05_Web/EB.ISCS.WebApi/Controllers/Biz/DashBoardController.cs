using EB.ISCS.Common.DataModel;
using EB.ISCS.Common.Models;
using EB.ISCS.Common.ViewModel;
using EB.ISCS.DapperServices.Repository;
using EB.ISCS.FrameworkHelp.Utilities;
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
    [OutputCache(clientCacheExpiration: 600, ServerCacheExpiration = 7200)]
    public class DashBoardController : BaseApiController
    {

        /// <summary>
        /// 今日实时运营指标
        /// 订单数 成交额 商品数 访客数
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<List<MonitorIndicatorRecord>> GetTodayRealMonitorIndicator(int id)
        {
            var result = new List<MonitorIndicatorRecord>();
            var service = GetService<MonitorIndicatorRecordService>();
            foreach (var item in DashBoardIndicatorModel.DailyMonitor)
            {
                var list = service.QueryLastRecord(id, item);
                if (list != null && list.Any())
                    result.Add(list.First());
                else
                {
                    result.Add(new MonitorIndicatorRecord());
                }
            }
            return ResponseResult<List<MonitorIndicatorRecord>>.GenSuccessResponse(result);
        }

        /// <summary>
        /// 获取图表插件数据
        /// </summary>
        /// <param name="id">业务类型</param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<ChartModel> GetDashBoardChartViewData(int id, int userId)
        {
            var data = new ChartModel() { XAxis = new List<dynamic>(), Series = new List<dynamic>[] { new List<dynamic>() } };
            try
            {
                var service = GetService<MonitorIndicatorRecordService>();
                var biz = EnumHelper.GetEnumByValue<ChartBiz>(id);
                var indicatorShortName = string.Empty;
                var seriesContainsName = false;
                switch (biz)
                {
                    case ChartBiz.Map:
                        indicatorShortName = Common.Constants.Indicator_ShortName_MonthAreaOrderNum;
                        seriesContainsName = true;
                        break;
                    case ChartBiz.TopN:
                        indicatorShortName = Common.Constants.Indicator_ShortName_MonthRealSellWell;
                        break;
                    case ChartBiz.BootomN:
                        indicatorShortName = Common.Constants.Indicator_ShortName_MonthOverStorage;
                        break;
                    case ChartBiz.Sell_ForMonth:
                        indicatorShortName = Common.Constants.Indicator_ShortName_DaySaleMoney;
                        break;
                    case ChartBiz.Flow_ForMonth:
                        indicatorShortName = Common.Constants.Indicator_ShortName_DayFlow;

                        return ResponseResult<ChartModel>.GenFaildResponse("功能待开发....");
                    case ChartBiz.Order_Trans:
                        indicatorShortName = Common.Constants.Indicator_ShortName_MonthConversionRate;
                        return ResponseResult<ChartModel>.GenFaildResponse("功能待开发....");
                    case ChartBiz.Pay_Channel:
                        indicatorShortName = Common.Constants.Indicator_ShortName_MonthPaymentChannel;
                        break;
                    case ChartBiz.Order_Status_ForMonth:
                        indicatorShortName = Common.Constants.Indicator_ShortName_MonthOrderStatus;
                        break;
                    case ChartBiz.Custom_Analy:
                        indicatorShortName = Common.Constants.Indicator_ShortName_MonthRealCustomerType;
                        return ResponseResult<ChartModel>.GenFaildResponse("功能待开发....");
                    case ChartBiz.Custo_From_Analy:
                        indicatorShortName = Common.Constants.Indicator_ShortName_MonthCustomerAddress;
                        break;
                    case ChartBiz.Logistics_Segment_Time_Analy:
                        seriesContainsName = true;
                        indicatorShortName = Common.Constants.Indicator_ShortName_MonthLinksCost;
                        break;
                    case ChartBiz.Logistics_SpendTime:
                        indicatorShortName = Common.Constants.Indicator_ShortName_MonthLogistics;
                        break;
                    case ChartBiz.ComplainForYear:
                        indicatorShortName = Common.Constants.Indicator_ShortName_MonthComplainNum;
                        return ResponseResult<ChartModel>.GenFaildResponse("功能待开发....");
                    case ChartBiz.Complain_Type:
                        indicatorShortName = Common.Constants.Indicator_ShortName_MonthComplainType;
                        return ResponseResult<ChartModel>.GenFaildResponse("功能待开发....");
                    default:
                        break;
                }
                if (userId > 0 && !string.IsNullOrEmpty(indicatorShortName))
                {
                    var resultData = service.QueryLastRecord(userId, indicatorShortName);
                    if (resultData != null && resultData.Any())
                    {
                        foreach (var item in resultData)
                        {
                            data.XAxis.Add(item.Name);
                            if (seriesContainsName)
                            {
                                data.Series[0].Add(new { name = item.Name, value = item.Value });
                            }
                            else
                            {
                                data.Series[0].Add(item.Value);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ResponseResult<ChartModel>.GenFaildResponse(ex.Message);
            }
            return ResponseResult<ChartModel>.GenSuccessResponse(data);
        }
    }
}