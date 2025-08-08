namespace AspireWebApp.Domain.Common.Interfaces;

public interface IAggregateRoot
{
    void AddDomainEvent(IDomainEvent domainEvent);

    IReadOnlyList<IDomainEvent> PopDomainEvents();
}