using System;
using Dapper;

namespace EB.ISCS.FrameworkEntity.SystemEntity
{
    public class SysExceptionLog
    {
        #region 公共属性

        ///<summary>
        /// 日志Id
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
        /// 发生时间
        ///</summary>
        public DateTime? ExceptionDate { get; set; }

        ///<summary>
        /// 功能模块
        ///</summary>
        public string ExceptionFunction { get; set; }

        ///<summary>
        /// 版本号
        ///</summary>
        public string ExceptionVersions { get; set; }

        ///<summary>
        /// 来源
        ///</summary>
        public string ExceptionSource { get; set; }

        ///<summary>
        /// 详细描述
        ///</summary>
        public string ExceptionDescription { get; set; }

        ///<summary>
        /// 堆栈
        ///</summary>
        public string ExceptionStackTrace { get; set; }

        ///<summary>
        /// 日志类型   1Api  2后台
        ///</summary>
        public string ExceptionType { get; set; }

        ///<summary>
        /// 日志类型名称   1Api  2后台
        ///</summary>
        public string ExceptionTypeName { get; set; }

        ///<summary>
        /// 引发异常方法
        ///</summary>
        public string ExceptionTargetSite { get; set; }

        ///<summary>
        /// IP地址
        ///</summary>
        public string ExceptionIP { get; set; }

        ///<summary>
        /// IP数值
        ///</summary>
        public int IPNum { get; set; }

        ///<summary>
        /// 机器名
        ///</summary>
        public string ComputerName { get; set; }

        ///<summary>
        /// 浏览器名称
        ///</summary>
        public string ExploreName { get; set; }

        ///<summary>
        /// 浏览器版本
        ///</summary>
        public string ExplorerVersions { get; set; }

        ///<summary>
        /// 来源设备
        ///</summary>
        public string SourceEquipment { get; set; }

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
        /// 删除状态 0未删除 1删除
        ///</summary>
        public int DeleteState { get; set; }

        ///<summary>
        /// 删除人员
        ///</summary>
        public int? DeleteUser { get; set; }

        ///<summary>
        /// 删除日期
        ///</summary>
        public DateTime? DeleteDate { get; set; }

        #endregion

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
        [NotMapped]
        public string Token { get; set; }
    }
}
