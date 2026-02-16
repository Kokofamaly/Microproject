namespace MyProject.Domain.Entities;
public class Message
{
    public int Id { get; set; }
    public string? Headline { get; set; }
    public string? BodyText { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }

    public Message()
    {
    }

    public Message(string? headline, string? bodyText, User? user)
    {
            Headline = headline;
            BodyText = bodyText;
            CreatedAt = DateTimeOffset.UtcNow;
            UserId = User!.Id;
            User = user; 
    }

    public void CreateMessage(string? headline, string? bodyText, User? user)
    {
        new Message()
        {
            Headline = headline,
            BodyText = bodyText,
            CreatedAt = DateTimeOffset.UtcNow,
            UserId = User!.Id,
            User = user
        };
    }
}