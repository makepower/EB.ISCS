namespace EB.ISCS.Common.DataModel
{
    /// <summary>
    /// 查询用户权限条件
    /// </summary>
    public class QueryUserPermissionModel
    {
        public QueryUserPermissionModel() { }
        public QueryUserPermissionModel(int userId, int menuId)
        {
            this.UserId = userId;
            this.MenuId = menuId;
        }
        /// <summary>
        /// 当前用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 当前所在页面的 菜单 Id
        /// </summary>
        public int MenuId { get; set; }
    }
}
