using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace EB.ISCS.Common.BaseController
{
    /// <inheritdoc />
    /// <summary>
    /// JsonResult 扩展类
    /// </summary>
    public class ExtendJsonResult : JsonResult
    {
        /// <inheritdoc />
        /// <summary>
        /// 扩展时间类型格式化
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var response = context.HttpContext.Response;
            if (this.Data == null) return;
            var setting = new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-dd HH:mm:ss"
            };
            // 设置日期序列化的格式
            response.Write(JsonConvert.SerializeObject(Data, setting));
        }
    }
}
