using OrderFlow.Worker;
using OrderFlow.Infrastructure.Messaging;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<Worker>();
builder.Services.AddSingleton<RabbitMqPublisher>();

var host = builder.Build();
host.Run();
