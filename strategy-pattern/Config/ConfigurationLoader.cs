using Microsoft.Extensions.Configuration;

namespace strategy_pattern.Config;

public static class ConfigurationLoader
{
    public static IConfiguration Load()
    {
        return new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
    }
}