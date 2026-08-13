using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.MedEstudios.Configurations;

public class EstadoEstudioConfiguration : IEntityTypeConfiguration<EstadoEstudio>
{
    public void Configure(EntityTypeBuilder<EstadoEstudio> entity)
    {
        entity.ToTable("ESTADOS_ESTUDIO");

        entity.HasKey(x => x.Id);

        entity.Property(x => x.Id)
            .HasColumnName("ID");

        entity.Property(x => x.nombre)
            .HasColumnName("NOMBRE")
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(x => x.descripcion)
            .HasColumnName("DESCRIPCION")
            .HasMaxLength(200);

        entity.Property(x => x.orden_flujo)
            .HasColumnName("ORDEN_FLUJO");
    }
}
