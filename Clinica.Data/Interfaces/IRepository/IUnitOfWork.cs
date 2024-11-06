namespace Clinica.Data.Interfaces.IRepository {
  public interface IUnitOfWork : IDisposable {
    ISpecialtyRepository SpecialtyRepository { get; }
    Task SaveChangesAsync();
  }
}
