using NewsEdge.DataAccess.Models.PrimaryModels;
using NewsEdge.DataAccess.Repositories.MainRepositories;

namespace NewsEdge.DataAccess.Repositories.NewsSectionRepository;

public interface INewsSectionRepository : ICountAsync, IAsyncFind<NewsSection, long>, IAsyncUpdate<NewsSection>
{
    public IQueryable<NewsSection> GetAll();
}
