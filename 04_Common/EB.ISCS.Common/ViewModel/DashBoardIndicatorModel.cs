using EB.ISCS.Common.DataModel;
using System;
using System.ComponentModel;

namespace EB.ISCS.Common.ViewModel
{
    public class DashBoardIndicatorModel
    {
        #region 今日实时  运营指标


        public static readonly string[] DailyMonitor = new string[] {

           Constants.Indicator_ShortName_RealPayOrderNum,
           Constants.Indicator_ShortName_RealPayMoney,
           Constants.Indicator_ShortName_RealPayGoodNum,
          Constants.Indicator_ShortName_RealVisitorNum };

        #endregion

        #region 模型

        /// <summary>
        /// 指标单值模型
        /// </summary>
        public class IndicatorSingleModel
        {
            /// <summary>
            /// id
            /// </summary>
            public int Id { get; set; }
            /// <summary>
            /// 名称
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// 值
            /// </summary>
            public double Value { get; set; }

            private double mom;
            /// <summary>
            /// 环比
            /// </summary>
            public double MOM { get { return Math.Abs(mom); } set { mom = value; } }

            /// <summary>
            /// 增幅
            /// </summary>
            public string TagIco
            {
                get
                {
                    return mom > 0 ? "glyphicon-arrow-up" : "glyphicon-arrow-down";
                }
            }


            /// <summary>
            /// 指标单值模型缺省转换
            /// </summary>
            public static implicit operator IndicatorSingleModel(IndicatorRecordViewModel indicator)
            {
                var m = new IndicatorSingleModel()
                {
                    Id = indicator.Define?.Id ?? 0,
                    Name = indicator.Define?.Name
                };
                if (indicator.Records != null || indicator.Records.Length > 0)
                {
                    m.Value = (double)indicator.Records[0].Value;
                    m.MOM = (double)indicator.Records[0].MoM;
                }
                return m;
            }
        }
        #endregion

    }

    #region 业务枚举

    /// <summary>
    /// 图标业务
    /// </summary>
    public enum ChartBiz
    {
        /// <summary>
        /// 地图
        /// </summary>
        [Description("地图")]
        Map,
        /// <summary>
        /// 销量TopN
        /// </summary>
        [Description("销量TopN")]
        TopN,
        /// <summary>
        /// 滞销TopN
        /// </summary>
        [Description("滞销TopN")]
        BootomN,
        /// <summary>
        /// 最近30天销售金额
        /// </summary>
        [Description("最近30天销售金额")]
        Sell_ForMonth,
        /// <summary>
        /// 最近30天流量
        /// </summary>
        [Description("最近30天流量")]
        Flow_ForMonth,
        /// <summary>
        /// 订单转化率
        /// </summary>
        [Description("订单转化率")]
        Order_Trans,
        /// <summary>
        /// 付款渠道
        /// </summary>
        [Description("付款渠道")]
        Pay_Channel,
        /// <summary>
        /// 订单状态
        /// </summary>
        [Description("订单状态")]
        Order_Status_ForMonth,
        /// <summary>
        /// 客户分析
        /// </summary>
        [Description("客户分析")]
        Custom_Analy,
        /// <summary>
        /// 客户地址分析
        /// </summary>
        [Description("客户地址分析")]
        Custo_From_Analy,
        /// <summary>
        /// 物流花费时间
        /// </summary>
        [Description("物流花费时间")]
        Logistics_Segment_Time_Analy,
        /// <summary>
        /// 物流排行
        /// </summary>
        [Description("物流排行")]
        Logistics_SpendTime,
        /// <summary>
        /// 月投诉
        /// </summary>
        [Description("月投诉")]
        ComplainForYear,
        /// <summary>
        /// 投诉类型
        /// </summary>
        [Description("投诉类型")]
        Complain_Type
    }
    #endregion
}
