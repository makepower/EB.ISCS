using Dapper;

namespace Maticsoft.Model
{
    /// <summary>
    ///物流跟踪信息 ：实体类
    /// </summary>	
    [Table("WayBillTraceInfo")]
    public class WayBillTraceInfo
    {

        /// <summary>
        /// 主键
        /// </summary>		
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 本地物流ID
        /// </summary>
        public int WayBillId { get; set; }
        /// <summary>
        /// 供应商物流Id
        /// </summary>		
        public int LogisticId { get; set; }
        /// <summary>
        /// 接受时间
        /// </summary>		
        public string AcceptTime { get; set; }
        /// <summary>
        /// 接受状态
        /// </summary>		
        public string AcceptStation { get; set; }
        /// <summary>
        /// 备注
        /// </summary>		
        public string Remark { get; set; }

    }
}