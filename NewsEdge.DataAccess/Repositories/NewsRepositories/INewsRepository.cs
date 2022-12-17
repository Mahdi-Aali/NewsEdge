using NewsEdge.DataAccess.Models.PrimaryModels;
using NewsEdge.DataAccess.Repositories.MainRepositories;

namespace NewsEdge.DataAccess.Repositories.NewsRepositories;

public interface INewsRepository : IAsyncAdd<News>, ISaveChangeAsync,
    ICountAsync, MainRepositories.IList<News>, IAsyncUpdate<News>,
    IAsyncFind<News, long>, IDisposable
{
    public Task<bool> AddWithCategoriesAndTagesAsync(News news, List<long> categories, string tages);

    public Task<bool> UpdateWithCategoriesAndTagesAsync(News news, List<long> categories, string tages);

    public IQueryable<News> GetByPage(int page, int skip, int take)
    {
        return GetAll().OrderByDescending(n => n.CreateDate)
            .Skip((page - 1) * skip)
            .Take(take);
    }
    public IQueryable<News> GetLastNews(int take = 4);
    public IQueryable<News> GetHotNews(int take = 5);
    public Task<List<News>> GetArchive(string text,int category, int pageId);
}
