using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculate1
{
    public class Add
    {
        public static int Sum(string str1)
        {
            int num1 = 0, num2 = 0;
            int index = 0;

            if (str1.IndexOf('+') == -1)    //判断是否输入+号
            {
                Console.WriteLine("输入错误字符串！");
                return 0;
            }
            else if (str1.IndexOf('+') != 0)
            {
                index = str1.IndexOf('+');
            }
            //Console.WriteLine("index:"+ index);
            int len1 = str1.Length;
            string substr1 = str1.Substring(0, index);
            string substr2 = str1.Substring(index + 1);
            if (substr1.Contains("-"))
            {
                substr1 = substr1.Substring(1, substr1.Length - 2);
            }
            if (substr2.Contains("-"))
            {
                substr2 = substr2.Substring(1, substr2.Length - 2);
            }
            num1 = Convert.ToInt32(substr1);
            num2 = Convert.ToInt32(substr2);
            //Console.WriteLine(Convert.ToInt32(substr1)+ Convert.ToInt32(substr2));
            return (num1 + num2);
        }
    }
}
