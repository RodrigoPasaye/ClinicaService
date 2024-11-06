using Clinica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinica.Data.Configurations {
  public class SpecialtyConfiguration : IEntityTypeConfiguration<Specialty> {
    public void Configure(EntityTypeBuilder<Specialty> builder) {
      builder.Property(x => x.Id).IsRequired();
      builder.Property(x => x.NombreEspecialidad).IsRequired().HasMaxLength(60);
      builder.Property(x => x.Descripcion).IsRequired().HasMaxLength(100);
      builder.Property(x => x.Activo).IsRequired();
    }
  }
}
