using AutoMapper;
using Clinica.Domain.DTOs;
using Clinica.Domain.Entities;

namespace Clinica.Utilities {
  public class MappingProfile : Profile {
    public MappingProfile() {
      CreateMap<Specialty, SpecialtyDto>().ForMember(s => s.Activo, m => m.MapFrom(s => s.Activo == true ? 1 : 0));
    }
  }
}
