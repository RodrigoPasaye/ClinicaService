using Clinica.Domain.Entities;

namespace Clinica.Data.Interfaces.IRepository {
  public interface ISpecialtyRepository : IGenericRepository<Specialty> {
    void Update(Specialty specialty);
  }
}
