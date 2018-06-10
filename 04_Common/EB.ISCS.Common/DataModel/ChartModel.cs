using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.ISCS.Common.DataModel
{
    /// <summary>
    /// 简易图标数据源 只存x y轴数据
    /// </summary>
    public class ChartModel
    {
        public List<dynamic> XAxis { get; set; }
        public List<dynamic>[] Series { get; set; }
    }
}
