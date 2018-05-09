using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EB.ISCS.FrameworkHelp.Encryption;
using System.Diagnostics;

namespace UnitTest.EB
{
    [TestClass]
    public class FrameworkUnitTest
    {
        [TestMethod]
        public void TestEncryption()
        {
            var str = "Data Source=localhost;Initial Catalog=EB;Persist Security Info=True;User ID=sa;Password=p@ssw0rd;";
            var encypt = EncryptionHelper.Encrypt(EncryptionAlgorithm.Rijndael, str);
            var decrypt = EncryptionHelper.Decrypt(EncryptionAlgorithm.Rijndael, encypt);
            Trace.WriteLine(encypt);
            Assert.AreEqual(str, decrypt);
        }
    }
}
