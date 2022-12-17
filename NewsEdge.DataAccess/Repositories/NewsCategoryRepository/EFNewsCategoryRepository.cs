using Microsoft.EntityFrameworkCore;
using NewsEdge.DataAccess.Models.Context;
using NewsEdge.DataAccess.Models.PrimaryModels;
using System.Linq.Expressions;

namespace NewsEdge.DataAccess.Repositories.NewsCategoryRepository;

public class EFNewsCategoryRepository : INewsCategoryRepository
{
    private NewsEdgeContext _context;

    public EFNewsCategoryRepository(NewsEdgeContext context)
    {
        _context = context;
    }

    public IQueryable<NewsCategory> GetAll() => _context.NewsCategories;

    public IQueryable<NewsCategory> GetAll(Expression<Func<NewsCategory, bool>> where) => _context.NewsCategories.Where(where);

    public IQueryable<NewsCategory> GetAll(Expression<Func<NewsCategory, bool>> where, params Expression<Func<NewsCategory, object>>[] includes)
    {
        DbSet<NewsCategory> newsCategories = _context.NewsCategories;

        if (includes.Length > 0)
        {
            foreach(var include in includes)
            {
                newsCategories.Include(include);
            }
        }

        return newsCategories.Where(where);
    }
}
