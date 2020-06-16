using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastraxGlobal.API.GraphQL.DTOs
{
    public class CreateUser
    {
        public long Id { get; set; }
        public string Username { get; set; }
        private string Password { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public long DesignationId { get; set; }
        public long DepartmentId { get; set; }
    }
}
