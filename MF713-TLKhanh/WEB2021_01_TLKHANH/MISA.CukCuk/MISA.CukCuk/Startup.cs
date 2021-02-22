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
using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces;
using MISA.CukCuk.Core.Services;
using MISA.CukCuk.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MISA.CukCuk
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

            services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            services.AddCors(option =>
            {
                option.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MISA.CukCuk", Version = "v1" });
            });
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MISA.CukCuk v1"));
            }
            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var errorMsg = new ErrorMessage();
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;

                errorMsg.DevMsg = exception.Message;
                errorMsg.UserMsg.Add("Có lỗi xảy ra vui lòng liên hệ MISA để được trợ giúp!");
                await context.Response.WriteAsJsonAsync(errorMsg);
            }));

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
