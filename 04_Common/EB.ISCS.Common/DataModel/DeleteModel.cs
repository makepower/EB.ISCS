using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.ISCS.Common.DataModel
{
    /// <summary>
    /// 删除数据实体
    /// </summary>
    public class DeleteModel : BaseModel
    {
        /// <summary>
        /// Data Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 删除数据Id字符串
        /// </summary>
        public string DelString { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// sql名称或where条件
        /// </summary>
        public string SqlName { get; set; }
    }
}
