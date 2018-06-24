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
        MonitorIndicatorRecordService _monitorIndicatorRecordService = null;
        DataSyncRecordService _dataSyncRecordService = null;

        int[] _calcIndicatorIds = null;

        public StatisticalService()
        {
            EBServiceProvider serviceProvider = new EBServiceProvider();
            _shopInfoService = serviceProvider.GetService<ShipInfoService>();
            _sysUserService = serviceProvider.GetService<SysUserService>();
            _monitorIndicatorService = serviceProvider.GetService<MonitorIndicatorService>();
            _monitorIndicatorRecordService = serviceProvider.GetService<MonitorIndicatorRecordService>();
            _dataSyncRecordService = serviceProvider.GetService<DataSyncRecordService>();
        }

        public void Start()
        {
            var userIds = _sysUserService.GetAllList().Select(x => x.Id)?.ToList();
            _calcIndicatorIds = _monitorIndicatorService.GetAllList().Where(x => x.IsCalc).Select(x => x.Id).ToArray();
            userIds.ForEach(u =>
            {
                Task.Run(() =>
                {
                    // 获取每个用户的所属店铺
                    var shipInfos = _shopInfoService.GetShipsByUserId(u);
                    // 找到虚拟店铺 虚拟店铺为用户所有实体店铺数据的聚合体
                    var virtualShip = shipInfos.First(x => x.Plat == (int)ApiPlatform.Local);
                    // 获取虚拟店铺的同步状态
                    var record = GetSyncRecord(virtualShip);

                    if (record == null || record.Status == 0)
                        return;

                    // 排除虚拟店铺 获取实体店铺的id
                    var ids = shipInfos?.Where(x => x.Id != virtualShip.Id).Select(x => x.Id).ToArray();
                    // 统计报表数据 计算环比
                    StatisRealMonitorIndicator(virtualShip, ids, record);
                    // 更新同步
                    UpdateyncRecord(record);
                });
            });
        }

        /// <summary>
        /// 统计运营监控指标 计算同比环比
        /// </summary>
        /// <param name="u"></param>
        private void StatisRealMonitorIndicator(ShipInfo virtualShip, int[] enityShipIds, DataSyncRecord syncRecord)
        {
            try
            {
                // 取出要统计的记录
                var monitorResult = _monitorIndicatorRecordService.QueryRecordByShipIds(enityShipIds);
                if (monitorResult == null || !monitorResult.Any()) return;

                syncRecord.LastSynSeriesNum += 1;
                syncRecord.LastSynDate = DateTime.Now;
                // 多个不同店铺的数据按照指标id进行分组
                var gp = from p in monitorResult
                         group p by p.IndicatorId into g
                         select new MonitorIndicatorRecord()
                         {
                             IndicatorId = g.Key,
                             Name = g.First().Name,
                             StatisDate = g.First().StatisDate,
                             Unit = g.First().Unit,
                             Value = g.Sum(x => x.Value)
                         };

                foreach (var item in gp)
                {
                    if (_calcIndicatorIds.Contains(item.IndicatorId))
                    {
                        var lastMonitorIndicator = _monitorIndicatorRecordService.QueryMonitorIndicator(new Common.DataModel.QueryRecordModel()
                        {
                            SeriesNum = syncRecord.LastSynSeriesNum,
                            UserId = syncRecord.UserId,
                            ShipId = syncRecord.ShopId,
                            IndicatorId = item.IndicatorId
                        });
                        if (lastMonitorIndicator == null || !lastMonitorIndicator.Any()) continue;
                        var match = lastMonitorIndicator.First();
                        if (match.Value > 0)
                            item.MoM = (item.Value - match.Value) / match.Value * 100;
                    }

                    item.ShipInfoId = virtualShip.Id;
                    _monitorIndicatorRecordService.Add(item);
                }

                _monitorIndicatorRecordService.RemoveToHistory(modelList: monitorResult.ToArray());

                _dataSyncRecordService.Update(syncRecord);
            }
            catch (Exception e)
            {
                FrameworkLog.LogModel.LogHelper.WriteErrorLog($"StatisMonitorIndicator数据同步失败", e);
            }
        }

        /// <summary>
        /// 迁移至历史记录
        /// </summary>
        /// <param name="monitorIndicatorRecordList"></param>
        private void MoveToHistory(params MonitorIndicatorRecord[] monitorIndicatorRecordList)
        {
            _monitorIndicatorRecordService.RemoveToHistory(modelList: monitorIndicatorRecordList);
        }

        /// <summary>
        /// 获取同步状态
        /// </summary>
        /// <param name="virtualShip"></param>
        /// <returns></returns>
        private DataSyncRecord GetSyncRecord(ShipInfo virtualShip)
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

        /// <summary>
        /// 更新同步状态
        /// </summary>
        /// <param name="dataSyncRecord"></param>
        private void UpdateyncRecord(DataSyncRecord dataSyncRecord)
        {
            if (dataSyncRecord.Id < 0)
                _dataSyncRecordService.Add(dataSyncRecord);
            else
                _dataSyncRecordService.Update(dataSyncRecord);
        }
    }
}
