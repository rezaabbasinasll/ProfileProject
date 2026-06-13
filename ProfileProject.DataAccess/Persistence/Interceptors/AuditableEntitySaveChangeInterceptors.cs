using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ProfileProject.Domain.Common;
using ProfileProject.Domain.Common.Interfaces;

namespace ProfileProject.DataAccess.Persistence.Interceptors;

public class AuditableEntitySaveChangeInterceptors : SaveChangesInterceptor
{
    private readonly IDateTime _dateTime;

    public AuditableEntitySaveChangeInterceptors(IDateTime dateTime)
    {
        _dateTime = dateTime;
    }
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateEntities(DbContext? dbContext)
    {
        if (dbContext is null) return;

        foreach (var entry in dbContext.ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Added)
                entry.Entity.SetCreateTime(_dateTime.Now);

            if (entry.State == EntityState.Modified)
                entry.Entity.SetUpdateTime(_dateTime.Now);
        }
    }
}
