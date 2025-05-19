namespace strategy_pattern;

public class ConsoleOutputStrategy : IOutputStrategy
{
    public void Write(string data)
    {
        Console.WriteLine($"Console Output: {data}");
    }
}