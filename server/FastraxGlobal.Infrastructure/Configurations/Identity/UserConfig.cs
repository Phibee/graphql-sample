using FastraxGlobal.Domain.Entities.Settings.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastraxGlobal.Infrastructure.Configurations
{
    class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasIndex(c => new { c.Email, c.Username }).IsUnique();

            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Username).HasMaxLength(32).IsRequired();
            builder.Property(typeof(string), "Salt").IsRequired();
            builder.Property(typeof(string), "Password").IsRequired();


            builder.Property(u => u.DisplayName)
                   .HasMaxLength(200)
                   .HasColumnType("varchar(250)")
                   .IsRequired();

            builder.HasOne(u => u.Designation)
                   .WithMany()
                   .HasForeignKey(u => u.DesignationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Department)
                   .WithMany()
                   .HasForeignKey(u => u.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Users", "settings");
        }
    }
}
