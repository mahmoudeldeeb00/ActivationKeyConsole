using ActivationKeyConsole.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cashier.Helpers.Helpers
{
    public class EncryptText
    {
        public static string EncryptPlainText(string text)
        {
            var iv = new byte[16];
            byte[] bytesArray;
            using (Aes aes = Aes.Create())
            {

                aes.Key = Encoding.UTF8.GetBytes(Setting.EncryptionKey);
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream crypToStream = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(crypToStream))
                        {
                            streamWriter.Write(text);
                        }
                        bytesArray = ms.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(bytesArray);
        }
    }

}
