using FastraxGlobal.Domain.Entities.Settings.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastraxGlobal.Domain.Entities.Settings.Modules
{
    public class ActionCustom
    {
        public long Id { get; set; }
        public long ActionId { get; set; }
        public long AccessModuleId { get; set; }
        public int RoleId { get; set; }
        public long UserId { get; set; }
        public bool IsEnable { get; set; }

        public virtual Modules.Action Action { get; set; }
        public virtual AccessModule AccessModule { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
