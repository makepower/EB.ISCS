using System;
using System.Text;

namespace EB.ISCS.FrameworkHelp.Encryption
{
    /// <summary>
    /// �ṩ���ܽ��ܷ���
    /// </summary>
    public static class EncryptionHelper
    {
        #region const
        /// <summary>
        /// Ĭ��ʹ�õ��ʺ���DES,RC2�㷨��Key
        /// </summary>
        private  const string m_ShortDefaultKey = "Soft";
        /// <summary>
        /// Ĭ��ʹ�õ�TRIPLEDES��RIJNDAEL�㷨��Key
        /// </summary> 
 
        private const string m_LongDefaultKey = "Soft.VeryKey";
 
        /// <summary>
        /// Ĭ��ʹ�õ��ʺ���DES,RC2,TRIPLEDES�㷨��InitVector
        /// </summary>
        private  const string m_ShortDefaultIV = "2001";

        /// <summary>
        /// Ĭ��ʹ�õ��ʺ���RIJNDAEL�㷨��InitVector
        /// </summary> 
 
        private const string m_LongDefaultIV = "VeryKey3";
 
        #endregion
        private static byte[] m_Key = null;

        

        private static byte[] m_initVec = null;

        #region properties
        /// <summary>
        /// ʹ�õļ�����������
        /// </summary>
        public static string Key
        {
            get
            {
                string result = string.Empty;
                if (m_Key != null)
                {
                    result = Encoding.Unicode.GetString(m_Key);
                }
                return result;
            }

        }
        /// <summary>
        /// ʹ�ü��ܵ���ʼƫ����
        /// </summary>
        public static string InitVector
        {
            get 
            {
                string result = string.Empty;
                if (m_initVec != null)
                {
                    result = Encoding.Unicode.GetString(m_initVec);
                }
                return result; 
            }

        }
        #endregion 

      /// <summary>
      /// �����û��������룬���μ���ʹ�õ��㷨����ɶ�ָ���ַ����ļ���
      /// <example><![CDATA[string result = EncryptionHelper.Encrypt("1234", EncryptionAlgorithm.Rc2, "5678", text);]]></example>
      /// <remarks>�����㷨����������ͳ�ʼ��ƫ������Ҫ��һ��
      /// DES��RC2:�������볤�Ⱥͳ�ʼ��ƫ�������� ������4���ַ�;
      /// Rijndael:�������볤�ȿ�����12,16���ַ�,��ʼ��ƫ����Ϊ8���ַ�;
      /// TripleDes:�������볤�ȿ���Ϊ8����12���ַ�,��ʼ��ƫ����Ϊ4���ַ�;
      /// ע��:����ṩ�����������ƫ�����������㷨�ı�׼,��ʹ���������,ʹ�����ڼ��ܺ�ͨ���ṩ��Key��InitVector���Ի�ü���ʱʹ�õ����������ƫ����
      /// </remarks>
      /// </summary>
      /// <param name="plainText">ʹ�õļ�����������</param>
      /// <param name="algorithm">�����㷨ö�ٶ���</param>
      /// <param name="userInitialVector">ʹ�õļ�����ʼƫ����</param>
      /// <param name="encryptionText">��Ҫ���ܵ��ַ�</param>
      /// <returns></returns>
        public static string Encrypt(string plainText, EncryptionAlgorithm algorithm, string userInitialVector, string encryptionText)
        {
            string result = string.Empty;
           
            if (encryptionText.Length > 0)
            {
                SetKey(algorithm, plainText);
                SetInitialVector(algorithm, userInitialVector);
                EncryptTransform transform = new EncryptTransform(m_Key,m_initVec);
                byte[] bytes = Encoding.Unicode.GetBytes(encryptionText);
                byte[] inArray = transform.Encrypt(algorithm, bytes);
                if (inArray.Length > 0)
                {
                    result = Convert.ToBase64String(inArray);
                }
                m_Key = transform.Key;
                m_initVec = transform.InitVec;
                
            }
            return result;

        }

        /// <summary>
        /// ָ����Ҫ���ܵ��ַ���ʹ��Ĭ�ϵ�����������㷨(DES)���м���
        /// </summary>
        /// <param name="encryptionText"></param>
        /// <returns></returns>
        public static string Encrypt(string encryptionText)
        {
            string result = string.Empty;
            result = Encrypt(m_ShortDefaultKey, EncryptionAlgorithm.Des, m_ShortDefaultIV, encryptionText);
            return result;
        }
        /// <summary>
        /// ָ����Ҫ���ܵ��ַ������㷨ʹ��Ĭ�ϵ�����������м���
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="encryptionText"></param>
        /// <returns></returns>
        public static string Encrypt(EncryptionAlgorithm algorithm, string encryptionText)
        {
            string result = string.Empty;
            string key = GetDefaultKey(algorithm);
            string iv = GetDefaultIV(algorithm);
            result = Encrypt(key, algorithm, iv, encryptionText);
            return result;
        }



