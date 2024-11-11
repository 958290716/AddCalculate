namespace ConsoleCalculator.Parser;

/// <summary>
/// Parser expressions that only contain two numbers and one operator
/// </summary>
public class NaiveParser : ITokenParser
{
    public List<Token> Parse(string expression)
    {
        List<Token> tokens = new List<Token>();
        int expLen = expression.Length; //get expression's length
        char expTemp; //get every char in expression
        int numTemp = 0; //record a whole number
        int numPosition = 0;//record the number's position
        int operatorNumRecord = 0; //record the numebr of operator,if bigger than or equal to 3,mean invaild input
        int hadNum = 0; //means it had already nums,avoid mistake
        int realCount = 0; //record numbers just include numbers and operators
        for(int i = 0; i<expLen; i++)// judge if there are only numbers in expression
        {
            int numCount = 0;
            if (Char.IsDigit(expression[i]))
            {
                numCount++;
            }
            if (i == expLen - 1)
            {
                if(numCount == expLen)
                {
                    throw new ArgumentException("only number(s) inputted");
                }
            }
        }
        for(int i = 0;i <expLen; i++) // start parse
        {
            expTemp = expression[i];
            if (Char.IsDigit(expTemp)){  // process number
                realCount++;
                numTemp += (int)((expTemp - '0') * Math.Pow(10, numPosition));//calculate current number
                numPosition++; //carry digit
                operatorNumRecord = 0; //reset operatorNumRecord
                hadNum = 1;
            }
            else if (expTemp == '+' || expTemp == '-')  //process operator
            {
                realCount++;
                if (numTemp != 0)
                {
                    Token numTokenTemp = new(TokenType.Number, numTemp.ToString()); //operator after number, means this number is completed
                    tokens.Add(numTokenTemp); //then store it in the list
                    numPosition = 0; //reset numPosition
                    numTemp = 0; // reset numTemp
                }
                Token operatorTokenTemp = new (TokenType.Operator, expTemp.ToString());
                tokens.Add(operatorTokenTemp);
                operatorNumRecord++;                
                if(operatorNumRecord == 2 && hadNum == 0) //input like ++1+1, means error
                {
                    throw new ArgumentException("Wrong input");
                }
                if(operatorNumRecord == 3)
                {
                    throw new ArgumentException("Too much operators!");
                }
            }
            else if (expTemp == ' ') // if expression is a invalid symbol ,skip it
            {
                
            }
            /*if(numTemp != 0 && hadNum != 0) //get the normal format number
            {
                Token numTokenTemp = new(TokenType.Number, numTemp.ToString()); //operator after number, means this number is completed
                tokens.Add(numTokenTemp); //then store it in the list
                numPosition = 0; //reset numPosition
                numTemp = 0; // reset numTemp
            }*/
            if(i == expLen - 1)
            {
                if(numTemp != 0) //get the last number
                {
                    Token numTokenTemp = new(TokenType.Number, numTemp.ToString()); //operator after number, means this number is completed
                    tokens.Add(numTokenTemp); //then store it in the list
                    numPosition = 0; //reset numPosition
                    numTemp = 0; // reset numTemp
                }
                else if (operatorNumRecord != 0) //if the last expression is an operator,means error 
                {
                    throw new ArgumentException("the last expression is operator,error!");
                }
            }
        }
        return tokens;
        //throw new NotImplementedException();

    }
}
