using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.ISCS.Common
{
    public class TreeBuilder
    {
        public static List<TreeNode> GetChildrenNodes(List<TreeNode> all, TreeNode curNode = null)
        {
            if (curNode == null) curNode = new TreeNode { id = 0 };
            List<TreeNode> childrens = all.Where(c => c.pid == curNode.id).ToList();
            foreach (var item in childrens)
            {
                item.children = GetChildrenNodes(all, item);
            }
            return childrens;
        }
    }
}
