using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace QS.DapperServices.Services.Sys
{
    /// <summary>
    /// 记录登录日志信息
    /// </summary>
    public class SysLoginLog
    {
        #region 公共属性

        ///<summary>
        /// 登录日志Id
        ///</summary>
        public int Id { get; set; }

        ///<summary>
        /// 登录用户
        ///</summary>
        public int UserId { get; set; }

        ///<summary>
        /// 用户名称
        ///</summary>
        //[Column("UserNmae")]
        public string UserName { get; set; }

        ///<summary>
        /// 登录时间
        ///</summary>
        public DateTime? LogDate { get; set; }

        ///<summary>
        /// 退出时间
        ///</summary>
        public DateTime? LogOutDate { get; set; }

        ///<summary>
        /// 客户端Ip地址
        ///</summary>
        public string ClientIpAddress { get; set; }

        ///<summary>
        /// 客户端名称
        ///</summary>
        public string ClientName { get; set; }

        ///<summary>
        /// 在线时间
        ///</summary>
        public string OnlineDate { get; set; }

        ///<summary>
        /// 是否成功
        ///</summary>
        public int IsSucceed { get; set; }

        ///<summary>
        /// 失败原因
        ///</summary>
        public string LogReason { get; set; }

        ///<summary>
        /// 用户SessionId
        ///</summary>
        public string SessionId { get; set; }

        ///<summary>
        /// 0 客户  1员工
        ///</summary>
        public int InUserType { get; set; }

        ///<summary>
        /// IP数值
        ///</summary>
        public int IPNum { get; set; }

        ///<summary>
        /// 是否有效  0 无效  1 有效
        ///</summary>
        public int Enabled { get; set; }

        ///<summary>
        /// 删除人员
        ///</summary>
        public int? DelUser { get; set; }

        ///<summary>
        /// 标识该行数据是否被删除 0删除 1未删除
        ///</summary>
        public int DelState { get; set; }

        ///<summary>
        /// 删除时间
        ///</summary>
        public DateTime? DelDate { get; set; }

        /// <summary>
        /// 用户身份凭据，登陆后可获得
        /// </summary>
        /// <returns></returns>
        public string Token { get; set; }

        #endregion

        #region 扩展属性
        ///<summary>
        /// 登录名称
        ///</summary>
        [NotMapped]
        public string LoginName { get; set; }
        /// <summary>
        /// 公司代码
        /// </summary>
        [NotMapped]
        public string CompanyCode { get; set; }
        #endregion
    }
}
