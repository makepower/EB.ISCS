using EB.ISCS.DapperServices.Repository;
using EB.ISCS.DapperServices.Services;
using EB.ISCS.FrameworkEntity;
using EB.ISCS.ToolService.Adapter.AliAdapter;
using EB.ISCS.ToolService.TripartiteDataService;
using Maticsoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.ISCS.ToolService
{
    public class AliDataServiceWrapper
    {

        public DateTime SyncDateTime
        {
            get
            {
                return dataSyncRecord.LastSynDate;
            }
        }

        private TradesService tradesService;
        private GoodInfoService goodInfoService;
        private DataSyncRecordService recordService;
        private DataSyncRecord dataSyncRecord;
        public AliDataServiceWrapper(string constr)
        {
            tradesService = new TradesService(constr);
            goodInfoService = new GoodInfoService(tradesService);
            recordService = new DataSyncRecordService(tradesService);
        }

        public void SyncData(ShipInfo info)
        {
            dataSyncRecord = recordService.GetRecordByShipId(info.Id);
            var service = new AliDataService();
            if (info.Status == 1)
            {
                // 初始化交易订单
                var trades = service.InitTradeSold(info).ToLocalTrades(info);
                trades?.ForEach(x => tradesService.Add(x));
                // 初始化商品数据
                var goods = service.QueryShopCatsInfo(info).ToLocalGoods(info);
                goods?.ForEach(x => goodInfoService.Add(x));
            }
            // 增量数据
            var incrementTrades = service.QueryTradeSoldIncrement(info, dataSyncRecord).ToLocalTrades(info);
            incrementTrades?.ForEach(x => tradesService.Add(x));

            // 运营数据
        }
    }
}
