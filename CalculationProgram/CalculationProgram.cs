using System;
using CalculationProgram.Interfaces;

namespace CalculationProgram;
class CalculationProgram
{
    static void Main(string[] args)
    {
        IMenu controlMenu = new ControlMenu();

        controlMenu.callMenu();

    }
}