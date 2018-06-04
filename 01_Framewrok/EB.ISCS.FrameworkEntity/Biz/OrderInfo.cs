using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
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
        /// Id
        /// </summary>		
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// trade_id
        /// </summary>		
        public int TradeId { get; set; }
        /// <summary>
        /// item_meal_name
        /// </summary>		
        public string item_meal_name { get; set; }
        /// <summary>
        /// seller_nick
        /// </summary>		
        public string seller_nick { get; set; }
        /// <summary>
        /// buyer_nick
        /// </summary>		
        public string buyer_nick { get; set; }
        /// <summary>
        /// refund_status
        /// </summary>		
        public string refund_status { get; set; }
        /// <summary>
        /// title
        /// </summary>		
        public string title { get; set; }
        /// <summary>
        /// price
        /// </summary>		
        public decimal price { get; set; }
        /// <summary>
        /// num
        /// </summary>		
        public decimal num { get; set; }
        /// <summary>
        /// total_fee
        /// </summary>		
        public decimal total_fee { get; set; }
        /// <summary>
        /// payment
        /// </summary>		
        public decimal payment { get; set; }
        /// <summary>
        /// oid
        /// </summary>		
        public string oid { get; set; }
        /// <summary>
        /// type
        /// </summary>		
        public string type { get; set; }
        /// <summary>
        /// discount_fee
        /// </summary>		
        public decimal discount_fee { get; set; }
        /// <summary>
        /// adjust_fee
        /// </summary>		
        public decimal adjust_fee { get; set; }
        /// <summary>
        /// modified
        /// </summary>		
        public DateTime modified { get; set; }
        /// <summary>
        /// order_attr
        /// </summary>		
        public string order_attr { get; set; }
        /// <summary>
        /// shipping_type
        /// </summary>		
        public string shipping_type { get; set; }
        /// <summary>
        /// bind_oid
        /// </summary>		
        public string bind_oid { get; set; }
        /// <summary>
        /// logistics_company
        /// </summary>		
        public string logistics_company { get; set; }
        /// <summary>
        /// invoice_no
        /// </summary>		
        public string invoice_no { get; set; }
        /// <summary>
        /// is_daixiao
        /// </summary>		
        public int is_daixiao { get; set; }
        /// <summary>
        /// store_code
        /// </summary>		
        public string store_code { get; set; }
        /// <summary>
        /// end_time
        /// </summary>		
        public DateTime end_time { get; set; }
        /// <summary>
        /// remark
        /// </summary>		
        public string remark { get; set; }

    }
}