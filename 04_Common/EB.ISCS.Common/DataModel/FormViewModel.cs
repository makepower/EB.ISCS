using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.ISCS.Common.DataModel
{
    public class FormPropertyModel
    {
        public FormViewModel[] List { get; set; }
        public int UserId { get; set; }
    }

    /// <summary>
    /// 映射页面模型Json
    /// </summary>
    public class FormViewModel
    {
        public string id { get; set; }
        public string dataType { get; set; }
        public string defaultValue { get; set; }
        public string format { get; set; }
        public int height { get; set; }
        public string modelType { get; set; }
        public string name { get; set; }
        public string percent { get; set; }
        public string pro { get; set; }
        public string rows { get; set; }
        public FormViewSettingModel setting { get; set; }
        public dynamic source { get; set; }
        public string tag { get; set; }
        public string validate { get; set; }
        public int temId { get; set; }
        public int formId { get; set; }
    }

    public class FormViewSettingModel
    {
        public string dataFormats { get; set; }
        public int fontSize { get; set; }
        public int minView { get; set; }
        public string move { get; set; }
    }
}
