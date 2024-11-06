using Clinica.Data.Interfaces;
using Clinica.Data.Services;
using Clinica.Data;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Clinica.Api.Exceptions;
using Clinica.Data.Interfaces.IRepository;
using Clinica.Data.Repositories;
using Clinica.Utilities;
using Clinica.BLL.Services.Interfaces;
using Clinica.BLL.Services;

namespace Clinica.Api.Extensions {
  public static class ApplicationBuilderExtensions {
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) {

      services.AddEndpointsApiExplorer();

      services.AddSwaggerGen(options => {
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
          Description = "Ingresar Bearer [espacio] token \r\n\r\n" +
            "Ejemplo: Bearer [tu token]",
          Name = "Authorization",
          In = ParameterLocation.Header,
          Scheme = "Bearer"
        });
         
        options.AddSecurityRequirement(new OpenApiSecurityRequirement() {
          {
            new OpenApiSecurityScheme {
              Reference = new OpenApiReference {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer",
              },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,
            },
            new List<string>()
          }
        });
      });

      var connectionString = configuration.GetConnectionString("Database");

      services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

      services.AddCors();

      services.AddScoped<ITokenService, TokenService>();

      services.Configure<ApiBehaviorOptions>(options => {
        options.InvalidModelStateResponseFactory = actionContext => {
          var errors = actionContext.ModelState
            .Where(e => e.Value.Errors.Count > 0)
            .SelectMany(x => x.Value.Errors)
            .Select(x => x.ErrorMessage).ToArray();
          var errorResponse = new ApiValidationEcxeptionResponse {
            Errores = errors
          };
          return new BadRequestObjectResult(errorResponse);
        };
      });

      services.AddScoped<IUnitOfWork, UnitOfWork>();

      services.AddAutoMapper(typeof(MappingProfile));

      services.AddScoped<ISpecialtyService, SpecialtyService>();

      return services;
    }
  }
}
