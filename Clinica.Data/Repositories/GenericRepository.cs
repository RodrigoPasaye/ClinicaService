using Clinica.Data.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Clinica.Data.Repositories {
  public class GenericRepository<T> : IGenericRepository<T> where T : class {

    private readonly ApplicationDbContext _context;
    private DbSet<T> _dbSet;

    public GenericRepository(ApplicationDbContext context) {
      _context = context;
      _dbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity) {
      await _dbSet.AddAsync(entity);
    }

    public void DeleteAsync(T entity) {
      _dbSet.Remove(entity);
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null) {
      IQueryable<T> query = _dbSet;

      if (filter != null) {
        query = query.Where(filter);
      }

      if (includeProperties != null) {
        foreach (var property in includeProperties.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries)) {
          query = query.Include(property);
        }
      }

      if (orderBy != null) {
        return await orderBy(query).ToListAsync();
      }

      return await query.ToListAsync();
    }

    public async Task<T> GetByIdAsync(Expression<Func<T, bool>> filter = null, string includeProperties = null) {
      IQueryable<T> query = _dbSet;

      if (filter != null) {
        query = query.Where(filter);
      }

      if (includeProperties != null) {
        foreach (var property in includeProperties.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries)) {
          query = query.Include(property);
        }
      }

      return await query.FirstOrDefaultAsync();
    }
  }
}
