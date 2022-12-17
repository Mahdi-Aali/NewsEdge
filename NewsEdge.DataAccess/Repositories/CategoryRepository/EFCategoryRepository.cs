using Microsoft.EntityFrameworkCore;
using NewsEdge.DataAccess.Models.Context;
using NewsEdge.DataAccess.Models.PrimaryModels;
using System.Linq.Expressions;

namespace NewsEdge.DataAccess.Repositories.CategoryRepository;

public class EFCategoryRepository : ICategoryRepository
{
    private NewsEdgeContext _context;

    public EFCategoryRepository(NewsEdgeContext context)
    {
        _context = context;
    }

    public IQueryable<Category> GetAll() => _context.Categories;

    public IQueryable<Category> GetAll(Expression<Func<Category, bool>> where) => _context.Categories.Where(where);

    public IQueryable<Category> GetAll(Expression<Func<Category, bool>> where, params Expression<Func<Category, object>>[] includes)
    {
        DbSet<Category> categories = _context.Categories;
        if (includes.Length > 0)
        {
            foreach(var include in includes)
            {
                categories.Include(include);
            }
        }

        return categories.Where(where);
    }

    public async Task<List<(string name,int id, int count)>> GetPopularCategories()
    {
        List<(string, int, int)> values = new();
        (await _context.Categories
            .Include(c => c.NewsCategories)
            .OrderByDescending(o => o.NewsCategories.Count())
            .Take(8)
            .ToListAsync())
            .ForEach(c => values.Add((c.Title, (int)c.CategoryId, c.NewsCategories.Count())));

        return values;
    }
}
