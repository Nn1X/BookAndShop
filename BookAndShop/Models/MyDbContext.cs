using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookAndShop.Models
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost; Port=5432; User Id=postgres; Password=sa; Database=BookShop");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Fio)
                    .HasColumnType("character varying")
                    .HasColumnName("FIO");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("character varying");

                entity.Property(e => e.IdAuthor)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id_Author");

                entity.Property(e => e.IdImage)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id_Image");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Title).HasColumnType("character varying");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdAuthor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkey_Books_Id_Author");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdImage)
                    .HasConstraintName("fkey_Books_Id_Image");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.Path).HasColumnType("character varying");
            });

            //modelBuilder.Entity<Role>(entity =>
            //{
            //    entity.Property(e => e.Name).HasColumnType("character varying");
            //});

            //modelBuilder.Entity<User>(entity =>
            //{
            //    entity.Property(e => e.Address).HasColumnType("character varying");

            //    entity.Property(e => e.Fio)
            //        .HasColumnType("character varying")
            //        .HasColumnName("FIO");

            //    entity.Property(e => e.IdRole)
            //        .ValueGeneratedOnAdd()
            //        .HasColumnName("Id_Role");

            //    entity.Property(e => e.Login).HasColumnType("character varying");

            //    entity.Property(e => e.Password).HasColumnType("character varying");

            //    entity.HasOne(d => d.IdRoleNavigation)
            //        .WithMany(p => p.Users)
            //        .HasForeignKey(d => d.IdRole)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("fkey_Users_Id_Role");
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
