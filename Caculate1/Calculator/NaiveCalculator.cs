using ConsoleCalculator.Parser;

namespace ConsoleCalculator.Calculator;

public class NaiveCalculator : ICalculator
{
    private readonly ITokenParser _parser;

    public NaiveCalculator(ITokenParser tokenParser)
    {
        _parser = tokenParser;
    }

    public double Calculate(string expression)
    {
        throw new NotImplementedException();
    }
}
