using Clinica.Data.Interfaces.IRepository;
using Clinica.Domain.Entities;

namespace Clinica.Data.Repositories {
  public class SpecialtyRepository : GenericRepository<Specialty>, ISpecialtyRepository {

    private readonly ApplicationDbContext _context;

    public SpecialtyRepository(ApplicationDbContext context) : base(context) {
      _context = context;
    }

    public void Update(Specialty specialty) {
      var specialtyDb = _context.Especialidades.FirstOrDefault(s => s.Id == specialty.Id);
      if (specialtyDb != null) {
        specialtyDb.NombreEspecialidad = specialty.NombreEspecialidad;
        specialtyDb.Descripcion = specialty.Descripcion;
        specialtyDb.Activo = specialty.Activo;
        specialtyDb.FechaActualizacion = DateTime.Now;
        _context.SaveChanges();
      }
    }
  }
}
