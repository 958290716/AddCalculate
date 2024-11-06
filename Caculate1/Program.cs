using ConsoleCalculator.Calculator;
using ConsoleCalculator.Parser;

var expression = Console.ReadLine();

if (expression == null)
{
    Console.WriteLine("Invalid expression");
    return;
}

NaiveParser parser = new();
NaiveCalculator calculator = new(parser);

Console.WriteLine(calculator.Calculate(expression));
