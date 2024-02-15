namespace Domain.Models.Activities.Event;

public class UserRegistrationEvent : IEvent
{
    public Guid Id { get; }
    public string Data { get; }
    public Guid ActivityId { get; }

    public UserRegistrationEvent(Guid id, string data, Guid activityId)
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

    public static UserRegistrationEvent Create(string data, Guid activityId)
    {
        Guid id = Guid.NewGuid();

        return new UserRegistrationEvent(id, data, activityId);
    }
}