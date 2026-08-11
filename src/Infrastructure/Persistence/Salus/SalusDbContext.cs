using Microsoft.EntityFrameworkCore;
using Domain.Entities.Salus;

namespace Infrastructure.Persistence.Salus;

public class SalusDbContext : DbContext
{
    public SalusDbContext(
        DbContextOptions<SalusDbContext> options)
        : base(options)
    {
    }

    public DbSet<Afiliado> Afiliados => Set<Afiliado>();
    public DbSet<Medico> Medicos => Set<Medico>();
    public DbSet<Procedimiento> Procedimientos => Set<Procedimiento>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(SalusDbContext).Assembly,
            t => t.Namespace == "Infrastructure.Persistence.Salus.Configurations");
    }
}
