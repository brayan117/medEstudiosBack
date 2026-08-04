using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Salus;

public class SalusDbContext : DbContext
{
    public SalusDbContext(
        DbContextOptions<SalusDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(SalusDbContext).Assembly,
            t => t.Namespace == "Infrastructure.Persistence.Salus.Configurations");
    }
}
