using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;


namespace LibrarySystem.DataAccess.Entities.Configurations
{

    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {

            builder.ToTable("Books");
            
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("Id");
            builder.Property(b => b.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);
            builder.Property(b => b.Author).HasColumnName("Author").IsRequired().HasMaxLength(255);
            builder.Property(b => b.Description).HasColumnName("Description");
            builder.Property(b => b.Price).HasColumnName("Price");


        }
    }

}
