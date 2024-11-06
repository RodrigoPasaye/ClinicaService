using Clinica.Domain.DTOs;

namespace Clinica.BLL.Services.Interfaces {
  public interface ISpecialtyService {
    Task<IEnumerable<SpecialtyDto>> GetAll();
    Task<SpecialtyDto> Add(SpecialtyDto specialtyDto);
    Task Update(SpecialtyDto specialtyDto);
    Task Delete(int id);
  }
}
