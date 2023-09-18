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
        public void UseExpression()
        {

            Dictionary<string, HashSet<int>> sets = new Dictionary<string, HashSet<int>>();
            Regex regexExpression = new Regex(@"^(\(*[A-Z]\s[-+/t]\s\(*[A-Z]\)*\s*(\s*[-+/t]\s*\(*[A-Z]\)*\s*)*){1,24}$");
            Regex regexBunch = new Regex(@"^[A-Z]\s[=]\s([0-9]+[,])*[0-9]+$");
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
                        /* menu.CallExpressionMenu(); */
                        Console.Write("Введите выражение: ");
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
                            MatchCollection letterMatches = Regex.Matches(input, "[A-Z]");
                            foreach (Match match in letterMatches)
                            {
                                if (!sets.ContainsKey(match.Value))
                                {
                                    AddValueElements(match.Value, ref sets);
                                }
                            }
                            MatchCollection letterMatchesBrekets = Regex.Matches(input, @"\((.*?)\)");

                            int numNameCall = 1;
                            foreach (Match match in letterMatchesBrekets)
                            {
                                string bunchName = "" + (TegNames)numNameCall;

                                AnalysisFragment(ref sets, match.Groups[1].Value, ref input, bunchName);
                                input = input.Replace("(" + match.Groups[1].Value + ")", bunchName);
                                numNameCall++;
                            }
                            AnalysisFragment(ref sets, input, ref input, "J");

                            for (; numNameCall >= 1; numNameCall--)
                            {
                                string bunchName = "" + (TegNames)numNameCall;
                                sets.Remove(bunchName);
                            }
                        }
                        else if (regexBunch.IsMatch(input))
                        {
                            MatchCollection letterMatches = Regex.Matches(input, "[A-Z]");
                            foreach (Match match in letterMatches)
                            {
                                AddFirstValueElements(match.Value, tokens[2], ref sets);
                            }
                        }
                        break;

                    case 2:
                        foreach (KeyValuePair<string, HashSet<int>> set in sets)
                        {
                            Console.WriteLine($"{set.Key} = [{string.Join(", ", set.Value)}]");
                        }

                        Console.ReadKey();
                        break;
                    case 3:
                        outMenu = true;
                        break;
                    default:
                        break;
                }
            }
            //     for (int i = 0; i < tokens.Length; i += 2)
            //     {
            //         System.Console.WriteLine("tokens[i] = " + tokens[i]);
            //         string setName = tokens[i];
            //         string operatorSymbol = "";
            //         if (i + 1 != tokens.Length)
            //         {
            //             System.Console.WriteLine("tokens[i + 1] = " + tokens[i + 1]);
            //             operatorSymbol = tokens[i + 1];
            //         }

            //         if (!sets.ContainsKey(setName))
            //         {
            //             sets[setName] = new HashSet<int>();
            //         }

            //             case "+":
            //                     string otherSetName = tokens[i + 2];
            //                     sets[setName].UnionWith(sets[otherSetName]);
            //                 break;
            //             case "-":
            //                 string otherSetNameInfo = tokens[i + 2];
            //                 sets[setName].ExceptWith(sets[otherSetNameInfo]);
            //                 break;

            //             default:
            //                 break;
            //         }
            //         // Выводим результат расчета (все элементы оставшихся множеств)
            //         Console.WriteLine("Результат:");
            //         foreach (KeyValuePair<string, HashSet<int>> set in sets)
            //         {
            //             Console.WriteLine($"{set.Key} = [{string.Join(", ", set.Value)}]");
            //         }

            //         Console.ReadKey();
            //     }

            // }
        }

        private void AddValueElements(string tokenName, ref Dictionary<string, HashSet<int>> sets)
        {
            string newSetName = tokenName;
            sets[newSetName] = new HashSet<int>();
            System.Console.WriteLine("How much elements in " + newSetName + " (write like: 1,2,3...)");
            string newInput = Console.ReadLine();

            // Разбиваем введенную строку на операторы и операнды множеств
            string[] newTokens = newInput.Split();
            string[] numbers = newTokens[0].Split(',');
            foreach (string number in numbers)
            {
                sets[newSetName].Add(int.Parse(number));
            }
        }

        private void AddFirstValueElements(string tokenName, string input, ref Dictionary<string, HashSet<int>> sets)
        {
            sets[tokenName] = new HashSet<int>();
            string[] numbers = input.Split(',');
            System.Console.WriteLine("numbers = " + numbers.Length);
            foreach (string number in numbers)
            {
                sets[tokenName].Add(int.Parse(number));
            }
        }

        private void AnalysisFragment(ref Dictionary<string, HashSet<int>> sets, string match, ref string input, string token)
        {
            Dictionary<string, HashSet<int>> setsBuf = new Dictionary<string, HashSet<int>>();
            setsBuf[token] = new HashSet<int>();
            int count = 1;
            int namesCount = 1;
            string[] brekets = match.Split(" ");
            int breketsLenght = 0;
            if (brekets.Length > 3)
            {
                breketsLenght = brekets.Length / 2;
            }
            else
            {
                breketsLenght = brekets.Length / 3;
            }
            for (int i = 0; i < breketsLenght; i++)
            {
                if (brekets[count] == "+")
                {
                    string otherSetNameFirst = brekets[count - 1];
                    string otherSetNameSecond = brekets[count + 1];
                    setsBuf[token].UnionWith(sets[otherSetNameFirst]);
                    setsBuf[token].UnionWith(sets[otherSetNameSecond]);
                }
                else if (brekets[count] == "-")
                {
                    string otherSetNameFirst = brekets[count - 1];
                    string otherSetNameSecond = brekets[count + 1];
                    setsBuf[token].IntersectWith(sets[otherSetNameFirst]);
                    setsBuf[token].IntersectWith(sets[otherSetNameSecond]);
                }
                else if (brekets[count] == "/")
                {
                    string otherSetNameFirst = brekets[count - 1];
                    string otherSetNameSecond = brekets[count + 1];
                    setsBuf[token].ExceptWith(sets[otherSetNameFirst]);
                    setsBuf[token].ExceptWith(sets[otherSetNameSecond]);
                }
                else if (brekets[count] == "t")
                {

                }
                count += 2;
            }
            sets[token] = new HashSet<int>();
            sets[token] = setsBuf[token];
            namesCount++;
        }
    }
}