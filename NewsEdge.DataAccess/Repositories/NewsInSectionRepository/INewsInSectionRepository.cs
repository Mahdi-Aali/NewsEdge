using NewsEdge.DataAccess.Models.PrimaryModels;
using NewsEdge.DataAccess.Repositories.MainRepositories;

namespace NewsEdge.DataAccess.Repositories.NewsInSectionRepository;

public interface INewsInSectionRepository : IAsyncAdd<NewsInSection>, ISaveChangeAsync
{
    public Task<bool> IsNewsInSectionExist(long sectionId, long newsId);

    public Task<bool> DeleteNewsFromSection(long sectionId, long newsId);

    public IQueryable<News> GetNewsBySection(long sectionId, int take, out string sectionName);
}
