using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace TraineeManagement.Services;

public class RabbitMqService
{
    private readonly IConnection _connection;

    public RabbitMqService(IConnection connection)
    {
        _connection = connection;
    }

    public async Task PublishAsync<T>(string queueName, T message)
    {
        using var channel = await _connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(
            queue: queueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        var json = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(json);

        await channel.BasicPublishAsync(
            exchange: string.Empty,
            routingKey: queueName,
            mandatory: true,
            body: body
        );
    }
}