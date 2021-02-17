using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using src.RealEstate.Dal.Context;
using src.RealEstate.Entity.Entities;
using src.RealEstate.Repository;
using src.RealEstate.Repository.Contracts;
using src.RealEstate.Service;
using src.RealEstate.Service.Contracts;

namespace RealEstate.Admin
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
            services.AddControllersWithViews();
            services.AddDbContext<EstateContext>(x => x.UseMySql(Configuration.GetConnectionString("MySqlProvider")));

            services.AddIdentity<EstateUser, EstateRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters += "öçşığüÖÇŞİĞÜ";
            })
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<EstateContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Login");
                options.LogoutPath = new PathString("/Logout");
                options.Cookie = new CookieBuilder
                {
                    Name = "user",
                    HttpOnly = false,
                    SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Lax,
                    SecurePolicy = CookieSecurePolicy.Always
                };
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(14);
            });

            services.Configure<DataProtectionTokenProviderOptions>(options => options.TokenLifespan = TimeSpan.FromMinutes(10));

            services.AddScoped<IMailService>(x => new MailService
            {
                Host = Configuration["Mail:Host"],
                Port = string.IsNullOrEmpty(Configuration["Mail:Port"]) ? 0 : Convert.ToInt32(Configuration["Mail:Port"]),
                Username = Configuration["Mail:Username"],
                Password = Configuration["Mail:Password"],
                UseSsl = !string.IsNullOrEmpty(Configuration["Mail:UseSsl"]) && Convert.ToBoolean(Configuration["Mail:UseSsl"]),
            });

            services.AddScoped<IUnitOfWork,UnitOfWork>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}