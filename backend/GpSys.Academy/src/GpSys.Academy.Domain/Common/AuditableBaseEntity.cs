namespace GpSys.Academy.Domain.Common
{
  public abstract class AuditableBaseEntity : BaseEntity
  {
    public DateTime CreatedAt { get; private set; }
    public string? CreatedBy { get; private set; }
    
    public DateTime? UpdatedAt { get; private set; }
    public string? UpdatedBy { get; private set; }

    public bool IsDeleted { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public string? DeletedBy { get; private set; }

    public void MarkCreated(DateTime now, string? user)
    {
      CreatedAt = now;
      CreatedBy = user;
    }

    public void MarkUpdated(DateTime now, string? user)
    {
      UpdatedAt = now;
      UpdatedBy = user;
    }

    public void SoftDelete(DateTime now, string? user)
    {
      if (IsDeleted) return;

      IsDeleted = true;
      DeletedAt = now;
      DeletedBy = user;
    }

    public void Restore()
    {
      if (!IsDeleted) return;

      IsDeleted = false;
    }

  }
}