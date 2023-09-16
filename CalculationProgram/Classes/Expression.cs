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
            IMenu menu = new MenuSelector();
            int answere = 0;
            bool outMenu = false;
            while (!outMenu)
            {
                Console.Clear();
                menu.CallExpressionMenu();
                Console.Write("Введите выражение с использованием множеств: ");
                string input = Console.ReadLine();

                // Разбиваем введенную строку на операторы и операнды множеств
                string[] tokens = input.Split();

                foreach (string tok in tokens)
                {
                    System.Console.WriteLine(tok);
                }

                // Создаем коллекцию для хранения множеств
                for (int i = 0; i < tokens.Length; i += 2)
                {
                    System.Console.WriteLine("tokens[i] = " + tokens[i]);
                    string setName = tokens[i];
                    string operatorSymbol = "";
                    if (i + 1 != tokens.Length)
                    {
                        System.Console.WriteLine("tokens[i + 1] = " + tokens[i + 1]);
                        operatorSymbol = tokens[i + 1];
                    }

                    // Если множество еще не было создано, создаем новое пустое множество
                    if (!sets.ContainsKey(setName))
                    {
                        sets[setName] = new HashSet<int>();
                    }
                    switch (operatorSymbol)
                    {
                        case "=":
                            if (i + 3 == tokens.Length)
                            {
                                string[] numbers = tokens[i + 2].Split(',');
                                System.Console.WriteLine("numbers = " + numbers.Length);
                                foreach (string number in numbers)
                                {
                                    sets[setName].Add(int.Parse(number));

                                }
                                i += 3;
                            }
                            else
                            {
                                string newSetName = tokens[i + 2];
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
                            break;
                        case "+":
                            if (sets[setName] != null)
                            {
                                System.Console.WriteLine("tokens[i + 2] = " + tokens[i + 2]);
                                string otherSetName = tokens[i + 2];
                                sets[setName].UnionWith(sets[otherSetName]);
                            }
                            break;
                        case "-":
                            string otherSetNameInfo = tokens[i + 2];
                            sets[setName].ExceptWith(sets[otherSetNameInfo]);
                            break;

                        default:
                            break;
                    }
                    // Выводим результат расчета (все элементы оставшихся множеств)
                    Console.WriteLine("Результат:");
                    foreach (KeyValuePair<string, HashSet<int>> set in sets)
                    {
                        Console.WriteLine($"{set.Key} = [{string.Join(", ", set.Value)}]");
                    }

                    Console.ReadKey();

                }

            }
        }
    }
}