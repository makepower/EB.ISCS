using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace EB.ISCS.FrameworkHelp.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public static class EnumHelper
    {
        #region get

        /// <summary>
        ///  ���ö��������������ȫ������б�
        /// </summary>
        /// <param name="enumType">ö�ٵ�����</param>
        /// <returns></returns>
        public static List<EnumItem> GetEnumItems(Type enumType)
        {
            return GetEnumItems(enumType, false);
        }

        /// <summary>
        /// ���ö��������������ȫ������б�����"All"��
        /// </summary>
        /// <param name="enumType">ö�ٶ�������</param>
        /// <returns></returns>
        public static List<EnumItem> GetEnumItemsWithAll(Type enumType)
        {
            return GetEnumItems(enumType, true);
        }

        /// <summary>
        /// ���ö��������������ȫ������б�
        /// </summary>
        /// <param name="enumType">ö�ٶ�������</param>
        /// <param name="withAll">�Ƿ���Ҫ����'All'</param>
        /// <returns></returns>
        public static List<EnumItem> GetEnumItems(Type enumType, bool withAll)
        {
            List<EnumItem> list = new List<EnumItem>();

            if (enumType.IsEnum != true)
            {
                //whether the type is enum type
                throw new InvalidOperationException();
            }

            if (withAll == true)
                list.Add(new EnumItem(-1, "All"));

            // �������Description��������Ϣ
            Type typeDescription = typeof(DescriptionAttribute);

            // ���ö�ٵ��ֶ���Ϣ����Ϊö�ٵ�ֵʵ������һ��static���ֶε�ֵ��
            System.Reflection.FieldInfo[] fields = enumType.GetFields();

            // ���������ֶ�
            foreach (FieldInfo field in fields)
            {
                // ���˵�һ������ö��ֵ�ģ���¼����ö�ٵ�Դ����
                if (field.FieldType.IsEnum == false)
                    continue;

                // ͨ���ֶε����ֵõ�ö�ٵ�ֵ
                int value = (int)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null);
                string text = string.Empty;

                // �������ֶε������Զ������ԣ�����ֻ����Description����
                object[] arr = field.GetCustomAttributes(typeDescription, true);
                if (arr.Length > 0)
                {
                    // ��ΪDescription�Զ������Բ������ظ�������ֻȡ��һ��
                    DescriptionAttribute aa = (DescriptionAttribute)arr[0];

                    // ������Ե�����ֵ
                    text = aa.Description;
                }
                else
                {
                    // ���û��������������ô����ʾӢ�ĵ��ֶ���
                    text = field.Name;
                }
                list.Add(new EnumItem(value, text));
            }

            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string GetDescriptionByEnum<T>(T t)
        {
            if (t == null)
            {
                return null;
            }
            Type enumType = typeof(T);
            List<EnumItem> list = GetEnumItems(enumType);
            foreach (EnumItem item in list)
            {
                if (Convert.ToInt32(item.Key) == Convert.ToInt32(t))
                    return item.Value.ToString();
            }
            return string.Empty;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string GetDescriptionByEnum(object t)
        {
            if (t == null)
            {
                return string.Empty;
            }
            Type enumType = t.GetType();
            List<EnumItem> list = GetEnumItems(enumType);
            foreach (EnumItem item in list)
            {
                if (Convert.ToInt32(item.Key) == Convert.ToInt32(t))
                    return item.Value.ToString();
            }
            return string.Empty;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="description"></param>
        /// <returns></returns>
        public static int GetValueByDescription<T>(string description)
        {
            Type enumType = typeof(T);
            List<EnumItem> list = GetEnumItems(enumType);
            foreach (EnumItem item in list)
            {
                if (item.Value.ToString().ToLower() == description.Trim().ToLower())
                    return Convert.ToInt32(item.Key);
            }
            return -1;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="description"></param>
        /// <returns></returns>
        public static T GetEnumByDescription<T>(string description)
        {
            if (description == null)
            {
                return default(T);
            }
            Type enumType = typeof(T);
            List<EnumItem> list = GetEnumItems(enumType);
            foreach (EnumItem item in list)
            {
                if (item.Value.ToString().ToLower() == description.Trim().ToLower())
                    return (T)item.Key;
            }
            return default(T);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T GetEnumByName<T>(string name)
        {
            Type enumType = typeof(T);
            List<EnumItem> list = GetEnumItems(enumType);
            bool flag = false;
            foreach (EnumItem item in list)
            {
                if (item.Value.ToString().ToLower() == name.Trim().ToLower())
                {
                    flag = true;
                    return (T)item.Key;
                }
            }
            if (!flag)
            {
                throw new ArgumentException("Can not found specify the name of the enum", "name");
            }
            return default(T);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T GetEnumByValue<T>(object value)
        {
            bool flag = false;
            if (value == null)
                throw new ArgumentNullException("value");
            try
            {
                Type enumType = typeof(T);
                List<EnumItem> list = GetEnumItems(enumType);
                foreach (EnumItem item in list)
                {
                    if (item.Key.ToString().Trim().ToLower() == value.ToString().Trim().ToLower())
                    {
                        flag = true;
                        return (T)item.Key;
                    }
                }
                if (!flag)
                {
                    throw new ArgumentException("Can not found specify the value of the enum", "value");
                }
                return default(T);
            }
            catch
            {
                return default(T);
            }
        }
        /// <summary>
        /// GetValueByEnum
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>int?</returns>
        public static int? GetValueByEnum(object value)
        {
            if (value == null)
                return null;
            try
            {
                return (int)value;
            }
            catch
            {
                return null;
            }
        }

        #endregion 

        #region Parse Enum
        /// <summary>
        /// �ṩValue���ַ�,ת��Ϊ��Ӧ��ö�ٶ���
        /// <remarks>������ö�ٶ���ֵ����ΪChar���͵�</remarks>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="c"></param>
        /// <returns></returns>
        public static T Parse<T>(char c) where T : struct
        {
            return Parse<T>((ulong)c);
        }

        /// <summary>
        /// �ṩValue���ַ�,ת��Ϊ��Ӧ��ö�ٶ���
        /// <remarks>������ö�ٶ���ֵ����ΪInt���͵�</remarks>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="l"></param>
        /// <returns></returns>
        public static T Parse<T>(ulong l) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("Need System.Enum as generic type!");
            }

            object o = Enum.Parse(typeof(T), l.ToString());
            if (Enum.IsDefined(typeof(T), o))
            {
                return (T)o;
            }

            throw new InvalidCastException();
        }

        /// <summary>
        /// �ṩValue���ַ�,ת��Ϊ��Ӧ��ö�ٶ���
        /// <remarks>������ö�ٶ���ֵ����ΪChar���͵�</remarks>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T Parse<T>(string value) where T : struct
        {
            if (value == null || value.Trim().Length != 1)
            {
                throw new ArgumentException("Invalid cast,value must be one character!");
            }

            return Parse<T>(value[0]);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="c"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryParse<T>(char c, out T result) where T : struct
        {
            return TryParse<T>((ulong)c, out result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryParse<T>(string value, out T result) where T : struct
        {
            try
            {
                if (value == null || value.Trim().Length != 1)
                {
                    throw new ArgumentException("Invalid cast,value must be one character!");
                }

                return TryParse<T>(value[0], out result);
            }
            catch
            {
                result = default(T);
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryParse<T>(ulong value, out T result) where T : struct
        {
            try
            {
                result = Parse<T>(value);
                return true;
            }
            catch
            {
                result = default(T);
                return false;
            }
        }
        #endregion

        /// <summary>
        /// ��ȡö�ٱ���ֵ�� Description ����
        /// </summary>
        /// <param name="obj">ö�ٱ���</param>
        /// <returns>������� Description ���ԣ��򷵻� Description ���Ե�ֵ�����򷵻�ö�ٱ���ֵ������</returns>
        public static string GetDescription(this Enum obj)
        {
            return GetDescription(obj, false);
        }

        /// <summary>
        /// ��ȡö�ٱ���ֵ�� Description ����
        /// </summary>
        /// <param name="obj">ö�ٱ���</param>
        /// <param name="isTop">�Ƿ�ı�Ϊ���ظ��ࡢö�����͵�ͷ Description ���ԣ������ǵ�ǰ�����Ի�ö�ٱ���ֵ�� Description ����</param>
        /// <returns>������� Description ���ԣ��򷵻� Description ���Ե�ֵ�����򷵻�ö�ٱ���ֵ������</returns>
        public static string GetDescription(this Enum obj, bool isTop)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            try
            {
                Type _enumType = obj.GetType();
                DescriptionAttribute dna = null;
                if (isTop)
                {
                    dna = (DescriptionAttribute)Attribute.GetCustomAttribute(_enumType, typeof(DescriptionAttribute));
                }
                else
                {
                    FieldInfo fi = _enumType.GetField(Enum.GetName(_enumType, obj));
                    dna = (DescriptionAttribute)Attribute.GetCustomAttribute(
                       fi, typeof(DescriptionAttribute));
                }
                if (dna != null && string.IsNullOrEmpty(dna.Description) == false)
                    return dna.Description;
            }
            catch
            {
            }
            return obj.ToString();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class EnumItem
    {


        private object m_key;
        private object m_value;

        /// <summary>
        /// 
        /// </summary>
        public object Key
        {
            get { return m_key; }
            set { m_key = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public object Value
        {
            get { return m_value; }
            set { m_value = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_key"></param>
        /// <param name="_value"></param>
        public EnumItem(object _key, object _value)
        {
            m_key = _key;
            m_value = _value;
        }
    }
}
