using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.ISCS.ToolService.Adapter
{
    /// <summary>
    /// 物流公司信息
    /// </summary>
    public class ShipperInforResponse
    {
        public string EBusinessID { get; set; }

        public bool Success { get; set; }

        public string LogisticCode { get; set; }

        public Shipper[] Shippers { get; set; }


        public class Shipper
        {
            public string ShipperCode { get; set; }

            public string ShipperName { get; set; }
        }
    }

    /// <summary>
    /// 物流信息
    /// </summary>
    public class LogisticsInfoResponse
    {
        public string EBusinessID { get; set; } //String  用户ID R
        public string OrderCode { get; set; } //String  订单编号 O
        public string ShipperCode { get; set; } //String  快递公司编码 R
        public string LogisticCode { get; set; } //String  物流运单号 O
        public bool Success { get; set; } //Bool    成功与否 R
        public string Reason { get; set; } //String  失败原因 O
        public int State { get; set; } //String  物流状态：2-在途中,3-签收,4-问题件
        public List<Trace> Traces { get; set; }

        public class Trace
        {
            public string AcceptTime { get; set; }
            public string AcceptStation { get; set; }
            public string Remark { get; set; }
        }
    }
}
