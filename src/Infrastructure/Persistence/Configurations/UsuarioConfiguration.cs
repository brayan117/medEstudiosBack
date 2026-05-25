using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class UsuarioConfiguration
    : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> entity)
    {
        // Nombre tabla
        entity.ToTable("usuarios");

        // Primary Key
        entity.HasKey(x => x.id);

        // id
        entity.Property(x => x.id)
            .HasColumnName("id");

        // username
        entity.Property(x => x.username)
            .HasColumnName("username")
            .HasMaxLength(100)
            .IsRequired();

        // password_hash
        entity.Property(x => x.password_hash)
            .HasColumnName("password_hash")
            .HasMaxLength(500)
            .IsRequired();

        // estado
        entity.Property(x => x.estado)
            .HasColumnName("estado")
            .IsRequired();

        // ultimo_login
        entity.Property(x => x.ultimo_login)
            .HasColumnName("ultimo_login");

        // fecha_creacion
        entity.Property(x => x.fecha_creacion)
            .HasColumnName("fecha_creacion")
            .IsRequired();
    }
}