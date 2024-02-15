namespace Domain.Models.Users;

public class Role
{
    public Guid Id { get; private init; }
    public string Title { get; private set; }

    public Role(Guid id, string title)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id can't be null", nameof(id));
        }
        
        Id = id;
        SetTitle(title);
    }

    public static Role Create(string title)
    {
        Guid id = Guid.NewGuid();

        return new Role(id, title);
    }

    public void SetTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("The title cannot be null or whitespace.", nameof(title));
        }

        Title = title;
    }
}