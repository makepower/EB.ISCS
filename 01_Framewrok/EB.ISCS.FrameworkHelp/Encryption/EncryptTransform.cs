using System;
using System.IO;
using System.Security.Cryptography;

namespace EB.ISCS.FrameworkHelp.Encryption
{
    /// <summary>
    /// �ṩ���ܽ��ܷ���
    /// </summary>
    internal class EncryptTransform
    {
        //private const int c_MaxLengthOf_IV_DES = 4;
        //private const int c_MaxLengthOf_IV_RC2 = 4;
        //private const int c_MaxLengthOf_IV_RIJNDAEL = 8;
        //private const int c_MaxLengthOf_IV_TRIPLEDES = 4;
        //private const int c_MaxLengthOf_Key_DES = 4;
        //private const int c_MaxLengthOf_Key_RC2 = 4;
        //private const int c_MaxLengthOf_Key_RIJNDAEL_1 = 8;
        //private const int c_MaxLengthOf_Key_RIJNDAEL_2 = 12;
        //private const int c_MaxLengthOf_Key_TRIPLEDES_1 = 8;
        //private const int c_MaxLengthOf_Key_TRIPLEDES_2 = 12;

        private byte[] m_Key = null;

        /// <summary>
        /// ��ȡ�����ü��ܽ��ܹ�����ʹ�õ���������
        /// </summary>
        public byte[] Key
        {
            get { return m_Key; }
            set { m_Key = value; }
        }


        private byte[] m_initVec = null;
        /// <summary>
        /// ��ȡ�����ü��ܽ��ܹ�����ʹ�õĳ�ʼ������
        /// </summary>
        public byte[] InitVec
        {
            get { return m_initVec; }
            set { m_initVec = value; }
        }

        public EncryptTransform(byte[] key, byte[] initVector)
        {
            this.m_Key = key;
            this.m_initVec = initVector;
        }
        /// <summary>
        /// �����ṩ��ö����Ϣ,�����Ҫʹ�õĽ����㷨�Ľӿ�
        /// </summary>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        internal ICryptoTransform GetDecryptoServiceProvider(EncryptionAlgorithm algorithm)
        {
            switch (algorithm)
            {
                case EncryptionAlgorithm.Des:
                    {
                        DES des = new DESCryptoServiceProvider();
                        des.Mode = CipherMode.CBC;
                        if (this.m_Key != null)
                        {
                            des.Key = m_Key;
                        }
                        if (m_initVec != null)
                        {
                            des.IV = m_initVec;
                        }
                        return des.CreateDecryptor();
                    }
                case EncryptionAlgorithm.Rc2:
                    {
                        RC2 rc = new RC2CryptoServiceProvider();
                        rc.Mode = CipherMode.CBC;
                        return rc.CreateDecryptor(m_Key, m_initVec);
                    }
                case EncryptionAlgorithm.Rijndael:
                    {
                        Rijndael rijndael = new RijndaelManaged();
                        rijndael.Mode = CipherMode.CBC;
                        return rijndael.CreateDecryptor(m_Key, m_initVec);
                    }
                case EncryptionAlgorithm.TripleDes:
                    {
                        TripleDES edes = new TripleDESCryptoServiceProvider();
                        edes.Mode = CipherMode.CBC;
                        return edes.CreateDecryptor(m_Key, m_initVec);
                    }
            }
            throw new CryptographicException("Algorithm ID '" + algorithm + "' not supported.");
        }

