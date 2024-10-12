using System.Linq.Expressions;

namespace BookStore.Core.RepositoryContracts
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T? GetById(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
