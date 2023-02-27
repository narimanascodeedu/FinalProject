using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using MotorOil.Domain.AppCode.Providers;
using MotorOil.Domain.Models.DataContexts;
using MotorOil.Domain.Models.Entities.Membership;
using System;
using System.Linq;
using System.Security.Claims;

namespace MotorOil.Domain.AppCode.Extensions
{
    public static partial class Extension
    {

        public static string[] policies = null;

        public static IServiceCollection SetupIdentity(this IServiceCollection services)
        {

            

            services.AddIdentity<MotorOilUser, MotorOilRole>()
                .AddEntityFrameworkStores<MotorOilDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<SignInManager<MotorOilUser>>();
            services.AddScoped<UserManager<MotorOilUser>>();
            services.AddScoped<RoleManager<MotorOilRole>>();


            services.AddScoped<IClaimsTransformation, AppClaimProvider>();

            services.Configure<IdentityOptions>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
                //cfg.User.AllowedUserNameCharacters = "";
                cfg.Password.RequiredLength = 3;
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequireUppercase = false;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireDigit = false;
                cfg.Password.RequiredUniqueChars = 1; //aabacc- tekrarlanmayan nece dene simvol olmalidi

                cfg.Lockout.DefaultLockoutTimeSpan = new TimeSpan(0,1,0);
                cfg.Lockout.AllowedForNewUsers = false;

                cfg.SignIn.RequireConfirmedPhoneNumber = false;
                cfg.SignIn.RequireConfirmedEmail = true;
                cfg.SignIn.RequireConfirmedAccount = false;
            });

            services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LoginPath = "/signin.html";
                cfg.AccessDeniedPath = "/accessdenied.html";

                cfg.Cookie.Name = "MotorOil";
                cfg.Cookie.HttpOnly = true;
                cfg.ExpireTimeSpan = new TimeSpan(0,15,0);
            });

            return services;
        }

        public static bool HasAccess(this ClaimsPrincipal principal, string policyName)
        {
            if (principal.IsInRole("sa"))
            {
                return true;
            }
            return principal.Claims.Any(c => c.Type.Equals(policyName) && c.Value.Equals("1"));
        }
        public static int GetCurrentUserId(this ClaimsIdentity identity)
        {
            return Convert.ToInt32(
                identity.Claims.FirstOrDefault(c => 
                c.Type.Equals(ClaimTypes.NameIdentifier))?.Value
                );
        }
        public static int GetCurrentUserId(this ClaimsPrincipal principal)
        {
            if (principal.Identity is ClaimsIdentity identity)
            {
                return identity.GetCurrentUserId();
            }
            return 0;
        }
        public static int GetCurrentUserId(this IActionContextAccessor ctx)
        {
            return ctx.ActionContext.HttpContext.User.GetCurrentUserId();
        }

        static public string GetPrincipalName(this ClaimsPrincipal principal)
        {
            string name = principal.Claims.FirstOrDefault(c => c.Type.Equals("name"))?.Value;
            string surname = principal.Claims.FirstOrDefault(c => c.Type.Equals("surname"))?.Value;

            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(surname))
            {
                return $"{name} {surname}";
            }

            return principal.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Email))?.Value;
        }
    }
}
