using CustomerManagement.Domain.Core.Services;
using System;
using System.Security.Cryptography;
using System.Text;

namespace CustomerManagement.Infrastructure.Cryptography
{
    public class CryptographyService : ICryptographyService
    {
        public string GetHash(string data)
        {
            if (data == null) throw new ArgumentException("Data is invalid");

            var bytes = Encoding.UTF8.GetBytes(data);
            using (var hashAlgorithm = SHA256.Create())
            {
                var hash = hashAlgorithm.ComputeHash(bytes);
                return _ByteArrayToHexString(hash);
            }
        }

        private string _ByteArrayToHexString(byte[] array)
        {
            var sb = new StringBuilder(array.Length * 2);
            foreach (byte b in array)
            {
                sb.AppendFormat("{0:x2}", b);
            }
            return sb.ToString();
        }
    }
}
