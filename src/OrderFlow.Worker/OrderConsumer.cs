using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace OrderFlow.Worker
{
    public class OrderConsumer
    {
        public async Task StartAsync()
        {
            //Creates a connection factory
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            //Opens connection and channel
            var connection = await factory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();

            //Ensures the queue exists
            await channel.QueueDeclareAsync(
                queue: "order-created",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            // Creates a consumer to receive messages asynchronously
            var consumer = new AsyncEventingBasicConsumer(channel);

            //Defines what happens when a message is received
            consumer.ReceivedAsync += async (sender, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray(); // Reads the message body

                var message = Encoding.UTF8.GetString(body); // COnverts bytes to string

                Console.WriteLine($"Message received: {message}");

                await Task.CompletedTask;
            };

            // Starts consuming messages from the queue
            await channel.BasicConsumeAsync(
                queue: "order-created",
                autoAck: true,
                consumer: consumer
            );
        }
    }
}