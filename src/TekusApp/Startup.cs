using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TekusApp.Domain.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TekusApp.Domain.Behaviors;
using FamiliesApp.Domain.Infrastructure.Repositories;
using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TekusApp.Utils;

namespace TekusApp
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
            // Enable CORS
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddMvc(options =>
                options.SuppressAsyncSuffixInActionNames = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                serverOptions => serverOptions.MigrationsAssembly("TekusApp"))
            );

            services.AddScoped<DbContext>(p => p.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IClientBehavior, ClientBehavior>();
            services.AddScoped<IServiceBehavior, ServiceBehavior>();
            services.AddScoped<IServiceCountryBehavior, ServiceCountryBehavior>();
            services.AddScoped<ICountryBehavior, CountryBehavior>();
            services.AddTransient(typeof(IDataStorage<>), typeof(DataStorage<>));


            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });


            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Tekus APP",      
                });
            });

            //services.AddAutoMapper();
            services.AddAutoMapper(typeof(Startup));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.ConfigureExceptionHandler();
            }

            app.UseCors("CorsPolicy");

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TekusApp V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
