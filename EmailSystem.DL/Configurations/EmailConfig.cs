using EmailSystem.DL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EmailSystem.DL.Configurations
{
    internal class EmailConfig : IEntityTypeConfiguration<EmailModel>
    {
        public void Configure(EntityTypeBuilder<EmailModel> modelBuilder)
        {

            // Since private properties are not mapped by default in EFCore, We configure primary key here instead.
            // This is a cleaner way to configuring entities.

            modelBuilder.ToTable("Emails") 
                .HasKey("id")
                .HasName("PK_Emails");


            // Configuring foreign keys.
            modelBuilder.HasOne(recipient => recipient.Recipient)
                .WithMany(users => users.ReceivedEmails)
                .HasForeignKey(recipient => recipient.RecipientId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.HasOne(sender => sender.Sender)
                .WithMany(users => users.SentEmails)
                .HasForeignKey(sender => sender.SenderID)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure Properties.
            modelBuilder.Property(email => email.Message).HasMaxLength(255);
            modelBuilder.Property(email => email.SentDate).HasColumnType("date");
                
        }
    }
}
