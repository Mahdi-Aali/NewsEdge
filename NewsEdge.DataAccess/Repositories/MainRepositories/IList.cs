using System.Linq.Expressions;

namespace NewsEdge.DataAccess.Repositories.MainRepositories
{
    public interface IList<T> where T : class
    {
        public IQueryable<T> GetAll();
        public IQueryable<T> GetAll(Expression<Func<T, bool>> where);
        public IQueryable<T> GetAll(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
    }
}
