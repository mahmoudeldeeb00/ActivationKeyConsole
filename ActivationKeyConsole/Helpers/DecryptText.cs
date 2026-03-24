using ActivationKeyConsole.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cashier.Helpers.Helpers
{
    public class DecryptText
    {
        public static async Task<string> DecryptPlainText(string text)
        {
            var iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(text);
            using (Aes aes = Aes.Create())
            {

                aes.Key = Encoding.UTF8.GetBytes(Setting.EncryptionKey);
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    using (CryptoStream crypToStream = new CryptoStream(ms, encryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(crypToStream))
                        {
                            return streamReader.ReadToEnd();
                        }

                    }
                }
            }

        }
    }
}
