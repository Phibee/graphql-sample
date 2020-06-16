using FastraxGlobal.Domain.Entities.Settings.Identity;
using FastraxGlobal.Domain.Interfaces.Repositories.Settings;
using FastraxGlobal.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastraxGlobal.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly MDbContext _context;
        public UserRepository(MDbContext context) : base(context)
        {
            _context = context;
        }

        public User GetSingleByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
