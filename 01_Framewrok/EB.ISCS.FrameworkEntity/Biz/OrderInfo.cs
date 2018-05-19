using Dapper;
using System;

namespace Maticsoft.Model
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
        /// OrderCode
        /// </summary>		
        public string OrderCode { get; set; }
        /// <summary>
        /// OrderDate
        /// </summary>		
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// Status
        /// </summary>		
        public int Status { get; set; }
        /// <summary>
        /// SaleId
        /// </summary>		
        public int SaleId { get; set; }
        /// <summary>
        /// buyerId
        /// </summary>		
        public string BuyerId { get; set; }
        /// <summary>
        /// GoodNum
        /// </summary>		
        public double GoodNum { get; set; }
        /// <summary>
        /// GoodFee
        /// </summary>		
        public decimal GoodFee { get; set; }
        /// <summary>
        /// DeliveryType
        /// </summary>		
        public int DeliveryType { get; set; }
        /// <summary>
        /// EndDate
        /// </summary>		
        public int EndDate { get; set; }
        /// <summary>
        /// Remark
        /// </summary>		
        public string Remark { get; set; }

        /// <summary>
        /// 店铺ID
        /// </summary>
        public int ShipId { get; set; }

    }
}