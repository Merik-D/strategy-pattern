namespace strategy_pattern;

public class OutputContext
{
    private IOutputStrategy _strategy;
    
    public OutputContext(IOutputStrategy strategy)
    {
        _strategy = strategy;
    }
    
    public void ProcessOutput(string data)
    {
        _strategy.Write(data);
    }
    
    public void SetStrategy(IOutputStrategy strategy)
    {
        _strategy = strategy;
    }
}