using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagment.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EmployeeManagment
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {

            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<EmployeeDbContext>(options => options.UseSqlServer(_config.GetConnectionString("EmpConnectionString")));
            services.AddMvc(opt => opt.EnableEndpointRouting = false).AddXmlSerializerFormatters();
            services.AddScoped<IEmployeeRepository, SqlEmployeeRepostory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                DeveloperExceptionPageOptions dexp = new DeveloperExceptionPageOptions();
                dexp.SourceCodeLineCount = 1;
                app.UseDeveloperExceptionPage(dexp);
            }

           // app.UseRouting();
           // //DefaultFilesOptions dd = new DefaultFilesOptions();
           // //dd.DefaultFileNames.Clear();
           // //dd.DefaultFileNames.Add("EmployeeList.html");
           // //app.UseDefaultFiles(dd);
             app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
           // app.UseMvc();
           //// app.UseFileServer();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("hi 3    " + env.EnvironmentName);               
            //});

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello Hello World  Help! <br>");
            //        await context.Response.WriteAsync(_config["ConfigKey"]);

            //    });
            //});


        }
    }
}
