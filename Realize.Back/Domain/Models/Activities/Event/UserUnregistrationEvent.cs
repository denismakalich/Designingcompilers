namespace Domain.Models.Activities.Event;

public class UserUnregistrationEvent : IEvent
{
    public Guid Id { get; }
    public string Data { get; }
    public Guid ActivityId { get; }

    public UserUnregistrationEvent(Guid id, string data, Guid activityId)
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

    public static UserUnregistrationEvent Create(string data, Guid activityId)
    {
        Guid id = Guid.NewGuid();

        return new UserUnregistrationEvent(id, data, activityId);
    }
}