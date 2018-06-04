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
        public int Id { get; set; }
        /// <summary>
        /// user_id
        /// </summary>		
        public int UserId { get; set; }
        /// <summary>
        /// ship_id
        /// </summary>		
        public int ShipId { get; set; }
        /// <summary>
        /// seller_nick
        /// </summary>		
        public string SellerNick { get; set; }
        /// <summary>
        /// payment
        /// </summary>		
        public decimal Payment { get; set; }
        /// <summary>
        /// seller_rate
        /// </summary>		
        public int SellerRate { get; set; }
        /// <summary>
        /// post_fee
        /// </summary>		
        public decimal PostFee { get; set; }
        /// <summary>
        /// receiver_name
        /// </summary>		
        public string ReceiverName { get; set; }
        /// <summary>
        /// receiver_state
        /// </summary>		
        public string ReceiverState { get; set; }
        /// <summary>
        /// receiver_address
        /// </summary>		
        public string ReceiverAddress { get; set; }
        /// <summary>
        /// receiver_zip
        /// </summary>		
        public string ReceiverZip { get; set; }
        /// <summary>
        /// receiver_mobile
        /// </summary>		
        public string ReceiverMobile { get; set; }
        /// <summary>
        /// receiver_phone
        /// </summary>		
        public string ReceiverPhone { get; set; }
        /// <summary>
        /// consign_time
        /// </summary>		
        public string ConsignTime { get; set; }
        /// <summary>
        /// received_payment
        /// </summary>		
        public decimal ReceivedPayment { get; set; }
        /// <summary>
        /// receiver_country
        /// </summary>		
        public string ReceiverCountry { get; set; }
        /// <summary>
        /// receiver_town
        /// </summary>		
        public string ReceiverTown { get; set; }
        /// <summary>
        /// order_tax_fee
        /// </summary>		
        public decimal OrderTaxFee { get; set; }
        /// <summary>
        /// shop_pick
        /// </summary>		
        public int ShopPick { get; set; }
        /// <summary>
        /// tid
        /// </summary>		
        public int Tid { get; set; }
        /// <summary>
        /// num
        /// </summary>		
        public decimal Num { get; set; }
        /// <summary>
        /// num_iid
        /// </summary>		
        public decimal NumIid { get; set; }
        /// <summary>
        /// status
        /// </summary>		
        public string Status { get; set; }
        /// <summary>
        /// title
        /// </summary>		
        public string Title { get; set; }
        /// <summary>
        /// type
        /// </summary>		
        public string Type { get; set; }
        /// <summary>
        /// price
        /// </summary>		
        public decimal Price { get; set; }
        /// <summary>
        /// discount_fee
        /// </summary>		
        public decimal DiscountFee { get; set; }
        /// <summary>
        /// total_fee
        /// </summary>		
        public decimal TotalFee { get; set; }
        /// <summary>
        /// created
        /// </summary>		
        public string Created { get; set; }
        /// <summary>
        /// pay_time
        /// </summary>		
        public string PayTime { get; set; }
        /// <summary>
        /// modified
        /// </summary>		
        public string Modified { get; set; }
        /// <summary>
        /// end_time
        /// </summary>		
        public string EndTime { get; set; }
        /// <summary>
        /// buyer_nick
        /// </summary>		
        public string BuyerNick { get; set; }
        /// <summary>
        /// has_buyer_message
        /// </summary>		
        public int HasBuyerMessage { get; set; }
        /// <summary>
        /// credit_card_fee
        /// </summary>		
        public decimal CreditCardFee { get; set; }
        /// <summary>
        /// step_trade_status
        /// </summary>		
        public string StepTradeStatus { get; set; }
        /// <summary>
        /// step_paid_fee
        /// </summary>		
        public string StepPaidFee { get; set; }
        /// <summary>
        /// mark_desc
        /// </summary>		
        public string MarkDesc { get; set; }
        /// <summary>
        /// shipping_type
        /// </summary>		
        public string ShippingType { get; set; }
        /// <summary>
        /// adjust_fee
        /// </summary>		
        public string AdjustFee { get; set; }
        /// <summary>
        /// trade_from
        /// </summary>		
        public string TradeFrom { get; set; }

    }
}