using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculationProgram.Interfaces;

namespace CalculationProgram
{
    public class ControlMenu : IMenu
    {
        void IMenu.callMenu()
        {
            Console.WriteLine(
                "Выберите вариант действия:\n" +
                "1. Задать универсум\n" +
                "2. Создание множеств(а)\n" +
                "3. Операции над множествами\n"
            );
        }
    }
}