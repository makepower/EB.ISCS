using System.Web;
using System.Web.Mvc;

namespace EB.ISCS.WebApi
{
    /// <summary>
    /// 
    /// </summary>
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
