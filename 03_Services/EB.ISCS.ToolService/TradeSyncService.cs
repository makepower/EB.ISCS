using Maticsoft.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EB.ISCS.ToolService
{
    /// <summary>
    /// 商家数据同步服务
    /// </summary>
    public class TradeSyncService
    {
        private string _connstr;

        public TradeSyncService(string connstr)
        {
            _connstr = connstr;
        }

        public void DoJob(List<ShipInfo> list)
        {
            var taskArray = new Task[list.Count];
            var num = list.Count;
            for (int i = 0; i < num; i++)
            {
                taskArray[i] = new Task(() =>
                {
                    if (list[i].Plat == 2)
                    {
                        // jd
                        new JdDataServiceWrapper(_connstr).SyncData(list[i]);
                    }
                    else if (list[i].Plat < 2)
                    {
                        //tb
                        new AliDataServiceWrapper(_connstr).SyncData(list[i]);
                    }
                });
            }

            Task.WaitAll(taskArray);

            FrameworkLog.LogModel.LogHelper.WriteInfoLog($"同步数据完成,开始统计数据");
            var statis = new StatisticalService();
            statis.Start();

        }
    }
}
