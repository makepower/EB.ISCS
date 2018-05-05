using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.ISCS.Common.DataModel
{
    /// <summary>
    /// 登录Token()
    /// </summary>
    public class SysLoginTokenModel : BaseModel
    {
        #region 公共属性

        ///<summary>
        /// 登录TokenId
        ///</summary>
        public int Id { get; set; }

        ///<summary>
        /// 部门Id
        ///</summary>
        public int? DepId { get; set; }

        ///<summary>
        /// 用户Id
        ///</summary>
        public int UserId { get; set; }

        ///<summary>
        /// 登录Token
        ///</summary>
        public new string Token { get; set; }

        ///<summary>
        /// 过期时间
        ///</summary>
        public DateTime ExpriedTime { get; set; }

        ///<summary>
        /// 录入日期
        ///</summary>
        public DateTime InDate { get; set; }

        #endregion

        #region 扩展属性

        /// <summary>
        /// 
        /// </summary>
        public SysLoginTokenModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="depId"></param>
        /// <param name="userId"></param>
        public SysLoginTokenModel(int? depId, int userId)
        {
            //客户端过期
            ExpriedTime = DateTime.Now.AddHours(10); //accessChannelID > 1 ? DateTime.Now.AddDays(7) : DateTime.Now.AddDays(1);
            InDate = DateTime.Now;
            Token = MakeToken(depId, userId, ExpriedTime);//Guid.NewGuid().ToString().Replace("-", string.Empty).ToUpper();
            UserId = userId;
        }

        /// <summary>
        /// 对Token进行Hash ,去掉非常规字符
        /// </summary>
        ///  <param name="depId"></param>
        ///  <param name="userId"></param>
        /// <param name="expriedTime"></param>
        /// <returns></returns>
        private string MakeToken(int? depId, int userId, DateTime expriedTime)
        {
            var guid = Guid.NewGuid().ToString().Replace("-", string.Empty).ToUpper();
            long ticks = expriedTime.Ticks / 10000000;
            //byte[] arrTicket = Encoding.UTF8.GetBytes(ticks.ToString());
            //byte[] hashBytes = new SHA256Managed().ComputeHash(arrTicket);
            //string strTicket = Convert.ToBase64String(hashBytes);
            string hashString = $"{depId}-{userId}{guid}{ticks}";
            return hashString;
        }

        /// <summary>
        /// 验证token是否被篡改
        /// </summary>
        /// <returns></returns>
	    public bool IsValid()
        {
            if (string.IsNullOrEmpty(Token))
            {
                return false;
            }
            long ticks = ExpriedTime.Ticks / 10000000;
            var shaTicket = Token.Substring($"{DepId}-{UserId}".Length + 32);
            //byte[] arrTicket = Encoding.UTF8.GetBytes(ticks.ToString());
            //byte[] hashBytes = new SHA256Managed().ComputeHash(arrTicket);
            //string strTicket = Convert.ToBase64String(hashBytes);
            bool bValid = (Token.IndexOf($"{DepId}-{UserId}", StringComparison.Ordinal) == 0 &&
                           shaTicket == ticks.ToString());
            return bValid;
        }
        #endregion
    }
}
