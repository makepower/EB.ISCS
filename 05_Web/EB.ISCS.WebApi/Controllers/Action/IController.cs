using System.Web;
using EB.ISCS.FrameworkHelp.Tools;

namespace EB.ISCS.WebApi.Controllers.Action
{

    public class BaseController 
    {
        public HttpContextBase Current => CurrentHttpContext.Instance();

        public HttpResponseBase Response => CurrentHttpContext.Instance().Response;

        public HttpServerUtilityBase Server => CurrentHttpContext.Instance().Server;

        public HttpRequestBase Request => CurrentHttpContext.Instance().Request;
    }
}