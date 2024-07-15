using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; } = null!;


    public virtual DbSet<BorrowedBook> BorrowedBooks { get; set; } = null!;

    public virtual DbSet<Customer> Customers { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Book__C223F3941538DD47");

            entity.ToTable("Book");

            entity.Property(e => e.BookId)
                .ValueGeneratedNever()
                .HasColumnName("Book_ID");
            entity.Property(e => e.Author)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BookName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Book_name");
        });

        modelBuilder.Entity<BorrowedBook>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BorrowedBook");

            entity.Property(e => e.BookId).HasColumnName("Book_ID");
            entity.Property(e => e.BookName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Book_name");
            entity.Property(e => e.DueDate)
                .HasColumnType("datetime")
                .HasColumnName("Due_Date");
            entity.Property(e => e.IssueDate)
                .HasColumnType("datetime")
                .HasColumnName("Issue_Date");
            entity.Property(e => e.IssuerId).HasColumnName("Issuer_id");

            entity.HasOne(d => d.Book).WithMany()
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK__BorrowedB__Book___3A81B327");

            entity.HasOne(d => d.Issuer).WithMany()
                .HasForeignKey(d => d.IssuerId)
                .HasConstraintName("FK__BorrowedB__Issue__3B75D760");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__customer__3214EC275455CF73");

            entity.ToTable("customer");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(125)
                .IsUnicode(false);
            entity.Property(e => e.ContactNumber).HasColumnName("Contact_number");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
