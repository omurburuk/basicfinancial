using BasicFinancial.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicFinancial.Data.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder
               .Property(m => m.LastName)
               .IsRequired()
               .HasMaxLength(50);
            builder
                .ToTable("Customer");
        }
    }
}
