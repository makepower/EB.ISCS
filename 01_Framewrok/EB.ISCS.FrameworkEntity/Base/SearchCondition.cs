using Dapper;

namespace EB.ISCS.FrameworkEntity.Base
{
    /// <summary>
    /// 查询条件基类
    /// </summary>
    public class SearchCondition
    {

        /// <summary>
        /// 每页条数
        /// </summary>
        [NotMapped]
        public int PageSize { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        [NotMapped]
        public int PageIndex { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [NotMapped]
        public string OrderBy { get; set; }

        /// <summary>
        /// Token
        /// </summary>
        [NotMapped]
        public string Token { get; set; }

        /// <summary>
        /// Where 条件
        /// </summary>
        [NotMapped]
        public string Where { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [NotMapped]
        public string InUserName { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>		
        [NotMapped]
        public string EditUserName { get; set; }
        /// <summary>
        /// 删除人
        /// </summary>
        [NotMapped]
        public string DelUserName { get; set; }
    }
}
