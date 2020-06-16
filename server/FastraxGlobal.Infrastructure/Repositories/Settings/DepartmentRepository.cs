using FastraxGlobal.Domain.Entities.Settings.Identity;
using FastraxGlobal.Domain.Interfaces.Repositories.Settings;
using FastraxGlobal.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastraxGlobal.Infrastructure.Repositories.Settings
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        private readonly MDbContext _context;
        public DepartmentRepository(MDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
