using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using CalculationProgram.Interfaces;

namespace CalculationProgram
{
    public class Bunch : Universum
    {
        IUniversum universum = new Universum();
        private int[] bunch = new int[0];

        IMenu menuSelector = new MenuSelector();
        int lenghtBunch;

        public Bunch(IUniversum newUniversum)
        {
            universum = newUniversum;
        }

        public void addElements()
        {
            bunchSizeChange();
            int answer = 0;
            bool exit = true;
            while (exit)
            {
                menuSelector.CallOperationsTypeMenu();
                if (int.TryParse(Console.ReadLine(), out answer))
                {
                    switch (answer)
                    {
                        case 1:
                            writeBunchElements();
                            break;
                        case 2:
                            randomBunchElements();
                            break;
                        case 3:
                            /* expressionsBunchElements(); */
                            break;
                        case 4:
                            exit = false;
                            break;
                        default:
                            break;
                    }
                    break;

                }
                else
                {
                    System.Console.WriteLine("Неверно задано значение!");
                }

            }
        }

        public string printBunchElements()
        {
            var text = "";
            foreach (int elements in bunch)
            {
                text += elements + " ";
            }
            return text;
        }

        private void bunchSizeChange()
        {
            bool cycleGo = true;
            while (cycleGo)
            {
                Console.WriteLine("Введите количество элементов вашего множества, которое больше 0, но меньше " + universum.getUniversum().Length);
                if (int.TryParse(Console.ReadLine(), out lenghtBunch))
                {
                    if (lenghtBunch < universum.getUniversum().Length & lenghtBunch > 0)
                    {
                        Array.Resize(ref bunch, lenghtBunch);
                        cycleGo = false;
                    }
                }
                else
                {
                    Console.WriteLine("Введите значение правильно!");
                }
            }
        }

        private void writeBunchElements()
        {
            Console.WriteLine("Введите элементы вашего множества,не выходя за промежуток от "
                              + universum.getUniversum()[0] + " до "
                              + universum.getUniversum()[universum.getUniversum().Length - 1] + ")");
            for (int count = 0; count < bunch.Length; count++)
            {
                int element;
                bool testParseElement = int.TryParse(Console.ReadLine(), out element);

                if (universum.getUniversum().Contains(element) && testParseElement && !bunch.Contains(element))
                {
                    bunch[count] = element;
                }
                else
                {
                    Console.WriteLine("Введите элемент в пределах допустимого значения  и не повторяющийся");
                    count--;
                }
            }
        }

        private void randomBunchElements()
        {
            Console.WriteLine("Введите элементы вашего множества,не выходя за промежуток от "
                              + universum.getUniversum()[0] + " до "
                              + universum.getUniversum()[universum.getUniversum().Length - 1] + ")");
            for (int count = 0; count < bunch.Length; count++)
            {
                
                Random random = new Random();
                int element = random.Next(universum.getUniversum()[0], universum.getUniversum()[universum.getUniversum().Length - 1]);

                if (universum.getUniversum().Contains(element) && !bunch.Contains(element))
                {
                    bunch[count] = element;
                }
                else
                {
                    Console.WriteLine("Введите элемент в пределах допустимого значения  и не повторяющийся");
                    count--;
                }
            }
        }

        public int[] getBunch() => bunch;

        public int GetBunchLenght()
        {
            int lenght = 0;
            foreach (int count in bunch)
            {
                lenght++;
            }
            return lenght;
        }
    }
}