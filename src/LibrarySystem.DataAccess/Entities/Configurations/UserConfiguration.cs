using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.DataAccess.Entities.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {


            builder.ToTable("Users");
            builder.Property(u => u.Id).HasColumnName("Id");
            builder.Property(u => u.Name).HasColumnName("Name");
            builder.Property(u => u.Email).HasColumnName("Email");
            builder.Property(u => u.PhoneNumber).HasColumnName("PhoneNumber");
            builder.Property(u => u.Balance).HasColumnName("Balance");
            builder.HasKey(u => u.Id);
        }
    }
}
