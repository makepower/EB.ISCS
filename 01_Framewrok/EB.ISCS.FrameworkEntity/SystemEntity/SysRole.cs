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


        #region ��չ����

        /// <summary>
        /// ��վ�� Id�����ڲ�ѯ��վ��˵�
        /// </summary>
        [NotMapped]
        public int BizType { get; set; }

        ///<summary>
        /// ¼������
        ///</summary>
        [NotMapped]
        public string InDateDisplayString { get { return InDate?.ToString("yyyy-MM-dd HH:mm:ss"); } set { } }

        ///<summary>
        /// �޸�����
        ///</summary>
        [NotMapped]
        public string EditDateDisplayString { get { return EditDate?.ToString("yyyy-MM-dd HH:mm:ss"); } set { } }

        /// <summary>
        /// �Ƿ�ͨ��վ������ѯ��true:��Ҫ����bizType���飬��֮����Ҫ
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
