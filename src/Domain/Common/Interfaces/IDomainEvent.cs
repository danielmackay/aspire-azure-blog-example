using MediatR;

namespace AspireWebApp.Domain.Common.Interfaces;

/// <summary>
/// Can be raised by an AggregateRoot to notify subscribers of a domain event.
/// </summary>
public interface IDomainEvent : INotification;