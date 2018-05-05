using System;
using Dapper;

namespace EB.ISCS.FrameworkEntity.SystemEntity
{
    
    public partial class SysRole
    {
        public int Id { get; set; }
        public Nullable<int> RoleLevel { get; set; }
        public string RoleName { get; set; }
        public Nullable<int> DepId { get; set; }
        public string RoleDescription { get; set; }
        public Nullable<int> CompanyRole { get; set; }
        public Nullable<int> RoleType { get; set; }
        public Nullable<int> RoleFatherId { get; set; }
        public Nullable<int> RoleIsManage { get; set; }
        public string RoleFatherIDPath { get; set; }
        public Nullable<int> DepSort { get; set; }
        public string RoleRemark { get; set; }
        public int Enabled { get; set; }
        public Nullable<int> InUser { get; set; }
        public Nullable<System.DateTime> InDate { get; set; }
        public Nullable<int> EditUser { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
        public Nullable<int> DelUser { get; set; }
        public int DelState { get; set; }
        public Nullable<System.DateTime> DelDate { get; set; }


        #region 扩展属性

        /// <summary>
        /// 子站点 Id，用于查询子站点菜单
        /// </summary>
        [NotMapped]
        public int BizType { get; set; }

        ///<summary>
        /// 录入日期
        ///</summary>
        [NotMapped]
        public string InDateDisplayString { get { return InDate?.ToString("yyyy-MM-dd HH:mm:ss"); } set { } }

        ///<summary>
        /// 修改日期
        ///</summary>
        [NotMapped]
        public string EditDateDisplayString { get { return EditDate?.ToString("yyyy-MM-dd HH:mm:ss"); } set { } }

        /// <summary>
        /// 是否通过站点来查询，true:需要根据bizType来查，反之则不需要
        /// </summary>
        [NotMapped]
        public bool IsSiteControl { get; set; }

        [NotMapped]
        public string InUserName { get; set; }
        [NotMapped]
        public string EditUserName { get; set; }
        #endregion
    }
}
