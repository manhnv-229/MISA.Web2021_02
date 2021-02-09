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
using Misa.Bussiness;
using Misa.Bussiness.Interfaces;
using Misa.Bussiness.Version1;
using Misa.Bussiness.Version2;
using Misa.Common;
using Misa.Common.Entities;
using Misa.Common.Enum;
using Misa.Common.Results;
using Misa.Data;

using Misa.Data.Interfaces;
using Misa.Data.Version1;
using Misa.Data.Version2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misa.NETCore
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Misa.NETCore", Version = "v1" });
            });
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:8080");
                                  });
            });

            // cấu hình Dependency Injection 
            services.AddScoped(typeof(IBaseData<>), typeof(DbConnection_V2<>));
            services.AddScoped(typeof(IBaseBussiness<>), typeof(BaseBussiness_V2<>));
           
            services.AddScoped<IEmployeeData, EmployeeData>();
            services.AddScoped<IEmployeeBussiness, EmployeeBussiness>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Misa.NETCore v1"));
            }

            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;

                //await context.Response.WriteAsJsonAsync(new { error = exception.Message });
                var errorResult = new List<ErrorResult>();
                errorResult.Add(new ErrorResult()
                {
                    DevMsg = exception.Message,
                    UserMsg = Properties.Resources.Error_Exeption,

                });

                var result =  new ServiceResult()
                {
                    Data = null,
                    Error = errorResult,
                    MISACukCukCode = MISACukCukServiceCode.Exception

                };
                await context.Response.WriteAsJsonAsync(result);
            }));

            app.UseHttpsRedirection();

            app.UseRouting();

            // sử dụng cors
            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
