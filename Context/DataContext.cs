using CatsReviewWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CatsReviewWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CatCategory> CatCategories { get; set; }
        public DbSet<CatOwner> CatOwners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatCategory>().HasKey(cc => new { cc.CatId, cc.CategoryId });
            modelBuilder.Entity<CatCategory>().HasOne(c => c.Cat).WithMany(cc => cc.CatCategories).HasForeignKey(c => c.CatId);
            modelBuilder.Entity<CatCategory>().HasOne(c => c.Category).WithMany(cc => cc.CatCategories).HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<CatOwner>().HasKey(co => new { co.CatId, co.OwnerId });
            modelBuilder.Entity<CatOwner>().HasOne(c => c.Cat).WithMany(co => co.CatOwners).HasForeignKey(c => c.CatId);
            modelBuilder.Entity<CatOwner>().HasOne(o => o.Owner).WithMany(co => co.CatOwners).HasForeignKey(c => c.OwnerId);
        }
    }
}