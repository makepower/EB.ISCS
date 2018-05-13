using Dapper;
using System;

namespace Maticsoft.Model
{
    /// <summary>
    ///运单信息 ：实体类
    /// </summary>	
    [Table("WayBillInfo")]
    public class WayBillInfo
    {

        /// <summary>
        /// Id
        /// </summary>		
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// OrderId
        /// </summary>		
        public int OrderId { get; set; }
        /// <summary>
        /// OrderCode
        /// </summary>		
        public string OrderCode { get; set; }
        /// <summary>
        /// ShipperCode
        /// </summary>		
        public string ShipperCode { get; set; }
        /// <summary>
        /// LogisticCode
        /// </summary>		
        public string LogisticCode { get; set; }
        /// <summary>
        /// State
        /// </summary>		
        public int State { get; set; }
        /// <summary>
        /// Success
        /// </summary>		
        public int Success { get; set; }
        /// <summary>
        /// Reason
        /// </summary>		
        public string Reason { get; set; }
        /// <summary>
        /// DeliveryAddress
        /// </summary>		
        public string DeliveryAddress { get; set; }
        /// <summary>
        /// MailingAddress
        /// </summary>		
        public string MailingAddress { get; set; }
        /// <summary>
        /// SyncDate
        /// </summary>		
        public DateTime SyncDate { get; set; }
        /// <summary>
        /// Remark
        /// </summary>		
        public string Remark { get; set; }

    }
}