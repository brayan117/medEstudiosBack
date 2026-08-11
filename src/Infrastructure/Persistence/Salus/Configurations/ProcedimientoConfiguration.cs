using Domain.Entities.Salus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Persistence.Salus.Configurations;

public class ProcedimientoConfiguration : IEntityTypeConfiguration<Procedimiento>
{
    public void Configure(EntityTypeBuilder<Procedimiento> builder)
    {
        builder.ToTable("TABLA_CUPS");

        builder.HasKey(x => x.id_codigo);

        builder.Property(x => x.id_codigo)
            .HasColumnName("ID_CODIGO");

        builder.Property(x => x.codigo_CUPS)
            .HasColumnName("CODICOCUPS");

        builder.Property(x => x.codigo_SOAT)
            .HasColumnName("CODIGO_SOAT");

        builder.Property(x => x.nom_procedimiento)
            .HasColumnName("NOM_PROCEDIMIENTO");

        builder.Property(x => x.grupo)
            .HasColumnName("GRUPO");

        builder.Property(x => x.estado)
            .HasColumnName("ESTADO");
    }
}