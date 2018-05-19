using Maticsoft.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace EB.ISCS.ToolService
{
    /// <summary>
    /// 商家数据同步服务
    /// </summary>
    public class TradeSyncService
    {
        private string _connstr;
        Task[] taskArrray = null;
        CountdownEvent countdown = null;
        private Dictionary<string, ShipInfo> dictionary = null;

        public TradeSyncService(string connstr)
        {
            _connstr = connstr;
            dictionary = new Dictionary<string, ShipInfo>();
            AuthServer.AuthFactory.Instance.AuthHandleEvent += Instance_AuthHandleEvent;
        }

        private void Instance_AuthHandleEvent(AuthServer.AuthModel obj)
        {
            if (dictionary.ContainsKey(obj.Key))
                dictionary[obj.Key].SessionKey = obj.AccessToken;
            countdown.Signal();
        }

        public void DoJob(List<ShipInfo> list)
        {
            // 1. 所有服务认证完成
            dictionary = list.ToDictionary(x => x.Id.ToString());
            countdown = new CountdownEvent(list.Count);
            foreach (var item in list)
            {
                AuthServer.AuthFactory.Instance.RegisterShopAuth(item);
            }
            countdown.Wait(new System.TimeSpan(0, 30, 0));/* 30分钟超时 */
            countdown.Dispose();

            // 2. 同步数据 
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
