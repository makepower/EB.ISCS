using EB.ISCS.Common.Models;
using EB.ISCS.DapperServices.Repository;
using Maticsoft.Model;
using System.Web.Http;

namespace EB.ISCS.WebApi.Controllers.Biz
{
    /// <summary>
    /// 同步配置
    /// </summary>
    public class SyncConfigController : BaseApiController
    {
        /// <summary>
        /// 保存同步配置信息
        /// </summary>
        /// <param name="cfg"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<bool> Save(SynchronizationConfig cfg)
        {
            var service = GetService<SynchronizationConfigService>();
            if (cfg.Id <= 0)
                return ResponseResult<bool>.GenSuccessResponse(service.Add(cfg) > 0);
            else
                return ResponseResult<bool>.GenSuccessResponse(service.Update(cfg));
        }

        /// <summary>
        /// 获取用户同步配置信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult<SynchronizationConfig> GetByUserId(int id)
        {
            var service = GetService<SynchronizationConfigService>();
            var result = service.GetByUserId(id);
            return ResponseResult<SynchronizationConfig>.GenSuccessResponse(result);
        }
    }
}