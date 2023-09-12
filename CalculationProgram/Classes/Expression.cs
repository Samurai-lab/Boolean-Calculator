using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CalculationProgram.Interfaces;
using Microsoft.VisualBasic;

namespace CalculationProgram
{
    public class Expression : IExpression
    {
        Bunch[] bunches = new Bunch[0];
        String pattern = @"\((.*?)\)";

        String expressionText = "";
        String newExpressionText = "";
        Dictionary<int, string> bracketsExpression = new Dictionary<int, string>();

        public void SolvingExpression()
        {
            newExpressionText = CreateNewExpression(expressionText);
            Console.WriteLine(newExpressionText);
            Console.WriteLine(bracketsExpression);
        }

        private string CreateNewExpression(string text)
        {
            int breakNum = 0;
            MatchCollection matches = Regex.Matches(expressionText, pattern);
            foreach (Match match in matches)
            {
                breakNum++;
                text = match.Groups[breakNum].Value;
                
                bracketsExpression[breakNum] = text;
                expressionText.Replace(text, "1");
            }
            return expressionText;
        }

        /* private int CountingParentheses(String text)
        {
            int counter = 0;
            foreach (Char element in text)
            {
                if (element.Equals("("))
                {
                    counter++;
                }
            }
            return counter;
        } */

        string IExpression.getExpression()
        {
            return expressionText;
        }

        void IExpression.setExpression(String text)
        {
            this.expressionText = text;
        }
    }
}