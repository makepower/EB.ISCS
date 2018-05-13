using Dapper;

namespace Maticsoft.Model
{
    /// <summary>
    ///OrderDetail ：实体类
    /// </summary>	
    [Table("OrderDetail")]
    public class OrderDetail
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
        /// GoodCode
        /// </summary>		
        public string GoodCode { get; set; }
        /// <summary>
        /// GoodName
        /// </summary>		
        public string GoodName { get; set; }
        /// <summary>
        /// Num
        /// </summary>		
        public int Num { get; set; }
        /// <summary>
        /// Price
        /// </summary>		
        public decimal Price { get; set; }
        /// <summary>
        /// GiftPoint
        /// </summary>		
        public decimal GiftPoint { get; set; }
        /// <summary>
        /// Remark
        /// </summary>		
        public string Remark { get; set; }

    }
}