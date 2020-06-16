using FastraxGlobal.Domain.Entities.Settings.Identity;
using FastraxGlobal.Domain.Interfaces.Repositories.Settings;
using FastraxGlobal.Domain.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FastraxGlobal.Infrastructure.Repositories.Settings
{
    public class SettingsUOW : ISettingUOW
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDesignationRepository _designationRepository;

        public SettingsUOW(
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IDepartmentRepository departmentRepository,
            IDesignationRepository designationRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _departmentRepository = departmentRepository;
            _designationRepository = designationRepository;
        }

        public Task<IEnumerable<Department>> Departments()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Designation>> Designations()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Role>> Roles()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> Users()
        {
            throw new NotImplementedException();
        }
    }
}
