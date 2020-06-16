using FastraxGlobal.Domain.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastraxGlobal.Domain.Entities.Settings.Identity
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        private string Salt { get; set; }
        public string GetSalt() => Salt;
        private string Password { get; set; }
        public string GetPassword() => Password;
        public void SetPassword(string password)
        {
            EncryptionService encrypt = new EncryptionService();
            Salt = encrypt.CreateSalt();
            Password = encrypt.EncryptPassword(password, Salt);
        }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public long DesignationId { get; set; }
        public long DepartmentId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastUpdate { get; set; }


        public virtual Designation Designation { get; set; }
        public virtual Department Department { get; set; }

        public User() => CreateDate = DateTime.UtcNow;
    }
}
