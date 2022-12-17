namespace NewsEdge.DataAccess.Repositories.MainRepositories;

public interface IAsyncUpdate<T> where T : class
{
    public Task<bool> UpdateAsync(T entity);
}
