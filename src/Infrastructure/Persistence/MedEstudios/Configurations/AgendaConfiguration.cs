using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.MedEstudios.Configurations;

public class AgendaConfiguration: IEntityTypeConfiguration<Agenda>
{
    public void Configure(EntityTypeBuilder<Agenda> entity)
    {
        entity.ToTable("AGENDA_ESTUDIOS");

        entity.HasKey(x => x.id);

        entity.Property(x => x.id)
            .HasColumnName("ID");
        
        entity.Property(x => x.estudio_id)
            .HasColumnName("ESTUDIO_ID");

        entity.Property(x => x.fecha_programada)
            .HasColumnName("FECHA_PROGRAMADA");

        entity.Property(x => x.fecha_inicio_real)
            .HasColumnName("FECHA_INICIO_REAL");

        entity.Property(x => x.fecha_fin_real)
            .HasColumnName("FECHA_FIN_REAL");
            
        entity.Property(x => x.duracion_estimada)
            .HasColumnName("DURACION_ESTIMADA");
            
        entity.Property(x => x.notas_procedimiento)
            .HasColumnName("NOTAS_PROCEDIMIENTO");

        entity.HasOne(x => x.Estudio)
            .WithMany()
            .HasForeignKey(x => x.estudio_id);
    }
    
}
    
