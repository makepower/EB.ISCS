using EB.ISCS.Common.Enum;
using EB.ISCS.DapperServices.Repository;
using EB.ISCS.DapperServices.Services;
using EB.ISCS.DapperServices.Services.Sys;
using EB.ISCS.FrameworkEntity;
using Maticsoft.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EB.ISCS.ToolService
{
    /// <summary>
    /// 统计服务
    /// </summary>
    public class StatisticalService
    {

        ShipInfoService _shopInfoService = null;
        SysUserService _sysUserService = null;
        MonitorIndicatorService _monitorIndicatorService = null;
        GoodMonitorTopNService _goodMonitorTopNService = null;
        DataSyncRecordService _dataSyncRecordService = null;

        public StatisticalService()
        {
            EBServiceProvider serviceProvider = new EBServiceProvider();
            _shopInfoService = serviceProvider.GetService<ShipInfoService>();
            _sysUserService = serviceProvider.GetService<SysUserService>();
            _monitorIndicatorService = serviceProvider.GetService<MonitorIndicatorService>();
            _goodMonitorTopNService = serviceProvider.GetService<GoodMonitorTopNService>();
            _dataSyncRecordService = serviceProvider.GetService<DataSyncRecordService>();
        }

        public void Start()
        {
            var userIds = _sysUserService.GetAllList().Select(x => x.Id)?.ToList();
            userIds.ForEach(u =>
            {
                Task.Run(() =>
                {
                    var shipInfos = _shopInfoService.GetShipsByUserId(u);
                    var virtualShip = shipInfos.First(x => x.Plat == (int)ApiPlatform.Local);
                    var record = GetRecord(virtualShip);
                    var ids = string.Join(",", shipInfos?.Where(x => x.Id != virtualShip.Id).Select(x => x.Id));
                    StatisMonitorIndicator(virtualShip, ids, record);
                    StatisTopNIndicator(virtualShip, ids, record);
                    SaveRecord(record);
                });
            });
        }

        /// <summary>
        /// 统计静态监控指标
        /// </summary>
        /// <param name="u"></param>
        private void StatisMonitorIndicator(ShipInfo virtualShip, string enityShipIds, DataSyncRecord syncRecord)
        {
            try
            {
                var monitorResult = _monitorIndicatorService.GetTodayIndicator(enityShipIds);

                var gp = from p in monitorResult
                         group p by p.Name into g
                         select new MonitorIndicator()
                         {
                             EnName = g.First().EnName,
                             GroupName = g.First().GroupName,
                             Name = g.First().Name,
                             ShortName = g.First().ShortName,
                             StatisDate = g.First().StatisDate,
                             StatisGroupType = g.First().StatisGroupType,
                             Unit = g.First().Unit,
                             Value = g.Sum(x => x.Value)
                         };

                System.Collections.Generic.IEnumerable<MonitorIndicator> lastMonitorIndicator = null;
                if (syncRecord.Id > 0)
                {
                    lastMonitorIndicator = _monitorIndicatorService.GetMonitorIndicatorBySeriesNum(syncRecord.LastSynSeriesNum);
                    syncRecord.LastSynSeriesNum += 1;
                    syncRecord.LastSynDate = DateTime.Now;
                }
                foreach (var item in gp)
                {
                    if (lastMonitorIndicator != null)
                    {
                        var match = lastMonitorIndicator.FirstOrDefault(x => x.Name.Equals(item.Name));
                        if (match == null)
                            continue;
                        item.MoM = (item.Value - match.Value) / match.Value * 100;
                    }
                    item.ShipInfoId = virtualShip.Id;
                    _monitorIndicatorService.Add(item);
                }
                _dataSyncRecordService.Update(syncRecord);
            }
            catch (Exception e)
            {
                FrameworkLog.LogModel.LogHelper.WriteErrorLog($"StatisMonitorIndicator数据同步失败", e);
            }
        }

        /// <summary>
        /// 统计动态监控指标
        /// </summary>
        /// <param name="u"></param>
        private void StatisTopNIndicator(ShipInfo virtualShip, string enityShipIds, DataSyncRecord syncRecord)
        {
            // 统计动态监控指标
            var topNResult = _goodMonitorTopNService.GetMonitorStstisForThirtyDays(enityShipIds);
            var gp = from p in topNResult
                     group p by new { p.StatisType, p.Name } into g
                     select new GoodMonitorTopN()
                     {
                         Name = g.First().Name,
                         ShortName = g.First().ShortName,
                         StatisDate = g.First().StatisDate,
                         Unit = g.First().Unit,
                         Value = g.Sum(x => x.Value),
                         StatisPeriodType = g.First().StatisPeriodType,
                         StatisType = g.First().StatisType,
                         ShipInfoId = virtualShip.Id,
                         SyncSerialNumber = syncRecord.LastSynSeriesNum
                     };
            foreach (var item in gp)
            {
                _goodMonitorTopNService.Add(item);
            }
        }

        private DataSyncRecord GetRecord(ShipInfo virtualShip)
        {
            var syncInfo = _dataSyncRecordService.GetRecordByShipId(virtualShip.Id);
            if (syncInfo == null)
            {
                syncInfo = new DataSyncRecord()
                {
                    LastSynDate = DateTime.Now,
                    LastSynSeriesNum = 1,
                    ShopId = virtualShip.Id,
                    Status = 1,
                    UserId = virtualShip.UserId
                };
                _dataSyncRecordService.Add(syncInfo);
            }
            return syncInfo;
        }

        private void SaveRecord(DataSyncRecord dataSyncRecord)
        {
            if (dataSyncRecord.Id < 0)
                _dataSyncRecordService.Add(dataSyncRecord);
            else
                _dataSyncRecordService.Update(dataSyncRecord);
        }
    }
}
