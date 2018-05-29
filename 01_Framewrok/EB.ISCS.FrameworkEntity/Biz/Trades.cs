using Dapper;
using System;

namespace Maticsoft.Model.ISSC
{
    /// <summary>
    ///交易信息 ：实体类
    /// </summary>	
    [Table("Trades")]
    public class Trades
    {

        /// <summary>
        /// id
        /// </summary>		
        public int id { get; set; }
        /// <summary>
        /// user_id
        /// </summary>		
        public int user_id { get; set; }
        /// <summary>
        /// ship_id
        /// </summary>		
        public int ship_id { get; set; }
        /// <summary>
        /// seller_nick
        /// </summary>		
        public string seller_nick { get; set; }
        /// <summary>
        /// payment
        /// </summary>		
        public decimal payment { get; set; }
        /// <summary>
        /// seller_rate
        /// </summary>		
        public int seller_rate { get; set; }
        /// <summary>
        /// post_fee
        /// </summary>		
        public decimal post_fee { get; set; }
        /// <summary>
        /// receiver_name
        /// </summary>		
        public string receiver_name { get; set; }
        /// <summary>
        /// receiver_state
        /// </summary>		
        public string receiver_state { get; set; }
        /// <summary>
        /// receiver_address
        /// </summary>		
        public string receiver_address { get; set; }
        /// <summary>
        /// receiver_zip
        /// </summary>		
        public string receiver_zip { get; set; }
        /// <summary>
        /// receiver_mobile
        /// </summary>		
        public string receiver_mobile { get; set; }
        /// <summary>
        /// receiver_phone
        /// </summary>		
        public string receiver_phone { get; set; }
        /// <summary>
        /// consign_time
        /// </summary>		
        public DateTime consign_time { get; set; }
        /// <summary>
        /// received_payment
        /// </summary>		
        public decimal received_payment { get; set; }
        /// <summary>
        /// receiver_country
        /// </summary>		
        public string receiver_country { get; set; }
        /// <summary>
        /// receiver_town
        /// </summary>		
        public string receiver_town { get; set; }
        /// <summary>
        /// order_tax_fee
        /// </summary>		
        public decimal order_tax_fee { get; set; }
        /// <summary>
        /// shop_pick
        /// </summary>		
        public int shop_pick { get; set; }
        /// <summary>
        /// tid
        /// </summary>		
        public int tid { get; set; }
        /// <summary>
        /// num
        /// </summary>		
        public decimal num { get; set; }
        /// <summary>
        /// num_iid
        /// </summary>		
        public decimal num_iid { get; set; }
        /// <summary>
        /// status
        /// </summary>		
        public string status { get; set; }
        /// <summary>
        /// title
        /// </summary>		
        public string title { get; set; }
        /// <summary>
        /// type
        /// </summary>		
        public string type { get; set; }
        /// <summary>
        /// price
        /// </summary>		
        public decimal price { get; set; }
        /// <summary>
        /// discount_fee
        /// </summary>		
        public decimal discount_fee { get; set; }
        /// <summary>
        /// total_fee
        /// </summary>		
        public decimal total_fee { get; set; }
        /// <summary>
        /// created
        /// </summary>		
        public DateTime created { get; set; }
        /// <summary>
        /// pay_time
        /// </summary>		
        public DateTime pay_time { get; set; }
        /// <summary>
        /// modified
        /// </summary>		
        public DateTime modified { get; set; }
        /// <summary>
        /// end_time
        /// </summary>		
        public DateTime end_time { get; set; }
        /// <summary>
        /// buyer_nick
        /// </summary>		
        public string buyer_nick { get; set; }
        /// <summary>
        /// has_buyer_message
        /// </summary>		
        public int has_buyer_message { get; set; }
        /// <summary>
        /// credit_card_fee
        /// </summary>		
        public decimal credit_card_fee { get; set; }
        /// <summary>
        /// step_trade_status
        /// </summary>		
        public string step_trade_status { get; set; }
        /// <summary>
        /// step_paid_fee
        /// </summary>		
        public string step_paid_fee { get; set; }
        /// <summary>
        /// mark_desc
        /// </summary>		
        public string mark_desc { get; set; }
        /// <summary>
        /// shipping_type
        /// </summary>		
        public string shipping_type { get; set; }
        /// <summary>
        /// adjust_fee
        /// </summary>		
        public string adjust_fee { get; set; }
        /// <summary>
        /// trade_from
        /// </summary>		
        public string trade_from { get; set; }

    }
}