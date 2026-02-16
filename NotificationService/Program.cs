using MassTransit;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddMassTransit();

app.MapGet("/", () => "Hello World!");

app.Run();

public class MessageDTO
{
    public string? Headline { get; set; }
    public string? BodyText { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? UserName { get; set; }
}

public class NotificationConsumer : IConsumer<MessageDTO>
{
    public Task Consume(ConsumeContext<MessageDTO> context)
    {
        Console.WriteLine($"[NOTIFICATION]\n Message CREATED:\n {context.Message.CreatedAt}\n {context.Message.UserName}:\n\t {context.Message.Headline}");
        return Task.CompletedTask;
    }
}
