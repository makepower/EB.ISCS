using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EB.ISCS.Common.Models
{
    /// <summary>
    /// 表单值模型
    /// </summary>
    public class FormDataModel
    {
        /// <summary>
        /// 节点GUID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        public string datatype { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string value { get; set; }

        #region ===static method==
        /// <summary>
        /// 从内容字符中加载表单数据
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static List<FormDataModel> LoadArrayFromJsonStr(string content)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<FormDataModel>>(content);
            }
            catch (Exception)
            {
                return new List<FormDataModel>();
            }
        }

        /// <summary>
        /// 从内容字符中加载表单数据
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static FormDataModel LoadFromJsonStr(string content)
        {
            try
            {
                return JsonConvert.DeserializeObject<FormDataModel>(content);
            }
            catch (Exception)
            {
                return new FormDataModel();
            }
        }
        #endregion
    }
}
