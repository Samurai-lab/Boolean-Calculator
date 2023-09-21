using System.Numerics;
using System;
using CalculationProgram.Interfaces;
using System.Text.RegularExpressions;
using System.IO.Compression;
using CalculationProgram.Classes;

namespace CalculationProgram;
class CalculationProgram
{
    static void Main(string[] args)
    {
        IMenu menuSelector = new MenuSelector();
        IUniversum universum = new Universum();
        Bunch[] bunches = new Bunch[0];
        Operations operations = new Operations(bunches);
        IExpression expression = new Expression();

        bool exitApp = false;
        string answer;
        int universumLenght = 0;

        while (!exitApp)
        {
            Console.Clear();
            menuSelector.CallMainMenu();
#pragma warning disable CS8600
            answer = Console.ReadLine();
#pragma warning restore CS8600
            switch (answer)
            {
                case "1":
                    universum.createOwnUniversum();
                    universumLenght = universum.getUniversum().Length;
                    break;

                case "2":
                    if (universumLenght == 0)
                    {
                        printUniversumError();
                        break;
                    };

                    Console.WriteLine("Введиете кол-во множеств (2 - 3):");

                    int bunchCount;
                    bool checkElement = int.TryParse(Console.ReadLine(), out bunchCount);

                    if (!checkElement && bunchCount < 2 && bunchCount > 3)
                    {
                        break;
                    }
                    Array.Resize(ref bunches, bunchCount);
                    for (int num = 0; num < bunchCount; num++)
                    {
                        Console.WriteLine("Множество " + (BunchNames)num);
                        bunches[num] = new Bunch(universum);
                        bunches[num].addElements();
                    }
                    operations = new Operations(bunches);
                    break;
                case "3":
                    if (universumLenght == 0)
                    {
                        printUniversumError();
                        break;
                    };
                    Console.WriteLine("Промежуток от " + universum.getUniversum()[0] + " до " + universum.getUniversum()[universumLenght - 1]);
                    Console.ReadKey();
                    break;

                case "4":
                    if (universumLenght == 0)
                    {
                        printUniversumError();
                        break;
                    }
                    else if (bunches.Length == 0)
                    {
                        printBunchError();
                        break;
                    };
                    int iterations = 0;
                    foreach (Bunch element in bunches)
                    {
                        Console.WriteLine("Множество " + (BunchNames)iterations + " = " + element.printBunchElements());

                        iterations++;
                    }
                    Console.ReadKey();
                    break;

                case "5":
                    if (universumLenght == 0)
                    {
                        printUniversumError();
                        break;
                    }
                    else if (bunches.Length == 0)
                    {
                        printBunchError();
                        break;
                    };

                    int[] displayMass = operations.OperationSelector();
                    foreach (int num in displayMass)
                    {
                        System.Console.Write(num + " ");
                    }

                    Console.ReadKey();
                    break;

                case "6":
                    if (universumLenght == 0)
                    {
                        printUniversumError();
                        break;
                    };
                    expression.UseExpression(universum);
                    break;

                case "7":
                    exitApp = true;
                    break;

                default:
                    Console.WriteLine("Введите команду верно!");
                    break;
            }
        }
        Console.Clear();
    }

    static void printUniversumError()
    {
        Console.WriteLine("Универсум не задан!\n\n"
                        + "Нажмите клавишу для продолжения");
        Console.ReadKey();
    }

    static void printBunchError()
    {
        Console.WriteLine("Множества не заданы!\n\n"
                        + "Нажмите клавишу для продолжения");
        Console.ReadKey();
    }

}
