using Dapper;
using System;

namespace Maticsoft.Model
{
    /// <summary>
    ///店铺信息 ：实体类
    /// </summary>	
    [Table("ShipInfo")]
    public class ShipInfo
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
        /// Code
        /// </summary>		
        public string Code { get; set; }
        /// <summary>
        /// Plat
        /// </summary>		
        public int Plat { get; set; }
        /// <summary>
        /// Name
        /// </summary>		
        public string Name { get; set; }
        /// <summary>
        /// Description
        /// </summary>		
        public string Description { get; set; }
        /// <summary>
        /// InDate
        /// </summary>		
        public DateTime InDate { get; set; }
        /// <summary>
        /// Status 0 不可用  1 可用  2 初始化 
        /// </summary>		
        public int Status { get; set; }
        /// <summary>
        /// AppKey
        /// </summary>		
        public string AppKey { get; set; }
        /// <summary>
        /// AppSecret
        /// </summary>		
        public string AppSecret { get; set; }
        /// <summary>
        /// DeliveryAddress
        /// </summary>		
        public string DeliveryAddress { get; set; }
        /// <summary>
        /// Remark
        /// </summary>		
        public string Remark { get; set; }
        /// <summary>
        /// Contract
        /// </summary>		
        public string Contract { get; set; }

        /// <summary>
        /// PlatName
        /// </summary>	
        [NotMapped]
        public string PlatName { get; set; }

        /// <summary>
        /// SessionKey
        /// </summary>	
        [NotMapped]
        public string SessionKey { get; set; }

    }
}