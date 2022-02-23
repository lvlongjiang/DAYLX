using EFContext;
using IRepositorySqlDb;
using IServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RepositorySqlDb;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAYLX
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
            //×¢ÈëEF
            var con = Configuration.GetConnectionString("con");
            services.AddDbContext<MyDbContext>(option => option.UseSqlServer(con));
            //²Ö´¢×¢Èë
            services.AddScoped(typeof(IRepositorySqlDbleave<>),typeof(RepositorySqlDbleave<>));
            //·þÎñ×¢Èë
            services.AddScoped<IServicesleave, Servicesleave>();
            //¿çÓòÅäÖÃ
            services.AddCors(s =>
            {
                s.AddPolicy("ljq", s =>
                {
                    s.AllowAnyMethod().AllowAnyHeader()
                    .SetIsOriginAllowed(_ => true).AllowCredentials();
                });
            });


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DAYLX", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DAYLX v1"));
            }

            app.UseCors("ljq");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
