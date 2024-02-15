using Domain.Models.Enums;

namespace Domain.Models.Activities;

public class ActivityRegistration
{
    public Guid Id { get; private init; }
    public Guid ActivityId { get; private set; }
    public Guid UserId { get; private set; }
    public StatusEnum Status { get; private set; }

    public ActivityRegistration(Guid id, Guid activityId, Guid userId, StatusEnum status)
    {
        Id = id;
        SetActivity(activityId);
        SetUser(userId);
        SetStatus(status);
    }

    public static ActivityRegistration Create(Guid activityId, Guid userId, StatusEnum status = StatusEnum.None)
    {
        Guid id = Guid.NewGuid();

        return new ActivityRegistration(id, activityId, userId, status);
    }

    public void SetActivity(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id can't be null", nameof(id));
        }

        ActivityId = id;
    }

    public void SetUser(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id can't be null", nameof(id));
        }

        UserId = id;
    }

    public void SetStatus(StatusEnum status = StatusEnum.Rejected) => Status = status;
}