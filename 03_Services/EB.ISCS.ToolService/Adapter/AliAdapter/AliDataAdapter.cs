using AutoMapper;
using Maticsoft.Model;
using Maticsoft.Model.ISSC;
using System.Collections.Generic;
using System.Linq;
using Top.Api.Domain;

namespace EB.ISCS.ToolService.Adapter.AliAdapter
{
    public static class AliDataAdapter
    {
        public static List<Trades> ToLocalTrades(this List<Trade> list, ShipInfo ship)
        {
            var tradeList = new List<Trades>();
            if (list == null || !list.Any())
                return tradeList;
            list.ForEach(x =>
            {
                var trade = Mapper.Map<Trades>(x);
                trade.ShipId = ship.Id;
                trade.UserId = ship.UserId;
                tradeList.Add(trade);
            });
            return tradeList;
        }

        public static List<GoodInfo> ToLocalGoods(this List<Product> list, ShipInfo ship)
        {
            var tradeList = new List<GoodInfo>();
            if (list == null || !list.Any())
                return tradeList;
            list.ForEach(x =>
            {
                var trade = Mapper.Map<GoodInfo>(x);
                tradeList.Add(trade);
            });
            return tradeList;
        }

        public static OrderInfo ToLocalOrder(this Order order, ShipInfo ship)
        {
            var tradeList = new OrderInfo();
            if (order == null)
                return tradeList;
           
            return Mapper.Map<OrderInfo>(order); ;
        }

        public static OrderDetail ToLocalOrderDetail(this Order order, ShipInfo ship)
        {
            var tradeList = new OrderDetail();
            if (order == null)
                return tradeList;

            return Mapper.Map<OrderDetail>(order); ;
        }
    }
}
