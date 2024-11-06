namespace ConsoleCalculator.Parser;

public interface ITokenParser
{
    public List<Token> Parse(string expression);
}
