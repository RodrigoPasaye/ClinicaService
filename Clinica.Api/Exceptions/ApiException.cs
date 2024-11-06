namespace Clinica.Api.Exceptions {
  public class ApiException : ApiExceptionResponse {
    public ApiException(int statusCode, string mensaje = null, string detalle = null) : base(statusCode, mensaje) {
      Detalle = detalle;
    }

    public string Detalle { get; set; }
  }
}
