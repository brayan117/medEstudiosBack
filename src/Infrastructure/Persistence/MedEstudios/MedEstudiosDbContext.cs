using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.MedEstudios;

public class MedEstudiosDbContext : DbContext
{
    public MedEstudiosDbContext(
        DbContextOptions<MedEstudiosDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<TiposUsuarios> TiposUsuarios => Set<TiposUsuarios>();
    public DbSet<Auditoria> Auditorias => Set<Auditoria>();
    public DbSet<Tecnico> Tecnicos => Set<Tecnico>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(MedEstudiosDbContext).Assembly,
            t => t.Namespace == "Infrastructure.Persistence.MedEstudios.Configurations");
    }
}