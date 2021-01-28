using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using DoctorDoc1.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DoctorDoc1.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using DoctorDoc1.Services;
using DoctorDoc1.interfaces;
using DoctorDoc1.Extensions;
using DoctorDoc1.Middleware;

// ovo jednom
// git init
// git remote add origin https://github.com/tehica/DoctorDocumentation.git

// git status
// git add .
// git commit -m "Initialize"
// git push origin master

// git remote add origin https://github.com/tehica/DoctorDocumentation.git
namespace DoctorDoc1
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
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDefaultIdentity<IdentityUser>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentity<AppUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            //services.ConfigureApplicationCookie(options =>
            //{
            //    // Cookie settings
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

            //    options.LoginPath = "/Identity/Account/Login";
            //    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            //    options.SlidingExpiration = true;
            //});

            services.AddApplicationServices();

            services.AddControllersWithViews();

            // pitati za ovaj dio da li ce isto vrijediti za 
            // services.AddControllers() i services.AddControllersWithViews()

            //services.Configure<ApiBehaviorOptions>(options =>
            //{
            //    options.InvalidModelStateResponseFactory = actionContext =>
            //    {
            //        // check if any errors is in ModelState and if errors count > 0
            //        // then select them and add into array
            //        var errors = actionContext.ModelState
            //                                  .Where(e => e.Value.Errors.Count > 0)
            //                                  .SelectMany(x => x.Value.Errors)
            //                                  .Select(x => x.ErrorMessage).ToArray();

            //        // populate Errors property in ApiValidationErrorResponse with 'errors' <- array
            //        var errorResponse = new ApiValidationErrorResponse
            //        {
            //            Errors = errors
            //        };

            //        // errorResponse is ApiValidationErrorResponse and it is passed as request
            //        return new BadRequestObjectResult(errorResponse);
            //    };
            //});

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //    app.UseDatabaseErrorPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area=Guest}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
