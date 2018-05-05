namespace EB.ISCS.Common.DataModel
{
    /// <summary>
    /// 系统菜单查询条件实体
    /// </summary>
    public class QueryMenuModel : SearchCondition
    {
        ///<summary>
		/// 模块Id
		///</summary>
		public int Id { get; set; }

        ///<summary>
        /// 模块Code
        ///</summary>
        public string MenuCode { get; set; }

        ///<summary>
        /// 模块名称
        ///</summary>
        public string MenuName { get; set; }

        ///<summary>
        /// 模块对应的页面路径，即打开页面路径
        ///</summary>
        public string PageUrl { get; set; }

        ///<summary>
        /// 控制器Key
        ///</summary>
        public string MenuControllerKey { get; set; }

        ///<summary>
        /// 操作Key
        ///</summary>
        public string MenuActionKey { get; set; }

        /// <summary>
        /// 是否获取所有状态（可用和禁用）的功能模块（菜单），缺省是只获取可用状态的,1表示获取所有（包括可用和禁用的）
        /// </summary>
        public int? IsGetAllMenus { get; set; }

        public string MenuCodes { get; set; }
    }
}
