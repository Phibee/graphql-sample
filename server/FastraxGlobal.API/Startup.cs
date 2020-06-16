using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FastraxGlobal.API.GraphQL;
using FastraxGlobal.API.GraphQL.Mutations;
using FastraxGlobal.API.GraphQL.Query;
using FastraxGlobal.API.GraphQL.Types;
using FastraxGlobal.API.Helpers.Extensions;
using FastraxGlobal.Domain.Interfaces.Repositories;
using FastraxGlobal.Domain.Interfaces.Repositories.Settings;
using FastraxGlobal.Infrastructure.Context;
using FastraxGlobal.Infrastructure.Repositories;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Execution.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FastraxGlobal.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddHttpContextAccessor();

            var config = Configuration["ConnectionStrings:lmsDb"];
            services.AddDbContext<MDbContext>(options => options.UseSqlServer(config, b => b.MigrationsAssembly("FastraxGlobal.Infrastructure")));

            services.ApplyServices();

            services.ApplyGraphQLService();

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UsePlayground();
            }

            //app.UseHttpsRedirection();

            app.UseGraphQL("/api");

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            });
        }
    }
}
