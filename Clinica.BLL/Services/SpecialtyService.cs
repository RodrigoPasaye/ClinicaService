using AutoMapper;
using Clinica.BLL.Services.Interfaces;
using Clinica.Data.Interfaces.IRepository;
using Clinica.Domain.DTOs;
using Clinica.Domain.Entities;

namespace Clinica.BLL.Services {
  public class SpecialtyService : ISpecialtyService {

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SpecialtyService(IUnitOfWork unitOfWork, IMapper mapper) {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    public async Task<IEnumerable<SpecialtyDto>> GetAll() {
      try {

        var list = await _unitOfWork.SpecialtyRepository.GetAllAsync(orderBy: s => s.OrderBy(s => s.NombreEspecialidad));

        return _mapper.Map<IEnumerable<SpecialtyDto>>(list);

      } catch (Exception) {
        throw;
      }
    }

    public async Task<SpecialtyDto> Add(SpecialtyDto specialtyDto) {
      try {

        Specialty specialty = new() {
          NombreEspecialidad = specialtyDto.NombreEspecialidad,
          Descripcion = specialtyDto.Descripcion,
          Activo = specialtyDto.Activo == 1 ? true : false,
          FechaCreacion = DateTime.Now,
          FechaActualizacion = DateTime.Now,
        };

        await _unitOfWork.SpecialtyRepository.AddAsync(specialty);
        await _unitOfWork.SaveChangesAsync();

        if ( specialty.Id == 0)
          throw new TaskCanceledException("La especialidad no se pudo crear");

        return _mapper.Map<SpecialtyDto>(specialty);

      } catch (Exception) {
        throw;
      }
    }

    public async Task Update(SpecialtyDto specialtyDto) {
      try {

        var specialtyDb = await _unitOfWork.SpecialtyRepository.GetByIdAsync(s => s.Id == specialtyDto.Id);

        if (specialtyDb == null)
          throw new TaskCanceledException("La especialidad no existe");

        specialtyDb.NombreEspecialidad = specialtyDto.NombreEspecialidad;
        specialtyDb.Descripcion = specialtyDto.Descripcion;
        specialtyDb.Activo = specialtyDto.Activo == 1 ? true : false;

        _unitOfWork.SpecialtyRepository.Update(specialtyDb);
        await _unitOfWork.SaveChangesAsync();

      } catch (Exception) {
        throw;
      }
    }

    public async Task Delete(int id) {
      try {

        var specialtyDb = await _unitOfWork.SpecialtyRepository.GetByIdAsync(s => s.Id == id);

        if (specialtyDb == null)
          throw new TaskCanceledException("La especialidad no existe");

        _unitOfWork.SpecialtyRepository.DeleteAsync(specialtyDb);
        await _unitOfWork.SaveChangesAsync();

      } catch (Exception) {
        throw;
      }
    }

  }
}
