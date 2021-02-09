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
using MISA.Common.Model;
using MISA.CUKCUK.DataLayer;
using MISA.DataLayer;
using MISA.DataLayer.Context;
using MISA.DataLayer.EntityDL;
using MISA.DataLayer.Interface;
using MISA.Service;
using MISA.Service.Entity;
using MISA.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CUKCUK.API
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MISA.CUKCUK.API", Version = "v1" });
            });


            //Gọi các interface ở đây
            //base
            services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>));
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IDbContext<>), typeof(LocalDbContext<>));
            //DataLayer
            services.AddScoped<ICustomerDL, CustomerDL>();
            services.AddScoped<ICustomerGroupDL, CustomerGroupDL>();
            //Service
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerGroupService, CustomerGroupService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MISA.CUKCUK.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            //Xử lý exception chung
            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;
                var errorMsg = new ErrorMsg();
                errorMsg.DevMsg = exception.Message;
                errorMsg.UserMsg = MISA.Common.Properties.Resources.Error_UserMsg;
                await context.Response.WriteAsJsonAsync(errorMsg);
                //await context.Response.WriteAsJsonAsync(new { error = exception.Message });
            }));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
