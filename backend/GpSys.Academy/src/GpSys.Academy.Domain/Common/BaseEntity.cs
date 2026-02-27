namespace GpSys.Academy.Domain.Common
{
  public abstract class BaseEntity
  {
    public Guid Id { get; protected set; }

    private readonly List<object> _domainEvents = [];
    public IReadOnlyCollection<object> DomainEvents => _domainEvents.AsReadOnly();

    protected BaseEntity()
    {
      Id = new Guid();
    }

    public void AddDomainEvent(object domainEvent)
    {
      _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
      _domainEvents.Clear();
    }
  }
};