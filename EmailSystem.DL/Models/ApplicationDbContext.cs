using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmailSystem.DL.Models
{
    /// <summary>
    /// Need to configure my AppContext to use default Identity user
    /// </summary>
    internal class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Instead of having all your custom configuration here, we split it out in configurations files individual for each model.
            builder.ApplyConfigurationsFromAssembly(assembly: typeof(ApplicationDbContext).Assembly);
        }
    }
}
