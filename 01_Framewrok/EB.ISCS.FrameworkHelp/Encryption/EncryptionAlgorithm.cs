using System;

namespace EB.ISCS.FrameworkHelp.Encryption
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public enum EncryptionAlgorithm
    {
        ///<summary>
        /// Des Encry Method
        ///</summary>
        Des = 1,
        ///<summary>
        ///</summary>
        Rc2,
        /// <summary>
        /// 
        /// </summary>
        Rijndael,
        /// <summary>
        /// 
        /// </summary>
        TripleDes
    }
}
