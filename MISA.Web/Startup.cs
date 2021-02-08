using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MISA.ApplicationCore;
using MISA.ApplicationCore.Interface;
using MISA.Common.Model;
using MISA.Infrastructure;
using MISA.Infrastructure.Interface;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Web
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
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MISA.Web", Version = "v1" });
            });

            services.AddScoped<IEmployeeDL, EmployeeDL>();
            services.AddScoped<IEmployeeDepartmentDL, EmployeeDepartmentDL>();
            services.AddScoped<IEmployeePositionDL, EmployeePositionDL>();
            services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>));

            services.AddScoped(typeof(IBaseBL<>), typeof(BaseBL<>));
            services.AddScoped<IEmployeePositionBL, EmployeePositionBL>();
            services.AddScoped<IEmployeeDepartmentBL, EmployeeDepartmentBL>();
            services.AddScoped<IEmployeeBL, EmployeeBL>();
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MISA.Web v1"));
            }

            // exception chung
            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;
                var errorMsg = new ErrorMsg();

                errorMsg.DevMsg = exception.Message;
                errorMsg.UserMsg.Add("Có lỗi xảy ra vui lòng liên hệ MISA");

                //await context.Response.WriteAsJsonAsync(new { error = exception.Message });
                await context.Response.WriteAsJsonAsync(errorMsg);
            }));

            app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
