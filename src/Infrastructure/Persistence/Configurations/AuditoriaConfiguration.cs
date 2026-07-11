using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class AuditoriaConfiguration 
: IEntityTypeConfiguration<Auditoria>
{
    public void Configure(EntityTypeBuilder<Auditoria> entity)
    {
        entity.ToTable("AUDITORIA");

        entity.HasKey(x => x.id);

        entity.Property(x => x.id)
            .HasColumnName("ID");

        entity.Property(x => x.usuario_id)
            .HasColumnName("USUARIO_ID");

        entity.Property(x => x.accion)
            .HasColumnName("ACCION");

        entity.Property(x => x.tabla_afectada)
            .HasColumnName("TABLA_AFECTADA");

        entity.Property(x => x.registro_id)
            .HasColumnName("REGISTRO_ID");

        entity.Property(x => x.fecha)
            .HasColumnName("FECHA");

        entity.Property(x => x.descripcion)
            .HasColumnName("DESCRIPCION");

        entity.Property(x => x.ip)
            .HasColumnName("IP");

        entity.Property(x => x.user_agent)
            .HasColumnName("USER_AGENT");

        entity.Property(x => x.username)
            .HasColumnName("USERNAME");

        entity.Property(x => x.rol)
            .HasColumnName("ROL");
    }
}
    
