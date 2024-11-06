namespace Clinica.Api.Exceptions {
  public class ApiExceptionResponse {
    public ApiExceptionResponse(int statusCode, string mensaje = null) {
      StatusCode = statusCode;
      Mensaje = mensaje ?? GetMessageStatuscode(statusCode);
    }

    public int StatusCode { get; set; }
    public string Mensaje { get; set; }

    private static string GetMessageStatuscode(int statusCode) {
      return statusCode switch {
        400 => "Solicitud no válida",
        401 => "No estas autorizado para este recurso",
        404 => "Recurso no encontrado",
        500 => "Error interno del Servidor",
        _ => null,
      };
    }
  }
}
