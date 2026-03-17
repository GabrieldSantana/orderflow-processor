using OrderFlow.Application.Interfaces;
using OrderFlow.Application.Services;
using OrderFlow.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IOrderRepository, InMemoryOrderRepository>(); // Use of Singleton to ensure a single instance across the entire application
builder.Services.AddScoped<IOrderProcessor, OrderProcessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();