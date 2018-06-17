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
        /// 主键
        /// </summary>		
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 订单Id
        /// </summary>		
        public int OrderId { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>		
        public string OrderCode { get; set; }
        /// <summary>
        /// 物流公司编号
        /// </summary>		
        public string ShipperCode { get; set; }
        /// <summary>
        /// 物流编号
        /// </summary>		
        public string LogisticCode { get; set; }
        /// <summary>
        /// 物流状态
        /// </summary>		
        public int State { get; set; }
        /// <summary>
        /// 物流成功状态
        /// </summary>		
        public int Success { get; set; }
        /// <summary>
        /// 原因
        /// </summary>		
        public string Reason { get; set; }
        /// <summary>
        /// 发货地址
        /// </summary>		
        public string DeliveryAddress { get; set; }
        /// <summary>
        /// 邮寄地址
        /// </summary>		
        public string MailingAddress { get; set; }
        /// <summary>
        /// 同步时间
        /// </summary>		
        public DateTime SyncDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>		
        public string Remark { get; set; }

    }
}