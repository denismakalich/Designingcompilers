namespace Domain.Models.Activities.Event;

public class CreateActivityEvent : IEvent
{
    public Guid Id { get; }
    public string Data { get; }
    public Guid ActivityId { get; }

    public CreateActivityEvent(Guid id, string data, Guid activityId)
    {
        ArgumentNullException.ThrowIfNull(id);
        ArgumentNullException.ThrowIfNull(activityId);

        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id can't be null", nameof(id));
        }

        if (activityId == Guid.Empty)
        {
            throw new ArgumentException("Id can't be null", nameof(activityId));
        }

        if (string.IsNullOrWhiteSpace(data))
        {
            throw new ArgumentException("The data cannot be null or whitespace.", nameof(data));
        }

        Id = id;
        Data = data;
        ActivityId = activityId;
    }

    public static CreateActivityEvent Create(string data, Guid activityId)
    {
        Guid id = Guid.NewGuid();

        return new CreateActivityEvent(id, data, activityId);
    }
}