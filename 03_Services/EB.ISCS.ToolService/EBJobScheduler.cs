using EB.ISCS.FrameworkHelp.Utilities;
using EB.ISCS.ToolService.TripartiteDataService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EB.ISCS.ToolService
{
    public class EBJobScheduler
    {
        private List<IDataService> _dataProviderThirdPart;

        private System.Threading.CancellationToken cancellationToken;

        EBJobScheduler()
        {
            _dataProviderThirdPart = new List<IDataService>
            {
                new AliDataService(),
                new JdDataService()
            };
            cancellationToken = new System.Threading.CancellationToken();
        }


        public static EBJobScheduler Default
        {
            get
            {
                return new EBJobScheduler();
            }
        }

        public void DoJob()
        {
            FrameworkLog.LogModel.LogHelper.WriteInfoLog($"开始同步数据");
            var task = new Task(() =>
            {
                _dataProviderThirdPart.ForEach(d =>
                {
                    try
                    {
                        d.SyncData();
                    }
                    catch (Exception ex)
                    {
                        FrameworkLog.LogModel.LogHelper.WriteErrorLog($"同步数据出错{d.Platform.GetDescription()}{ d.ServiceName}", ex);
                    }

                });
            }, cancellationToken).ContinueWith((t) =>
            {
                FrameworkLog.LogModel.LogHelper.WriteInfoLog($"同步数据完成,开始统计数据");
                var statis = new StatisticalService();
                statis.Start();
            }, cancellationToken).ContinueWith((t) =>
            {
                if (t.IsCompleted)
                    FrameworkLog.LogModel.LogHelper.WriteInfoLog($"统计数据完成");
                else
                    FrameworkLog.LogModel.LogHelper.WriteInfoLog($"同步统计数据未正常结束,请检查运行日志");
            });

        }

        public string CornExpression { get; set; }
    }
}
