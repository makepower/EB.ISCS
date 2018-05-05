namespace EB.ISCS.FrameworkEntity.Base
{
    /// <summary>
    /// 分页模型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedListData<T>
    {
        /// <summary>
        /// 页数据对象
        /// </summary>
        public PagingInfo PagingInfo { get; set; }
        /// <summary>
        /// 页数据对象
        /// </summary>
        public T PagingData { get; set; }

        /// <summary>
        /// 分页数据对象构造
        /// </summary>
        public PagedListData()
        {
            this.PagingInfo = new PagingInfo(20, 1);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PagingInfo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        public PagingInfo(int pageSize, int pageIndex)
        {
            this.PageSize = pageSize <= 0 ? 10 : pageSize;
            this.PageIndex = pageIndex < 0 ? 0 : pageIndex;
        }
        /// <summary>
        /// 获取或设置页面索引（第几页）
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 获取或设置每页显示数据量
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 获取或设置总记录数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount => this.TotalCount / this.PageSize + (this.TotalCount % this.PageSize > 0 ? 1 : 0);
    }

    /// <summary>
    /// 分页查询条件模型
    /// </summary>
    public class PageSearch
    {
        /// <summary>
        /// 每页条数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Where 条件
        /// </summary>
        public string Where { get; set; }
}
}
