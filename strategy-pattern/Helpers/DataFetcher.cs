namespace strategy_pattern;

public class DataFetcher
{
    private readonly HttpClient _httpClient = new();

    public async Task FetchAndSaveAsync(string url, string filePath)
    {
        var data = await _httpClient.GetStringAsync(url);
        await File.WriteAllTextAsync(filePath, data);
        Console.WriteLine("Data fetched and saved.");
    }
}