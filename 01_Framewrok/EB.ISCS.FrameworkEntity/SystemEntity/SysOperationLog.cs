using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace EB.ISCS.FrameworkEntity.SystemEntity
{
    public class SysOperationLog
    {
        #region 公共属性

        ///<summary>
        /// 操作日志Id
        ///</summary>
        public int Id { get; set; }

        ///<summary>
        /// 用户Id
        ///</summary>
        public int UserId { get; set; }

        ///<summary>
        /// 客户Id
        ///</summary>
        public int CustomerId { get; set; }

        ///<summary>
        /// 客户端Ip地址
        ///</summary>
        public string ClientIpAddress { get; set; }

        ///<summary>
        /// 模块名称
        ///</summary>
        public string MenuName { get; set; }

        ///<summary>
        /// 模块Id
        ///</summary>
        public int MenuId { get; set; }

        ///<summary>
        /// 功能操作Id
        ///</summary>
        public int MenuActionId { get; set; }

        ///<summary>
        /// 功能操作名称
        ///</summary>
        public string MenuActionName { get; set; }

        ///<summary>
        /// 服务名称
        ///</summary>
        public string ServiceName { get; set; }

        ///<summary>
        /// 功能模块
        ///</summary>
        public string FunctionController { get; set; }

        ///<summary>
        /// 方法名称
        ///</summary>
        public string MethodAction { get; set; }

        ///<summary>
        /// 参数
        ///</summary>
        public string Parameters { get; set; }

        ///<summary>
        /// 执行时间
        ///</summary>
        public DateTime? ExecutionTime { get; set; }

        ///<summary>
        /// 执行耗时
        ///</summary>
        public int ExecutionDuration { get; set; }

        ///<summary>
        /// 客户端名称
        ///</summary>
        public string ClientName { get; set; }

        ///<summary>
        /// 浏览器信息
        ///</summary>
        public string BrowserInfo { get; set; }

        ///<summary>
        /// 操作内容
        ///</summary>
        public string Exception { get; set; }

        ///<summary>
        /// 类的说明
        ///</summary>
        public string Description { get; set; }

        ///<summary>
        /// 来源设备
        ///</summary>
        public string SourceEquipment { get; set; }

        ///<summary>
        /// 自定义信息
        ///</summary>
        public string CustomData { get; set; }

        ///<summary>
        /// IP数值
        ///</summary>
        public int IPNum { get; set; }

        ///<summary>
        /// 登录Token
        ///</summary>
        public string Token { get; set; }

        ///<summary>
        /// 浏览器代理
        ///</summary>
        public string Navigator { get; set; }

        ///<summary>
        /// 浏览地址
        ///</summary>
        public string RequestUri { get; set; }

        ///<summary>
        /// 上次请求地址
        ///</summary>
        public string UrlReferrer { get; set; }

        ///<summary>
        /// 请求类型 0请求前 1请求后
        ///</summary>
        public int RequestType { get; set; }

        ///<summary>
        /// 是否有效  0 无效  1 有效
        ///</summary>
        public int Enabled { get; set; }

        ///<summary>
        /// 录入人员
        ///</summary>
        public int? InUser { get; set; }

        ///<summary>
        /// 录入日期
        ///</summary>
        public DateTime? InDate { get; set; }

        ///<summary>
        /// 删除人员
        ///</summary>
        public int? DelUser { get; set; }

        ///<summary>
        /// 标识该行数据是否被删除 0未删除 1删除
        ///</summary>
        public int DelState { get; set; }

        ///<summary>
        /// 删除时间
        ///</summary>
        public DateTime? DelDate { get; set; }

        #endregion

        #region 扩展属性
        ///<summary>
		/// 用户名称
		///</summary>
        [NotMapped]
        public string UserName { get; set; }

        ///<summary>
        /// 登录名称
        ///</summary>
        [NotMapped]
        public string LoginName { get; set; }
        #endregion
    }


}
