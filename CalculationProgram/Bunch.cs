using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculationProgram.Interfaces;

namespace CalculationProgram
{
    public class Bunch : Universum
    {
        IUniversum universum = new Universum();
        private int[] bunch = new int[0];
        int lenghtOfBunch;

        public Bunch(IUniversum newUniversum)
        {
            universum = newUniversum;
        }

        public void addElements()
        {
            bool cycleGo = true;
            while (cycleGo)
            {
                Console.WriteLine("Введите количество элементво вашего множества, которое больше 0, но меньше " + universum.getUniversum().Length);
                if (int.TryParse(Console.ReadLine(), out lenghtOfBunch))
                {
                    if (lenghtOfBunch < universum.getUniversum().Length & lenghtOfBunch > 0)
                    {
                        Array.Resize(ref bunch, lenghtOfBunch);
                        cycleGo = false;
                    }
                }
                else
                {
                    Console.WriteLine("Введите значение правильно!");
                }
            }

            Console.WriteLine("Введите элементы вашего множества,не выходя за промежуток от " +
                            universum.getUniversum()[0] + " до " + universum.getUniversum()[universum.getUniversum().Length - 1] + ")");
            for (int count = 0; count < bunch.Length; count++)
            {
                int element;
                bool testElement = int.TryParse(Console.ReadLine(), out element);
                if (universum.getUniversum().Contains(element) && testElement)
                {
                    bunch[count] = element;
                }
                else
                {
                    Console.WriteLine("Введите элемент в пределах допустимого значения");
                    count--;
                }
            }
        }

        public int[] getBunch()
        {
            return bunch;
        }
    }
}