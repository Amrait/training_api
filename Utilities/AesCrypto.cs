using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace TrainingApi.Utilities
{
    internal class AesCrypto
    {
        private static AesCryptoServiceProvider cryptoProvider;
        static AesCrypto()
        {
            cryptoProvider = new AesCryptoServiceProvider
            {
                BlockSize = 128,
                KeySize = 256
            };
            byte[] key = {
                205, 125, 98, 27, 38, 251, 244, 181, 53, 251,
                146, 143, 48, 149, 97, 149, 234, 46, 216, 108,
                223, 217, 73, 140, 247, 128, 224, 38, 115, 54, 112, 19 };
            byte[] IV = {
                16, 238, 27, 142, 128, 8, 201, 47,
                162, 224, 49, 248, 201, 170, 141, 46
            };
            cryptoProvider.IV = IV;
            cryptoProvider.Key = key;
            cryptoProvider.Mode = CipherMode.CBC;
            cryptoProvider.Padding = PaddingMode.PKCS7;
        }
        public static string Encrypt(string _clearInput)
        {
            ICryptoTransform transform = cryptoProvider.CreateEncryptor();
            byte[] encryptedBytes = transform.TransformFinalBlock(Encoding.ASCII.GetBytes(_clearInput), 0, _clearInput.Length);

            return Convert.ToBase64String(encryptedBytes);
        }

        
        public static string Decrypt(string _encryptedText)
        {
            ICryptoTransform transform = cryptoProvider.CreateDecryptor();
            byte[] encryptedBytes = Convert.FromBase64String(_encryptedText);
            byte[] decryptedBytes = transform.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

            return Encoding.ASCII.GetString(decryptedBytes);

        }
    }
}
