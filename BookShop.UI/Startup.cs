using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Database;
using Pomelo.EntityFrameworkCore;
using Stripe;
using BookShop.Application.Users;
using BookShop.UI.Infrastructure;
using BookShop.Domain.Infrastructure;
using BookShop.Application.Cart;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.DataProtection;
using System.IO;
using BookShop.UI.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace BookShop.UI
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
            services.AddHttpContextAccessor();

            services.AddRazorPages();
            services.AddControllersWithViews();

            services.AddIdentity<ApplicationUser, IdentityRole> (options => 
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            services.ConfigureApplicationCookie(options => 
            {
                options.LoginPath = "/Accounts/Login";
            });

            services.AddAuthorization(options => 
            {
                options.AddPolicy("Admin", policy => policy.RequireClaim("Role","Admin"));
                //options.AddPolicy("Manager", policy => policy.RequireClaim("Role", "Manager"));
                options.AddPolicy("Manager", policy => policy
                .RequireAssertion(context =>
                context.User.HasClaim("Role", "Manager")
                || context.User.HasClaim("Role", "Admin")));
            });

            services
                .AddMvc(options => 
                {
                    options.EnableEndpointRouting = false; //сделано из-за app.UseMvcWithDefaultRoute();
                })
                .AddRazorPagesOptions(options => 
                {
                    options.Conventions.AuthorizeFolder("/Admin");
                    options.Conventions.AuthorizePage("/Admin/ConfigureUsers","Admin");
                })
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest)
                .AddFluentValidation(x => x.RegisterValidatorsFromAssembly(typeof(Startup).Assembly));//добавление всех валидаций через рефлексию сборки

            services.AddSession(options => {
                options.Cookie.Name = "Cart";
                options.Cookie.MaxAge = TimeSpan.FromMinutes(20);
            });

            //

            var serverVersion = new MySqlServerVersion(new Version(5, 7, 33));

            services.AddDbContextPool<ApplicationDbContext>(options =>
            {
                options.UseMySql("server=localhost;user=root;password=pass;database=bookshopdb;", serverVersion);
            });

            services.AddApplicationServices();
            //Шифрование
            services.AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(@"bin\debug\BookShopKeys"));
            services.AddSignalR();
            services.AddSingleton<IUserIdProvider, CustomUserIdProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
           
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chat");
            });

            app.UseMvcWithDefaultRoute(); 
        }
    }
}
