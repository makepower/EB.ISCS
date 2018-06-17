using Dapper;

namespace Maticsoft.Model
{
    /// <summary>
    ///商品信息 ：实体类
    /// </summary>	
    [Table("GoodInfo")]
    public class GoodInfo
    {

        /// <summary>
        /// 主键
        /// </summary>		
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>		
        public string Name { get; set; }
        /// <summary>
        /// 编码
        /// </summary>		
        public string Code { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>		
        public int StoreId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>		
        public string Remark { get; set; }

    }
}