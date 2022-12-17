namespace NewsEdge.DataAccess.Repositories.MainRepositories;

public interface IAsyncDelete<T> where T : class
{
    public Task DeleteAsync(T entity);
}
