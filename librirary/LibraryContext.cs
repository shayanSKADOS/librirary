using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Library;

public partial class LibraryContext : DbContext
{
    public LibraryContext()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Bookcopy> Bookcopies { get; set; }

    public virtual DbSet<Bookloan> Bookloans { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;database=library;user=root;password=", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.42-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("admin");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Password)
                .HasMaxLength(512)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(45)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("book");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Author)
                .HasMaxLength(255)
                .HasColumnName("author");
            entity.Property(e => e.Category)
                .HasMaxLength(100)
                .HasColumnName("category");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Bookcopy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("bookcopies");

            entity.HasIndex(e => e.BookId, "book_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.IsAvailable)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("isAvailable");

            entity.HasOne(d => d.Book).WithMany(p => p.Bookcopies)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bookcopies_ibfk_1");
        });

        modelBuilder.Entity<Bookloan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("bookloan");

            entity.HasIndex(e => e.BookCopyId, "bookCopyId");

            entity.HasIndex(e => e.MembrId, "membrId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookCopyId).HasColumnName("bookCopyId");
            entity.Property(e => e.LoanDate)
                .HasColumnType("timestamp")
                .HasColumnName("loanDate");
            entity.Property(e => e.MembrId).HasColumnName("membrId");
            entity.Property(e => e.ReturnDate)
                .HasColumnType("timestamp")
                .HasColumnName("returnDate");

            entity.HasOne(d => d.BookCopy).WithMany(p => p.Bookloans)
                .HasForeignKey(d => d.BookCopyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bookloan_ibfk_1");

            entity.HasOne(d => d.Membr).WithMany(p => p.Bookloans)
                .HasForeignKey(d => d.MembrId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bookloan_ibfk_2");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("member");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(512)
                .HasColumnName("password");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.Username)
                .HasMaxLength(45)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
