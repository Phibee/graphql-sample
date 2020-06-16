using FastraxGlobal.Domain.Entities.Settings.Identity;
using FastraxGlobal.Domain.Interfaces.Repositories.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FastraxGlobal.Domain.Interfaces.UnitOfWork
{
    public interface ISettingUOW
    {
        public Task<IEnumerable<User>> Users();
        public Task<IEnumerable<Role>> Roles();
        public Task<IEnumerable<Department>> Departments();
        public Task<IEnumerable<Designation>> Designations();
    }
}
