﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Szkolimy_za_darmo_api.Core.Interfaces;
using Szkolimy_za_darmo_api.Persistance;
using Szkolimy_za_darmo_api.Services;

namespace Szkolimy_za_darmo_api
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
            services.AddDbContext<SzdDbContext>(options => options.UseMySQL(Configuration.GetConnectionString("Default")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITrainingRepository, TrainingRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IInstructorRepository, InstructorRepository>();
            services.AddScoped<IResourceRepository, ResourceRepository>();
            services.AddScoped<ICsvService, CsvService>();

            services.AddScoped<IEmailService, EmailService>();

            services.AddAutoMapper();
            services.AddCors();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(
                b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
                
            app.UseMvc();
        }
    }
}