        /// <summary>
        /// �����û��������룬ʹ��Ĭ�ϵļ����㷨��ɶ�ָ���ַ����ļ���
        /// <remarks>Ĭ��ΪDES�㷨���м���</remarks>
        ///  <example><![CDATA[string result = EncryptionHelper.Encrypt("1234", "5678", text);]]></example>
        /// </summary>
        /// <param name="plainText">ʹ�õļ�����������</param>
        /// <param name="userInitialVector">ʹ�õļ�����ʼƫ����</param>
        /// <param name="encryptionText">��Ҫ���ܵ��ַ���</param>
        /// <returns>���ܺ���ַ���</returns>
        public static string Encrypt(string plainText, string userInitialVector, string encryptionText)
        {
            string result = string.Empty;
            result = Encrypt(plainText, EncryptionAlgorithm.Des, userInitialVector, encryptionText);
            return result;
        }

        /// <summary>
        /// �����û��������룬����ʹ�õĽ����㷨����ɶ�ָ���ַ����Ľ��ܣ�
        /// ָ���Ľ����㷨������ַ���ʹ�ü��ܵ��㷨һ��
        /// �����㷨����������ͳ�ʼ��ƫ������Ҫ��һ��
        /// DES��RC2:�������볤�Ⱥͳ�ʼ��ƫ�������� ������4���ַ�;
        /// Rijndael:�������볤�ȿ�����12,16���ַ�,��ʼ��ƫ����Ϊ8���ַ�;
        /// TripleDes:�������볤�ȿ���Ϊ8����12���ַ�,��ʼ��ƫ����Ϊ4���ַ�;
        /// </summary>
        /// <param name="plainText">������������</param>
        /// <param name="algorithm">ʹ�õļ����㷨</param>
        /// <param name="userInitialVector">����ʱʹ�õ���ʼƫ����</param>
        /// <param name="encryptionText">���ܺ���ַ���</param>
        /// <returns></returns>
        public static string Decrypt(string plainText, EncryptionAlgorithm algorithm, string userInitialVector, string encryptionText)
        {
            string result = string.Empty;
            SetKey(algorithm, plainText);
            SetInitialVector(algorithm, userInitialVector);
            EncryptTransform transform = new EncryptTransform(m_Key, m_initVec);
            byte[] bytesData = Convert.FromBase64String(encryptionText);
            byte[] bytes = null;
            try
            {
                bytes = transform.Decrypt(algorithm, bytesData);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            if (bytes.Length > 0)
            {
                result = Encoding.Unicode.GetString(bytes);
            }
            m_Key = transform.Key;
            m_initVec = transform.InitVec;
            return result;

        }

       /// <summary>
        /// �����û��������룬ʹ��Ĭ�Ͻ����㷨��ɶ�ָ���ַ����Ľ���
       /// </summary>
       /// <param name="plainText">����ʱʹ�õ���������</param>
       /// <param name="userInitialVector">����ʱʹ�õ���ʼƫ����</param>
       /// <param name="encryptionText">���ܺ���ַ���</param>
       /// <returns></returns>
        public static string Decrypt(string plainText, string userInitialVector, string encryptionText)
        {
            string result = string.Empty;
            result=Decrypt(plainText, EncryptionAlgorithm.Des,userInitialVector,encryptionText);
            return result;

        }

        /// <summary>
        /// ʹ��Ĭ�ϵ��㷨(DES)��Ĭ�ϵ�����������н���
        /// </summary>
        /// <param name="encryptionText"></param>
        /// <returns></returns>
        public static string Decrypt(string encryptionText)
        {
            string result = string.Empty;
            result = Decrypt(m_ShortDefaultKey, EncryptionAlgorithm.Des, m_ShortDefaultIV, encryptionText);
            return result;

        }
        /// <summary>
        /// ָ������ʱʹ�õ��㷨,ʹ��Ĭ�ϵ�����������н���
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="encryptionText"></param>
        /// <returns></returns>
        public static string Decrypt(EncryptionAlgorithm algorithm,string encryptionText)
        {
            string result = string.Empty;
            string key = GetDefaultKey(algorithm);
            string iv = GetDefaultIV(algorithm);
            result = Decrypt(key, algorithm, iv, encryptionText);
            return result;

        }

        /// <summary>
        /// �����㷨���Ĭ�ϵ�Key
        /// </summary>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        private static string GetDefaultKey(EncryptionAlgorithm algorithm)
        {
            string result = m_ShortDefaultKey;
            switch (algorithm)
            {
                case EncryptionAlgorithm.Rijndael:
                    {
//#if SmartCard
//                        uint a = 0;
//                        Encry fei = new Encry();
//                        uint r = fei.Find();
//                        if (r <= 0)
//                        {
//                            throw new Exception("Cannot found Database you setting");
//                        }
//                        object ro = new object();
//                        lock (SmartCardLockHelper.SmartCardLocker)
//                        {
//                            fei.Open(a);
//                            string str = string.Format("0071{3}2{0}{1}{2}000000", (char)(DateTime.Today.Year - 2000),
//                                                       (char)(DateTime.Today.Month), (char)(DateTime.Today.Day), (char)12);
//                            byte[] bytes = Encoding.UTF8.GetBytes(str);
//                            fei.Run(a, 0x2200, 128, bytes, out ro);
//                            fei.RsaEnc(0, 0x1002, 128, ref ro);
//                            byte[] b = ro as byte[];
//                            str = Encoding.UTF8.GetString(b).Substring(0, bytes[4]);
//                            result = str;
//                            fei.Close(a);
//                        }
//#else
                        result = m_LongDefaultKey;
//#endif
                        break;
                    }
                case EncryptionAlgorithm.TripleDes:
                    {
//#if SmartCard
//                        uint a = 0;
//                        Encry fei = new Encry();
//                        uint r = fei.Find();
//                        if (r <= 0)
//                        {
//                            throw new Exception("Cannot found Database you setting");
//                        }
//                        object ro = new object();
//                        lock (SmartCardLockHelper.SmartCardLocker)
//                        {
//                            fei.Open(a);
//                            string str = string.Format("0071{3}2{0}{1}{2}000000", (char)(DateTime.Today.Year - 2000),
//                                                       (char)(DateTime.Today.Month), (char)(DateTime.Today.Day), (char)12);
//                            byte[] bytes = Encoding.UTF8.GetBytes(str);
//                            fei.Run(a, 0x2200, 128, bytes, out ro);
//                            fei.RsaEnc(0, 0x1002, 128, ref ro);
//                            byte[] b = ro as byte[];
//                            str =  Encoding.UTF8.GetString(b).Substring(0, bytes[4]);
//                            result = str;
//                            fei.Close(a);
//                        }
//#else
                        result = m_LongDefaultKey;
//#endif
                        break;
                    }
            }
            return result;
        }
        /// <summary>
        /// �����㷨���Ĭ�ϵ�IV
        /// </summary>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        private static string GetDefaultIV(EncryptionAlgorithm algorithm)
        {
            string result = m_ShortDefaultIV;
            switch (algorithm)
            {
                case EncryptionAlgorithm.Rijndael:
                    {
//#if SmartCard
//                        uint a = 0;
//                        Encry fei = new Encry();
//                        uint r = fei.Find();
//                        if (r <= 0)
//                        {
//                            throw new Exception("Cannot found Database you setting");
//                        }
//                        object ro = new object();
//                        lock (SmartCardLockHelper.SmartCardLocker)
//                        {
//                            fei.Open(a);
//                            string str = string.Format("0083{3}2{0}{1}{2}000000", (char) (DateTime.Today.Year - 2000),
//                                                       (char) (DateTime.Today.Month), (char) (DateTime.Today.Day),(char)8);
//                            byte[] bytes = Encoding.UTF8.GetBytes(str);
//                            fei.Run(a, 0x2200, 128, bytes, out ro);
//                            fei.RsaEnc(0, 0x1002, 128, ref ro);
//                            byte[] b = ro as byte[];
//                            str =  Encoding.UTF8.GetString(b).Substring(0, bytes[4]);
//                            result = str;
//                            fei.Close(a);
//                        }
//#else
                        result = m_LongDefaultIV;
//#endif
                        break;
                    }

            }
                    return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="initialVector"></param>
        /// <returns></returns>
        private static void SetInitialVector(EncryptionAlgorithm algorithm, string initialVector)
        {
            if (null != initialVector)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(initialVector);
                switch (algorithm)
                {
                    case EncryptionAlgorithm.Des:
                        {
                            if ( bytes.Length == 8)
                            {
                                m_initVec = bytes;

                            }
                            break;
                        }

                    case EncryptionAlgorithm.Rc2:
                        {
                            if ( bytes.Length == 8)
                            {
                                m_initVec = bytes;

                            }
                            break;
                        }
                    case EncryptionAlgorithm.Rijndael:
                        {
                            if ( bytes.Length ==16)
                            {
                                m_initVec = bytes;

                            }
                            break;
                        }
                    case EncryptionAlgorithm.TripleDes:
                        {
                            if (bytes.Length == 8)
                            {
                                m_initVec = bytes;

                            }
                            break;
                        }
                }
            }
        }

        private static void SetKey(EncryptionAlgorithm algorithm, string key)
        {
            if (null != key)
            {
                byte[] keyByte = Encoding.Unicode.GetBytes(key);
                switch (algorithm)
                {
                    case EncryptionAlgorithm.Des:
                        {
                            if (keyByte.Length== 8)
                            {
                                m_Key = keyByte;
                            }
                            break;
                        }

                    case EncryptionAlgorithm.Rc2:
                        {
                            if (keyByte.Length == 8)
                            {
                                m_Key = keyByte;
                            }
                            break;
                        }
                    case EncryptionAlgorithm.Rijndael:
                        {
                            if (keyByte.Length==24 || (keyByte.Length == 32))
                            {
                                m_Key = keyByte;
                            }
                            break;
                        }
                    case EncryptionAlgorithm.TripleDes:
                        {
                            if (keyByte.Length ==16 ||(keyByte.Length == 24))
                            {
                                m_Key = keyByte;
                            }
                            break;
                        }
                }
            }
        }

    }
}
