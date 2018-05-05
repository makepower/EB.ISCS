using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Newtonsoft.Json;
using EB.ISCS.Common.BaseController;
using EB.ISCS.Common.DataModel;
using EB.ISCS.Common.Models;
using EB.ISCS.FrameworkEntity.SystemEntity;
using EB.ISCS.FrameworkHelp.Utilities;

namespace EB.ISCS.Admin.Controllers
{
    /// <summary>
    /// 公共控制器
    /// </summary>
    public class CommonController : BaseController
    {
      
       

        /// <summary>
        /// 获取当前用户在当前页面上面的按钮权限
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetUserPagePermissions(int menuId)
        {
            QueryUserPermissionModel queryModel = new QueryUserPermissionModel(this.CurrentUser.UserId, menuId);
            var result = ServiceHelper.CallService<List<SysMenuPermission>>(
                ServiceConst.CommonService.GetUserPagePermissions,
                JsonConvert.SerializeObject(queryModel),
                this.CurrentUser.Token);
            if (result.Code == (int)ResultCode.Success)
            {
                var isSuperAdmin = this.CurrentUser.LoginName.Equals("superadmin") && (this.CurrentUser.UserIsManage == 1);
                return Json(new
                {
                    permissions = result.Data,
                    isSuperAdmin = isSuperAdmin,
                    message = result.Message
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(
                    new
                    {
                        permissions = new List<SysMenuPermission>(),
                        isSuperAdmin = false,
                        message = result.Message
                    },
                    JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 获取指定枚举的键值对类型 value，描述
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetEnumKeyDescripion(string name)
        {
            var result = ServiceHelper.CallService<List<EnumItem>>($"{ServiceConst.CommonService.GetEnumKeyDescripion}?enumName={name}", null,
                this.CurrentUser.Token);
            List<TreeItemViewModel> list = new List<TreeItemViewModel>();
            if (result.Data.Count > 0)
            {
                list.Add(new TreeItemViewModel() { id = 0, text = "----请选择----" });
                result.Data.ForEach(x =>
                    list.Add(new TreeItemViewModel()
                    {
                        id = Convert.ToInt32(x.Key),
                        text = x.Value.ToString()
                    }));
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    
        //获取当前登录用户信息
        public ActionResult GetCurrentUser()
        {
            return Json(this.CurrentUser, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult GetGridHeader()
        {
            string strGvXml = Request.Form["GV_XML"];   //XML名称

            string strXmlParent = "Xml";
            DataTable dtResult = new DataTable("FieldsList");

            dtResult.Columns.Add("Name", typeof(string));
            dtResult.Columns.Add("FieldName", typeof(string));
            dtResult.Columns.Add("Width", typeof(string));
            dtResult.Columns.Add("Align", typeof(string));
            dtResult.Columns.Add("IsSort", typeof(string));
            dtResult.Columns.Add("sumwidth", typeof(string));
            dtResult.Columns.Add("display_sort", typeof(string));
            dtResult.Columns.Add("data_type", typeof(string));
            dtResult.Columns.Add("if_need", typeof(string));
            dtResult.Columns.Add("if_editor", typeof(string));

            double dbTotalWidth = 0;
            XmlDocument xmlDoc = new XmlDocument();
            string fileName = GetPhysicalApplicationPath + strXmlParent + "\\GV_Xml\\" + strGvXml + ".xml";

            xmlDoc.Load(fileName);
            XmlNodeList xWitsTablesList = xmlDoc.SelectNodes("/config");
            if (xWitsTablesList != null)
                foreach (XmlNode xOracleNode in xWitsTablesList)
                {
                    foreach (XmlNode node2 in xOracleNode.ChildNodes)
                    {
                        if (node2.Attributes != null && IsXMLUtility.XmlHelper.GetAttributeInnerText(node2.Attributes["Desc"]) == "在用")
                        {
                            DataRow dr = dtResult.NewRow();
                            dr["Name"] = IsXMLUtility.XmlHelper.GetAttributeInnerText(node2.Attributes["Name"]);
                            dr["FieldName"] =
                                IsXMLUtility.XmlHelper.GetAttributeInnerText(node2.Attributes["FieldName"]);
                            dr["Width"] = IsXMLUtility.XmlHelper.GetAttributeInnerText(node2.Attributes["Width"]);
                            dbTotalWidth +=
                                Convert.ToDouble(
                                    IsXMLUtility.XmlHelper.GetAttributeInnerText(node2.Attributes["Width"]));
                            dr["Align"] =
                                IsXMLUtility.XmlHelper.GetAttributeInnerText(node2.Attributes["Align"]).Length == 0
                                    ? "Left"
                                    : IsXMLUtility.XmlHelper.GetAttributeInnerText(node2.Attributes["Align"]);
                            dr["Width"] = IsXMLUtility.XmlHelper.GetAttributeInnerText(node2.Attributes["Width"]);
                            dr["IsSort"] =
                                IsXMLUtility.XmlHelper.GetAttributeInnerText(node2.Attributes["IsSort"]).Length == 0
                                    ? "true"
                                    : IsXMLUtility.XmlHelper.GetAttributeInnerText(node2.Attributes["IsSort"]);
                            dr["data_type"] =
                                IsXMLUtility.XmlHelper.GetAttributeInnerText(node2.Attributes["data_type"]).Length == 0
                                    ? "1"
                                    : IsXMLUtility.XmlHelper.GetAttributeInnerText(node2.Attributes["data_type"]);
                            dr["if_need"] =
                                IsXMLUtility.XmlHelper.GetAttributeInnerText(node2.Attributes["if_need"]).Length == 0
                                    ? "1"
                                    : IsXMLUtility.XmlHelper.GetAttributeInnerText(node2.Attributes["if_need"]);
                            dr["if_editor"] =
                                IsXMLUtility.XmlHelper.GetAttributeInnerText(node2.Attributes["if_editor"]).Length == 0
                                    ? "1"
                                    : IsXMLUtility.XmlHelper.GetAttributeInnerText(node2.Attributes["if_editor"]);
                            dtResult.Rows.Add(dr);
                        }
                    }
                }
            foreach (DataRow dr in dtResult.Rows)
            {
                dr["sumwidth"] = dbTotalWidth.ToString(CultureInfo.InvariantCulture);
            }
            var res = DataTableToJson(dtResult);
            return Content(res, "application/json");
        }
        /// <summary>
        /// 返回 服务器应用程序的根目录的物理文件系统路径
        /// </summary>
        /// <returns></returns>
        public static string GetPhysicalApplicationPath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }
        }

        /// <summary>      
        /// dataTable转换成Json格式      
        /// </summary>      
        /// <param name="dt"></param>   
        /// <param name="message">自定义Json传入拼接</param>
        /// <returns></returns>      
        public static string DataTableToJson(DataTable dt, string message = "", int iPage = 0, int iRows = 0)
        {
            int iStartIndex = 0;
            int iEndIndex = 0;
            int iMaxIndex = dt.Rows.Count;  //最大数值
            if (iPage > 0)
            {
                iStartIndex = (iPage - 1) * iRows;
                iEndIndex = iRows * iPage - 1;
                iEndIndex = (iEndIndex > iMaxIndex ? iMaxIndex : iEndIndex);
            }
            else
            {
                iStartIndex = 0;
                iEndIndex = iMaxIndex;
            }
            StringBuilder strJsonData = new StringBuilder();
            strJsonData.Append("[");
            for (int i = iStartIndex; i < iEndIndex; i++)
            {
                strJsonData.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    strJsonData.Append("\"");
                    strJsonData.Append(dt.Columns[j].ColumnName.ToUpper().Trim());
                    strJsonData.Append("\":\"");
                    strJsonData.Append(dt.Rows[i][j].ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", ""));
                    strJsonData.Append("\",");
                }
                strJsonData.Remove(strJsonData.Length - 1, 1);
                strJsonData.Append("},");
            }
            if (strJsonData.Length > 1)
            {
                strJsonData.Remove(strJsonData.Length - 1, 1);
            }

            if (message != "")
            {
                strJsonData.Append(message);
            }

            strJsonData.Append("]");
            return strJsonData.ToString();
        }
 
    }
}