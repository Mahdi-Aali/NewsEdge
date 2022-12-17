using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using NewsEdge.DataAccess.Models.Context;
using NewsEdge.DataAccess.Models.PrimaryModels;
using System.Linq.Expressions;

namespace NewsEdge.DataAccess.Repositories.NewsRepositories;

public class EFNewsRepository : INewsRepository
{
    private NewsEdgeContext _context;

    public EFNewsRepository(NewsEdgeContext context)
    {
        _context = context;
    }

    public IQueryable<News> GetAll() => _context.News.Include(n => n.NewsEdgeUser);

    public IQueryable<News> GetAll(Expression<Func<News, bool>> where) => GetAll().Where(where);
    public IQueryable<News> GetAll(Expression<Func<News, bool>> where, params Expression<Func<News, object>>[] includes)
    {
        DbSet<News> news = _context.News;
        if (includes.Length > 0)
        {
            foreach(var include in includes)
            {
                news.Include(include);
            }
        }
        return news.Where(where);
    }

    public IQueryable<News> GetLastNews(int take = 4)
    {
        return GetAll().OrderByDescending(n => n.CreateDate).Where(ln => ln.State).Take(take);
    }

    public IQueryable<News> GetHotNews(int take = 5)
    {
        return _context.News
            .Include(n => n.NewsViews)
            .Include(n => n.NewsCategories)
            .ThenInclude(tn => tn.Category)
            .Include(n => n.NewsEdgeUser)
            .OrderByDescending(o => o.NewsViews.Count).Take(take);
    }

    public async Task<bool> AddAsync(News entity)
    {
        try
        {
            await _context.AddAsync(entity);
            await SaveChangeAsync();
            return true;
        }
        catch
        {
            // TODO: exception logging
            return false;
        }
    }

    public async Task<bool> AddWithCategoriesAndTagesAsync(News news, List<long> categories, string tages)
    {
        try
        {
            await AddAsync(news);
            // TODO: null saving bug!!!
            tages.Split("#").ToList()
                .ForEach(async t => await _context.NewsTags
                .AddAsync(new() { Title = t, NewsId = news.NewsId }));

            await _context.NewsCategories.AddRangeAsync(categories.Select(c => new NewsCategory()
            {
                NewsId = news.NewsId,
                CategoryId = c
            }));
            await SaveChangeAsync();
            return true;
        }
        catch
        {
            // TODO: exception logging
            return false;
        }
    }
    public async Task<bool> UpdateAsync(News entity)
    {
        try
        {
            _context.Update(entity);
            await SaveChangeAsync();
            return true;
        }
        catch
        {
            // TODO: exception logging
            return false;
        }
    }

    public async Task<bool> UpdateWithCategoriesAndTagesAsync(News news, List<long> categories, string tages)
    {
        try
        {
            await UpdateAsync(news);
            _context.NewsTags.RemoveRange(_context.NewsTags.Where(nt => nt.NewsId.Equals(news.NewsId)));
            await _context.NewsTags.AddRangeAsync(tages.Split("#").Select(t => new NewsTag()
            {
                NewsId = news.NewsId,
                Title = t
            }));

            _context.NewsCategories.RemoveRange(_context.NewsCategories.Where(nc => nc.NewsId.Equals(news.NewsId)));
            await _context.NewsCategories.AddRangeAsync(categories.Select(c => new NewsCategory()
            {
                CategoryId = c,
                NewsId = news.NewsId
            }));
            await SaveChangeAsync();
            return true;
        }
        catch
        {
            // TODO: exception logging
            return false;
        }
    }

    public async Task<News> FindAsync(long id) => await _context.News.Include(n => n.NewsEdgeUser)
        .FirstOrDefaultAsync(n => n.NewsId.Equals(id));

    public async Task<long> CountAsync() => await _context.News.CountAsync();

    public async Task SaveChangeAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<List<News>> GetArchive(string text, int category, int pageId = 1)
    {
        List<News> archive = new List<News>();
        if (category > 0)
        {
            archive.AddRange(_context.NewsCategories
                .Include(n => n.News)
                .ThenInclude(n => n.NewsTags)
                .Include(n => n.News.NewsEdgeUser)
                .Where(nc => nc.CategoryId.Equals(category))
                .Select(nc => nc.News));
        }
        else
        {
            archive = await _context.News
                .Include(n => n.NewsEdgeUser)
                .Include(n => n.NewsTags)
                .ToListAsync();
        }

        if (!string.IsNullOrEmpty(text))
        {
            archive = archive.Where(a => a.Title.Contains(text)).ToList();
            archive.AddRange(_context.NewsTags.Include(n => n.News).Where(nt => nt.Title.Contains(text)).Select(nt => nt.News));
        }
        

        return archive.Distinct().Skip((pageId - 1) * 6).Take(6).ToList();
    }
}
