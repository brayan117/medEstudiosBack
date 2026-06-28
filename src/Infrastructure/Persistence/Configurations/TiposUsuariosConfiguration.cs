using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class TiposUsuariosConfiguration
    : IEntityTypeConfiguration<TiposUsuarios>
{
    public void Configure(EntityTypeBuilder<TiposUsuarios> entity)
    {
        // Nombre tabla
        entity.ToTable("TIPOS_USUARIOS");

        // Primary Key
        entity.HasKey(x => x.id);

        // id
        entity.Property(x => x.id)
            .HasColumnName("ID");

        // nombre
        entity.Property(x => x.nombre)
            .HasColumnName("NOMBRE")
            .HasMaxLength(50)
            .IsRequired();

        // descripcion
        entity.Property(x => x.descripcion)
            .HasColumnName("DESCRIPCION")
            .HasMaxLength(255)
            .IsRequired();

            
    }
}