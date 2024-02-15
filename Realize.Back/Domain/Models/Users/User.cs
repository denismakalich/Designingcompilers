using System.Security.Cryptography;

namespace Domain.Models.Users;

public class User
{
    public Guid Id { get; private init; }
    public string Name { get; private set; }
    public string SecondName { get; private set; }
    public Email Email { get; private set; }
    public string Password { get; private set; }
    private byte[] PasswordSalt { get; set; }
    private List<Role> Roles { get; }
    public IReadOnlyCollection<Role> ReadRoles => Roles.AsReadOnly();

    public User(
        Guid id,
        string name,
        string secondName,
        Email email,
        string password,
        byte[] passwordSalt,
        List<Role> roles)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id can't be null", nameof(id));
        }

        Id = id;
        SetName(name);
        SetSecondName(secondName);
        SetEmail(email);
        Password = password;
        PasswordSalt = passwordSalt;
        Roles = roles;
    }

    public User Create(string name, string secondName, Email email, string password)
    {
        Guid id = Guid.NewGuid();
        List<Role> roles = new List<Role>();
        byte[] salt = GenerateSalt();
        string passwordHash = GenerateHash(password, salt);

        return new User(id, name, secondName, email, passwordHash, salt, roles);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("The name cannot be null or whitespace.", nameof(name));
        }

        Name = name;
    }

    public void SetSecondName(string secondName)
    {
        if (string.IsNullOrWhiteSpace(secondName))
        {
            throw new ArgumentException("The name cannot be null or whitespace.", nameof(secondName));
        }

        SecondName = secondName;
    }

    public void SetEmail(Email email)
    {
        ArgumentNullException.ThrowIfNull(email);

        Email = email;
    }

    public void SetPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("The password cannot be null or whitespace.", nameof(password));
        }

        if (VerifyPassword(password, Password))
        {
            string newPassword = GenerateHash(password, PasswordSalt);

            Password = newPassword;
        }
    }

    private byte[] GenerateSalt()
    {
        const int saltLenght = 64;
        byte[] salt = new byte[saltLenght];

        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        return salt;
    }

    private string GenerateHash(string password, byte[] salt)
    {
        string saltString = Convert.ToBase64String(salt);
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, saltString);

        return hashedPassword;
    }

    // Должен ли он быть в домене?
    public bool VerifyPassword(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}