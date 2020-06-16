using FastraxGlobal.Domain.Entities.Settings;
using FastraxGlobal.Domain.Entities.Settings.Identity;
using FastraxGlobal.Domain.Interfaces.Repositories.Settings;
using FastraxGlobal.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastraxGlobal.Infrastructure.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        private readonly MDbContext _context;
        public RoleRepository(MDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
