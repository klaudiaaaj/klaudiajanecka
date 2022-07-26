using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebAPI.Models
{
    public partial class kjaneckaContext : DbContext
    {
        public kjaneckaContext()
        {
        }

        public kjaneckaContext(DbContextOptions<kjaneckaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<IdToken> IdTokens { get; set; }
        public virtual DbSet<Platform> Platforms { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=157.158.104.78,21433;Database=kjanecka;Trusted_Connection=false;User Id=kjanecka; Password=Inzynierka2021!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<IdToken>(entity =>
            {
                entity.HasKey(e => e.TokenId)
                    .HasName("PK__IdTokens__658FEEEA09200EBA");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasColumnName("create_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Exp).HasColumnName("exp");

                entity.Property(e => e.Iat).HasColumnName("iat");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nickname");

                entity.Property(e => e.PlatformUserId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Platform>(entity =>
            {
                entity.Property(e => e.PlatformId).ValueGeneratedNever();

                entity.Property(e => e.PlatformName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.AppNickname)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
