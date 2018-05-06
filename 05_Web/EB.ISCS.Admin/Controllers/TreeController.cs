using EB.ISCS.Common.BaseController;
using System.Collections.Generic;
using System.Linq;

namespace EB.ISCS.Admin.Controllers
{
    /// <summary>
    /// treeview common controller
    /// </summary>
    public class TreeController : BaseController
    {
        /// <summary>
        /// generate client tree model
        /// </summary>
        /// <param name="items">all nodes</param>
        /// <param name="pid">parent id</param>
        /// <returns></returns>
        private List<TreeItemViewModel> GenerateTreeViewModel(IList<TreeItemViewModel> items, int pid)
        {
            var result = new List<TreeItemViewModel>();
            var fathers = items?.Where(t => t.fatherId == pid);
            foreach (var item in fathers)
            {
                item.children = GenerateTreeViewModel(items, item.id);
                result.Add(item);
            }

            return result;
        }
 
        private IList<TreeItemViewModel> MockData()
        {
            var model = new List<TreeItemViewModel>();

            model.Add(new TreeItemViewModel { id = 1, fatherId = 0, text = "11111" });
            model.Add(new TreeItemViewModel { id = 2, fatherId = 1, text = "11111" });
            model.Add(new TreeItemViewModel { id = 3, fatherId = 0, text = "22222" });
            model.Add(new TreeItemViewModel { id = 4, fatherId = 1, text = "11111" });
            model.Add(new TreeItemViewModel { id = 5, fatherId = 2, text = "3333" });
            model.Add(new TreeItemViewModel { id = 6, fatherId = 2, text = "11111" });
            model.Add(new TreeItemViewModel { id = 7, fatherId = 0, text = "4444444" });
            model.Add(new TreeItemViewModel { id = 8, fatherId = 1, text = "11111" });
            model.Add(new TreeItemViewModel { id = 9, fatherId = 3, text = "99999999" });
            model.Add(new TreeItemViewModel { id = 10, fatherId = 4, text = "11111" });
            model.Add(new TreeItemViewModel { id = 11, fatherId = 10, text = "11111" });
            model.Add(new TreeItemViewModel { id = 12, fatherId = 0, text = "11111" });
            model.Add(new TreeItemViewModel { id = 13, fatherId = 12, text = "11111" });
            model.Add(new TreeItemViewModel { id = 14, fatherId = 9, text = "333333333" });

            return model;
        }
    }
}