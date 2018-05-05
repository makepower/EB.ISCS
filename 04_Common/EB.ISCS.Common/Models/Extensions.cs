using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using System.Net.Http;
using EB.ISCS.FrameworkEntity.Base;

namespace EB.ISCS.Common.Models
{
    public static class Extensions
    {
        public static CurrentUserModel InitFromHttpContext(this CurrentUserModel current)
        {
            var userIdentity = (HttpContext.Current.User.Identity as ClaimsIdentity);
            if (userIdentity != null && userIdentity.IsAuthenticated)
            {
                var user = userIdentity.FindFirst(x => x.Type == ClaimTypes.UserData);
                string userJson = user?.Value;
                if (!string.IsNullOrEmpty(userJson))
                {
                    return JsonConvert.DeserializeObject<CurrentUserModel>(userJson);
                }
            }
            return null;
        }


        /// <summary>
        /// 从请求上下人文提取业务票据Token
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public static string Token(this HttpRequestMessage requestMessage)
        {
            if (requestMessage == null)
                return string.Empty;
            var ticket = requestMessage.Headers.Authorization.Parameter;
            var array = ticket.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (array.Length > 1)
                return array[1];
            return string.Empty;

        }

        /// <summary>
        /// 对服务端分页数据进行序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pagedList"></param>
        /// <returns></returns>
        public static object JqGridJsonData<T>(this PagedListData<List<T>> pagedList)
        {

            var json = new
            {
                page = pagedList?.PagingInfo?.PageIndex ?? 1,
                records = pagedList?.PagingInfo?.TotalCount ?? 0,
                total = pagedList?.PagingInfo?.PageCount,
                rows = pagedList?.PagingData?.ToArray() ?? new List<T>().ToArray()
            };
            return json;
        }
    }
}
