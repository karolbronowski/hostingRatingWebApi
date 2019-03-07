using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hostingRatingWebApi.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using hostingRatingWebApi.Handlers.Interfaces;
using hostingRatingWebApi.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System.Text;
using hostingRatingWebApi.Extensions;
using hostingRatingWebApi.Mappers;
using hostingRatingWebApi.Filters;
using Newtonsoft.Json;
using hostingRatingWebApi.Repositories;
using hostingRatingWebApi.Services;

namespace hostingRatingWebApi
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
            // ===== Swagger =====
            services.AddSwaggerDocumentation();
            // ===== CORS =====
             services.AddCors(options =>
            {
                options.
                AddPolicy("CorsPolicy",
                builder => builder
                    .WithOrigins("http://localhost:4200","https://localhost:4200")
                    .WithMethods(new string[] { "GET", "POST", "PUT", "DELETE" })
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .Build()
                    );
            });
            // ===== Add Jwt Authentication ========
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JwtIssuer"],
                    ValidAudience = Configuration["JwtIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"]))
                    };
                });

            services.AddDistributedMemoryCache();

             services.AddScoped<IBrandPackageRepository,BrandPackageRepository>();   
             services.AddScoped<IBrandRepository,BrandRepository>();   

              services.AddScoped<IBrandPackageService,BrandPackageService>();   
             services.AddScoped<IBrandService,BrandService>();  

            services.AddSingleton<IJwtHandler,JwtHandler>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); 

            var connection = "Data Source=hostingRatingWebApi.db";
            services.AddDbContext<DatabaseContext>(options => options.UseSqlite(connection));

            services.AddSession(options =>
            {
                
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromMinutes(Double.Parse(Configuration["IdleTimeoutMinutes"]));
                options.Cookie.HttpOnly = true;
            });
            services.AddSingleton(AutoMapperConfig.Initialize());
            services.AddMvc(opt =>
            {
                opt.Filters.Add(typeof(ValidatorActionFilter));
                opt.Filters.Add(typeof(JsonExceptionFilter));                
            })
            .AddJsonOptions(
                x => {
                x.SerializerSettings.Formatting = Formatting.Indented;
                x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerDocumentation();
            app.UseCors("CorsPolicy");
            app.UseSession();
            app.UseMvc();
        }
    }
}
