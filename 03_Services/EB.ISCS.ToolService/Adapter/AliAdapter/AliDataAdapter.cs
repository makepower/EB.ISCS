using Maticsoft.Model;
using System.Collections.Generic;
using System.Linq;
using Top.Api.Domain;

namespace EB.ISCS.ToolService.Adapter.AliAdapter
{
    public static class AliDataAdapter
    {
        public static List<OrderInfo> ToWayBill(this List<Trade> list)
        {
            var bills = new List<OrderInfo>();
            if (list == null || !list.Any())
                return bills;
            list.ForEach(x =>
            {
                var bill = new OrderInfo()
                {
                    GoodNum = x.Num,
                    GoodFee = decimal.Parse(x.TotalFee),
                    BuyerId = x.BuyerAlipayNo,

                };
                bills.Add(bill);
            });
            return bills;
        }
    }
}
