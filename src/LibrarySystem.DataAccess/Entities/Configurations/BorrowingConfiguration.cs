using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.DataAccess.Entities.Configurations
{
    public class BorrowingConfiguration : IEntityTypeConfiguration<Borrowing>
    {


        public void Configure(EntityTypeBuilder<Borrowing> builder)
        {
            builder.ToTable("Borrowing");
            builder.HasOne(c => c.Copy)
            .WithMany(b => b.Borrowings)
            .HasForeignKey(c => c.CopyId);

            builder.HasOne(u => u.User)
            .WithMany(b => b.Borrowings)
            .HasForeignKey(u => u.UserId);

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("Id");
            builder.Property(b => b.UserId).HasColumnName("UserId");
            builder.Property(b => b.CopyId).HasColumnName("CopyId");
            builder.Property(b => b.UserName).HasColumnName("UserName");
            builder.Property(b => b.BookName).HasColumnName("BookName");
            builder.Property(b => b.BorrowedDate).HasColumnName("BorrowedDate");
            builder.Property(b => b.ReturnDate).HasColumnName("ReturnDate");
            builder.Property(b => b.BorrowPrice).HasColumnName("BorrowPrice");



        }
    }
}
