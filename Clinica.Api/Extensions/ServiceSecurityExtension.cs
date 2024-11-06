using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Clinica.Api.Extensions {
  public static class ServiceSecurityExtension {
    public static IServiceCollection AddServiceSecurity(this IServiceCollection services, IConfiguration configuration) {

      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"])),
          ValidateIssuer = false,
          ValidateAudience = false,
        };
      });

      return services;
    }
  }
}
