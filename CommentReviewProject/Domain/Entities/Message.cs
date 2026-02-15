public class Message
{
    public int Id { get; set; }
    public string? Headline { get; set; }
    public string? BodyText { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }

    private Message()
    {
        CreatedAt = DateTimeOffset.UtcNow;
    }
}