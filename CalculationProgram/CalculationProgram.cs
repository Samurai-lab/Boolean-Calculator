using System;
using CalculationProgram.Interfaces;

namespace CalculationProgram;
class CalculationProgram
{
    static void Main(string[] args)
    {
        IMenu controlMenu = new ControlMenu();
        IUniversum universum = new Universum();

        controlMenu.callMenu();
        universum.createOwnUniversum();

        for (int count = 0; count < universum.getUniversum().Length; count++)
        {
            Console.WriteLine(universum.getUniversum()[count]);
        }

    }
}