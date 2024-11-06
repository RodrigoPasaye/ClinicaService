using Clinica.Api.Exceptions;
using Clinica.Data;
using Clinica.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Api.Controllers {
  public class ErrorTestController : BaseApiController {

    private readonly ApplicationDbContext _context;

    public ErrorTestController(ApplicationDbContext context) {
      _context = context;
    }

    [Authorize]
    [HttpGet("Auth")]
    public ActionResult<string> GetNotAuthorize() {
      return "No autorizado";
    }

    [HttpGet("NotFound")]
    public ActionResult<User> GetNotFound() {
      var objeto = _context.Usuarios.Find(-1);
      if (objeto == null) return NotFound(new ApiExceptionResponse(404));
      return objeto;
    }

    [HttpGet("ServerError")]
    public ActionResult<string> GetServerError() {
      var objeto = _context.Usuarios.Find(-1);
      var objetoString = objeto.ToString();
      return objetoString;
    }

    [HttpGet("BadRequest")]
    public ActionResult<string> GetBadRequest() {
      return BadRequest(new ApiExceptionResponse(400));
    }
  }
}
