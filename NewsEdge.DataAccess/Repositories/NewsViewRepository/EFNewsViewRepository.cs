using Microsoft.EntityFrameworkCore;
using NewsEdge.DataAccess.Models.Context;
using NewsEdge.DataAccess.Models.PrimaryModels;

namespace NewsEdge.DataAccess.Repositories.NewsViewRepository;

public class EFNewsViewRepository : INewsViewRepository
{
    private NewsEdgeContext _context;

    public EFNewsViewRepository(NewsEdgeContext context)
    {
        _context = context;
    }
    
    public async Task<bool> AddAsync(NewsView entity)
    {
        try
        {
            if (!await _context.NewsViews.AnyAsync(nv => nv.IP.Equals(entity.IP) && nv.NewsId.Equals(entity.NewsId)))
            {
                await _context.AddAsync(entity);
                await SaveChangeAsync();
            }
            return true;
        }
        catch 
        {
            return false;
        }
    }

    public async Task<long> GetNewsViewCoungAsync(long newsId)
    {
        return await _context.NewsViews.CountAsync(nv => nv.NewsId.Equals(newsId));
    }

    public async Task SaveChangeAsync()
    {
        await _context.SaveChangesAsync();
    }
}
