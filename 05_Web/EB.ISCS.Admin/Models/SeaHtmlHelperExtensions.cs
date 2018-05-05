using System.Web.Mvc;

namespace EB.ISCS.Admin.Models
{
    public static class SeaHtmlHelperExtensions
    {
        public static MvcHtmlString RequiredFlag(this HtmlHelper html, string flag = null)
        {
            if (string.IsNullOrEmpty(flag))
            {
                flag = "*";
            }
            return new MvcHtmlString($"<strong class=\"text-danger\">{flag}</strong>");
        }
    }
}
