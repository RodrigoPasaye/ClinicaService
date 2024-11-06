using System.ComponentModel.DataAnnotations;

namespace Clinica.Domain.DTOs {
  public class SpecialtyDto {
    public int Id { get; set; }

    [Required(ErrorMessage = "La Especialidad es requerida")]
    [StringLength(60, MinimumLength = 1, ErrorMessage = "La especialidad debe ser mínimo 1 máximo 60 caracteres")]
    public string NombreEspecialidad { get; set; }

    [Required(ErrorMessage = "La Descripcion es requerida")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "La Descripcion debe ser mínimo 1 máximo 100 caracteres")]
    public string Descripcion { get; set; }

    [Required(ErrorMessage = "El campo Activo es requerido")]
    public int Activo { get; set; }
  }
}
