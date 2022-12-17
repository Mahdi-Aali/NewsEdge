namespace NewsEdge.DataAccess.Repositories.MainRepositories;

public interface IAsyncFind<T,Key> where T : class
{
    public Task<T> FindAsync(Key id);
}
