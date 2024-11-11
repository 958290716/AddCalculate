using ConsoleCalculator.Calculator;
using ConsoleCalculator.Parser;

namespace ConsoleCalculator.Tests
{
    public class NaiveCalculatorTests
    {
        private static NaiveCalculator GetNaiveCalculator() => new(new NaiveParserPlus());

        [Theory]
        [InlineData("1+1", 2)]
        [InlineData("1+-1", 0)]
        [InlineData("-1+1", 0)]
        [InlineData("1-1", 0)]
        [InlineData("1-+1", 0)]
        [InlineData("-1-1", -2)]
        [InlineData("1++1", 2)]
        [InlineData("1--1", 2)]
        [InlineData("999+1", 1000)]
        [InlineData("1+999", 1000)]
        public void Calculate_WhenHasValidInput_ShouldReturnCorrectResult(
            string expression,
            double expected
        )
        {
            var calculator = GetNaiveCalculator();
            //Act
            double actual = calculator.Calculate(expression);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(" 1+1", 2)]
        [InlineData("1+1 ", 2)]
        [InlineData("1 +1", 2)]
        [InlineData("1+ 1", 2)]
        [InlineData("1 + - 1", 0)]
        public void Calculate_WhenhasWhiteSpaces_ShouldReturnCorrectResult(
            string expression,
            double expected
        )
        {
            var calculator = GetNaiveCalculator();
            //Act
            double actual = calculator.Calculate(expression);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1")]
        [InlineData("+1")]
        [InlineData("1+1-")]
        [InlineData("-1-")]
        [InlineData("1---1")]
        [InlineData("1+++1")]
        [InlineData("1 + + + 1")]
        [InlineData("++1+1")]
        public void Calculate_WhenHasInvalidInput_ShouldThrowException(string expression)
        {
            var calculator = GetNaiveCalculator();
            Assert.Throws<ArgumentException>(() => calculator.Calculate(expression));
            /// Should throws <see cref="ArgumentException"/>
        }
    }
}
