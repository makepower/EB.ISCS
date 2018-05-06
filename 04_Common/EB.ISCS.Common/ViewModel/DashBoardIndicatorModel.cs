namespace EB.ISCS.Common.ViewModel
{
    public class DashBoardIndicatorModel
    {
        #region 今日实时  运营指标

        /// <summary>
        /// 
        /// </summary>
        public const string PayOrderNum = "PayOrderNum";
        /// <summary>
        /// 
        /// </summary>
        public const string PayMoney = "PayOrderNum";
        /// <summary>
        /// 
        /// </summary>
        public const string PayGoodNum = "PayGoodNum";
        /// <summary>
        /// 
        /// </summary>
        public const string VisitorNum = "VisitorNum";
        /// <summary>
        /// 
        /// </summary>
        public const string SalesAmount = "SalesAmount";
        /// <summary>
        /// 
        /// </summary>
        public const string PV = "PV";
        /// <summary>
        /// 
        /// </summary>
        public const string UV = "UV";
        public static readonly string[] DailyMonitor = new string[] { PayOrderNum, PayMoney, PayGoodNum, VisitorNum };

        #endregion

        #region TopN

        /// <summary>
        /// 畅销
        /// </summary>
        public const string SellWell = "SellWell";
        /// <summary>
        /// 滞销
        /// </summary>
        public const string OverStorage = "SellWell";
        /// <summary>
        /// 转化率
        /// </summary>
        public const string ConversionRate = "ConversionRate";
        /// <summary>
        /// 付款渠道
        /// </summary>
        public const string PaymentChannel = "PaymentChannel";

        /// <summary>
        /// 订单状态
        /// </summary>
        public const string OrderStatus = "OrderStatus";


        /// <summary>
        /// 客户类型
        /// </summary>
        public const string CustomerType = "CustomerType";

        /// <summary>
        /// 客户地址
        /// </summary>
        public const string CustomerAddress = "CustomerAddress";

        /// <summary>
        /// 环节消费时间
        /// </summary>
        public const string LinksCost = "LinksCost";

        /// <summary>
        /// 物流消费时间
        /// </summary>
        public const string Logistics = "Logistics";
        #endregion

    }
}
