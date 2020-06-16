using FastraxGlobal.Domain.Interfaces.Repositories;
using FastraxGlobal.Domain.Interfaces.Repositories.Settings;
using FastraxGlobal.Domain.Interfaces.Services;
using FastraxGlobal.Domain.Services;
using FastraxGlobal.Infrastructure.Context;
using FastraxGlobal.Infrastructure.Repositories;
using FastraxGlobal.Infrastructure.Repositories.Settings;
using HotChocolate;
using HotChocolate.Execution.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FastraxGlobal.API.Helpers.Extensions
{
    public enum SQLDbProvider
    {
        MSSQL,
        MYSQL
    }

    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Applies collection of DI services 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection ApplyServices(this IServiceCollection services)
        {
            services.AddScoped<IEncryptionService, EncryptionService>();
            services.AddScoped<IMembershipService, MembershipService>();

            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IDesignationRepository, DesignationRepository>();

            #region Settings

            #region Requests

            #endregion

            #region System
            #endregion System

            #region User
            #endregion User

            #region StandardEntries
            #endregion StandardEntries

            #endregion Settings

            #region CRM

            #region Accounts
            #endregion Accounts

            #region Sales
            #endregion Sales

            #region Projects
            #endregion Projects

            #region Complaints
            #endregion Complaints

            #endregion CRM

            #region AssetManagement

            #region StandardEntries
            #endregion StandardEntries

            #region Components
            #endregion Components

            #region GeneralAssets
            #endregion GeneralAssets

            #region Vehicles
            #endregion Vehicles

            #endregion AssetManagement

            return services;
        }

        /// <summary>
        /// Applies GraphQL Implementation
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection ApplyGraphQLService(this IServiceCollection services)
        {
            var schemaBuild = SchemaBuilder.New().ModifyOptions(opt => opt.UseXmlDocumentation = true);

            // Types
            var types = Assembly.GetEntryAssembly().GetTypes().Where(t => t.Namespace == "FastraxGlobal.API.GraphQL.Types" && t.IsClass && t.DeclaringType == null).ToList();
            types.ForEach(_type => schemaBuild.AddType(_type));

            // Queries
            var queries = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == "FastraxGlobal.API.GraphQL.Query" && t.IsClass && t.DeclaringType == null).ToList();
            queries.ForEach(_type => schemaBuild.AddQueryType(_type));

            // Mutations
            var mutations = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == "FastraxGlobal.API.GraphQL.Mutations" && t.IsClass && t.DeclaringType == null).ToList();
            mutations.ForEach(_type => schemaBuild.AddMutationType(_type));

            services.AddGraphQL(s => schemaBuild.AddServices(s).Create(),
                new QueryExecutionOptions { TracingPreference = TracingPreference.OnDemand }
            );

            return services;
        }

        /// <summary>
        /// Defines your MDBContext Connection String
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString">Connection String</param>
        /// <param name="provider">Specify SQL Provider, default provider is MSSQL</param>
        /// <returns></returns>
        public static IServiceCollection AddContextConnection(this IServiceCollection services, string connectionString, SQLDbProvider provider = SQLDbProvider.MSSQL)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("Please define your connection string.");

            services.AddDbContext<MDbContext>(options =>
            {
                if (provider == SQLDbProvider.MSSQL)
                    options.UseSqlServer(connectionString);
            });

            return services;
        }

    }
}
