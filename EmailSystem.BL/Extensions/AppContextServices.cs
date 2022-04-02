using EmailSystem.DL.Identity;
using EmailSystem.DL.Models;
using EmailSystem.BL.Services;
using EmailSystem.Domain.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using EmailSystem.Domain.Models;

namespace EmailSystem.BL.Extensions
{
    public static class AppContextServices
    {
        public static IServiceCollection AddAppContext(this IServiceCollection services,
                                                        string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            }, contextLifetime: ServiceLifetime.Transient);
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
