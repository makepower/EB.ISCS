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
        /// Id
        /// </summary>		
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>		
        public string Name { get; set; }
        /// <summary>
        /// Code
        /// </summary>		
        public string Code { get; set; }
        /// <summary>
        /// StoreId
        /// </summary>		
        public int StoreId { get; set; }
        /// <summary>
        /// Remark
        /// </summary>		
        public string Remark { get; set; }

    }
}