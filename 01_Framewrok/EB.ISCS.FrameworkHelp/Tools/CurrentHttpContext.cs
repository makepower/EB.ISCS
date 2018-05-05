using System;
using System.Web;

namespace EB.ISCS.FrameworkHelp.Tools
{
    /// <summary>
    /// 包装HttpContext.Current
    /// </summary>
    public static class CurrentHttpContext
    {
        /// <summary>
        /// 当前上下文
        /// </summary>
        public static Func<HttpContextBase> Instance = () => new HttpContextWrapper(HttpContext.Current);
    }
}
