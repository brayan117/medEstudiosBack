using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistence.Configurations;

public class UsuarioConfiguration
    : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> entity)
    {
        // Nombre tabla
        entity.ToTable("USUARIOS");

        // Primary Key
        entity.HasKey(x => x.id);

        // id
        entity.Property(x => x.id)
            .HasColumnName("ID")
            .ValueGeneratedNever();

        // username
        entity.Property(x => x.username)
            .HasColumnName("USERNAME")
            .HasMaxLength(100)
            .IsRequired();

        // password_hash
        entity.Property(x => x.password_hash)
            .HasColumnName("PASSWORD_HASH")
            .HasMaxLength(500)
            .IsRequired();

        // estado
        entity.Property(x => x.estado)
            .HasColumnName("ESTADO")
            .HasColumnType("INTEGER")
            .IsRequired()
            .HasConversion(new BoolToZeroOneConverter<int>());

        // tipo_usuario_id
        entity.Property(x => x.tipo_usuario_id)
            .HasColumnName("TIPO_USUARIO_ID")
            .IsRequired();

        // ultimo_login
        entity.Property(x => x.ultimo_login)
            .HasColumnName("ULTIMO_LOGIN");

        // fecha_creacion
        entity.Property(x => x.fecha_creacion)
            .HasColumnName("FECHA_CREACION")
            .IsRequired();

        //relacion con tipo de usuario
        entity.HasOne(x => x.TipoUsuario)
            .WithMany(x => x.Usuarios)
            .HasForeignKey(x => x.tipo_usuario_id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}