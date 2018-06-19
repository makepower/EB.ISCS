using Dapper;

namespace Maticsoft.Model.ISSC
{
    /// <summary>
    ///交易信息 ：实体类
    /// </summary>	
    [Table("Trades")]
    public class Trades
    {
        /// <summary>
        /// 主键
        /// </summary>		
        public int Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>		
        public int UserId { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>		
        public int ShipId { get; set; }
        /// <summary>
        /// 卖家id  (阿里旺旺,京东卖家)
        /// </summary>		
        public string SellerId { get; set; }
        /// <summary>
        /// 买家Id
        /// </summary>		
        public string BuyerId { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>		
        public decimal Payment { get; set; }
        /// <summary>
        /// 卖家折扣
        /// </summary>		
        public int SellerRate { get; set; }
        /// <summary>
        /// 邮费
        /// </summary>		
        public decimal PostFee { get; set; }
        /// <summary>
        /// 交付时间
        /// </summary>		
        public string ConsignTime { get; set; }
        /// <summary>
        /// 已收货款
        /// </summary>		
        public decimal ReceivedPayment { get; set; }
        /// <summary>
        /// 订单税费
        /// </summary>		
        public decimal OrderTaxFee { get; set; }
        /// <summary>
        /// 店铺折扣
        /// </summary>		
        public int ShopPick { get; set; }
        /// <summary>
        /// 交易Id
        /// </summary>		
        public int Tid { get; set; }
        /// <summary>
        /// 交易数量
        /// </summary>		
        public decimal Num { get; set; }
        /// <summary>
        /// 交易数字编号
        /// </summary>		
        public decimal NumIid { get; set; }
        /// <summary>
        /// 状态
        /// </summary>		
        public string Status { get; set; }
        /// <summary>
        /// 标题
        /// </summary>		
        public string Title { get; set; }
        /// <summary>
        /// 类型
        /// </summary>		
        public string Type { get; set; }
        /// <summary>
        /// 单价
        /// </summary>		
        public decimal Price { get; set; }
        /// <summary>
        /// 折扣
        /// </summary>		
        public decimal DiscountFee { get; set; }
        /// <summary>
        /// 总费用
        /// </summary>		
        public decimal TotalFee { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>		
        public string Created { get; set; }
        /// <summary>
        /// 支付时间
        /// </summary>		
        public string PayTime { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>		
        public string Modified { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>		
        public string EndTime { get; set; }
   
        /// <summary>
        /// 是否有买家留言信息
        /// </summary>		
        public int HasBuyerMessage { get; set; }
        /// <summary>
        /// 信用卡
        /// </summary>		
        public decimal CreditCardFee { get; set; }
        /// <summary>
        /// 分期支付状态
        /// </summary>		
        public string StepTradeStatus { get; set; }
        /// <summary>
        /// 分期支付费用
        /// </summary>		
        public string StepPaidFee { get; set; }
        /// <summary>
        /// 标记
        /// </summary>		
        public string MarkDesc { get; set; }
        /// <summary>
        /// 物流类型
        /// </summary>		
        public string ShippingType { get; set; }
        /// <summary>
        /// 调整费用
        /// </summary>		
        public string AdjustFee { get; set; }
        /// <summary>
        /// 交易来源
        /// </summary>		
        public string TradeFrom { get; set; }

    }
}