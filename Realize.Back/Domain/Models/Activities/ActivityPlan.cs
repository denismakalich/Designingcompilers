namespace Domain.Models.Activities;

public class ActivityPlan
{
    public Guid Id { get; private init; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime TimeEdit { get; private set; }

    public ActivityPlan(Guid id, string title, string description)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id can't be null", nameof(id));
        }

        Id = id;
        SetTitle(title);
        SetDescription(description);
        SetTimeEdit();
    }

    public static ActivityPlan Create(string title, string description)
    {
        Guid id = Guid.NewGuid();

        return new ActivityPlan(id, title, description);
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

    public void SetTimeEdit()
    {
        TimeEdit = DateTime.Now;
    }
}