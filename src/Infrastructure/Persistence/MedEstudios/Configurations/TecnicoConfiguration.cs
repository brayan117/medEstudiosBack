using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.MedEstudios.Configurations;

public class TecnicoConfiguration 
: IEntityTypeConfiguration<Tecnico>
{
    public void Configure(EntityTypeBuilder<Tecnico> entity)
    {
        entity.ToTable("TECNICOS");

        entity.HasKey(x => x.id);

        entity.Property(x => x.id)
            .HasColumnName("ID");

        entity.Property(x => x.usuario_id)
            .HasColumnName("USUARIO_ID");
        
        entity.Property(x => x.codigo_tecnico)
            .HasColumnName("CODIGO_TECNICO");
        
        entity.Property(x => x.nombres)
            .HasColumnName("NOMBRES");
        
        entity.Property(x => x.apellidos)
            .HasColumnName("APELLIDOS");
        
        entity.Property(x => x.telefono)
            .HasColumnName("TELEFONO");
        
        entity.Property(x => x.estado)
            .HasColumnName("ESTADO");
    }
}
    
