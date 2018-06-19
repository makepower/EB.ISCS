using System.ComponentModel;

namespace EB.ISCS.Common.Enum
{
    /// <summary>
    /// 平台接口枚举
    /// </summary>
    public enum ApiPlatform
    {
        /// <summary>
        /// 阿里淘宝
        /// </summary>
        [Description("阿里淘宝")]
        Ali_Tb = 0,
        /// <summary>
        /// 阿里天猫
        /// </summary>
        [Description("阿里天猫")]
        Ali_Tm,
        /// <summary>
        /// 京东
        /// </summary>
        [Description("京东")]
        Jd,
        /// <summary>
        /// 本地平台
        /// </summary>
        [Description("本地平台")]
        Local
    }

    /// <summary>
    /// 统计类型
    /// </summary>
    public enum StatisGroupType
    {
        /// <summary>
        /// 运营
        /// </summary>
        [Description("运营")]
        Operations,
        /// <summary>
        /// 商品
        /// </summary>
        [Description("商品")]
        Good,
        /// <summary>
        /// 物流
        /// </summary>
        [Description("物流")]
        Logistics,
        /// <summary>
        /// 客户
        /// </summary>
        [Description("客户")]
        Customers,
        /// <summary>
        /// 交易
        /// </summary>
        [Description("交易")]
        Transaction
    }
}
