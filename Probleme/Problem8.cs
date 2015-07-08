using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probleme
{
    // You are given n variable declaration_s and a _printf instruction. You must display the output of the instruction.
    // https://mindcoding.ro/pb/printf
    class Problem8
    {
        private static int N;

        public static void solve()
        {
            Console.WriteLine("Problem 8");

            var variables = GetVariables();

            var expression = Console.ReadLine();
            var outExpression = "";

            var expressionVariables = expression.Split(',');
            var expressionBuffer = new List<char>();
            var variableCount = 0;

            if(expressionVariables.Length > 1)
            {
                for (var i = 1; i < expressionVariables.Length; i++)
                    expressionBuffer.Add(expressionVariables[i][0]);
            }

            for(var i = 0;i < expression.Length;i++)
            {
                if (expression[i] == ',')
                    break;

                if (N > 0 && i < expression.Length - 1 && expression[i] == '%')
                {
                    switch(expression[i+1])
                    {
                        case 's':           // string
                            var sValue = variables[expressionBuffer[variableCount++] - 'a'].ToString();
                            outExpression += sValue;
                            i = i + 1;
                            break;
                        case '.':           // floating-point
                            if(variables[expressionBuffer[variableCount++] - 'a'] is double == false)
                            {
                                Console.WriteLine("Double value expected at index {0}", i);
                                return;
                            }

                            var fValue = (double)variables[expressionBuffer[variableCount++] - 'a'];
                            var precision = int.Parse(expression.Substring(i + 2, expression.IndexOf('f', i) - i - 2));

                            outExpression += Math.Round(fValue, precision);

                            i = expression.IndexOf('f', i);

                            break;
                        default:            // integer
                            var iValue = (int)variables[expressionBuffer[variableCount++] - 'a'];

                            if (variables[expressionBuffer[variableCount++] - 'a'] is int == false)
                            {
                                Console.WriteLine("Integer value expected at index {0}", i);
                                return;
                            }

                            var width = int.Parse(expression.Substring(i + 1, expression.IndexOf('d', i) - i - 1));

                            outExpression += iValue.ToString().PadLeft(width);

                            i = expression.IndexOf('d', i);

                            break;
                    }
                }
                else
                    outExpression += expression[i];
            }

            Console.WriteLine(outExpression);
        }

        private static object[] GetVariables()
        {
            var variables = new object['z' - 'a' + 1];

            Console.WriteLine("Enter N:");

            N = -1;
            var sN = Console.ReadLine();

            if (string.IsNullOrEmpty(sN))
                N = 0;
            else
            {
                foreach (var ch in sN)
                    if (!char.IsDigit(ch))
                    {
                        N = 0;
                        break;
                    }

                if (N != 0)
                    N = int.Parse(sN);
            }

            var line = "";
            var value = "";

            for (var i = 0; i < variables.Length; i++)
                variables[i] = null;

            for (var i = 0; i < N; i++)
            {
                line = Console.ReadLine();
                value = line.Substring(2);

                if (isInteger(value))
                {
                    variables[line[0] - 'a'] = int.Parse(value);
                }
                else
                {
                    if (isDouble(value))
                        variables[line[0] - 'a'] = double.Parse(value);
                    else
                        variables[line[0] - 'a'] = value;
                }
            }

            for (var i = 0; i < variables.Length; i++)
            {
                if (variables[i] != null)
                    Console.WriteLine(((char)('a' + i)).ToString() + " " + variables[i].GetType() + " " + variables[i].ToString());
            }

            return variables;
        }

        private static bool isInteger(string str)
        {
            if (str[0] != '-' && !char.IsDigit(str[0]))
                return false;

            for (var i = 1; i < str.Length; i++)
                if (!char.IsDigit(str[i]))
                    return false;

            return true;
        }

        private static bool isDouble(string str)
        {
            var dotCount = 0;

            if (str[0] != '-' && str[0] != '.' && !char.IsDigit(str[0]))
                return false;

            if (str[0] == '.')
                dotCount = 1;

            for (var i = 1; i < str.Length; i++)
            {
                if (!char.IsDigit(str[i]))
                {
                    if (str[i] == '.')
                        if (dotCount == 1)
                            return false;
                        else
                            dotCount = 1;
                    else
                        return false;
                }
            }

            return true;
        }
    }
}
