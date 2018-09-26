﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Harman.Business;
using Harman.Data.Entity.DataAccess;
using Harman.Data.Entity.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Harman.Services.Api
{
    public class Startup
    {
        //private IContainer _autofacContainer;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
            {
                   options.AddPolicy("patients",
                    policy => policy.WithOrigins("http://localhost:60767/"));
            });
            services.AddMvc(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("patients"));
            });

            services.AddSwaggerGen(c =>
            {
                // Swagger options go here
                c.SwaggerDoc("v1", new Info { Title = "Harman Patient Api", Version = "v1" });
                c.DescribeAllEnumsAsStrings();
            });

            services.AddScoped(_ => new HealthCareMainDBContext());
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatient, Patient>();

            //var builder = new ContainerBuilder();

            //builder.RegisterType<IPatientRepository>().As<PatientRepository>().InstancePerLifetimeScope();
            //builder.RegisterType<IPatient>().As<Patient>().InstancePerLifetimeScope();

            //builder.Populate(services);

            //_autofacContainer = builder.Build();
            services.AddAutoMapper();

            //return new AutofacServiceProvider(_autofacContainer);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.UseCors("patients");

            app.UseMvcWithDefaultRoute();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseMvc();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Patient API V1"));
        }
    }
}
