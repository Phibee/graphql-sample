using FastraxGlobal.Domain.Entities.Settings.Identity;
using FastraxGlobal.Domain.Interfaces.Repositories.Settings;
using FastraxGlobal.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastraxGlobal.Infrastructure.Repositories.Settings
{
    public class DesignationRepository : BaseRepository<Designation>, IDesignationRepository
    {
        private readonly MDbContext _context;
        public DesignationRepository(MDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
