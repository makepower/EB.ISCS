using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.ISCS.Common.BaseController
{
    public class NavigationItem
    {
        public NavigationItem() { }

        public List<NavigationItem> Children { get; set; }
        public string IconClass { get; set; }
        public string Target { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int MenuId { get; set; }
    }
}
