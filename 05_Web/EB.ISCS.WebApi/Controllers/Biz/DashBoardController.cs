using EB.ISCS.Common.DataModel;
using EB.ISCS.Common.Enum;
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
        public ResponseResult<List<MonitorIndicatorRecord>> GetMonitorStstisForThirtyDays(int id)
        {
            try
            {
                ResultCode code = ResultCode.Success;
                var shipService = GetService<ShipInfoService>();
                var shipInfos = shipService.GetShipsByUserId(id);
                var ids = shipInfos.First(x => x.Plat == (int)ApiPlatform.Local).Id.ToString();
                var monitorService = GetService<MonitorIndicatorRecordService>();
                var listResult = monitorService.GetMonitorStstisForThirtyDays(ids);
                if (listResult == null)
                {
                    code = ResultCode.Faild;
                    return ResponseResult<List<MonitorIndicatorRecord>>.GenFaildResponse(code);
                }

                return ResponseResult<List<MonitorIndicatorRecord>>.GenSuccessResponse(listResult);
            }
            catch (Exception ex)
            {
                return ResponseResult<List<MonitorIndicatorRecord>>.GenFaildResponse(ex.Message);
            }

        }

        /// <summary>
        /// 获取图标插件数据
        /// </summary>
        /// <param name="id">业务类型</param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<ChartModel> GetDashBoardChartViewData(int id, int userId)
        {
            var data = new ChartModel();
            try
            {
                var biz = EnumHelper.GetEnumByValue<ChartBiz>(id);
                if (biz == ChartBiz.Complain_Type)
                {
                    return ResponseResult<ChartModel>.GenFaildResponse("功能待开发....");
                }
                else if (biz == ChartBiz.ComplainForYear)
                {
                    return ResponseResult<ChartModel>.GenFaildResponse("功能待开发....");
                }
                else if (biz == ChartBiz.Logistics_SpendTime)
                {
                    data.XAxis = new List<dynamic>() { "顺丰", "圆通", "申通", "韵达", "蜂鸟" };
                    data.Series = new List<dynamic>[1] {  new List<dynamic>() { 20, 45, 35, 19, 30 }
                };
                }
                else if (biz == ChartBiz.Logistics_Segment_Time_Analy)
                {
                    data.XAxis = new List<dynamic>() { "浏览", "下单", "出货", "物流" };
                    data.Series = new List<dynamic>[1] {  new List<dynamic>() {  new { name = "浏览", value = 15 },
                         new { name = "下单", value = 5 },
                         new { name = "出货", value =20 },
                         new { name = "物流", value =50 } } };
                }
                else if (biz == ChartBiz.Custo_From_Analy)
                {
                    data.XAxis = new List<dynamic>() { "北京", "天津", "上海", "重庆", "河北", "河南", "云南" };
                    data.Series = new List<dynamic>[1] { new List<dynamic>() { 15, 5, 20, 50, 15, 8, 10 } };
                }
                else if (biz == ChartBiz.Custom_Analy)
                {
                    return ResponseResult<ChartModel>.GenFaildResponse("功能待开发....");
                }
                else if (biz == ChartBiz.Order_Status_ForMonth)
                {
                    data.XAxis = new List<dynamic>() { "未付款", "暂停", "等待出库", "已出库", "买家已收货", "已取消", "换货订单", "锁定订单", "异常订单", "退款中" };
                    data.Series = new List<dynamic>[1] { new List<dynamic>() { 85, 15, 8, 5, 8, 13, 45, 25, 36, 10 } };
                }
                else if (biz == ChartBiz.Pay_Channel)
                {
                    data.XAxis = new List<dynamic>() { "微信", "支付宝", "银行卡", "货到付款" };
                    data.Series = new List<dynamic>[1] { new List<dynamic>() { 185, 125, 58, 5, 28 } };
                }
                else if (biz == ChartBiz.Order_Trans)
                {
                    return ResponseResult<ChartModel>.GenFaildResponse("功能待开发....");
                }
                else if (biz == ChartBiz.Flow_ForMonth)
                {
                    return ResponseResult<ChartModel>.GenFaildResponse("功能待开发....");
                }
                else if (biz == ChartBiz.Sell_ForMonth)
                {
                    data.XAxis = new List<dynamic>() { "1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月" };
                    data.Series = new List<dynamic>[1] { new List<dynamic>() { 118, 72, 205, 112, 304, 156, 238, 219, 110, 69, 84, 112 } };
                }
                else if (biz == ChartBiz.TopN)
                {
                    data.XAxis = new List<dynamic>() { "衬衫", "羊毛衫", "雪纺衫", "裤子", "高跟鞋" };
                    data.Series = new List<dynamic>[1] { new List<dynamic>() { 185, 160, 126, 80, 60, 45 } };
                }
                else if (biz == ChartBiz.BootomN)
                {
                    data.XAxis = new List<dynamic>() { "花瓶", "榻榻米", "风扇", "毛巾", "粽子" };
                    data.Series = new List<dynamic>[1] { new List<dynamic>() { 1, 5, 12, 18, 21, 25 } };
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