using EmailSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmailSystem.DL.Configurations
{
    internal class UserConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> modelBuilder)
        {
            // Configure Primary Key.
            //modelBuilder.ToTable("Users")
            //    .HasKey("id")
            //    .HasName("PK_Users");

            // Configure Properties.
            modelBuilder.Property(user => user.FirstName)
                .HasMaxLength(64);
            modelBuilder.Property(user => user.LastName)
                .HasMaxLength(64);
            modelBuilder.Property(user => user.Email)
                .IsRequired();
            modelBuilder.HasIndex(user => user.Email).IsUnique();
                
                



        }
    }
}
