using FastraxGlobal.Domain.Entities.Settings.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastraxGlobal.Infrastructure.Configurations.Identity
{
    public class DesignationConfig : IEntityTypeConfiguration<Designation>
    {
        public void Configure(EntityTypeBuilder<Designation> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();

            builder.Property(r => r.Title).IsRequired();

            builder.ToTable("Designations", "settings");
        }
    }
}
