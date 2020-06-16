using FastraxGlobal.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace FastraxGlobal.Domain.Services
{
    public class EncryptionService : IEncryptionService
    {
        public string CreateSalt()
        {
            var data = new byte[0x10];

            var cryptoServiceProvider = RandomNumberGenerator.Create();
            cryptoServiceProvider.GetBytes(data);
            return Convert.ToBase64String(data);
        }

        public string EncryptPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = $"{salt}{password}";
                byte[] saltedPasswordAsBytes = Encoding.UTF8.GetBytes(saltedPassword);
                var test = sha256.ComputeHash(saltedPasswordAsBytes);
                return Convert.ToBase64String(sha256.ComputeHash(saltedPasswordAsBytes));
            }
        }
    }
}
