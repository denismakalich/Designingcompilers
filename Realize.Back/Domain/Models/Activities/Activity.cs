using Domain.Models.Activities.Event;

namespace Domain.Models.Activities;

public class Activity
{
    public Guid Id { get; private init; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime ActivityStartTime { get; private set; }
    public Guid PlatformId { get; private set; }
    private List<ActivityRegistration> _activityRegistrations { get; } = new();
    public IReadOnlyCollection<ActivityRegistration> ReadActivityRegistrations => _activityRegistrations.AsReadOnly();
    private List<ActivityPlan> _activityPlans { get; } = new();
    public IReadOnlyCollection<ActivityPlan> ReadActivityPlans => _activityPlans.AsReadOnly();
    private List<IEvent> _events { get; } = new();
    public IReadOnlyCollection<IEvent> ReadEvents => _events.AsReadOnly();

    public Activity(
        Guid id,
        string title,
        string description,
        DateTime activityStartTime,
        Guid platformId)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id can't be null", nameof(id));
        }

        Id = id;
        SetTitle(title);
        SetDescription(description);
        SetActivityStartTime(activityStartTime);
        SetPlatform(platformId);
    }

    public static Activity Create(string title, string description, DateTime activityStartTime, Guid platformId)
    {
        Guid id = Guid.NewGuid();

        return new Activity(id, title, description, activityStartTime, platformId);
    }

    public void SetTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("The title cannot be null or whitespace.", nameof(title));
        }

        Title = title;
    }

    public void SetDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("The description cannot be null or whitespace.", nameof(description));
        }

        Description = description;
    }

    public void SetActivityStartTime(DateTime startTime)
    {
        ArgumentNullException.ThrowIfNull(startTime);

        ActivityStartTime = startTime;
    }

    public void SetPlatform(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id can't be null", nameof(id));
        }

        PlatformId = id;
    }
}