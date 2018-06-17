using Dapper;

namespace EB.ISCS.FrameworkEntity.Biz
{
    /// <summary>
    /// 交易人
    /// </summary>
    [Table("Trader")]
    public class Trader
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string Id { get; set; }
        /// <summary>
        /// 用户主键
        /// </summary>
        public string UserKey { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
        public string UserStatus { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string TelePhone { get; set; }
        /// <summary>
        /// 用户主键
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string Provice { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 区县
        /// </summary>
        public string District { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string DetailStreet { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 编辑人员
        /// </summary>
        public string EditDate { get; set; }
        /// <summary>
        /// 录入人员
        /// </summary>
        public string InUser { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return string.Concat(UserKey, MobilePhone).GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var o = obj as Trader;
            if (o == null)
                return false;
            return UserKey.Equals(o.UserKey) && MobilePhone.Equals(o.MobilePhone);
        }
        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{UserKey}-{MobilePhone}";
        }

    }
}
