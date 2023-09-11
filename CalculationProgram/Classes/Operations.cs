using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculationProgram.Interfaces;

namespace CalculationProgram.Classes
{
    public class Operations
    {
        public void operationSelector()
        {
            IMenu menuSelector = new MenuSelector();
            bool back = false;
            string answer;

            while (!back)
            {
                Console.Clear();
                menuSelector.CallOperationsMenu();
                answer = Console.ReadLine();
                Console.Clear();
                switch (answer)
                {
                    case "1":

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

    }
}