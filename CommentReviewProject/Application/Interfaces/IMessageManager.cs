using MyProject.Domain.Entities;
using MyProject.Application.DTOs;
using MyProject.Infrastructure;

namespace MyProject.Application.Interfaces;

public interface IMessageManager
{
    public Task<MessageDTO> CreateMessageAsync(Message message);
}

public class MessageManager : IMessageManager
{
    private readonly AppDbContext _context;

    public MessageManager(AppDbContext context) => _context = context;

    public async Task<MessageDTO> CreateMessageAsync(Message message)
    {
        message.CreatedAt = DateTimeOffset.UtcNow;
        await _context.Messages.AddAsync(message);
        await _context.SaveChangesAsync();

        return new MessageDTO
        {
            Headline = message.Headline,
            BodyText = message.BodyText,
            CreatedAt = DateTimeOffset.UtcNow,
            UserName = message.User!.Name
        };
    }
}

