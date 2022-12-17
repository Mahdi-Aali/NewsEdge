using NewsEdge.DataAccess.Models.PrimaryModels;

namespace NewsEdge.DataAccess.Repositories.CategoryRepository;

public interface ICategoryRepository : MainRepositories.IList<Category>
{
    public Task<List<(string name,int id, int count)>> GetPopularCategories();
}
