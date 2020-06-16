using FastraxGlobal.Domain.Entities.Settings;
using FastraxGlobal.Domain.Entities.Settings.Identity;
using FastraxGlobal.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastraxGlobal.Domain.Services
{
    public class MembershipService : IMembershipService
    {
        public MembershipService()
        {

        }

        public User CreateUser(string username, string email, string password, int[] roles)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public List<IdentityRole> GetUserRoles(string username)
        {
            throw new NotImplementedException();
        }

        public bool isPasswordValid(User user, string password)
        {
            throw new NotImplementedException();
        }
    }
}
