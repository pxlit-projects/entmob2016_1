using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using frontend.Service;
using MainApp.Authentication;
using frontend.Domain;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using Windows.Security.Cryptography;

namespace MainApp.Utility
{
    public static class PasswordHandler
    {
        private static IEmployeeService service = new EmployeeService(LoggedUser.Username, LoggedUser.Password);

        public static string Md5Encrypt(string password, string salt)
        {
            string algoritmName = HashAlgorithmNames.Md5;

            HashAlgorithmProvider algoritmProvider = HashAlgorithmProvider.OpenAlgorithm(algoritmName);

            CryptographicHash md5Hash = algoritmProvider.CreateHash();

            IBuffer buffMsg = CryptographicBuffer.ConvertStringToBinary(salt + password, BinaryStringEncoding.Utf16BE);
            md5Hash.Append(buffMsg);
            IBuffer result = md5Hash.GetValueAndReset();

            string encryptedHash = CryptographicBuffer.EncodeToBase64String(result);
            return encryptedHash;

            //MD5 md5 = MD5.Create();

            //byte[] result = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(salt + password));

            //StringBuilder strBuilder = new StringBuilder();
            //for (int i = 0; i < result.Length; i++)
            //{
            //    strBuilder.Append(result[i].ToString("x2"));
            //}

            //return strBuilder.ToString();
        }

        public static string GenerateSalt()
        {
            // Define the length, in bytes, of the buffer.
            uint length = 32;

            // Generate random data and copy it to a buffer.
            IBuffer buffer = CryptographicBuffer.GenerateRandom(length);

            // Encode the buffer to a hexadecimal string (for display).
            string randomHex = CryptographicBuffer.EncodeToHexString(buffer);

            return randomHex;
        }
    }
}
