using Microsoft.EntityFrameworkCore;
using NewsEdge.DataAccess.Models.Context;
using NewsEdge.DataAccess.Models.PrimaryModels;

namespace NewsEdge.DataAccess.Repositories.NewsCommentRepository;

public class EFCommentRepository : ICommentRepository
{
    private NewsEdgeContext _context;

    public EFCommentRepository(NewsEdgeContext context)
    {
        _context = context;
    }
    public async Task<bool> AddAsync(NewsComment entity)
    {
        try
        {
            await _context.NewsComments.AddAsync(entity);
            await SaveChangeAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public IQueryable<NewsComment> GetAllByNews(long newsId)
    {
        return _context.NewsComments.Where(nc => nc.NewsId.Equals(newsId)).OrderByDescending(nc => nc.CreateDate);
    }

    public async Task<long> GetCommentCountByNewsId(long newsId)
    {
        return await _context.NewsComments.LongCountAsync(c => c.NewsId.Equals(newsId));
    }

    public async Task SaveChangeAsync()
    {
        await _context.SaveChangesAsync();
    }
}
