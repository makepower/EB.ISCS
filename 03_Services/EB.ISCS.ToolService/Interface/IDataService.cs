using EB.ISCS.Common.Enum;
using Maticsoft.Model;

namespace EB.ISCS.ToolService
{
    interface ISyncDataService : IService
    {

        string TradesSoldGetUrl { get; }

        string TradesSoldIncrementGetUrl { get; }


        string TradeFullinfoGetUrl { get; }

        string LogisticsOrdersGetUrl { get; }
    }
}
