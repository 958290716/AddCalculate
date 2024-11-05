using Caculate1;

namespace AddTest1
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("1+1", 2)]
        [InlineData("1+(-1)", 0)]
        [InlineData("(-1)+1", 0)]
        public void Add_Chartoint(string str1, int expected)
        {
            //Arrange


            //Act
            int actual = Add.Sum(str1);

            //Assert
            Assert.Equal(expected, actual);

        }
    }
}