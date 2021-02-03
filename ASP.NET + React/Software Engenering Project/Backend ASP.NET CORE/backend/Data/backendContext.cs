using Microsoft.EntityFrameworkCore;
using backend.Models;
using Microsoft.AspNetCore.Identity;

namespace backend.Data
{
    public class backendContext : DbContext
    {
        public backendContext(DbContextOptions<backendContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set;}
        public DbSet<Category> Categories { get; set; }
        public DbSet<ArticleFile> ArticleFile { get; set; }
        public DbSet<Orcid> Orcid { get; set; }
        public DbSet<CategoryReviewer> CategoryReviewers { get; set; }
        public DbSet<ArticleReviewer> ArticleReviewer { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Orcid>()
                .HasIndex(o => o.OrcId)
                .IsUnique();

            builder.Entity<ArticleReviewer>()
                .HasKey(ar => new { ar.ReviewerId, ar.ArticleId });

            builder.Entity<ArticleReviewer>()
                .HasOne(ar => ar.Reviewer)
                .WithMany(r => r.ArticleReviewers)
                .HasForeignKey(ar => ar.ReviewerId);

            builder.Entity<ArticleReviewer>()
               .HasOne(ar => ar.Article)
               .WithMany(a => a.ArticleReviewers)
               .HasForeignKey(ar => ar.ArticleId);
        }
    }
}
