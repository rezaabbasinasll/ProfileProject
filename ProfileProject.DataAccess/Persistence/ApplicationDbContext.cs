using Microsoft.EntityFrameworkCore;
using ProfileProject.Domain.Entities.Profile;
using System.Reflection;
using ProfileProject.DataAccess.Persistence.Interceptors;

namespace ProfileProject.DataAccess.Persistence;

public class ApplicationDbContext : DbContext
{
    private readonly AuditableEntitySaveChangeInterceptors _auditableEntitySaveChangeInterceptors;

    public ApplicationDbContext(
        AuditableEntitySaveChangeInterceptors auditableEntitySaveChangeInterceptors,
        DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        _auditableEntitySaveChangeInterceptors = auditableEntitySaveChangeInterceptors;
    }

    // db set
    public DbSet<ProfileEntity> Profiles => Set<ProfileEntity>();

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(_auditableEntitySaveChangeInterceptors is not null)
            optionsBuilder.AddInterceptors(_auditableEntitySaveChangeInterceptors);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
    }
}
