using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FastraxGlobal.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FastraxGlobal.Domain.Entities.Settings;
using FastraxGlobal.Domain.Entities.Settings.Identity;

namespace FastraxGlobal.Infrastructure.Context
{
    public class MDbContext : DbContext
    {
        public MDbContext(DbContextOptions<MDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);

            System.Reflection.Assembly assemblyWithConfigurations = GetType().Assembly; //get whatever assembly you want
            modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Department> Department { get; set; }
    }
}
