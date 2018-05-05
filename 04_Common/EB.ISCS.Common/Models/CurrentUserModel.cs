using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EB.ISCS.Common.DataModel;

namespace EB.ISCS.Common.Models
{
    public class CurrentUserModel:BaseModel
    {
        #region 公共属性

        ///<summary>
        /// 用户Id
        ///</summary>
        public int UserId { get; set; }

        ///<summary>
        /// 部门Id
        ///</summary>
        public int? UserDepId { get; set; }
      
        ///<summary>
        /// 用户名称
        ///</summary>
        public string UserName { get; set; }

        ///<summary>
        /// 登录名称
        ///</summary>
        public string LoginName { get; set; }

        ///<summary>
        /// 是否冻结 0冻结 1非冻结
        ///</summary>
        public int? UserIsFreeze { get; set; }

        ///<summary>
        /// 是否系统帐号0 否 1是
        ///</summary>
        public int? UserIsManage { get; set; }

        ///<summary>
        /// 中文名
        ///</summary>
        public string EmployeeName { get; set; }

        ///<summary>
        /// 职位
        ///</summary>
        public int? UserPosition { get; set; }
        ///<summary>
        /// 客户Id
        ///</summary>
        public int? UserCustomerId { get; set; }
        ///<summary>
        /// 座机号码
        ///</summary>
        public string PlaneNumber { get; set; }

        ///<summary>
        /// 部门名称
        ///</summary>
        public string DepName { get; set; }

        ///<summary>
        ///部门名称路径
        ///</summary>
        public string NamePath { get; set; }

        #endregion

        #region 公共方法

        /// <summary>
        /// 是否系统管理员
        /// </summary>
        /// <returns></returns>
        public bool IsSysAdmin()
        {
            return this.UserIsManage == 1;
        }
        #endregion
    }
}
