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

        Bunch a = new Bunch(universum);

        a.addElements();

        for (int count = 0; count < a.getBunch().Length; count++)
        {
            Console.WriteLine(a.getBunch()[count]);
        }

    }
}