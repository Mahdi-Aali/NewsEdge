using Microsoft.EntityFrameworkCore;
using NewsEdge.DataAccess.Models.Context;
using NewsEdge.DataAccess.Models.PrimaryModels;

namespace NewsEdge.DataAccess.Repositories.NewsInSectionRepository;

public class EFNewsInSectionRepository : INewsInSectionRepository
{
    private NewsEdgeContext _context;

    public EFNewsInSectionRepository(NewsEdgeContext context)
    {
        _context = context;
    }
    public IQueryable<News> GetNewsBySection(long sectionId, int take, out string sectionName)
    {
        sectionName = _context.NewsSections.Find(sectionId)!.SectionName;
        return _context.NewsInSections
            .Include(nis => nis.News)
            .ThenInclude(n => n.NewsEdgeUser)
            .Where(nis => nis.NewsSectionId.Equals(sectionId))
            .Take(take)
            .Select(nis => nis.News)
            .Where(n => n.State)
            .OrderByDescending(n => n.CreateDate);
    }
    public async Task<bool> AddAsync(NewsInSection entity)
    {
        try
        {
            await _context.NewsInSections.AddAsync(entity);
            await SaveChangeAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    private async Task DeleteAsync(NewsInSection entity)
    {
        _context.NewsInSections.Remove(entity);
        await SaveChangeAsync();
    }

    public async Task<bool> DeleteNewsFromSection(long sectionId, long newsId)
    {
        if (await IsNewsInSectionExist(sectionId, newsId))
        {
            NewsInSection newsInSection = await _context.NewsInSections
                .FirstAsync(nic => nic.NewsId.Equals(newsId) && nic.NewsSectionId.Equals(sectionId));
            try
            {
                await DeleteAsync(newsInSection);
                return true;
            }
            catch
            {
                return false;
            }
        }
        return false;
    }

    public async Task<bool> IsNewsInSectionExist(long sectionId, long newsId)
    {
        return await _context.NewsInSections.AnyAsync(nic => nic.NewsId.Equals(newsId) && nic.NewsSectionId.Equals(sectionId));
    }

    public async Task SaveChangeAsync()
    {
        await _context.SaveChangesAsync();
    }
}
