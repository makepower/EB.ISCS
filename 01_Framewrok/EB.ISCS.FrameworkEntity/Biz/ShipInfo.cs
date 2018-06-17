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
        /// 主键
        /// </summary>		
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>		
        public int UserId { get; set; }
        /// <summary>
        /// 店铺编码
        /// </summary>		
        public string Code { get; set; }
        /// <summary>
        /// 平台id
        /// </summary>		
        public int Plat { get; set; }
        /// <summary>
        /// 名称
        /// </summary>		
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>		
        public string Description { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>		
        public DateTime InDate { get; set; }
        /// <summary>
        /// 店铺初始化状态 0 不可用  1 初始化  2 增量同步 
        /// </summary>		
        public int Status { get; set; }
        /// <summary>
        /// App主键
        /// </summary>		
        public string AppKey { get; set; }
        /// <summary>
        /// App密钥
        /// </summary>		
        public string AppSecret { get; set; }
        /// <summary>
        /// 发货地址
        /// </summary>		
        public string DeliveryAddress { get; set; }
        /// <summary>
        /// 备注
        /// </summary>		
        public string Remark { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>		
        public string Contract { get; set; }

        /// <summary>
        /// 平台名称
        /// </summary>	
        [NotMapped]
        public string PlatName { get; set; }

        /// <summary>
        /// Session主键
        /// </summary>	
        [NotMapped]
        public string SessionKey { get; set; }

        /// <summary>
        /// 用户key卖家id
        /// </summary>
        [NotMapped]
        public string UserCode { get; set; }


    }
}