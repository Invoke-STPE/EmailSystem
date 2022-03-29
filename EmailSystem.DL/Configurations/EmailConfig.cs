using EmailSystem.DL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EmailSystem.DL.Configurations
{
    internal class EmailConfig : IEntityTypeConfiguration<EmailModel>
    {
        public void Configure(EntityTypeBuilder<EmailModel> modelBuilder)
        {

            // Since private properties are not mapped by default in EFCore, We configure it here instead.

            modelBuilder.ToTable("Emails") // Set a name for the table instead of EmailModel
                .HasKey("id") // Tell EFCore to find the field called ID.
                .HasName("PK_Emails");


            // Configurations of both foreing keys, sender and recipient.
            modelBuilder.HasOne(recipient => recipient.Recipient)
                .WithMany(users => users.Emails)
                .HasForeignKey(recipient => recipient.RecipientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.HasOne(sender => sender.Sender)
                .WithMany(users => users.Emails)
                .HasForeignKey(sender => sender.SenderID)
                .OnDelete(DeleteBehavior.Cascade);
            //builder.Property(email => email.Sender).HasMaxLength(64);
            //builder.Property(email => email.Recipient).HasMaxLength(64);
            modelBuilder.Property(email => email.Message).HasMaxLength(255);
            modelBuilder.Property(email => email.SentDate).HasColumnType("date");
                
        }
    }
}
