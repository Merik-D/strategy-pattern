using StackExchange.Redis;
using Microsoft.Extensions.Configuration;
namespace strategy_pattern;

public class RedisOutputStrategy : IOutputStrategy
{
    private readonly ISubscriber _subscriber;
    private readonly string _channel;

    public RedisOutputStrategy(IConfiguration config)
    {
        var redisHost = config["Redis:Host"];
        var redisPort = config["Redis:Port"];
        var redisPassword = config["Redis:Password"];
        
        var connectionString = $"{redisHost}:{redisPort}";
        if (!string.IsNullOrEmpty(redisPassword))
        {
            connectionString = $"{redisPassword}@{connectionString}";
        }
        
        var redis = ConnectionMultiplexer.Connect(connectionString);
        _subscriber = redis.GetSubscriber();
        _channel = config["Redis:Channel"];
    }

    public void Write(string data)
    {
        _subscriber.Publish(_channel, data);
        Console.WriteLine($"Published to Redis channel '{_channel}': {data}");
    }
}