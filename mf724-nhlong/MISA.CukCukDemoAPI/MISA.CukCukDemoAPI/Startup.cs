using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MISA.Service.Interfaces;
using MISA.DataLayer;
using MISA.Service;

namespace DemoApi
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
            services.AddControllers();
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MISA.DEMO.API Service",
                    Version = "v1"
                });
                c.CustomSchemaIds(type => type.ToString());
            });
            services.AddScoped<IEmployeeReposity, EmployeeReposity>();
            services.AddScoped<IEmployeeServices, EmployeeService>();
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            // services.AddScoped(typeof(IBaseReposity<>), typeof(BaseReposity<>));
            // Chuyển sang Db2 là Database mẫu của anh Mạnh.Tuy nhiên phần DB của anh Mạnh không có bảng Department.
             services.AddScoped(typeof(IBaseReposity<>), typeof(BaseReposityDb2<>));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MISA.DEMO.API Services V1");
                c.RoutePrefix = "swagger";
            });
            app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
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
