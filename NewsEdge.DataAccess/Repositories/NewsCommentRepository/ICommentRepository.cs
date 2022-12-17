using NewsEdge.DataAccess.Models.PrimaryModels;
using NewsEdge.DataAccess.Repositories.MainRepositories;

namespace NewsEdge.DataAccess.Repositories.NewsCommentRepository;

public interface ICommentRepository : IAsyncAdd<NewsComment>, ISaveChangeAsync
{
    public IQueryable<NewsComment> GetAllByNews(long newsId);
    public Task<long> GetCommentCountByNewsId(long newsId);
}
