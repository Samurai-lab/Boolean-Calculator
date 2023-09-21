using System.Xml.Linq;
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
        IUniversum universumElement;

        public void UseExpression(IUniversum universum)
        {

            universumElement = universum;

            Dictionary<string, HashSet<int>> sets = new Dictionary<string, HashSet<int>>();
            Regex regexExpression = new Regex(@"^(\(*[A-Z]\s[-+/t]\s\(*[A-Z]\)*\s*(\s*[-+/t]\s*\(*[A-Z]\)*\s*)*){1,24}$");
            Regex regexBunch = new Regex(@"^[A-Z]\s[=]\s([-]*[0-9]+[,])*[-]*[0-9]+$");
            IMenu menu = new MenuSelector();

            int answere = 0;
            bool outMenu = false;
            while (!outMenu)
            {
                Console.Clear();

                menu.CallExpressionMenu();
                System.Console.WriteLine("Выберите пункт меню");
                if (!int.TryParse(Console.ReadLine(), out answere))
                {
                    System.Console.WriteLine("Выберите значение из представленных!");
                    Console.ReadKey();
                    break;
                }
                switch (answere)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Задайте множества,не выходя за промежуток от "
                                          + universumElement.getUniversum()[0] + " до "
                                          + universumElement.getUniversum()[universumElement.getUniversum().Length - 1] + " или введите вырожение: ");
                        string input = Console.ReadLine();
                        string[] tokens = input.Split();
                        if (!regexExpression.IsMatch(input) && !regexBunch.IsMatch(input))
                        {
                            System.Console.WriteLine("Выражение задано неверно!");
                            Console.ReadKey();
                            break;
                        }
                        else if (regexExpression.IsMatch(input))
                        {
                            UnidentifiedExpression(ref input, ref sets);

                        }
                        else if (regexBunch.IsMatch(input))
                        {
                            UnidentifiedBunch(ref input, ref sets, ref tokens);
                        }
                        break;

                    case 2:
                        PrintDictionaryElements(sets);
                        Console.ReadKey();
                        break;
                    case 3:
                        outMenu = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void UnidentifiedExpression(ref string input, ref Dictionary<string, HashSet<int>> sets)
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
            foreach (KeyValuePair<string, HashSet<int>> set in sets)
            {
                Console.WriteLine($"{set.Key} = [{string.Join(", ", set.Value)}]");
            }
        }

        private void UnidentifiedBunch(ref string input, ref Dictionary<string, HashSet<int>> sets, ref string[] tokens)
        {
            MatchCollection letterMatches = Regex.Matches(input, "[A-Z]");
            foreach (Match match in letterMatches)
            {
                AddDictionaryValue(match.Value, tokens[2], ref sets);
            }
        }
    }
}