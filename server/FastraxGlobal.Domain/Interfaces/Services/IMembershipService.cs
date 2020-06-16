using FastraxGlobal.Domain.Entities.Settings;
using FastraxGlobal.Domain.Entities.Settings.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastraxGlobal.Domain.Interfaces.Services
{
    public interface IMembershipService
    {
        User CreateUser(string username, string email, string password, int[] roles);
        User GetUser(int userId);
        List<IdentityRole> GetUserRoles(string username);
        bool isPasswordValid(User user, string password);
    }
}
