using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.ISCS.ToolService.Interface
{
    /// <summary>
    /// 签名接口
    /// </summary>
    interface IThirdAuth
    {
        string Signature(IDictionary<string, string> parameters, string secret, string signMethod);
    }
}
