using Clinica.Data.Interfaces.IRepository;

namespace Clinica.Data.Repositories {
  public class UnitOfWork : IUnitOfWork {

    private readonly ApplicationDbContext _context;
    public ISpecialtyRepository SpecialtyRepository { get; private set; }

    public UnitOfWork(ApplicationDbContext context) {
      _context = context;
      SpecialtyRepository = new SpecialtyRepository(context);
    }

    public void Dispose() {
      _context.Dispose();
    }

    public async Task SaveChangesAsync() {
      await _context.SaveChangesAsync();
    }
  }
}
