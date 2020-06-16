using FastraxGlobal.API.GraphQL.DTOs;
using FastraxGlobal.Domain.Entities.Settings;
using FastraxGlobal.Domain.Entities.Settings.Identity;
using FastraxGlobal.Domain.Interfaces.Repositories.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastraxGlobal.API.GraphQL.Mutations
{
    public class UserMutation
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IDesignationRepository _designationRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public UserMutation(IRoleRepository roleRepository,
            IUserRepository userRepository,
            IDepartmentRepository departmentRepository,
            IDesignationRepository designationRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _departmentRepository = departmentRepository;
            _designationRepository = designationRepository;
        }

        public Role CreateRole(CreateRole role)
        {
            var roleMap = new Role()
            {
                RoleName = role.RoleName
            };

            _roleRepository.Add(roleMap);
            _roleRepository.Commit();

            return roleMap;
        }

        public User CreateUser(CreateUser user)
        {
            var userMap = new User()
            {
                Username = user.Username,
                DisplayName = user.DisplayName,
                Email = user.Email,
                IsActive = true,
                DesignationId = user.DesignationId,
                DepartmentId = user.DepartmentId
            };

            _userRepository.Add(userMap);
            _userRepository.Commit();

            return userMap;
        }

        public Department CreateDepartment(CreateDepartment department)
        {
            var departmentMap = new Department()
            {
                Title = department.Title,
                Description = department.Description
            };

            _departmentRepository.Add(departmentMap);
            _departmentRepository.Commit();

            return departmentMap;
        }

        public Department DeleteDepartment(DeleteDepartmentInput department)
        {
            var departmentToDelete = _departmentRepository.GetSingle(b => b.Id == department.Id);
            _departmentRepository.Delete(departmentToDelete);
            _departmentRepository.Commit();

            return departmentToDelete;
        }

        public Designation CreateDesignation(CreateDesignation designation)
        {
            var designationMap = new Designation()
            {
                Title = designation.Title,
                Description = designation.Description
            };

            _designationRepository.Add(designationMap);
            _designationRepository.Commit();

            return designationMap;
        }

        public Designation DeleteDesignation(DeleteDesignationInput designation)
        {
            var designationToDelete = _designationRepository.GetSingle(b => b.Id == designation.Id);
            _designationRepository.Delete(designationToDelete);
            _designationRepository.Commit();

            return designationToDelete;
        }

    }
}
