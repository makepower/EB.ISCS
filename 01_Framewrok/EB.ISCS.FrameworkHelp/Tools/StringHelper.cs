using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;


namespace EB.ISCS.Framework.Utilities.String
{
    /// <summary>
    /// 提供字符串相关想法集合
    /// 1、GetStrArray(string str, char speater, bool toLower)  把字符串按照分隔符转换成 List
    /// 2、GetStrArray(string str) 把字符串转 按照, 分割 换为数据
    /// 3、GetArrayStr(List list, string speater) 把 List 按照分隔符组装成 string
    /// 4、GetArrayStr(List list)  得到数组列表以逗号分隔的字符串
    /// 5、GetArrayValueStr(Dictionary<int, int> list)得到数组列表以逗号分隔的字符串
    /// 6、DelLastComma(string str)删除最后结尾的一个逗号
    /// 7、DelLastChar(string str, string strchar)删除最后结尾的指定字符后的字符
    /// 8、ToSBC(string input)转全角的函数(SBC case)
    /// 9、ToDBC(string input)转半角的函数(SBC case)
    /// 10、GetSubStringList(string o_str, char sepeater)把字符串按照指定分隔符装成 List 去除重复
    /// 11、GetCleanStyle(string StrList, string SplitString)将字符串样式转换为纯字符串
    /// 12、GetNewStyle(string StrList, string NewStyle, string SplitString, out string Error)将字符串转换为新样式
    /// 13、SplitMulti(string str, string splitstr)分割字符串
    /// 14、SqlSafeString(string String, bool IsDel)
    /// </summary>
    public static class StringHelper
    {


        /// <summary>
        /// 去掉字符串的前后空格。当字符串为null时，返回null
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string TrimString(string s)
        {
            return s == null ? null : s.Trim();
        }

        /// <summary>
        /// Encodes all the characters in the specified System.String into a sequence of bytes.
        /// </summary>
        /// <param name="s"></param>
        /// <returns>A byte array containing the results of encoding the specified set of characters.</returns>
        /// <exception cref="System.ArgumentNullException">s is null.</exception>
        public static byte[] ConvertToBytes(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }

            return ConvertToBytes(s, new ASCIIEncoding());
        }

