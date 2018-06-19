using AutoMapper;
using Maticsoft.Model;
using Maticsoft.Model.ISSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.ISCS.ToolService.Adapter.JdAdapter
{
   public static class JdDataAdapter
    {
        public static List<Trades> ToLocalTrades(this List<Jd.Api.Domain.OrderInfo> list, ShipInfo ship)
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

        public static List<GoodInfo> ToLocalGoods(this List<Jd.Api.Domain.Product> list, ShipInfo ship)
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

        public static OrderInfo ToLocalOrder(this Jd.Api.Domain.OrderInfo order, ShipInfo ship)
        {
            var tradeList = new OrderInfo();
            if (order == null)
                return tradeList;

            return Mapper.Map<OrderInfo>(order); ;
        }
    }
}
