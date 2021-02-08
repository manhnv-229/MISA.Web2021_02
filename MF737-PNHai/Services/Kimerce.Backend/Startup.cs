using System;
using System.IO;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Kimerce.Backend.Dto;
using Kimerce.Backend.Infrastructure.Data;
using Kimerce.Backend.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Kimerce.Backend.Infrastructure.Services.Employees;
using Kimerce.Backend.Infrastructure.Services.Books;

namespace Kimerce.Backend
{
    /// <summary>
    /// Startup
    /// </summary>

    public class Startup
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {

            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // Sử dụng MisaDbContext để kết nối đến test Database thông qua connectstrong trong file appsetting.json 
            // Db thứ 2 

            services.AddDbContext<MisaDbContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("PartConnection")));

            // Sử dụng KimDbContext để kết nối đến MisaIntern Database thông qua connectstrong trong file appsetting.json
            //Db thứ nhất 
            //services.AddDbContext<KimDbContext>(options =>
            //            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            #region Repositories
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IMisaRepository<>), typeof(MisaRepository<>));
            #endregion

            #region Services
            //services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IBookService, BookService>();
            #endregion
           





            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins, builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MISA Intern API", Version = "v1" });

                //c.IncludeXmlComments("/swagger/v1/swagger.json", true);
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
            app.UseSwagger();

            //app.UseReDoc(c =>
            //{
            //    c.SpecUrl = "/swagger/v1/swagger.json";
            //    c.DocumentTitle = "Product API V1";
            //    c.RoutePrefix = string.Empty;
            //});

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            AutoMapperConfig.Init();

        }
    }
}
