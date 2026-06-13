namespace ProfileProject.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public bool IsDeleted { get; private set; }


    protected abstract void Validator();

    public void SoftDelete()
    {
        IsDeleted = true;
        DeletedAt = DateTime.UtcNow;
    }

    public void SetCreateTime(DateTime createTime) => CreatedAt = createTime;
    public void SetUpdateTime(DateTime updateTime) => UpdatedAt = updateTime;
    public void SetDeleteTime(DateTime deleteTime) => DeletedAt = deleteTime;
}