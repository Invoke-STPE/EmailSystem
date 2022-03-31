using EmailSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailSystem.DL.Models
{
    public interface IApplicationDbContext
    {
        DbSet<EmailModel> Emails { get; set; }
    }
}