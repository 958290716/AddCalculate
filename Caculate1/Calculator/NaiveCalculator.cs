using ConsoleCalculator.Parser;

namespace ConsoleCalculator.Calculator;

public class NaiveCalculator(ITokenParser _parser) : ICalculator
{
    public double Calculate(string expression)
    {
        List<Token> tokens = _parser.Parse(expression);

        if (tokens.Count != 3)
            throw new Exception("Invalid expression");
        if (tokens[0].Type != TokenType.Number || tokens[2].Type != TokenType.Number)
            throw new Exception("Invalid expression");
        if (tokens[1].Type != TokenType.Operator)
            throw new Exception("Invalid expression");

        var num1 = double.Parse(tokens[0].Value);
        var num2 = double.Parse(tokens[2].Value);

        return tokens[1].Value switch
        {
            "+" => num1 + num2,
            "-" => num1 - num2,
            _ => throw new Exception("Unsupported operation"),
        };
    }
}
