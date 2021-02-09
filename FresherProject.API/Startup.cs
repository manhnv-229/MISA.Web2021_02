using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FresherProject.DataLayer.Database;
using Microsoft.OpenApi.Models;
using FresherProject.Service.Interfaces;
using FresherProject.Service;
using FresherProject.DataLayer.Interfaces;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using FresherProject.Common.Message;

namespace FresherProject.API
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
            //DBConnector.connectionString = Configuration.GetConnectionString("MISACukCukConnection");
            services.AddControllers();
            services.AddCors();
            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddHttpClient();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MISA.CukCuk.API Service"
                    ,
                    Version = "v1"
                });
                c.CustomSchemaIds(type => type.ToString());
            });

            // Cau hinh DI Dependency Injection: Khu su phu thuoc cua cac interfaces
            //services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<IEmployeeService, EmployeeService>();

            // Cau hinh DI cho viec giao tiep giua DataLayer va Service
            //services.AddScoped(typeof(IDBConnector<>), typeof(DBConnector<>));

            //Doi sang database khác:
            //services.AddScoped(typeof(IDBConnector<>), typeof(DBConnectorV2<>));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Middleware xu li exception
            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;

                var errorMsg = new ErrorMsg();
                errorMsg.DevMsg = exception.Message;
                errorMsg.UserMsg.Add("Có lỗi xảy ra, vui lòng liên hệ Phạm Văn Ngọc để được trợ giúp!");

                await context.Response.WriteAsync("Có lỗi xảy ra, vui lòng liên hệ Phạm Văn Ngọc để được trợ giúp!");
            }));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MISA.CukCuk.API Service V1");
                c.RoutePrefix = "swagger";
            });


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
