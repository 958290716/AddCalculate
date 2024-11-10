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
        double result = 0;
        string tempOperator1 = "";
        string tempOperator2 = "";
        //int seq = 0; //record list position
        int isNum = 0; // record is a Number or not
        int isOperator = 0; //record is a Operator or not
        List<Token> listToken1 = _parser.Parse(expression);
        foreach(Token T1 in listToken1)
        {
            if(isNum == 0 && isOperator == 0) //both isNum and isOperator is 0,means start of the Tokenlist
            {
                if(T1.Type == TokenType.Number)
                {
                    result = int.Parse(T1.Value);                   
                }
                if(T1.Type == TokenType.Operator)
                {
                    isOperator = 1;
                    tempOperator1 = T1.Value;
                    continue;
                }
            }
            
            if(isOperator == 1) //isOperator is 1 means just add or minus
            {
                if (T1.Type == TokenType.Number) //just one operator, just add or minus
                {
                    if (tempOperator1 == "+")
                    {
                        result += int.Parse(T1.Value);
                        isOperator = 0; // reset isOperator
                    }
                    else if (tempOperator1 == "-")
                    {
                        result += (-1) * int.Parse(T1.Value);
                        isOperator = 0; // reset isOperator
                    }
                }
                else if (T1.Type == TokenType.Operator)  
                {
                    tempOperator2 = T1.Value;
                    isOperator = 2;
                    continue;
                }
            }
            if (isOperator == 2) //isOperator is 2 means need process the number first,only number after two operators
            { 
                if(tempOperator2 == "+" && tempOperator1 == "+") 
                {
                    result += int.Parse(T1.Value);
                    tempOperator1 = "";
                    tempOperator2 = "";
                    isOperator = 0;
                }
                else if(tempOperator2 == "-" && tempOperator1 == "+")
                {
                    result += (-1) * int.Parse(T1.Value);
                    tempOperator1 = "";
                    tempOperator2 = "";
                    isOperator = 0;
                }
                else if (tempOperator2 == "+" && tempOperator1 == "-")
                {
                    result -= int.Parse(T1.Value);
                    tempOperator1 = "";
                    tempOperator2 = "";
                    isOperator = 0;
                }
                else if (tempOperator2 == "-" && tempOperator1 == "-")
                {
                    result -= (-1) * int.Parse(T1.Value);
                    tempOperator1 = "";
                    tempOperator2 = "";
                    isOperator = 0;
                }
            }
        }
        return result;
    }
}
