using System.Linq.Expressions;

namespace ProfileProject.Domain.Common.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void SoftDelete(TEntity entity);
    void HardDelete(TEntity entity);

    Task<TEntity?> GetByIdAsync(Guid id);

    Task<PagedModel<TEntity>> GetPagedAsync(
        int pageSize,
        int pageNumber,
        Expression<Func<TEntity, bool>>? expression = null);

    IQueryable<TEntity> Query();
}
