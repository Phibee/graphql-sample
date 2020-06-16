using System;
using System.Collections.Generic;
using System.Text;

namespace FastraxGlobal.Domain.Entities.Settings
{
    public class AccessModule
    {
        public long Id { get; set; }
        public string ModuleName { get; set; }
        public int? ParentAccessModuleId { get; set; }


        public AccessModule ParentAccessModule { get; set; }
    }
}
