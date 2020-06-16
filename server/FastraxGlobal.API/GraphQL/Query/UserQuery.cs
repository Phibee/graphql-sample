using FastraxGlobal.Domain.Entities.Settings;
using FastraxGlobal.Domain.Entities.Settings.Identity;
using FastraxGlobal.Domain.Interfaces.Repositories.Settings;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastraxGlobal.API.GraphQL.Query
{
    public class UserQuery
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDesignationRepository _designationRepository;

        public UserQuery(
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

        public Task<IEnumerable<User>> Users() => _userRepository.GetAllAsync();

        public Task<IEnumerable<Role>> Roles() => _roleRepository.GetAllAsync();

        public Task<IEnumerable<Department>> Departments() => _departmentRepository.GetAllAsync();

        public Task<IEnumerable<Designation>> Designations() => _designationRepository.GetAllAsync();
    }
}
