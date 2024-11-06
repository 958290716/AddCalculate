using ConsoleCalculator.Calculator;
using ConsoleCalculator.Parser;

namespace ConsoleCalculator.Tests
{
    public class NaiveCalculatorTests
    {
        private NaiveCalculator GetNaiveCalculator() => new(new NaiveParser());

        [Theory]
        [InlineData("1+1", 2)]
        [InlineData("1+-1", 0)]
        [InlineData("-1+1", 0)]
        [InlineData("1-1", 0)]
        [InlineData("1-+1", 0)]
        [InlineData("-1-1", -2)]
        [InlineData("1++1", -2)]
        [InlineData("1--1", -2)]
        public void Calculate_WhenHasValidInput_ShouldReturnCorrectResult(
            string expression,
            double expected
        )
        {
            var calculator = GetNaiveCalculator();
            throw new NotImplementedException();
        }

        [Theory]
        [InlineData(" 1+1", 2)]
        [InlineData("1+1 ", 2)]
        [InlineData("1 +1", 2)]
        [InlineData("1+ 1", 2)]
        [InlineData("1 + - 1", 2)]
        public void Calculate_WhenhasWhiteSpaces_ShouldReturnCorrectResult(
            string expression,
            double expected
        )
        {
            var calculator = GetNaiveCalculator();
            throw new NotImplementedException();
        }

        [Theory]
        [InlineData("1")]
        [InlineData("1+1-")]
        [InlineData("-1-")]
        [InlineData("1---1")]
        [InlineData("1+++1")]
        [InlineData("1 + + + 1")]
        public void Calculate_WhenHasInvalidInput_ShouldThrowException(string expression)
        {
            var calculator = GetNaiveCalculator();
            throw new NotImplementedException();

            /// Should throws <see cref="ArgumentException"/>
        }
    }
}
