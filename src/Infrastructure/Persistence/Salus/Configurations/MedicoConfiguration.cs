using Domain.Entities.Salus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Salus.Configurations;

public class MedicoConfiguration : IEntityTypeConfiguration<Medico>
{
    public void Configure(EntityTypeBuilder<Medico> builder)
    {
        builder.ToTable("TABLA_PROFESIONALES");

        builder.HasKey(x => x.id);

        builder.Property(x => x.id)
            .HasColumnName("ID");

        builder.Property(x => x.codigo)
            .HasColumnName("CODIGO");

        builder.Property(x => x.habilita_facturacion)
            .HasColumnName("HABILTA_FACTURACION");

        builder.Property(x => x.nombres)
            .HasColumnName("NOMBRES");

        builder.Property(x => x.tipo_espacialista)
            .HasColumnName("TIPO_ESPECIALISTA");

        builder.Property(x => x.cod_especialidad)
            .HasColumnName("COD_ESPECIALIDAD");

        builder.Property(x => x.espacialidad)
            .HasColumnName("ESPECIALIDAD");

        builder.Property(x => x.reg_profesional)
            .HasColumnName("REG_PROFESIONAL");

        builder.Property(x => x.fecha_sistema)
            .HasColumnName("FECHA_SISTEMA");

        builder.Property(x => x.documento)
            .HasColumnName("DOCUMENTO");

        builder.Property(x => x.estado)
            .HasColumnName("ESTADO");
    }
}