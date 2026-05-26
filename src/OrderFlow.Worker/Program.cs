using OrderFlow.Worker;
using OrderFlow.Infrastructure.Messaging;

var builder = Host.CreateApplicationBuilder(args);
var consumer = new OrderConsumer();

builder.Services.AddHostedService<Worker>();
builder.Services.AddSingleton<RabbitMqPublisher>();

await consumer.StartAsync();

await Task.Delay(Timeout.Infinite);

var host = builder.Build();
host.Run();
