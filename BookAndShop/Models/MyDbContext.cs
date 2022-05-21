using Microsoft.EntityFrameworkCore;

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
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
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

                entity.HasMany(d => d.Genres)
                    .WithMany(p => p.Books);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Name).HasColumnType("character varying");

                entity.HasMany(d => d.Books)
                    .WithMany(p => p.Genres);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.Path).HasColumnType("character varying");
            });

           

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
