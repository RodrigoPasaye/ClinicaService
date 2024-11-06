using System.Net;

namespace Clinica.Domain.DTOs {
  public class ApiResponse {
    public HttpStatusCode StatusCode { get; set; }
    public bool IsSuccessful { get; set; }
    public string Message { get; set; }
    public object Result { get; set; }
  }
}
