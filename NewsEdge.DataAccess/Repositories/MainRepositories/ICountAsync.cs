namespace NewsEdge.DataAccess.Repositories.MainRepositories;

public interface ICountAsync
{
    public Task<long> CountAsync();
}
