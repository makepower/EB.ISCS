using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.ISCS.Common.DataModel
{
    /// <summary>
    /// 用户查询实体
    /// </summary>
    public class QueryUserModel : SearchCondition
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 员工客户 0员工 2超级管理员
        /// </summary>
        public int UserType { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 用户编码
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 角色编号
        /// </summary>
        public int RoleId { get; set; }

    }


    /// <summary>
    /// 员工客户 0员工 1工人 2超级管理员
    /// </summary>
    public enum EnumUserType
    {
        /// <summary>
        /// 员工
        /// </summary>
        User = 0,

        /// <summary>
        /// 超级管理员
        /// </summary>
        SuperAdmin = 2
    }
}
