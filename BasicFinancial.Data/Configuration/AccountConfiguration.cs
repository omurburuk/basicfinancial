using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore; 
using BasicFinancial.Core.Models;

namespace BasicFinancial.Data.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasOne(m => m.Customer)
                .WithMany(a => a.Accounts)
                .HasForeignKey(m => m.CustomerId);

            builder
                .ToTable("Account");
        }
    }
}
