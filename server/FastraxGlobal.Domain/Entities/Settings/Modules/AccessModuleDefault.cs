using FastraxGlobal.Domain.Entities.Settings.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastraxGlobal.Domain.Entities.Settings.Modules
{
    public class AccessModuleDefault
    {
        public long Id { get; set; }
        public long AccessModuleId { get; set; }
        public long RoleId { get; set; }
        public bool IsEnable { get; set; }

        public virtual AccessModule AccessModule { get; set; }
        public virtual Role Role { get; set; }
    }
}
