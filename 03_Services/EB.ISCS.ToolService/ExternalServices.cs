using EB.ISCS.ToolService.Interface;
using System.Collections.Generic;

namespace EB.ISCS.ToolService
{
    /// <summary>
    /// 外部服务
    /// </summary>
    public abstract class ExternalServices : IThirdAuth
    {
        public virtual string Signature(IDictionary<string, string> parameters, string secret, string signMethod)
        {
            return string.Empty;
        }
    }
}
