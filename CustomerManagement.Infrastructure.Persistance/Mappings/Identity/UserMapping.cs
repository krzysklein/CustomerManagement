using CustomerManagement.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Infrastructure.Persistance.Mappings.Identity
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> userTypeBuilder)
        {
            userTypeBuilder.ToTable("Users");

            userTypeBuilder.Property(user => user.Id);
            userTypeBuilder.Property(user => user.UserName);
            userTypeBuilder.Property(user => user.PasswordHash);
            userTypeBuilder.OwnsOne(user => user.ContactDetails, contactDetailsTypeBuilder =>
            {
                contactDetailsTypeBuilder.Property(contactDetails => contactDetails.FirstName);
                contactDetailsTypeBuilder.Property(contactDetails => contactDetails.LastName);
            });

            userTypeBuilder.HasIndex(t => t.UserName)
                .IsUnique();
        }
    }
}
