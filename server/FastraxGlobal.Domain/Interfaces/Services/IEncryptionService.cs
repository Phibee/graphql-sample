using System;
using System.Collections.Generic;
using System.Text;

namespace FastraxGlobal.Domain.Interfaces.Services
{
    public interface IEncryptionService
    {
        string CreateSalt();
        string EncryptPassword(string password, string salt);
    }
}
