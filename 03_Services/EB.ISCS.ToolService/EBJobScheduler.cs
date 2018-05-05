using EB.ISCS.ToolService.TripartiteDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EB.ISCS.ToolService
{
    public class EBJobScheduler
    {
        private List<IDataService> _dataProviderThirdPart;

        EBJobScheduler()
        {
            _dataProviderThirdPart = new List<IDataService>
            {
                new AliDataService(),
                new JdDataService()
            };

        }


        public static EBJobScheduler Default
        {
            get
            {
                return new EBJobScheduler();
            }
        }

        public void DoJob()
        {
            _dataProviderThirdPart.ForEach(d =>
            {
                try
                {
                    d.SyncData();
                }
                catch (Exception ex)
                {
                    FrameworkLog.LogModel.LogHelper.WriteErrorLog("同步数据出错", ex);
                }

            });
        }

        public string CornExpression { get; set; }
    }
}
