namespace Clinica.Api.Exceptions {
  public class ApiValidationEcxeptionResponse : ApiExceptionResponse {
    public ApiValidationEcxeptionResponse() : base(400) { }

    public IEnumerable<string> Errores { get; set; }
  }
}