        /// <summary>
        /// Encodes all the characters in the specified System.String into a sequence of bytes.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="encoding"></param>
        /// <returns>A byte array containing the results of encoding the specified set of characters.</returns>
        /// <exception cref="System.ArgumentNullException">s is null.</exception>
        public static byte[] ConvertToBytes(string s, Encoding encoding)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }

            return encoding.GetBytes(s);
        }
        /// <summary>
        /// 判断一个字符是否是 数字型
        /// </summary>
        /// <param name="numStr"></param>
        /// <returns></returns>
        public static bool IsNumber(string numStr)
        {
            decimal a;
            return decimal.TryParse(numStr, out a);
        }
        /// <summary>
        /// 判断一个字符串是否是INT型 的
        /// </summary>
        /// <param name="intStr"></param>
        /// <returns></returns>
        public static bool IsInt(string intStr)
        {
            int a;
            return int.TryParse(intStr, out a);
        }
        /// <summary>
        /// JavaScript 转义符
        /// </summary>
        /// <param name="sourceString"></param>
        /// <returns></returns>
        public static string JSEscapeCharacter(string sourceString)
        {
            string escape = sourceString;
            if (sourceString.Contains("|"))
            {
                escape = escape.Replace('|', ' ');
            }
            escape = escape.Replace(@"\", "\\");
            escape = escape.Replace("'", "\\\'");
            escape = escape.Replace("\r\n", "");
            return escape;
        }
        private static char[][] WhitelistCodes = InitWhitelistCodes();
        /// <summary>
        /// InternalHtmlEncode
        /// </summary>
        /// <param name="input">input</param>
        /// <returns></returns>
        public static string InternalHtmlEncode(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            int length = 0;
            int num2 = input.Length;
            char[] chArray = new char[num2 * 8];
            for (int i = 0; i < num2; i++)
            {
                int index = input[i];
                if (WhitelistCodes[index] != null)
                {
                    char[] chArray2 = WhitelistCodes[index];
                    chArray[length++] = '&';
                    chArray[length++] = '#';
                    for (int j = 0; j < chArray2.Length; j++)
                    {
                        chArray[length++] = chArray2[j];
                    }
                    chArray[length++] = ';';
                }
                else
                {
                    chArray[length++] = input[i];
                }
            }
            return new string(chArray, 0, length);
        }
        private static char[][] InitWhitelistCodes()
        {
            char[][] chArray = new char[0x10000][];
            for (int i = 0; i < chArray.Length; i++)
            {
                if ((((((i >= 0x61) && (i <= 0x7a)) || ((i >= 0x41) && (i <= 90))) || (((i >= 0x30) && (i <= 0x39)) || ((((i == 0x20) || (i == 0x2e)) || ((i == 0x2c) || (i == 0x2d))) || ((i == 0x5f) || ((i >= 0x100) && (i <= 0x24f)))))) || ((((i >= 880) && (i <= 0x7ff)) || ((i >= 0x900) && (i <= 0x18af))) || (((i >= 0x1900) && (i <= 0x1a1f)) || ((i >= 0x1b00) && (i <= 0x1b7f))))) || (((((i >= 0x1e00) && (i <= 0x1fff)) || ((i >= 0x2c00) && (i <= 0x2ddf))) || (((i >= 0x3040) && (i <= 0x312f)) || ((i >= 0x3190) && (i <= 0x31bf)))) || (((((i >= 0x31f0) && (i <= 0x31ff)) || ((i >= 0xa000) && (i <= 0xa4cf))) || (((i >= 0xa720) && (i <= 0xa82f)) || ((i >= 0xa840) && (i <= 0xa87f)))) || (((i >= 0xac00) && (i <= 0xd7af)) || ((i >= 0x4e00) && (i <= 0x9fc3))))))
                {
                    chArray[i] = null;
                }
                else
                {
                    string str = i.ToString();
                    int length = str.Length;
                    char[] chArray2 = new char[length];
                    for (int j = 0; j < length; j++)
                    {
                        chArray2[j] = str[j];
                    }
                    chArray[i] = chArray2;
                }
            }
            return chArray;
        }
        /// <summary>
        /// IP地址转换为数字
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public static uint IPToInt(string ipAddress)
        {
            string disjunctiveStr = ".,: ";
            char[] delimiter = disjunctiveStr.ToCharArray();
            string[] startIP = null;
            for (int i = 1; i <= 5; i++)
            {
                startIP = ipAddress.Split(delimiter, i);
            }
            string a1 = startIP[0].ToString();
            string a2 = startIP[1].ToString();
            string a3 = startIP[2].ToString();
            string a4 = startIP[3].ToString();
            uint U1 = uint.Parse(a1);
            uint U2 = uint.Parse(a2);
            uint U3 = uint.Parse(a3);
            uint U4 = uint.Parse(a4);

            uint U = U1 << 24;
            U += U2 << 16;
            U += U3 << 8;
            U += U4;
            return U;
        }
        /// <summary>
        /// 数字转换为IP地址
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public static string IntToIP(uint ipAddress)
        {
            long ui1 = ipAddress & 0xFF000000;
            ui1 = ui1 >> 24;
            long ui2 = ipAddress & 0x00FF0000;
            ui2 = ui2 >> 16;
            long ui3 = ipAddress & 0x0000FF00;
            ui3 = ui3 >> 8;
            long ui4 = ipAddress & 0x000000FF;
            string IPstr = "";
            IPstr = System.Convert.ToString(ui1) + "." + System.Convert.ToString(ui2) + "." + System.Convert.ToString(ui3) + "." + System.Convert.ToString(ui4);
            return IPstr;
        }


        public static bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input) || input.Trim() == string.Empty;
        }

        /// <summary>
        /// Gets the left string.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <param name="leftLength">Length of the left.</param>
        /// <returns></returns>
        public static string GetLeftString(string description, int leftLength)
        {
            if (IsNullOrEmpty(description) || description.Length <= leftLength)
            {
                return description;
            }
            return description.Substring(0, leftLength);
        }
        /// <summary>
        /// Gets the right string.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <param name="leftLength">Length of the left.</param>
        /// <returns></returns>
        public static string GetRightString(string description, int leftLength)
        {
            if (IsNullOrEmpty(description) || description.Length <= leftLength)
            {
                return description;
            }
            return description.Substring(description.Length - leftLength);
        }

        /// <summary>
        /// Trims the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>return trim value,if value can convert to string;otherwise,return null.</returns>
        public static string Trim(object value)
        {
            string convertible = Convert.ToString(value);
            if (string.IsNullOrEmpty(convertible))
            {
                return convertible;
            }
            return convertible.Trim();
        }

        public static string ConvertString(string description, string defaultValue)
        {
            if (IsNullOrEmpty(description))
            {
                return defaultValue;
            }
            return description;
        }

        public static string ConvertString(string description)
        {
            if (IsNullOrEmpty(description))
            {
                return "";
            }
            return description;
        }

        //public static string XMLEncode(string strText)
        //{
        //    if (string.IsNullOrEmpty(strText))
        //    {
        //        return string.Empty;
        //    }
        //    string strTextRet = strText;
        //    strTextRet = strTextRet.Replace("&", "&amp;");
        //    strTextRet = strTextRet.Replace("\"", "&quot;");
        //    strTextRet = strTextRet.Replace("'", "&apos;");
        //    strTextRet = strTextRet.Replace("<", "&lt;");
        //    strTextRet = strTextRet.Replace(">", "&gt;");
        //    return strTextRet;
        //}

        public static string XmlDecode(string data)
        {
            if (IsNullOrEmpty(data))
            {
                return string.Empty;
            }
            return Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(data, "&apos;", "'", RegexOptions.IgnoreCase), "&quot;", "\"", RegexOptions.IgnoreCase), "&lt;", "<", RegexOptions.IgnoreCase), "&gt;", ">", RegexOptions.IgnoreCase), "&amp;", "&", RegexOptions.IgnoreCase);
        }

        public static string XmlEncode(string data)
        {
            if (IsNullOrEmpty(data))
            {
                return string.Empty;
            }
            return data.Replace("&", "&amp;").Replace(">", "&gt;").Replace("<", "&lt;").Replace("\"", "&quot;").Replace("'", "&apos;");
        }

        public static XmlNode GetSingleNode(XmlDocument input, string xPath)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(input.NameTable);
            nsmgr = null;

            return GetSingleNode(input, xPath, nsmgr);
        }

        public static XmlNode GetSingleNode(XmlDocument input, string xPath, XmlNamespaceManager nsmgr)
        {
            XmlNode m_return = null;
            try
            {
                if (nsmgr == null)
                {
                    m_return = input.SelectSingleNode(xPath);
                }
                else
                {
                    m_return = input.SelectSingleNode(xPath, nsmgr);
                }
            }
            catch { }

            return m_return;
        }
        /// <summary>
        /// Filters the blank control string.
        /// </summary>
        /// <param name="val">The val.</param>
        /// <returns></returns>
        public static string FilterBlankControlString(string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                return string.Empty;
            }
            return val.Replace("\r", "").Replace("\n", "").Replace("\t", "");
        }
        /// <summary>
        /// Gets the separation string by comma.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public static string GetSeparationStringByComma(ICollection values)
        {
            if (values == null || values.Count == 0)
            {
                return string.Empty;
            }
            string ret = string.Empty;
            foreach (object item in values)
            {
                if (item == null)
                {
                    continue;
                }
                ret += item.ToString() + ",";
            }
            return string.IsNullOrEmpty(ret) ? ret : ret.Substring(0, ret.Length - 1);
        }
        /// <summary>
        /// Gets the separation string by comma and single quotes.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public static string GetSeparationStringByCommaAndSingleQuotes(ICollection values)
        {
            if (values == null || values.Count == 0)
            {
                return string.Empty;
            }
            string ret = string.Empty;
            foreach (object item in values)
            {
                if (item == null)
                {
                    continue;
                }
                ret += "'" + item.ToString() + "',";
            }
            return string.IsNullOrEmpty(ret) ? ret : ret.Substring(0, ret.Length - 1);
        }


        /// <summary>
        /// 把字符串按照分隔符转换成 List
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="speater">分隔符</param>
        /// <param name="toLower">是否转换为小写</param>
        /// <returns></returns>
        public static List<string> GetStrArray(string str, char speater, bool toLower)
        {
            List<string> list = new List<string>();
            string[] ss = str.Split(speater);
            foreach (string s in ss)
            {
                if (!string.IsNullOrEmpty(s) && s != speater.ToString())
                {
                    string strVal = s;
                    if (toLower)
                    {
                        strVal = s.ToLower();
                    }
                    list.Add(strVal);
                }
            }
            return list;
        }
        /// <summary>
        /// 把字符串转 按照, 分割 换为数据
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string[] GetStrArray(string str)
        {
            return str.Split(new Char[] { ',' });
        }
        /// <summary>
        /// 把 List<string> 按照分隔符组装成 string
        /// </summary>
        /// <param name="list"></param>
        /// <param name="speater"></param>
        /// <returns></returns>
        public static string GetArrayStr(List<string> list, string speater)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                {
                    sb.Append(list[i]);
                }
                else
                {
                    sb.Append(list[i]);
                    sb.Append(speater);
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 得到数组列表以逗号分隔的字符串
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string GetArrayStr(List<int> list)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                {
                    sb.Append(list[i].ToString());
                }
                else
                {
                    sb.Append(list[i]);
                    sb.Append(",");
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 得到数组列表以逗号分隔的字符串
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string GetArrayValueStr(Dictionary<int, int> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<int, int> kvp in list)
            {
                sb.Append(kvp.Value + ",");
            }
            if (list.Count > 0)
            {
                return DelLastComma(sb.ToString());
            }
            else
            {
                return "";
            }
        }


        #region 删除最后一个字符之后的字符

        /// <summary>
        /// 删除最后结尾的一个逗号
        /// </summary>
        public static string DelLastComma(string str)
        {
            return str.Substring(0, str.LastIndexOf(","));
        }

        /// <summary>
        /// 删除最后结尾的指定字符后的字符
        /// </summary>
        public static string DelLastChar(string str, string strchar)
        {
            return str.Substring(0, str.LastIndexOf(strchar));
        }
        /// <summary>
        /// 删除最后结尾的长度
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string DelLastLength(string str, int Length)
        {
            if (string.IsNullOrEmpty(str))
                return "";
            str = str.Substring(0, str.Length - Length);
            return str;
        }
        #endregion

        /// <summary>
        /// 转全角的函数(SBC case)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToSBC(string input)
        {
            //半角转全角：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }

        /// <summary>
        ///  转半角的函数(SBC case)
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns></returns>
        public static string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }

        /// <summary>
        /// 把字符串按照指定分隔符装成 List 去除重复
        /// </summary>
        /// <param name="o_str"></param>
        /// <param name="sepeater"></param>
        /// <returns></returns>
        public static List<string> GetSubStringList(string o_str, char sepeater)
        {
            List<string> list = new List<string>();
            string[] ss = o_str.Split(sepeater);
            foreach (string s in ss)
            {
                if (!string.IsNullOrEmpty(s) && s != sepeater.ToString())
                {
                    list.Add(s);
                }
            }
            return list;
        }


        #region 将字符串样式转换为纯字符串
        /// <summary>
        ///  将字符串样式转换为纯字符串
        /// </summary>
        /// <param name="StrList"></param>
        /// <param name="SplitString"></param>
        /// <returns></returns>
        public static string GetCleanStyle(string StrList, string SplitString)
        {
            string RetrunValue = "";
            //如果为空，返回空值
            if (StrList == null)
            {
                RetrunValue = "";
            }
            else
            {
                //返回去掉分隔符
                string NewString = "";
                NewString = StrList.Replace(SplitString, "");
                RetrunValue = NewString;
            }
            return RetrunValue;
        }
        #endregion

        #region 将字符串转换为新样式
        /// <summary>
        /// 将字符串转换为新样式
        /// </summary>
        /// <param name="StrList"></param>
        /// <param name="NewStyle"></param>
        /// <param name="SplitString"></param>
        /// <param name="Error"></param>
        /// <returns></returns>
        public static string GetNewStyle(string StrList, string NewStyle, string SplitString, out string Error)
        {
            string ReturnValue = "";
            //如果输入空值，返回空，并给出错误提示
            if (StrList == null)
            {
                ReturnValue = "";
                Error = "请输入需要划分格式的字符串";
            }
            else
            {
                //检查传入的字符串长度和样式是否匹配,如果不匹配，则说明使用错误。给出错误信息并返回空值
                int strListLength = StrList.Length;
                int NewStyleLength = GetCleanStyle(NewStyle, SplitString).Length;
                if (strListLength != NewStyleLength)
                {
                    ReturnValue = "";
                    Error = "样式格式的长度与输入的字符长度不符，请重新输入";
                }
                else
                {
                    //检查新样式中分隔符的位置
                    string Lengstr = "";
                    for (int i = 0; i < NewStyle.Length; i++)
                    {
                        if (NewStyle.Substring(i, 1) == SplitString)
                        {
                            Lengstr = Lengstr + "," + i;
                        }
                    }
                    if (Lengstr != "")
                    {
                        Lengstr = Lengstr.Substring(1);
                    }
                    //将分隔符放在新样式中的位置
                    string[] str = Lengstr.Split(',');
                    foreach (string bb in str)
                    {
                        StrList = StrList.Insert(int.Parse(bb), SplitString);
                    }
                    //给出最后的结果
                    ReturnValue = StrList;
                    //因为是正常的输出，没有错误
                    Error = "";
                }
            }
            return ReturnValue;
        }
        #endregion

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="splitstr"></param>
        /// <returns></returns>
        public static string[] SplitMulti(string str, string splitstr)
        {
            string[] strArray = null;
            if ((str != null) && (str != ""))
            {
                strArray = new Regex(splitstr).Split(str);
            }
            return strArray;
        }
        public static string SqlSafeString(string String, bool IsDel)
        {
            if (IsDel)
            {
                String = String.Replace("'", "");
                String = String.Replace("\"", "");
                return String;
            }
            String = String.Replace("'", "&#39;");
            String = String.Replace("\"", "&#34;");
            return String;
        }

        #region 获取正确的Id，如果不是正整数，返回0
        /// <summary>
        /// 获取正确的Id，如果不是正整数，返回0
        /// </summary>
        /// <param name="_value"></param>
        /// <returns>返回正确的整数ID，失败返回0</returns>
        public static int StrToId(string _value)
        {
            if (IsNumberId(_value))
                return int.Parse(_value);
            else
                return 0;
        }
        #endregion

        #region 检查一个字符串是否是纯数字构成的，一般用于查询字符串参数的有效性验证。
        /// <summary>
        /// 检查一个字符串是否是纯数字构成的，一般用于查询字符串参数的有效性验证。(0除外)
        /// </summary>
        /// <param name="_value">需验证的字符串。。</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool IsNumberId(string _value)
        {
            return QuickValidate("^[1-9]*[0-9]*$", _value);
        }
        #endregion

        #region 快速验证一个字符串是否符合指定的正则表达式。
        /// <summary>
        /// 快速验证一个字符串是否符合指定的正则表达式。
        /// </summary>
        /// <param name="_express">正则表达式的内容。</param>
        /// <param name="_value">需验证的字符串。</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool QuickValidate(string _express, string _value)
        {
            if (_value == null) return false;
            Regex myRegex = new Regex(_express);
            if (_value.Length == 0)
            {
                return false;
            }
            return myRegex.IsMatch(_value);
        }
        #endregion

        #region 根据配置对指定字符串进行 MD5 加密
        /// <summary>
        /// 根据配置对指定字符串进行 MD5 加密
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string GetMD5(string s)
        {
            //md5加密
            s = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(s, "md5").ToString();

            return s.ToLower().Substring(8, 16);
        }
        #endregion

        #region 得到字符串长度，一个汉字长度为2
        /// <summary>
        /// 得到字符串长度，一个汉字长度为2
        /// </summary>
        /// <param name="inputString">参数字符串</param>
        /// <returns></returns>
        public static int StrLength(string inputString)
        {
            System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
            int tempLen = 0;
            byte[] s = ascii.GetBytes(inputString);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                    tempLen += 2;
                else
                    tempLen += 1;
            }
            return tempLen;
        }
        #endregion

        #region 截取指定长度字符串
        /// <summary>
        /// 截取指定长度字符串
        /// </summary>
        /// <param name="inputString">要处理的字符串</param>
        /// <param name="len">指定长度</param>
        /// <returns>返回处理后的字符串</returns>
        public static string ClipString(string inputString, int len)
        {
            bool isShowFix = false;
            if (len % 2 == 1)
            {
                isShowFix = true;
                len--;
            }
            System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
            int tempLen = 0;
            string tempString = "";
            byte[] s = ascii.GetBytes(inputString);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                    tempLen += 2;
                else
                    tempLen += 1;

                try
                {
                    tempString += inputString.Substring(i, 1);
                }
                catch
                {
                    break;
                }

                if (tempLen > len)
                    break;
            }

            byte[] mybyte = System.Text.Encoding.Default.GetBytes(inputString);
            if (isShowFix && mybyte.Length > len)
                tempString += "…";
            return tempString;
        }
        #endregion

        #region HTML转行成TEXT
        /// <summary>
        /// HTML转行成TEXT
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string HtmlToTxt(string strHtml)
        {
            string[] aryReg ={
            @"<script[^>]*?>.*?</script>",
            @"<(\/\s*)?!?((\w+:)?\w+)(\w+(\s*=?\s*(([""'])(\\[""'tbnr]|[^\7])*?\7|\w+)|.{0})|\s)*?(\/\s*)?>",
            @"([\r\n])[\s]+",
            @"&(quot|#34);",
            @"&(amp|#38);",
            @"&(lt|#60);",
            @"&(gt|#62);",
            @"&(nbsp|#160);",
            @"&(iexcl|#161);",
            @"&(cent|#162);",
            @"&(pound|#163);",
            @"&(copy|#169);",
            @"&#(\d+);",
            @"-->",
            @"<!--.*\n"
            };

            string newReg = aryReg[0];
            string strOutput = aryReg.Select(t => new Regex(t, RegexOptions.IgnoreCase)).Aggregate(strHtml, (current, regex)
                => regex.Replace(current, string.Empty));

            strOutput.Replace("<", "");
            strOutput.Replace(">", "");
            strOutput.Replace("\r\n", "");


            return strOutput;
        }
        #endregion

        #region 判断对象是否为空
        /// <summary>
        /// 判断对象是否为空，为空返回true
        /// </summary>
        /// <typeparam name="T">要验证的对象的类型</typeparam>
        /// <param name="data">要验证的对象</param>        
        public static bool IsNullOrEmpty<T>(T data)
        {
            //如果为null
            if (data == null)
            {
                return true;
            }

            //如果为""
            if (data.GetType() == typeof(string))
            {
                if (string.IsNullOrEmpty(data.ToString().Trim()))
                {
                    return true;
                }
            }

            //如果为DBNull
            if (data.GetType() == typeof(DBNull))
            {
                return true;
            }

            //不为空
            return false;
        }

        /// <summary>
        /// 判断对象是否为空，为空返回true
        /// </summary>
        /// <param name="data">要验证的对象</param>
        public static bool IsNullOrEmpty(object data)
        {
            //如果为null
            if (data == null)
            {
                return true;
            }

            //如果为""
            if (data.GetType() == typeof(string))
            {
                if (string.IsNullOrEmpty(data.ToString().Trim()))
                {
                    return true;
                }
            }

            //如果为DBNull
            if (data.GetType() == typeof(DBNull))
            {
                return true;
            }

            //不为空
            return false;
        }
        #endregion
    }
}
