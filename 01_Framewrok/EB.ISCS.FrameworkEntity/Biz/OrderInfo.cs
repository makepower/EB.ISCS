using System;
using Dapper;

namespace Maticsoft.Model.ISSC
{
    /// <summary>
    ///订单信息 ：实体类
    /// </summary>	
    [Table("OrderInfo")]
    public class OrderInfo
    {

        /// <summary>
        /// 主键
        /// </summary>		
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 交易ID
        /// </summary>		
        public int TradeId { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>		
        public string ItemMealName { get; set; }
        /// <summary>
        ///  退款状态
        /// </summary>		
        public string RefundStatus { get; set; }
        /// <summary>
        /// 标题
        /// </summary>		
        public string Title { get; set; }
        /// <summary>
        /// 单价
        /// </summary>		
        public decimal Price { get; set; }
        /// <summary>
        /// 数量
        /// </summary>		
        public decimal Num { get; set; }
        /// <summary>
        /// 总费用
        /// </summary>		
        public decimal TotalFee { get; set; }
        /// <summary>
        /// 支付费用
        /// </summary>		
        public decimal Payment { get; set; }
        /// <summary>
        /// 订单ID
        /// </summary>		
        public string Oid { get; set; }
        /// <summary>
        /// 类型
        /// </summary>		
        public string Type { get; set; }
        /// <summary>
        /// 打折费用
        /// </summary>		
        public decimal DiscountFee { get; set; }
        /// <summary>
        /// 修正费用
        /// </summary>		
        public decimal AdjustFee { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>		
        public DateTime Modified { get; set; }
        /// <summary>
        /// 订单属性
        /// </summary>		
        public string OrderAttr { get; set; }
        /// <summary>
        /// 物流类型
        /// </summary>		
        public string ShippingType { get; set; }
        /// <summary>
        /// 绑定的子订单标号
        /// </summary>		
        public string BindOid { get; set; }
        /// <summary>
        /// 快递公司
        /// </summary>		
        public string LogisticsCompany { get; set; }
        /// <summary>
        /// 发票编号 子订单运单号
        /// </summary>		
        public string InvoiceNo { get; set; }
        /// <summary>
        /// 是否代销
        /// </summary>		
        public int IsDaixiao { get; set; }
        /// <summary>
        /// 店铺编号
        /// </summary>		
        public string StoreCode { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>		
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>		
        public string Remark { get; set; }

    }
}