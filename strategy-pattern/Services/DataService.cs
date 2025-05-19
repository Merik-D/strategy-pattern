using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace strategy_pattern.Services;

public class DataService
{
    private readonly IConfiguration _config;

    public DataService(IConfiguration config)
    {
        _config = config;
    }

    public async Task FetchAsync()
    {
        var fetcher = new DataFetcher();
        await fetcher.FetchAndSaveAsync(_config["Data:Url"], "data.json");
    }

    public async Task RunAsync()
    {
        if (!File.Exists("data.json"))
        {
            Console.WriteLine("Data file not found. Please run 'fetch' first.");
            return;
        }

        var json = await File.ReadAllTextAsync("data.json");
        var items = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(json);

        IOutputStrategy strategy = _config["Output:Type"] switch
        {
            "Kafka" => new KafkaOutputStrategy(_config["Kafka:Topic"]),
            "Redis" => new RedisOutputStrategy(_config),
            _ => new ConsoleOutputStrategy()
        };

        var outputContext = new OutputContext(strategy);

        foreach (var item in items)
        {
            string itemStr = string.Join(", ", item.Select(kv => $"{kv.Key}: {kv.Value}"));
            outputContext.ProcessOutput(itemStr);
        }
    }
}