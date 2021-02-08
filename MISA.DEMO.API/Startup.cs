using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using MISA.Common.Models;
using MISA.Service.Interface;
using MISA.Service;
using MISA.DataLayer;
using MISA.DataLayer.Interface;
using MISA.DataLayer.Context;

namespace MISA.DEMO.API
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
                c.CustomSchemaIds(Type => Type.ToString());
            });
            // Cấu hình DI
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IDepartmentContext, DepartmentContext>();
            services.AddScoped<IPositionContext, PositionContext>();
            services.AddScoped<IEmployeeContext, EmployeeContext>();
            services.AddScoped(typeof(IDbContext<>), typeof(DbContextV2<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MISA.DEMO.API Service V1");
                c.RoutePrefix = "swagger";
            });

            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;

                var errorMsg = new ErrorMsg()
                {
                    DevMsg = exception.Message,
                    
                    
                };
                errorMsg.UserMsg.Add("Có lỗi xảy ra vui lòng liên hệ MISA để được hỗ trợ.");
                var result = JsonConvert.SerializeObject(errorMsg);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }));
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
