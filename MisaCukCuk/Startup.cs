using Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MISA.DataLayer;
using MISA.DataLayer.DbContext1;
using MISA.DataLayer.DbContext2;
using MISA.DataLayer.Interfaces;
using MISA.Service;
using MISA.Service.Interfaces;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisaCukCuk
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MisaCukCuk", Version = "v1" });
            });

            // Note Review Code: Đây là config tầng data phụ thực hiện theo yêu cầu của anh
            // tầng data chả luôn chả về mảng rỗng, thêm sửa xóa luôn trả về 1
            /*services.AddScoped((typeof(IDbContext<>)), (typeof(DbContextV2<>)));
            services.AddScoped((typeof(IOfficeRepository<>)), (typeof(MISA.DataLayer.DbContext2.OfficeRepositoryV2<>)));
            services.AddScoped((typeof(IPositionRepository<>)), (typeof(MISA.DataLayer.DbContext2.PositionRepositoryV2<>)));
            services.AddScoped((typeof(IEmployeeRepository<>)), (typeof(MISA.DataLayer.DbContext2.EmployeeRepositoryV2<>)));
            services.AddScoped((typeof(IBaseService<>)), (typeof(BaseService<>)));*/

            // Note Review Code: Đây là config tầng data chính
            // đầy đủ các chức năng thêm sửa xóa.
            services.AddScoped((typeof(IDbContext<>)), (typeof(DbContext<>)));
            services.AddScoped((typeof(IOfficeRepository<>)), (typeof(MISA.DataLayer.DbContext1.OfficeRepository<>)));
            services.AddScoped((typeof(IPositionRepository<>)), (typeof(MISA.DataLayer.DbContext1.PositionRepository<>)));
            services.AddScoped((typeof(IEmployeeRepository<>)), (typeof(MISA.DataLayer.DbContext1.EmployeeRepository<>)));
            
            //Config tầng service
            services.AddScoped((typeof(IBaseService<>)), (typeof(BaseService<>)));
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IOfficeService, OfficeService>();
            services.AddScoped<IPositionService, PositionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MisaCukCuk v1"));
            }

            // xử lí exception chung
            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;

                ErrorMessenger errorMsg = new ErrorMessenger();
                errorMsg.DevMsg = exception.Message;
                errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorService_Exception);
                await context.Response.WriteAsJsonAsync(errorMsg);
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
