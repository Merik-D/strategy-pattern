using strategy_pattern.Config;
using strategy_pattern.Services;

var config = ConfigurationLoader.Load();
var dataService = new DataService(config);

if (args.Length == 0)
{
    Console.WriteLine("Usage: fetch | run");
    return;
}

switch (args[0])
{
    case "fetch":
        await dataService.FetchAsync();
        break;

    case "run":
        await dataService.RunAsync();
        break;

    default:
        Console.WriteLine("Invalid command. Usage: fetch | run");
        break;
}