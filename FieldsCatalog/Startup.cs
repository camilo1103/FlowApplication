using Application.Field.Implementation.Validation;
using Application.Field.Interfaces.Validation;
using AutoMapper;
using Infrastructure.Fields.Implementation.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Configuration.Database;

namespace FieldsCatalog
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
            var connectionString = Environment.GetEnvironmentVariable("SQL_SERVER_CONNECTION");

            services.AddDbContext<FieldContext>(
                options => options.UseSqlServer(connectionString),
                ServiceLifetime.Scoped);
            services.UseRepository(typeof(FieldContext));
            //add aplication injections
            services.AddScoped<IValidationApplication, ValidationApplication>();
            services.AddControllers();
            MapperConfiguration mappingConfig = new MapperConfiguration(config =>
            {
                config.AddMaps("Domain.Configuration.Field");
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
