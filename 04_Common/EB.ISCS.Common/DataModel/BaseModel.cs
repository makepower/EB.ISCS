using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EB.ISCS.Common.Models;

namespace EB.ISCS.Common.DataModel
{
    /// <summary>
    /// 基本
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// 用户身份凭据，登陆后可获得
        /// </summary>
        /// <returns></returns>
        public string Token { get; set; }
        /// <summary>
        /// 状态码
        /// </summary>
        /// <returns></returns>
        public ResultCode Valid()
        {
            return ResultCode.Success;
        }
    }
}
