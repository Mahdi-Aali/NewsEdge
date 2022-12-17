using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewsEdge.DataAccess.Models.PrimaryModels;

namespace NewsEdge.DataAccess.Models.Context;

public class NewsEdgeContext : IdentityDbContext<NewsEdgeUser, IdentityRole<long>, long>
{
	public NewsEdgeContext(DbContextOptions<NewsEdgeContext> options) : base(options)
	{

	}

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<NewsView> NewsViews => Set<NewsView>();
    public DbSet<News> News => Set<News>();
    public DbSet<NewsTag> NewsTags => Set<NewsTag>();
    public DbSet<NewsCategory> NewsCategories => Set<NewsCategory>();
    public DbSet<NewsComment> NewsComments => Set<NewsComment>();
    public DbSet<NewsSection> NewsSections => Set<NewsSection>();
    public DbSet<NewsInSection> NewsInSections => Set<NewsInSection>();


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Category>()
            .HasOne(c => c.Category1)
            .WithMany(c => c.Categories)
            .HasForeignKey(fk => fk.ParentId);

        builder.Entity<News>()
            .HasOne(n => n.NewsEdgeUser)
            .WithMany(neu => neu.News)
            .HasForeignKey(n => n.UserId);

        base.OnModelCreating(builder);
    }
}
