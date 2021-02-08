using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
using MISA.Common.Models;
using MISA.DataLayer;
using MISA.Service;
using MISA.Service.Interface;
using MISA.Services;
using Newtonsoft.Json.Serialization;

namespace MISA_API_Demo
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
            //DBConnector.connectionString = Configuration.GetConnectionString("TXTConnection");
            //services.AddControllers();
            services.AddCors();

            // Cấu hình DI
            services.AddScoped(typeof(IDBConnector<>), typeof(DBConnectorV2<>));
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo{
                        Title = "MISA.DEMO.API Sevice",
                        Version = "v1"
                    });
                    c.CustomSchemaIds(type => type.ToString());
                });
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                // Use the default property (Pascal) casing
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(o=>o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseSwagger();
            app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MISA.DEMO.API Sevice V1");
                    c.RoutePrefix = "swagger";
                });

            app.UseHttpsRedirection();

            // Xử lí exeption chung
            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;

                var serviceResult = new ErroMsg();
                serviceResult.DevMsg = exception.Message;
                serviceResult.UserMsg.Add(MISA.Common.Properties.Resources.ExceptionMsg);
                await context.Response.WriteAsync(serviceResult.DevMsg);
                await context.Response.WriteAsync(serviceResult.UserMsg.ToString());
            }));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
