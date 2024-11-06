using Clinica.Domain.Entities;

namespace Clinica.Data.Interfaces {
  public interface ITokenService {
    string CreateToken(User usuario);
  }
}
