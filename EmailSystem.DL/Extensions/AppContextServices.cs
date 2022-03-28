using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmailSystem.DL.Extensions
{
    public static class AppContextServices
    {
        public static IServiceCollection AddAppContext(IServiceCollection services,
                                                        string connectionString)
        {
            services.AddDbContext<AppContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
