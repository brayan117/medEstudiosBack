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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(SalusDbContext).Assembly,
            t => t.Namespace == "Infrastructure.Persistence.Salus.Configurations");
    }
}
