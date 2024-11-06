using Clinica.Api.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Api.Controllers {
  [Route("Errores/{codigo}")]
  [ApiExplorerSettings(IgnoreApi = true)]
  public class ErrorController : BaseApiController {
    public IActionResult Error(int codigo) {
      return new ObjectResult(new ApiExceptionResponse(codigo));
    }
  }
}
