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
        public AliDataServiceWrapper(string constr)
        {

        }

        public void SyncData(ShipInfo info)
        {
            var service = new AliDataService();
            service.InitTradeSold(info);
        }
    }
}
