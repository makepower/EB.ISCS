using System;
using System.Collections.Generic;
using Dapper;

namespace EB.ISCS.FrameworkEntity.SystemEntity
{
    [Table("SysUser")]
    public partial class SysUser
    {
        public int Id { get; set; }
        public Nullable<int> UserDepId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public string UserName { get; set; }
        public string LoginName { get; set; }
        public string PassWord { get; set; }
        public string LastPassword { get; set; }
        public Nullable<int> UserExtent { get; set; }
        public int Enabled { get; set; }
        public bool UserIsFreeze { get; set; }
        public Nullable<int> UserIsManage { get; set; }
        public string UserRemark { get; set; }
        public Nullable<System.DateTime> BeginDate { get; set; }
        public Nullable<System.DateTime> ExpireDade { get; set; }
        public Nullable<int> IsExpireDate { get; set; }
        public Nullable<int> RoleId { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<int> PartitionFalg { get; set; }
        public Nullable<int> FlowDepId { get; set; }
        public Nullable<int> FlowTypeCode { get; set; }
        public Nullable<int> UserType { get; set; }
        public Nullable<int> UserPosition { get; set; }
        public Nullable<int> UserCustomerId { get; set; }
        /// <summary>
        /// 任务批次号
        /// </summary>
        public string PlaneNumber { get; set; }
        public Nullable<int> WhetherDog { get; set; }
        public Nullable<int> Securitylevel { get; set; }
        public Nullable<int> DistrictId { get; set; }
        public Nullable<int> DataGroupId { get; set; }
        public Nullable<int> InUser { get; set; }
        public Nullable<System.DateTime> InDate { get; set; }
        public Nullable<int> EditUser { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
        public int DelState { get; set; }
        public Nullable<int> DelUser { get; set; }
        public Nullable<System.DateTime> DelDate { get; set; }




        #region 扩展属性      

        [NotMapped]
        public string InUserName { get; set; }
        [NotMapped]
        public string EditUserName { get; set; }
        /// <summary>
        /// 用户权限集
        /// </summary>
        [NotMapped]
        public IList<string> Permissions { get; set; }

        /// <summary>
        /// 登录IP地址
        /// </summary>
        [NotMapped]
        public string IPAddress { get; set; }
        /// <summary>
        /// 录IP地址所在地址
        /// </summary>
        [NotMapped]
        public string IPAddressName { get; set; }
        /// <summary>
        /// 是否系统账户；拥有所以权限
        /// </summary>
        [NotMapped]
        public bool IsSystem { get; set; }

        ///<summary>
        ///公司编号
        ///</summary>    
        [NotMapped]
        public string CompanyCode { get; set; }

        ///<summary>
        /// 公司名称
        ///</summary>
        [NotMapped]
        public string CompanyName { get; set; }

        ///<summary>
        /// 部门编号
        ///</summary>
        [NotMapped]
        public string DepCode { get; set; }

        ///<summary>
        /// 部门名称
        ///</summary>
        [NotMapped]
        public string DepName { get; set; }

        ///<summary>
        ///部门Id路径
        ///</summary>
        [NotMapped]
        public string FatherIDPath { get; set; }

        ///<summary>
        ///部门名称路径
        ///</summary>
        [NotMapped]
        public string NamePath { get; set; }

        ///<summary>
        ///公司父Id
        ///</summary>
        [NotMapped]
        public int CompanyFatherId { get; set; }

        ///<summary>
        ///公司Id路径
        ///</summary>
        [NotMapped]
        public string CompanyFatherIDPath { get; set; }

        ///<summary>
        ///公司Enabled
        ///</summary>
        [NotMapped]
        public int CompanyEnabled { get; set; }

        ///<summary>
        ///公司loge1
        ///</summary>
        [NotMapped]
        public byte[] Logo1 { get; set; }

        ///<summary>
        ///试用截至日期
        ///</summary>
        [NotMapped]
        public string TryUseDate { get; set; }

        ///<summary>
        /// 服务器CPU编号
        ///</summary>
        [NotMapped]
        public string ServerCPUCode { get; set; }

        ///<summary>
        ///服务器硬盘编号
        ///</summary>
        [NotMapped]
        public string ServerDiskCode { get; set; }

        ///<summary>
        ///公司删除状态 0删除 1未删除
        ///</summary>
        [NotMapped]
        public int CompanyDelState { get; set; }

        ///<summary>
        ///部门Enabled
        ///</summary>
        [NotMapped]
        public int DepEnabled { get; set; }

        ///<summary>
        ///部门删除状态 0删除 1未删除
        ///</summary>
        [NotMapped]
        public int DepDelState { get; set; }

        ///<summary>
        /// 角色名称
        ///</summary>
        [NotMapped]
        public string RoleName { get; set; }

        /// <summary>
        /// 部门列表
        /// </summary>
        [NotMapped]
        public List<SysUser> children { get; set; }

        ///<summary>
        /// 原密码
        ///</summary>
        [NotMapped]
        public string OldPassword { get; set; }

        ///<summary>
        /// 新密码
        ///</summary>
        [NotMapped]
        public string NewPassword { get; set; }

        ///<summary>
        /// 确认新密码
        ///</summary>
        [NotMapped]
        public string ConNewPassword { get; set; }


        ///<summary>
        /// 起始有效日期
        ///</summary>
        [NotMapped]
        public string StrBeginDate
        {
            get
            {
                if (BeginDate == DateTime.MinValue)
                {
                    return string.Empty;
                }
                return BeginDate?.ToString("yyyy-MM-dd");
            }
        }

        ///<summary>
        /// 终止有效期
        ///</summary>
        [NotMapped]
        public string StrExpireDade
        {
            get
            {
                if (ExpireDade == DateTime.MinValue)
                {
                    return string.Empty;
                }
                return ExpireDade?.ToString("yyyy-MM-dd");
            }
        }

        ///<summary>
        /// 录入日期格式显示
        ///</summary>
        [NotMapped]
        public string InDateString
        {
            get
            {
                if (InDate == DateTime.MinValue)
                {
                    return string.Empty;
                }
                return InDate?.ToString("yyyy-MM-dd");
            }
        }

        ///<summary>
        /// 编辑日期格式显示
        ///</summary>
        [NotMapped]
        public string EditDateString
        {
            get
            {
                if (EditDate == DateTime.MinValue)
                {
                    return string.Empty;
                }
                return EditDate?.ToString("yyyy-MM-dd");
            }
        }

        ///<summary>
        /// 编辑日期格式显示
        ///</summary>
        [NotMapped]
        public string DelDateString
        {
            get
            {
                if (DelDate == DateTime.MinValue)
                {
                    return string.Empty;
                }
                return DelDate?.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// 身份证号
        /// </summary>
        [NotMapped]
        public string IDCard { get; set; }

        #endregion
    }
}