        /// <summary>
        /// �����ṩ��ö����Ϣ,�����Ҫʹ�õļ����㷨�Ľӿ�
        /// </summary>
        /// <param name="algorithm">�㷨ö��</param>
        /// <returns></returns>
        internal ICryptoTransform GetEncryptoServiceProvider(EncryptionAlgorithm algorithm)
        {

            switch (algorithm)
            {
                case EncryptionAlgorithm.Des:
                    {
                        DES des = new DESCryptoServiceProvider();
                        des.Mode = CipherMode.CBC;
                        if (null != m_Key)
                        {
                            des.Key = m_Key;
                        }
                        else
                        {
                            m_Key = des.Key;
                        }
                        if (null != m_initVec)
                        {
                            des.IV = m_initVec;
                        }
                        else
                        {
                            m_initVec = des.IV;
                        }
                        return des.CreateEncryptor();
                    }


                case EncryptionAlgorithm.Rc2:
                    {
                        RC2 rc = new RC2CryptoServiceProvider();
                        rc.Mode = CipherMode.CBC;
                        if (null != m_Key)
                        {
                            rc.Key = m_Key;
                        }
                        else
                        {
                            m_Key = rc.Key;
                        }
                        if (null != m_initVec)
                        {
                            rc.IV = m_initVec;
                        }
                        else
                        {
                            m_initVec = rc.IV;
                        }
                        return rc.CreateEncryptor();
                    }
                case EncryptionAlgorithm.Rijndael:
                    {
                        Rijndael rijndael = new RijndaelManaged();
                        rijndael.Mode = CipherMode.CBC;
                        if (null != m_Key)
                        {
                            rijndael.Key = m_Key;
                        }
                        else
                        {
                            m_Key = rijndael.Key;
                        }
                        if (null != m_initVec)
                        {
                            rijndael.IV = m_initVec;
                        }
                        else
                        {
                            m_initVec = rijndael.IV;
                        }
                        return rijndael.CreateEncryptor();
                    }
                case EncryptionAlgorithm.TripleDes:
                    {
                        TripleDES edes = new TripleDESCryptoServiceProvider();
                        edes.Mode = CipherMode.CBC;
                        if (null != m_Key)
                        {
                            edes.Key = m_Key;
                        }
                        else
                        {
                            m_Key = edes.Key;
                        }
                        if (null != m_initVec)
                        {
                            edes.IV = m_initVec;
                        }
                        else
                        {
                            m_initVec = edes.IV;
                        }
                        return edes.CreateEncryptor();
                    }
                default:
                    throw new CryptographicException("Algorithm ID '" + algorithm + "' not supported.");
            }
            
        }

        /// <summary>
        /// �ṩ����ʵ�ֽ��ܵķ���
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="bytesData">��Ҫ���ܵ���Ϣ</param>
        /// <returns></returns>
        public byte[] Decrypt(EncryptionAlgorithm algorithm, byte[] bytesData)
        {
            byte[] result = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                ICryptoTransform cryptoServiceProvider = GetDecryptoServiceProvider(algorithm);
                using (CryptoStream stream2 = new CryptoStream(stream, cryptoServiceProvider, CryptoStreamMode.Write))
                {
                    try
                    {
                        stream2.Write(bytesData, 0, bytesData.Length);
                        stream2.FlushFinalBlock();
                        stream2.Close();
                        result = stream.ToArray();
                    }
                    catch (Exception exception)
                    {
                        throw new Exception("Error while writing decrypted data to the stream: \n" + exception.Message);
                    }
                }
                stream.Close();
            }
            return result;
        }
        /// <summary>
        /// �ṩ����ʵ�ּ��ܵķ���
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="bytesData">��Ҫ���ܵ���Ϣ</param>
        /// <returns></returns>
        public byte[] Encrypt(EncryptionAlgorithm algorithm, byte[] bytesData)
        {
            byte[] result = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                ICryptoTransform cryptoServiceProvider = this.GetEncryptoServiceProvider(algorithm);
                using (CryptoStream stream2 = new CryptoStream(stream, cryptoServiceProvider, CryptoStreamMode.Write))
                {
                    try
                    {
                        stream2.Write(bytesData, 0, bytesData.Length);
                        stream2.FlushFinalBlock();
                        stream2.Close();
                        result = stream.ToArray();
                    }
                    catch (Exception exception)
                    {
                        throw new Exception("Error while writing encrypted data to the stream: \n" + exception.Message);
                    }
                }
                stream.Close();
            }
            return result;
        }


    }
}
