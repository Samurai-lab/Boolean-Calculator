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
        Dictionary<string, HashSet<int>> sets = new Dictionary<string, HashSet<int>>();

        public void UseExpression(IUniversum universum, Dictionary<string, HashSet<int>> setElement)
        {

            universumElement = universum;
            if (setElement.Count > 0) sets = setElement;

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
            bool allElementAdded = true;
            MatchCollection letterMatches = Regex.Matches(input, "[A-Z]");
            foreach (Match match in letterMatches)
            {
                if (!sets.ContainsKey(match.Value))
                {
                    AddDictionaryValue(match.Value, ref sets);
                    if (!sets.ContainsKey(match.Value))
                    {
                        allElementAdded = false;
                        break;
                    }
                }
            }

            if (allElementAdded)
            {
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
        }

        private void AddDictionaryValue(string tokenName, ref Dictionary<string, HashSet<int>> sets)
        {
            sets[tokenName] = new HashSet<int>();
            System.Console.WriteLine("How much elements in " + tokenName + " (write like: 1,2,3...)");
            string newInput = Console.ReadLine();

            // Разбиваем введенную строку на операторы и операнды множеств
            string[] newTokens = newInput.Split();
            string[] numbers = newTokens[0].Split(',');
            foreach (string number in numbers)
            {
                if (universumElement.getUniversum().Contains(int.Parse(number)) && !sets[tokenName].Contains(int.Parse(number)))
                {
                    sets[tokenName].Add(int.Parse(number));
                }
                else
                {
                    Console.WriteLine("Присутствуют повторяющиеся и не входящие в универсум элементы!");
                    sets.Remove(tokenName);
                    Console.ReadKey();
                }
            }
        }

        private void AddDictionaryValue(string tokenName, string input, ref Dictionary<string, HashSet<int>> sets)
        {
            sets[tokenName] = new HashSet<int>();
            string[] numbers = input.Split(',');
            foreach (string number in numbers)
            {
                if (universumElement.getUniversum().Contains(int.Parse(number)) && !sets[tokenName].Contains(int.Parse(number)))
                {
                    sets[tokenName].Add(int.Parse(number));
                }
                else
                {
                    Console.WriteLine("Присутствуют повторяющиеся и не входящие в универсум элементы!");
                    sets.Remove(tokenName);
                    Console.ReadKey();
                    break;
                }
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
                AnalysisFragmentOperations(brekets, count, ref setsBuf, token, ref sets);
                count += 2;
            }
            foreach (string elements in setsBuf.Keys)
            {
                sets.Add(elements, setsBuf[elements]);
            }
            Console.Clear();
            if (sets.ContainsKey("J"))
            {
                System.Console.WriteLine("Итоговое множество: ");
                PrintDictionaryElements(setsBuf);
                Console.ReadKey();
            }
            sets.Remove("J");
            namesCount++;
        }

        private void AnalysisFragmentOperations(string[] brekets, int count,
                                ref Dictionary<string, HashSet<int>> setsBuf,
                                string token, ref Dictionary<string,
                                HashSet<int>> sets)
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
                sets["hp"] = new HashSet<int>();
                sets["hp"].UnionWith(sets[otherSetNameFirst]);
                sets["hp"].IntersectWith(sets[otherSetNameSecond]);
                setsBuf[token].UnionWith(sets["hp"]);
                sets.Remove("hp");
            }
            else if (brekets[count] == "/")
            {
                string otherSetNameFirst = brekets[count - 1];
                string otherSetNameSecond = brekets[count + 1];
                sets["hp"] = new HashSet<int>();
                sets["hp"].UnionWith(sets[otherSetNameFirst]);
                sets["hp"].ExceptWith(sets[otherSetNameSecond]);
                setsBuf[token].UnionWith(sets["hp"]);
                sets.Remove("hp");
            }
            else if (brekets[count] == "t")
            {
                string otherSetNameFirst = brekets[count - 1];
                string otherSetNameSecond = brekets[count + 1];
                sets["hpFirst"] = new HashSet<int>();
                sets["hpSecond"] = new HashSet<int>();
                sets["hpFirst"].UnionWith(sets[otherSetNameFirst]);
                sets["hpFirst"].IntersectWith(sets[otherSetNameSecond]);
                sets["hpSecond"].UnionWith(sets[otherSetNameFirst]);
                sets["hpSecond"].UnionWith(sets[otherSetNameSecond]);
                sets["hpSecond"].ExceptWith(sets["hpFirst"]);
                setsBuf[token].UnionWith(sets["hpSecond"]);
                sets.Remove("hpFirst");
                sets.Remove("hpSecond");

            }
        }

        private void PrintDictionaryElements(Dictionary<string, HashSet<int>> sets)
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