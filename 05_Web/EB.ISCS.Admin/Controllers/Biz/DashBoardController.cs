using EB.ISCS.Common.BaseController;
using EB.ISCS.Common.DataModel;
using EB.ISCS.Common.Models;
using EB.ISCS.Common.ViewModel;
using EB.ISCS.FrameworkHelp.Utilities;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using static EB.ISCS.Common.ViewModel.DashBoardIndicatorModel;

namespace EB.ISCS.Admin.Controllers.Biz
{
    public class DashBoardController : BaseController
    {
        /// <summary>
        /// 首页四指标 天
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult TodayReal()
        {
            var result = new BaseResult<List<IndicatorSingleModel>>()
            {
                Code = (int)ResultCode.Success,
                Data = new List<IndicatorSingleModel>() { },
                Message = "暂无相关数据"
            };

            var serviceReturn = ServiceHelper.CallService<List<IndicatorSingleModel>>($"{ServiceConst.BizApi.DashBoardTodayRealMonitorIndicator}/{CurrentUser.UserId}",
               null, this.CurrentUser.Token);

            if (serviceReturn.Code == (int)ResultCode.Success)
            {
                result.Data = serviceReturn.Data;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 图表数据
        /// </summary>
        /// <param name="id">枚举</param>
        /// <returns></returns>
        public JsonResult GetChartData(int id)
        {
            var result = new BaseResult<ChartModel>()
            {
                Code = (int)ResultCode.Success
            };
            var biz = EnumHelper.GetEnumByValue<ChartBiz>(id);
            result.Data = QueryChartSourceData(biz);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #region private method
        /// <summary>
        /// 获取Demo数据源
        /// </summary>
        /// <param name="biz"></param>
        /// <returns></returns>
        private ChartModel QueryChartSourceData(ChartBiz biz)
        {
            var model = GetServerSourceData(biz);
            if (model == null && System.Configuration.ConfigurationManager.AppSettings["DashBoard_ShowDemoIfMissing"].ToLower().Equals(bool.TrueString))
                model = GetDemoSourceData(biz);
            return model;
        }

        /// <summary>
        /// 获取Demo数据源
        /// </summary>
        /// <param name="biz"></param>
        /// <returns></returns>
        private ChartModel GetServerSourceData(ChartBiz biz)
        {
            var serviceReturn = ServiceHelper.CallService<ChartModel>($"{ServiceConst.BizApi.DashBoardGetDashBoardChartViewData}?id={(int)biz}&userId={CurrentUser.UserId}",null, this.CurrentUser.Token);
            if (serviceReturn.Code == (int)ResultCode.Success)
                return serviceReturn.Data;
            else
                return null;
        }

        /// <summary>
        /// 获取Demo数据源
        /// </summary>
        /// <param name="biz"></param>
        /// <returns></returns>
        private ChartModel GetDemoSourceData(ChartBiz biz)
        {
            var data = new Tuple<List<dynamic>, List<dynamic>>(item1: new List<dynamic>(), item2: new List<dynamic>());
            if (biz == ChartBiz.Complain_Type)
            {
                data = new Tuple<List<dynamic>, List<dynamic>>(
                    item1: new List<dynamic>() { "包裹丢失", "首次派送延误", "外包装破损", "包裹缺失", "包裹错误", "重量不符" },
                    item2: new List<dynamic>() { 12, 45, 5, 9, 30, 15 }
                );
            }
            else if (biz == ChartBiz.ComplainForYear)
            {
                data = new Tuple<List<dynamic>, List<dynamic>>(
                     item1: new List<dynamic>() { "1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月" },
                     item2: new List<dynamic>() { 12, 45, 5, 9, 30, 15, 24, 13, 34, 7, 18, 26 }
                );
            }
            else if (biz == ChartBiz.Logistics_SpendTime)
            {
                data = new Tuple<List<dynamic>, List<dynamic>>(
                     item1: new List<dynamic>() { "顺丰", "圆通", "申通", "韵达", "蜂鸟" },
                     item2: new List<dynamic>() { 20, 45, 35, 19, 30 }
                );
            }
            else if (biz == ChartBiz.Logistics_Segment_Time_Analy)
            {
                data = new Tuple<List<dynamic>, List<dynamic>>(
                     item1: new List<dynamic>() { "浏览", "下单", "出货", "物流" },
                     item2: new List<dynamic>() { new { name = "浏览", value = 15 },
                         new { name = "下单", value = 5 },
                         new { name = "出货", value =20 },
                         new { name = "物流", value =50 } }
                );
            }
            else if (biz == ChartBiz.Custo_From_Analy)
            {
                data = new Tuple<List<dynamic>, List<dynamic>>(
                     item1: new List<dynamic>() { "北京", "天津", "上海", "重庆", "河北", "河南", "云南" },
                     item2: new List<dynamic>() { 15, 5, 20, 50, 15, 8, 10 }
                );
            }
            else if (biz == ChartBiz.Custom_Analy)
            {
                data = new Tuple<List<dynamic>, List<dynamic>>(
                     item1: new List<dynamic>() { "普通客户", "大客户", "VIP" },
                     item2: new List<dynamic>() { new { name = "普通客户", value = 85 },
                         new { name = "大客户", value =15 },
                         new { name = "VIP", value = 8 } }
                );
            }
            else if (biz == ChartBiz.Order_Status_ForMonth)
            {
                data = new Tuple<List<dynamic>, List<dynamic>>(
                     item1: new List<dynamic>() { "未付款", "暂停", "等待出库", "已出库", "买家已收货", "已取消", "换货订单", "锁定订单", "异常订单", "退款中" },
                     item2: new List<dynamic>() { 85, 15, 8, 5, 8, 13, 45, 25, 36, 10 }
                );
            }
            else if (biz == ChartBiz.Pay_Channel)
            {
                data = new Tuple<List<dynamic>, List<dynamic>>(
                     item1: new List<dynamic>() { "微信", "支付宝", "银行卡", "货到付款" },
                     item2: new List<dynamic>() { 185, 125, 58, 5, 28 }
                );
            }
            else if (biz == ChartBiz.Order_Trans)
            {
                data = new Tuple<List<dynamic>, List<dynamic>>(
                     item1: new List<dynamic>() { "线上转换", "线下转换", "流量转换" },
                     item2: new List<dynamic>() { new { name = "线上转换", value = 18 },
                         new { name = "线下转换", value = 12 },
                         new { name = "流量转换", value = 25 } }
                );
            }
            else if (biz == ChartBiz.Flow_ForMonth)
            {
                data = new Tuple<List<dynamic>, List<dynamic>>(
                     item1: new List<dynamic>() { "1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月" },
                     item2: new List<dynamic>() { 18, 12, 25, 12, 34, 56, 38, 29, 10, 9, 4, 12 }
                );
            }
            else if (biz == ChartBiz.Sell_ForMonth)
            {
                data = new Tuple<List<dynamic>, List<dynamic>>(
                     item1: new List<dynamic>() { "1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月" },
                     item2: new List<dynamic>() { 118, 72, 205, 112, 304, 156, 238, 219, 110, 69, 84, 112 }
                );
            }
            else if (biz == ChartBiz.TopN)
            {
                data = new Tuple<List<dynamic>, List<dynamic>>(
                     item1: new List<dynamic>() { "衬衫", "羊毛衫", "雪纺衫", "裤子", "高跟鞋" },
                     item2: new List<dynamic>() { 185, 160, 126, 80, 60, 45 }
                );
            }
            else if (biz == ChartBiz.BootomN)
            {
                data = new Tuple<List<dynamic>, List<dynamic>>(
                     item1: new List<dynamic>() { "花瓶", "榻榻米", "风扇", "毛巾", "粽子" },
                     item2: new List<dynamic>() { 1, 5, 12, 18, 21, 25 }
                );
            }
            else if (biz == ChartBiz.Map)
            {
                var random = new Random();
                var proviceList = new string[] { "北京", "天津", "上海", "重庆", "河北", "河南", "云南",
            "辽宁","黑龙江","湖南","安徽","山东","新疆","江苏","浙江","江西","湖北","广西",
            "甘肃","山西","内蒙古","陕西","吉林","福建","贵州","广东","青海",
            "西藏","四川","宁夏","海南","台湾","香港","澳门"};
                var charData = new ChartModel()
                {
                    Series = new List<dynamic>[] { new List<dynamic>() },
                    XAxis = new List<dynamic>()
                };
                charData.XAxis.AddRange(proviceList);
                foreach (var item in proviceList)
                {
                    charData.Series[0].Add(new { name = item, value = (int)(random.NextDouble() * 1000) });
                }
                return charData;
            }
            return new ChartModel() { Tag = "-Demo", XAxis = data.Item1, Series = new List<dynamic>[1] { data.Item2 } };
        }

        #endregion
    }
}