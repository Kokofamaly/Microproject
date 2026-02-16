using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using MyProject.Infrastructure;
using MassTransit;
using MyProject.Domain.Entities;
using MyProject.Application.DTOs;
using MyProject.Application.Interfaces;


var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("Database");
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(connection);
});

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) => cfg.Host("localhost"));
});

builder.Services.AddOpenApi();
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();
builder.Services.AddScoped<IMessageManager, MessageManager>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapPost("/messages", async (string headline, string text, User? user, AppDbContext db, IPublishEndpoint publish) =>
{
    Message? message = new(headline, text, user);
    await db.Messages.AddAsync(message);

    MessageDTO? mDTO = new MessageDTO
    {
        Headline = message.Headline,
        BodyText = message.BodyText,
        CreatedAt = message.CreatedAt,
        UserName = message?.User?.Name
    };
    await publish.Publish<MessageDTO>(mDTO);

    return Results.Ok(mDTO);
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
