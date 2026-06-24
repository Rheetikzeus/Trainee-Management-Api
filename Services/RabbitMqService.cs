using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace TraineeManagement.Services;

public class RabbitMqService
{
    private readonly IConnection _connection;

    private const string QueueName = "submission-processing";
    private const string DlxExchange = "Submissions.dlx";
    private const string DlqQueue = "Submissions.dlq";
    private const string DlxRoutingKey = "Submission.failed";

    public RabbitMqService(IConnection connection)
    {
        _connection = connection;
    }

    public async Task PublishAsync<T>(string queueName, T message)
    {
        using var channel = await _connection.CreateChannelAsync();

        await channel.ExchangeDeclareAsync(QueueName, ExchangeType.Topic, durable: true);
        await channel.ExchangeDeclareAsync(DlxExchange, ExchangeType.Headers, durable: true);

        await channel.QueueDeclareAsync(DlqQueue, durable: true, exclusive: false, autoDelete: false);
        await channel.QueueBindAsync(DlqQueue, DlxExchange, routingKey: DlxRoutingKey);

        IDictionary<string, object?> queueArguments = new Dictionary<string, object?>()
        {
            { "x-dead-letter-exchange", DlxExchange },
            { "x-dead-letter-routing-key", DlxRoutingKey }
        };


        await channel.QueueDeclareAsync(
            queue: queueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: queueArguments
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