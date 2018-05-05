using System.Collections.Generic;

namespace EB.ISCS.Common.BaseController
{
    public class TreeItemViewModel
    {
        public int id { get; set; }

        public int code { get; set; }
        public int fatherId { get; set; }
        public string text { get; set; }

        public int sort { get; set; }
        public string iconCls { get; set; }
        public IEnumerable<TreeItemViewModel> children { get; set; }
    }
}
