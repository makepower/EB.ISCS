using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.ISCS.Common.DataModel
{
    public class QueryFromModel : SearchCondition
    {
        /// <summary>
        /// 表格设计名称
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 表格设计分类Id
        /// </summary>
        public int DicType { get; set; }
    }
}
