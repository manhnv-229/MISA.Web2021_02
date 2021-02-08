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
using MisaCukCuk_ApplicationCore.ApplicationCore.CustomerApplicationCore;
using MisaCukCuk_ApplicationCore.ApplicationCore.CustomerGroupApplicationCore;
using MisaCukCuk_ApplicationCore.ApplicationCore.DepartmentApplicationCore;
using MisaCukCuk_ApplicationCore.ApplicationCore.EmployeeApplicationCore;
using MisaCukCuk_ApplicationCore.ApplicationCore.PositionApplicationCore;
using MisaCukCuk_ApplicationCore.BaseApplicationCore;
using MisaCukCuk_Entity.Common;
using MisaCukCuk_Infarstructure.Infarstructure.CustomerGroupInfarstructure;
using MisaCukCuk_Infarstructure.Infarstructure.CustomerInfarstructure;
using MisaCukCuk_Infarstructure.Infarstructure.DepartmentInfarstructure;
using MisaCukCuk_Infarstructure.Infarstructure.EmployeeInfarstructure;
using MisaCukCuk_Infarstructure.Infarstructure.PositionInfarstructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisaCukCuk_ServiceApi
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
            services.AddTransient<ICustomerApplicationCore, CustomerApplicationCore>();
            services.AddTransient<ICustomerInfarstructure, CustomerInfarstructure>();
            services.AddTransient<IEmployeeInfarstructure, EmployeeInfarstructure>();
            services.AddTransient<IEmployeeApplicationCore, EmployeeApplicationCore>();
            services.AddTransient<ICustomerGroupApplicationCore, CustomerGroupApplicationCore>();
            services.AddTransient<ICustomerGroupInfarstructure, CustomerGroupInfarstructure>();
            services.AddTransient<IDepartmentApplicationCore, DepartmentApplicationCore>();
            services.AddTransient<IDepartmentInfarstructure, DepartmentInfarstructure>();
            services.AddTransient<IPositionApplicationCore, PositionApplicationCore>();
            services.AddTransient<IPositionInfarstructure, PositionInfarstructure>();
            //cấu hình DI
            services.AddTransient(typeof(IBaseApplicationCore<>), typeof(BaseApplicationCore<>));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MisaCukCuk_ServiceApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MisaCukCuk_ServiceApi v1"));
            };
            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;
                var errorMsg = new ErrorMsg();
                errorMsg.DevMsg = exception.Message;
                errorMsg.UserMsg.Add(MisaCukCuk_Entity.Properties.Resources.Exception);

                //await context.Response.WriteAsJsonAsync(new { error = exception.Message });
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
