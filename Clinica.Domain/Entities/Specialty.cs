using System.ComponentModel.DataAnnotations;

namespace Clinica.Domain.Entities {
  public class Specialty {
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 1, ErrorMessage = "La especialidad debe ser mínimo 1 máximo 60 caracteres")]
    public string NombreEspecialidad { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "La Descripcion debe ser mínimo 1 máximo 100 caracteres")]
    public string Descripcion { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }
    public DateTime FechaActualizacion { get; set; }
  }
}
