using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculationProgram.Interfaces;

namespace CalculationProgram
{
    public class Universum : IUniversum
    {
        private int[] u;
        int start, final;
        public Universum()
        {
            u = new int[0];

            start = 0;
            final = 0;
        }
        void IUniversum.createOwnUniversum()
        {
            createBorders();
            for (int count = 0; start <= final; count++)
            {

                u[count] = start;
                start++;
            }
        }

        int[] IUniversum.getUniversum() => u;

        private void createBorders()
        {
            while (final <= start)
            {
                Console.WriteLine("Введине начальную границу значений:");
                if (int.TryParse(Console.ReadLine(), out start)) { }
                else
                {
                    Console.WriteLine("Введите начальную величину корректно!");
                    continue;
                }
                Console.WriteLine("Введине конечную границу занчений:");
                if (int.TryParse(Console.ReadLine(), out final) && final > start) { }
                else
                { Console.WriteLine("Введите конечную величину корректно!"); }
            }

            if (start >= 0)
            {
                Array.Resize(ref u, final - start + 1);
            }
            else if (start < 0)
            {
                Array.Resize(ref u, final + Math.Abs(start) + 1);
            }
            else
            {
                Array.Resize(ref u, Math.Abs(final + start) + 1);
            }
        }

    }
}