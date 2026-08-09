using Domain.Entities.Salus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Salus.Configurations;

public class AfiliadoConfiguration : IEntityTypeConfiguration<Afiliado>
{
    public void Configure(EntityTypeBuilder<Afiliado> builder)
    {
        builder.HasNoKey();

        builder.ToTable("TABLA_AFILIADO");
        
        builder.Property(x => x.historia)
            .HasColumnName("HISTORIA");

        builder.Property(x => x.tipo_documento)
            .HasColumnName("TIPO_DOCUMENTO");
        
        builder.Property(x => x.documento)
            .HasColumnName("DOCUMENTO");
        
        builder.Property(x => x.ape1)
            .HasColumnName("APE1");
        
        builder.Property(x => x.ape2)
            .HasColumnName("APE2");
        
        builder.Property(x => x.nom1)
            .HasColumnName("NOM1");
        
        builder.Property(x => x.nom2)
            .HasColumnName("NOM2");
        
        builder.Property(x => x.fecha_nacimiento)
            .HasColumnName("FECHA_NACIMIENTO");
        
        builder.Property(x => x.sexo)
            .HasColumnName("SEXO");
        
        builder.Property(x => x.direccion)
            .HasColumnName("DIRECCION");
        
        builder.Property(x => x.celular)
            .HasColumnName("CELULAR");
        
        builder.Property(x => x.mail)
            .HasColumnName("MAIL");
        
        builder.Property(x => x.fecha_creacion)
            .HasColumnName("FECHA_CREACION");
        
        builder.Property(x => x.cod_municipio)
            .HasColumnName("COD_MUNICIPIO");
        
        builder.Property(x => x.municipio)
            .HasColumnName("MUNICIPIO");
        
        builder.Property(x => x.cod_dpto)
            .HasColumnName("COD_DPTO");
        
        builder.Property(x => x.departamento)
            .HasColumnName("DEPARTAMENTO");

        builder.Property(x => x.cod_eps)
            .HasColumnName("COD_EPS");
        
        builder.Property(x => x.regimen)
            .HasColumnName("REGIMEN");
        
        builder.Property(x => x.estado_paciente)
            .HasColumnName("ESTADO_PACIENTE");
    }
}
    
