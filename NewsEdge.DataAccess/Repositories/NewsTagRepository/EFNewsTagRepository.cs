using Microsoft.EntityFrameworkCore;
using NewsEdge.DataAccess.Models.Context;
using NewsEdge.DataAccess.Models.PrimaryModels;
using System.Linq.Expressions;

namespace NewsEdge.DataAccess.Repositories.NewsTagRepository;

public class EFNewsTagRepository : INewsTagRepository
{
    private NewsEdgeContext _context;

    public EFNewsTagRepository(NewsEdgeContext context)
    {
        _context = context;
    }
    public IQueryable<NewsTag> GetAll() => _context.NewsTags;

    public IQueryable<NewsTag> GetAll(Expression<Func<NewsTag, bool>> where) => _context.NewsTags.Where(where);

    public IQueryable<NewsTag> GetAll(Expression<Func<NewsTag, bool>> where, params Expression<Func<NewsTag, object>>[] includes)
    {
        DbSet<NewsTag> newsTags = _context.NewsTags;

        if (includes.Length > 0)
        {
            foreach(var include in includes)
            {
                newsTags.Include(include);
            }
        }

        return newsTags.Where(where);
    }
}
