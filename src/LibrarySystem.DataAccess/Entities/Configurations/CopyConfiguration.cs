using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.DataAccess.Entities.Configurations
{
    public class CopyConfiguration : IEntityTypeConfiguration<Copy>
    {
        public void Configure(EntityTypeBuilder<Copy> builder)
        {
            builder.ToTable("Copies");
            builder.HasOne(b => b.Book)
            .WithMany(c => c.Copies)
            .HasForeignKey(b => b.BookId);
            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.NumberOfCopies).HasColumnName("NumberOfCopies");
            builder.Property(c => c.Status).HasColumnName("Status");
            builder.Property(c => c.BookId).HasColumnName("BookId");
        }
    }
}
