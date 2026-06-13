using Microsoft.EntityFrameworkCore;
using ProfileProject.DataAccess.Persistence;
using ProfileProject.Domain.Common;
using ProfileProject.Domain.Common.Interfaces;
using System.Linq.Expressions;

namespace ProfileProject.DataAccess.Common.Implementations;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly ApplicationDbContext Context;
    protected readonly DbSet<TEntity> DbSet;

    public BaseRepository(ApplicationDbContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }

    public async Task AddAsync(
        TEntity entity)
    {
        await DbSet.AddAsync(entity);
        await Context.SaveChangesAsync();
    }

    public void Update(TEntity entity)
    {
        DbSet.Update(entity);
        Context.SaveChanges();
    }

    public void SoftDelete(TEntity entity)
    {
        entity.SoftDelete();
        DbSet.Update(entity);
        Context.SaveChanges();
    }

    public void HardDelete(TEntity entity)
    {
        DbSet.Remove(entity);
        Context.SaveChanges();
    }

    public async Task<TEntity?> GetByIdAsync(
        Guid id)
    {
        return await DbSet
            .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
    }

    public async Task<PagedModel<TEntity>> GetPagedAsync(
        int pageSize,
        int pageNumber,
        Expression<Func<TEntity, bool>>? expression = null)
    {
        var query = DbSet
            .Where(x => !x.IsDeleted)
            .AsQueryable();

        if (expression is not null)
            query = query.Where(expression);

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedModel<TEntity>
        {
            Items = items,
            PageSize = pageSize,
            PageNumber = pageNumber,
            TotalCount = totalCount
        };
    }

    public IQueryable<TEntity> Query()
    {
        return DbSet.Where(x => !x.IsDeleted);
    }
}
