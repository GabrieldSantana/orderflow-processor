using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace OrderFlow.Infrastructure.Messaging;
public class RabbitMqPublisher 
{
    public async Task Publish<T>(string queue, T message)
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost"
        };

        using var connection = await factory.CreateConnectionAsync(); //TCP with RabbitMQ
        using var channel = await connection.CreateChannelAsync(); // "session" in connection

        await channel.QueueDeclareAsync(
            queue: queue, // Queue name
            durable: false, // Queue doesn't persist after restart
            exclusive: false, // Queue can be used by multiple consumers
            autoDelete: false, // Queue can't be deleted automatically
            arguments: null
        );

        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

        await channel.BasicPublishAsync(
            exchange: "", // Default exchange
            routingKey: queue, // Queue name
            body: body // Message
        );
    }
}