using ConsoleCalculator.Parser;

namespace ConsoleCalculator.Tests;

public class NaiveParserPlusTests
{
    [Theory]
    [InlineData("1+1")]
    [InlineData("1+-1")]
    [InlineData("-1+1")]
    [InlineData("1-1")]
    [InlineData("1-+1")]
    [InlineData("-1-1")]
    [InlineData("1++1")]
    [InlineData("1--1")]
    [InlineData("999+1")]
    [InlineData("1+999")]
    [InlineData("999++1")]
    [InlineData("1++999")]
    [InlineData("1*1")]
    [InlineData("1/1")]
    [InlineData("1*+1")]
    [InlineData("1/-1")]
    [InlineData("0.01+1.99")]
    [InlineData("1 + 1")]
    [InlineData("1+2-3/4*5+-6-+7*+8/-9+10")]
    public void Parse_WhenHasValidInput_ShouldPass(string expression)
    {
        var parser = new NaiveParserPlus();
        Assert.NotNull(parser.Parse(expression));
    }

    [Theory]
    [InlineData("")]
    [InlineData("+")]
    [InlineData("-")]
    [InlineData("++")]
    [InlineData("--")]
    [InlineData("+++")]
    [InlineData("--+")]
    [InlineData("1")]
    [InlineData("+1")]
    [InlineData("-1")]
    [InlineData("*1")]
    [InlineData("/1")]
    [InlineData("1+/1")]
    [InlineData("1+*1")]
    [InlineData("1+/+1")]
    [InlineData("1+++1")]
    [InlineData("0.1")]
    [InlineData("1+")]
    [InlineData("1 + + + 1")]
    [InlineData("blah")]
    public void Parse_WhenHasInvalidInput_ShouldThrowException(string expression)
    {
        var parser = new NaiveParserPlus();
        Assert.Throws<ArgumentException>(() => parser.Parse(expression));
    }
}
