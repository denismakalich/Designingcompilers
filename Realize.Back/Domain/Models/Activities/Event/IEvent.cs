namespace Domain.Models.Activities.Event;

public interface IEvent
{
    public Guid Id { get; }
    public string Data { get; }
    public Guid ActivityId { get; }
}