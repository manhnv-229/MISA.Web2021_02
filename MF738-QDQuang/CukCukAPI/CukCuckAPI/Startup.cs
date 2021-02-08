using CukCuk.BL;
using CukCuk.BL.Interfaces;
using CukCuk.BL.Services;
using CukCuk.Common.Models;
using CukCuk.DataLayer;
using CukCuk.DataLayer.DataLayers;
using CukCuk.DataLayer.Interfaces;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CukCuckAPI
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CukCuckAPI", Version = "v1" });
            });

            // Cấu hình Dependency Injection
            services.AddScoped(typeof(IBaseBL<>), typeof(BaseBL<>));

            // Cơ sở dữ liệu 1
            services.AddScoped(typeof(IDbConnector<>), typeof(DbConnector<>));
            // Cơ sở dữ liệu 2
            // services.AddScoped(typeof(IDbConnector<>), typeof(DbConnectorV2<>));

            services.AddScoped<ICustomerBL, CustomerBL>();
            // services.AddScoped<ICustomerBL, CustomerBLV2>();
            services.AddScoped<ICustomerDL, CustomerDL>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CukCuckAPI v1"));
            }
            // Xử lý exception chung
            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;

                var errMsg = new ErrMsg();
                errMsg.DevMsg = exception.Message;
                errMsg.UserMsg.Add("Có lỗi xảy ra vui lòng liên hệ 0355");
                // await context.Response.WriteAsJsonAsync(new { error = exception.Message });
                await context.Response.WriteAsJsonAsync(errMsg);
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
