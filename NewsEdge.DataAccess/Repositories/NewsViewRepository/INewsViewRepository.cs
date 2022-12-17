using NewsEdge.DataAccess.Models.PrimaryModels;
using NewsEdge.DataAccess.Repositories.MainRepositories;

namespace NewsEdge.DataAccess.Repositories.NewsViewRepository;

public interface INewsViewRepository : IAsyncAdd<NewsView>, ISaveChangeAsync
{
    public Task<long> GetNewsViewCoungAsync(long newsId);
}
