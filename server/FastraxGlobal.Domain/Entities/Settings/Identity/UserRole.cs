using System;
using System.Collections.Generic;
using System.Text;

namespace FastraxGlobal.Domain.Entities.Settings.Identity
{
    public class UserRole
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public long UserId { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
