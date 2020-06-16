using FastraxGlobal.Domain.Entities.Settings;
using FastraxGlobal.Domain.Entities.Settings.Identity;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastraxGlobal.API.GraphQL.Types
{
    public class RoleType : ObjectType<Role>
    {
        protected override void Configure(IObjectTypeDescriptor<Role> descriptor)
        {
            descriptor.Field(x => x.Id).Type<IntType>();
            descriptor.Field(x => x.RoleName).Type<StringType>();
        }
    }
}
