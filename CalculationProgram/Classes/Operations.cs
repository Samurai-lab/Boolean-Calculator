using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculationProgram.Interfaces;

namespace CalculationProgram.Classes
{
    public class Operations
    {
        Bunch[] bunches = new Bunch[3];
        Bunch[] bunchesResult;
        public Operations(Bunch[] bunches)
        {
            this.bunches = bunches;
            bunchesResult = new Bunch[bunches.Length];
        }
        public void OperationSelector()
        {
            IMenu menuSelector = new MenuSelector();
            bool back = false;
            string answer;
            string combination;

            while (!back)
            {
                Console.Clear();
                menuSelector.CallOperationsMenu();
                answer = Console.ReadLine();
                Console.Clear();
                combination = AskAboutCombination();
                AddOperatingElement(combination);
                switch (answer)
                {
                    case "1":
                        for (int counter = 0; counter < bunchesResult.Length; counter++)
                        {
                            System.Console.WriteLine(bunchesResult[counter].printBunchElements());
                            Console.ReadKey();
                        }
                        break;

                    case "2":

                        break;

                    case "3":

                        break;

                    case "4":

                        break;

                    case "5":
                        back = true;
                        break;

                    default:
                        Console.WriteLine("Введите команду верно!");
                        Console.ReadKey();
                        break;
                }

            }
        }

        private string AskAboutCombination()
        {
            string first = "";
            string second = "";
            string thrith = "";
            int numberBunches;
            System.Console.WriteLine("С каким количеством множеств вы хотите провести операцию? (Доступно " +
                                        bunches.Length + " множество)");
            if (int.TryParse(Console.ReadLine(), out numberBunches))
            {
                switch (numberBunches)
                {
                    case 1:
                        first = "A";
                        break;
                    case 2:
                        if (bunches.Length == 3)
                        {
                            System.Console.WriteLine("Введине название первого множества:");
                            first = Console.ReadLine();
                            System.Console.WriteLine("Введине название второго множества:");
                            second = Console.ReadLine();
                        }
                        else
                        {
                            first = "A";
                            second = "B";
                        }
                        break;
                    case 3:
                        first = "A";
                        second = "B";
                        thrith = "C";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                System.Console.WriteLine("Введено недопустимое значение!");
            }

            return first + second + thrith;
        }

        private void AddOperatingElement(string text)
        {
            foreach (char element in text)
            {
                if (element == 'A')
                {
                    bunchesResult[0] = bunches[0];
                }
                else if (element == 'B')
                {
                    bunchesResult[1] = bunches[1];
                }
                else
                {
                    bunchesResult[2] = bunches[2];
                }
            }
        }

    }
}