using System.ComponentModel.DataAnnotations;

namespace Clinica.Domain.DTOs {
  public class RegisterDto {
    [Required(ErrorMessage = "UserName es Requerido")]
    public required string UserName { get; set; }
    [Required(ErrorMessage = "Password es Requerido")]
    [StringLength(10, MinimumLength = 4, ErrorMessage = "El Password debe de ser mínimo 4 máximo 10")]
    public required string Password { get; set; }
  }
}
