using System.Collections.Generic;

namespace EB.ISCS.Common
{
    public class TreeNode
    {
        public int id { get; set; }
        public int pid { get; set; }
        public string text { get; set; }
        public List<TreeNode> children { get; set; }
    }
}
