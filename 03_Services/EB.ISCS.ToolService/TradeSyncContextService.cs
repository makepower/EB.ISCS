using EB.ISCS.DapperServices.Repository;
using EB.ISCS.DapperServices.Services.Sys;
using EB.ISCS.ToolService.Adapter;
using Maticsoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EB.ISCS.ToolService
{
    /// <summary>
    /// 同步上下文服务
    /// </summary>
    public class TradeSyncContextService
    {
        private SynchronizationConfigService _configService = null;
        private ShipInfoService _shipInfoService = null;
        private SysUserService _sysUserService = null;


        /// <summary>
        /// 上下文数据
        /// </summary>
        public SyncContext SyncContext { get; }

        public TradeSyncContextService(SynchronizationConfigService configService)
        {
            _configService = configService ?? throw new Exception("配置服务为空");
            SyncContext = new SyncContext();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="constr"></param>
        /// <param name="userIds"></param>
        public TradeSyncContextService(string constr)
        {
            _configService = new SynchronizationConfigService(constr);
            SyncContext = new SyncContext();
        }

        /// <summary>
        /// 构造上下文
        /// </summary>
        /// <param name="userIds">可以指定用户</param>
        public void BuildContext(params int[] userIds)
        {
            _shipInfoService = new ShipInfoService(_configService);
            _sysUserService = new SysUserService(_configService);
            SyncContext.Context?.Clear();
            var shops = _shipInfoService.GetAllList().ToList().FindAll(x => x.Status > 0 && x.Plat != 3);
            var gp = shops.GroupBy(x => x.UserId);
            var configs = _configService.GetAllList().ToList();
            configs.ForEach(x =>
            {
                if (userIds == null || userIds.Contains(x.UserId))
                    SyncContext.Context.Add(GetSyncContext(x, gp));
            });
        }

        private UserSyncContext GetSyncContext(SynchronizationConfig config, IEnumerable<IGrouping<int, ShipInfo>> grouping)
        {
            var sync = new UserSyncContext();
            var user = _sysUserService.GetModelById(config.UserId);
            sync.TaskId = user.PlaneNumber;

            sync.UserId = config.UserId;
            sync.SyncPeriodHours = config.SyncUnit.Equals("1") ? config.SyncPeriod : config.SyncPeriod * 24;
            sync.Shops = new List<ShipInfo>();
            var myShops = grouping.FirstOrDefault(x => x.Key == config.UserId).ToList();
            var shopIds = config.StoreIds.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var syncShops = myShops.FindAll(x => shopIds.Contains(x.Id.ToString()));
            sync.Shops.AddRange(syncShops);
            return sync;
        }
    }
}
