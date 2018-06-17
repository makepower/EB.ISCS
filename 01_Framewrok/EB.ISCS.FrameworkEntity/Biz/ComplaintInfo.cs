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
        /// 主键
        /// </summary>		
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>		
        public int UserId { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>		
        public int StoreId { get; set; }
        /// <summary>
        /// 订单ID
        /// </summary>		
        public int OrderId { get; set; }
        /// <summary>
        /// 物流ID
        /// </summary>		
        public int WaybillId { get; set; }
        /// <summary>
        /// 描述
        /// </summary>		
        public string Description { get; set; }
        /// <summary>
        ///  投诉类型 0"包裹丢失", 1"首次派送延误",2 "外包装破损", 3"包裹缺失", 4"包裹错误", 5"重量不符"
        /// </summary>		
        public int ComplaintType { get; set; }
        /// <summary>
        ///  处理结果 0 未处理  1  处理中  2 已完成 
        /// </summary>		
        public int Status { get; set; }
        /// <summary>
        /// 投诉处理结果
        /// </summary>		
        public string Result { get; set; }
        /// <summary>
        /// 编辑时间
        /// </summary>		
        public DateTime EditDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>		
        public string Remark { get; set; }

    }
}