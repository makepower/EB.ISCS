using Dapper;
using System;

namespace Maticsoft.Model
{
    /// <summary>
    ///投诉信息表 ：实体类
    /// </summary>	
    [Table("ComplaintInfo")]
    public class ComplaintInfo
    {

        /// <summary>
        /// Id
        /// </summary>		
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// UserId
        /// </summary>		
        public int UserId { get; set; }
        /// <summary>
        /// StoreId
        /// </summary>		
        public int StoreId { get; set; }
        /// <summary>
        /// OrderId
        /// </summary>		
        public int OrderId { get; set; }
        /// <summary>
        /// WaybillId
        /// </summary>		
        public int WaybillId { get; set; }
        /// <summary>
        /// Description
        /// </summary>		
        public string Description { get; set; }
        /// <summary>
        /// 0 网上 2 电话  3 线下
        /// </summary>		
        public int ComplaintType { get; set; }
        /// <summary>
        /// 0 未处理   1  处理中  2 已完成 
        /// </summary>		
        public int Status { get; set; }
        /// <summary>
        /// Result
        /// </summary>		
        public string Result { get; set; }
        /// <summary>
        /// EditDate
        /// </summary>		
        public DateTime EditDate { get; set; }
        /// <summary>
        /// Remark
        /// </summary>		
        public string Remark { get; set; }

    }
}