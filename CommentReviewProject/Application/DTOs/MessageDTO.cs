namespace MyProject.Application.DTOs;

public class MessageDTO
{
    public string? Headline { get; set; }
    public string? BodyText { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? UserName { get; set; }
    
}