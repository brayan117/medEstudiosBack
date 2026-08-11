using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.MedEstudios.Configurations;

public class EstudioConfiguration : IEntityTypeConfiguration<Estudio>
{
    public void Configure(EntityTypeBuilder<Estudio> entity)
    {
        entity.ToTable("ESTUDIOS");

        entity.HasKey(e => e.Id);

        entity.Property(e => e.Id)
        .HasColumnName("ID");

        entity.Property(e => e.paciente_id)
        .HasColumnName("PACIENTE_ID");

        entity.Property(e => e.medico_solicitante_id)
        .HasColumnName("MEDICO_SOLICITANTE_ID");

        entity.Property(e => e.tecnico_principal_id)
        .HasColumnName("TECNICO_PRINCIPAL_ID");

        entity.Property(e => e.tipo_estudio_id)
        .HasColumnName("TIPO_ESTUDIO_ID");

        entity.Property(e => e.fecha_solicitud)
        .HasColumnName("FECHA_SOLICITUD");

        entity.Property(e => e.estado_id)
        .HasColumnName("ESTADO_ID");

        entity.Property(e => e.motivo_estudio)
        .HasColumnName("MOTIVO_ESTUDIO");

        entity.Property(e => e.observaciones)
        .HasColumnName("OBSERVACIONES");

        entity.Property(e => e.prioridad)
        .HasColumnName("PRIORIDAD");
    }
}