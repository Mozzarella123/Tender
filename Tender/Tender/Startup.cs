using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TenderApp.Data;
using TenderApp.Models;
using TenderApp.Services;
using TenderApp.Models.BusinessModels;
using TenderApp.Data.Repositories;

namespace TenderApp
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            services.Configure<IdentityOptions>(options =>
            {
                //Password options
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;

                //User options
                options.User.RequireUniqueEmail = true;
                
                
            });
            services.Configure<IdentityErrorDescriber>(options =>
            {
                
            });
            // Create application services.
            services.AddTransient<IEmailSender, EmailSender>();
            //services.AddTransient<IContext, IEFContext>();
            services.AddTransient<IContext, ApplicationDbContext>();
            services.AddTransient<IEFContext, ApplicationDbContext>();
            services.AddTransient<IRepository, GlobalRepository>();
            services.AddTransient<IRepository<Sub>, SubRepos>();
            services.AddTransient<IRepository<SubGroup>, SubGroupRepos>();

            services.AddTransient<IRepository<Category>, CategoryRepos>();

            //services.AddTransient<IRepository, ApplicationDbContext>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();






            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
