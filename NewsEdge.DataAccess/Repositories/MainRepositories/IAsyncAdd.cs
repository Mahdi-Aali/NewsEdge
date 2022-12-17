namespace NewsEdge.DataAccess.Repositories.MainRepositories;

public interface IAsyncAdd<T> where T : class
{
    public Task<bool> AddAsync(T entity);
}
