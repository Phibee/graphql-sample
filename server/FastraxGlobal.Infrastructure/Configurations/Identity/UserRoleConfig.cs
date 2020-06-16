using FastraxGlobal.Domain.Entities.Settings;
using FastraxGlobal.Domain.Entities.Settings.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastraxGlobal.Infrastructure.Configurations.Identity
{
    public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasOne(r => r.Role)
                   .WithMany()
                   .HasForeignKey(r => r.RoleId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.User)
                   .WithMany()
                   .HasForeignKey(u => u.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("UserRoles", "settings");
        }
    }
}
