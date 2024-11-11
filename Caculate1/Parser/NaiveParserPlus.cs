using System.Text.RegularExpressions;

namespace ConsoleCalculator.Parser;

/// <summary>
/// Parser expressions that only contain two numbers and one operator
/// </summary>
public partial class NaiveParserPlus : ITokenParser
{
    public List<Token> Parse(string expression)
    {
        // Sanitize
        expression = Sanitize(expression);

        // Parse
        List<Token> tokens = [];
        int i;
        for (i = 0; i < expression.Length; )
        {
            // number or operator
            if (MaybeNumber(i))
            {
                var result = RealNumberRegex().Match(expression, i);
                // Is a number starting from i
                if (result.Success && result.Index == i)
                {
                    var numberString = result.Value;
                    tokens.Add(new Token(TokenType.Number, numberString));
                    i += numberString.Length;
                    continue;
                }
            }
            // operator
            if (ShouldBeBinaryOperator(i))
            {
                tokens.Add(new Token(TokenType.Operator, expression[i].ToString()));
                i++;
                continue;
            }
            else
            {
                throw new ArgumentException($"Invalid input at index {i}");
            }
        }

        // Validate
        if (tokens.Count == 0)
        {
            throw new ArgumentException("Expression cannot be empty");
        }
        else if (tokens.Count == 1)
        {
            if (tokens.First().Type == TokenType.Number)
            {
                throw new ArgumentException("Expression cannot be a number");
            }
            else if (tokens.First().Type == TokenType.Operator)
            {
                throw new ArgumentException("Expression cannot be an operator");
            }
        }
        else if (tokens.Last().Type == TokenType.Operator)
        {
            throw new ArgumentException("Expression cannot end with an operator");
        }

        return tokens;

        // Indicate the substring starts from i may be a number but not certain.
        bool MaybeNumber(int i)
        {
            var currentChar = expression[i];
            if (IsDigit(currentChar))
            {
                return true;
            }
            // Last token is an operator and current char is - or +
            if (
                (tokens.Count == 0 || tokens.Last().Type == TokenType.Operator)
                && IsSign(currentChar)
            )
            {
                return true;
            }
            return false;
        }

        bool ShouldBeBinaryOperator(int i)
        {
            if (tokens.Count == 0)
                return false;
            if (tokens.Last().Type != TokenType.Operator && IsOperator(expression[i]))
                return true;
            return false;
        }
    }

    protected static string Sanitize(string expression)
    {
        // Remove all whitespaces.
        return new(expression.Where(c => !char.IsWhiteSpace(c)).ToArray());
    }

    protected static bool IsOperator(char c)
    {
        return c == '+' || c == '-' || c == '*' || c == '/';
    }

    protected static bool IsSign(char c)
    {
        return c == '+' || c == '-';
    }

    protected static bool IsDigit(char c)
    {
        return char.IsDigit(c);
    }

    [GeneratedRegex(@"[+-]?([0-9]*[.])?[0-9]+")]
    private static partial Regex RealNumberRegex();
}
