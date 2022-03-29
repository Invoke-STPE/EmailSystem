using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmailSystem.DL.Models
{
    /// <summary>
    /// Need to configure my AppContext to use default Identity user
    /// </summary>
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
    }
}
