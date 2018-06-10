using EB.ISCS.Common.BaseController;
using EB.ISCS.Common.DataModel;
using EB.ISCS.Common.Models;
using EB.ISCS.Common.ViewModel;
using Maticsoft.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;
using static EB.ISCS.Common.ViewModel.DashBoardIndicatorModel;

namespace EB.ISCS.Admin.Controllers.Biz
{
    public class DashBoardController : BaseController
    {
        /// <summary>
        /// 首页四指标
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult TodayReal()
        {
            var result = new BaseResult<List<IndicatorModel>>()
            {
                Code = (int)ResultCode.Success,
                Data = new List<IndicatorModel>()
                {
                    new IndicatorModel(){ Id=1, Name=PayOrderNum, Value=180, MOM=3.1  },
                      new IndicatorModel(){ Id=1, Name=PayMoney, Value=2120, MOM=2.2  },
                        new IndicatorModel(){ Id=1, Name=VisitorNum, Value=358, MOM=-1.5  },
                          new IndicatorModel(){ Id=1, Name=PayGoodNum, Value=113, MOM=16.8  }
                },
                Message = string.Empty
            };

            var serviceReturn = ServiceHelper.CallService<List<MonitorIndicator>>($"{ServiceConst.BizApi.DashBoardTodayRealMonitorIndicator}/{CurrentUser.UserId}",
               null, this.CurrentUser.Token);

            if (serviceReturn.Code == (int)ResultCode.Success)
            {
                result.Data.Clear();
                serviceReturn.Data.ForEach(t =>
                {
                    result.Data.Add(t);
                });
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetChartData(int type)
        {
            var result = new BaseResult<ChartModel>() {
                 Code =(int)ResultCode.Success
            };
            switch (type)
            {
                case (int)ChartBiz.Map:
                    break;
                case (int)ChartBiz.TopN:
                    break;
                case (int)ChartBiz.BootomN:
                    break;
                case (int)ChartBiz.Sell_ForMonth:
                    break;
                case (int)ChartBiz.Flow_ForMonth:
                    break;
                case (int)ChartBiz.Order_Trans:
                    break;
                case (int)ChartBiz.Pay_Channel:
                    break;
                case (int)ChartBiz.Order_Status_ForMonth:
                    break;
                case (int)ChartBiz.Custom_Analy:
                    break;
                case (int)ChartBiz.Custo_From_Analy:
                    break;
                case (int)ChartBiz.Logistics_Segment_Time_Analy:
                    break;
                case (int)ChartBiz.Logistics_SpendTime:
                    break;
                case (int)ChartBiz.ComplainForYear:
                    break;
                case (int)ChartBiz.Complain_Type:
                    break;
                default:
                    break;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
    }
}