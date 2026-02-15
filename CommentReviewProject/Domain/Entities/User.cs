namespace MyProject.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public List<Message> Messages { get; set; } = new();

    private User()
    {

    }

    public void CreateUser(string? name)
    {
        new User()
        {
            Id = Guid.NewGuid(),
            Name = name
        };
    }
}