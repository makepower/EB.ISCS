using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hangfire;
using Hangfire.MemoryStorage;
using EB.ISCS.ToolService;
using EB.ISCS.DapperServices.Base;

[assembly: OwinStartup(typeof(EB.ISCS.WebApi.Startup))]

namespace EB.ISCS.WebApi
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configuration
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            //指定Hangfire使用内存存储后台任务信息
            GlobalConfiguration.Configuration.UseMemoryStorage();
            //启用HangfireServer这个中间件（它会自动释放）
            app.UseHangfireServer();
            //启用Hangfire的仪表盘（可以看到任务的状态，进度等信息）
            app.UseHangfireDashboard();

            FrameworkLog.LogModel.LogHelper.WriteInfoLog("数据同步任务启动...");

            new EBJobScheduler(DapperProvider.GetConnString()).Start();

        }

        /// <summary>
        /// 默认24小时更新一次数据
        /// </summary>
        /// <returns></returns>
        private string ReadCorn()
        {
            return Cron.Daily();
        }
    }
}
