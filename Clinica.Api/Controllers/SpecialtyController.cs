using Clinica.BLL.Services.Interfaces;
using Clinica.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Clinica.Api.Controllers {
  public class SpecialtyController : BaseApiController {

    private readonly ISpecialtyService _specialtyService;
    private ApiResponse _response;

    public SpecialtyController(ISpecialtyService specialtyService) {
      _specialtyService = specialtyService;
      _response = new();
    }

    [HttpGet]
    public async Task<IActionResult> Get() {
      try {

        _response.Result = await _specialtyService.GetAll();
        _response.IsSuccessful = true;
        _response.StatusCode = HttpStatusCode.OK;

      } catch (Exception ex) {
        _response.IsSuccessful = false;
        _response.Message = ex.Message;
        _response.StatusCode = HttpStatusCode.BadRequest;
      }
      return  Ok(_response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(SpecialtyDto specialtyDto) {
      try {

        await _specialtyService.Add(specialtyDto);

        _response.IsSuccessful = true;
        _response.StatusCode = HttpStatusCode.Created;

      } catch (Exception ex) {
        _response.IsSuccessful = false;
        _response.Message = ex.Message;
        _response.StatusCode = HttpStatusCode.BadRequest;
      }
      return Ok(_response);
    }

    [HttpPut]
    public async Task<IActionResult> Update(SpecialtyDto specialtyDto) {
      try {

        await _specialtyService.Update(specialtyDto);

        _response.IsSuccessful = true;
        _response.StatusCode = HttpStatusCode.NoContent;

      } catch (Exception ex) {
        _response.IsSuccessful = false;
        _response.Message = ex.Message;
        _response.StatusCode = HttpStatusCode.BadRequest;
      }
      return Ok(_response);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) {
      try {

        await _specialtyService.Delete(id);

        _response.IsSuccessful = true;
        _response.StatusCode = HttpStatusCode.NoContent;
      } catch (Exception ex) {
        _response.IsSuccessful = false;
        _response.Message = ex.Message;
        _response.StatusCode = HttpStatusCode.BadRequest;
      }
      return Ok(_response);
    }
  }
}
