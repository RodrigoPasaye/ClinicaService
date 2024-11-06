using System.Linq.Expressions;

namespace Clinica.Data.Interfaces.IRepository {
  public interface IGenericRepository<T> where T : class {
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null);
    Task<T> GetByIdAsync(Expression<Func<T, bool>> filter = null, string includeProperties = null);
    Task AddAsync(T entity);
    void DeleteAsync(T entity);
  }
}
