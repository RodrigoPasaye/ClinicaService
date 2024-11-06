using Clinica.Data;
using Clinica.Data.Interfaces;
using Clinica.Domain.DTOs;
using Clinica.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Clinica.Api.Controllers {
  public class UserController : BaseApiController {

    private readonly ApplicationDbContext _context;
    private readonly ITokenService _tokenService;

    public UserController(ApplicationDbContext context, ITokenService tokenService) {
      _context = context;
      _tokenService = tokenService;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> Get() {
      var users = await _context.Usuarios.ToListAsync();
      return Ok(users);
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetById(int id) {
      var user = await _context.Usuarios.FindAsync(id);
      return Ok(user);
    }

    [HttpPost("Register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto) {

      if (await UserExists(registerDto.UserName)) return BadRequest("El nombre de usuario ya esta registrado");

      using var hmac = new HMACSHA512();

      var user = new User {
        UserName = registerDto.UserName.ToLower(),
        PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
        PasswordSalt = hmac.Key
      };

      _context.Usuarios.Add(user);
      await _context.SaveChangesAsync();

      var userDto = new UserDto {
        UserName = user.UserName,
        Token = _tokenService.CreateToken(user)
      };

      return Ok(userDto);
    }

    [HttpPost("Login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto) {

      var user = await _context.Usuarios.SingleOrDefaultAsync(x => x.UserName == loginDto.UserName);

      if (user == null) return Unauthorized("Usuario no válido");

      using var hmac = new HMACSHA512(user.PasswordSalt);

      var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

      for (var i = 0; i < computedHash.Length; i++) {
        if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Password no válido");
      }

      var userDto = new UserDto {
        UserName = user.UserName,
        Token = _tokenService.CreateToken(user)
      };

      return Ok(userDto);
    }

    private async Task<bool> UserExists(string userName) {
      return await _context.Usuarios.AnyAsync(u => u.UserName == userName.ToLower());
    }
  }
}
