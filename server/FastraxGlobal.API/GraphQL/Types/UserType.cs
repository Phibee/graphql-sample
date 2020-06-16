using FastraxGlobal.Domain.Entities.Settings.Identity;
using FastraxGlobal.Domain.Interfaces.Repositories.Settings;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastraxGlobal.API.GraphQL.Types
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Field(x => x.Id).Type<IntType>();
            descriptor.Field(x => x.Username).Type<StringType>();
            descriptor.Field(x => x.Department).Resolver(
                    ctx => ctx.Service<IDepartmentRepository>().GetSingle(d => d.Id == ctx.Parent<User>().DepartmentId));
            descriptor.Field(x => x.Designation).Resolver(
                    ctx => ctx.Service<IDesignationRepository>().GetSingle(d => d.Id == ctx.Parent<User>().DesignationId));
        }
    }
}
