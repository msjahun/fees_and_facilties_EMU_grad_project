using ASPNetRazorPageDemo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ASPNetRazorPageDemo
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
            //services.AddMvc().WithRazorPagesRoot("/MyPages");
            //services.AddMvc().WithRazorPagesAtContentRoot();
            services.AddMvc();
            //var connection = @"Server=DARK-SHILLA\SQLEXPRESS;Database=fees_and_facilities;Trusted_Connection=True;";
            //services.AddDbContext<fees_and_facilitiesContext>(options => options.UseSqlServer(connection));

            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
            //services.Configure<RazorPagesOptions>(options => options.RootDirectory = "/MyPages");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
