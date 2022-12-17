using Microsoft.EntityFrameworkCore;
using NewsEdge.DataAccess.Models.Context;
using NewsEdge.DataAccess.Models.PrimaryModels;

namespace NewsEdge.DataAccess.Repositories.NewsSectionRepository;

public class EFNewsSectionRepository : INewsSectionRepository
{
    private NewsEdgeContext _context;
    public EFNewsSectionRepository(NewsEdgeContext context)
    {
        _context = context;
    }

    public async Task<long> CountAsync() => await _context.NewsSections.CountAsync();

    public async Task<NewsSection> FindAsync(long id)
    {
        return await _context.NewsSections
            .Include(nc => nc.NewsInSections)?
            .FirstOrDefaultAsync(ns => ns.NewsSectionId.Equals(id));
    }


    public IQueryable<NewsSection> GetAll() => _context.NewsSections.Include(nc => nc.NewsInSections);

    public async Task<bool> UpdateAsync(NewsSection entity)
    {
        try
        {
            _context.NewsSections.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
