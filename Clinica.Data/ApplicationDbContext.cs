using Clinica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Clinica.Data {
  public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Usuarios { get; set; }
    public DbSet<Specialty> Especialidades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
  }
}
