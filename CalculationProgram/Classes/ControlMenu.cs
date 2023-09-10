using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculationProgram.Interfaces;

namespace CalculationProgram
{
    public class ControlMenu : IMenu
    {
        void IMenu.CallMenu()
        {
            
            Console.WriteLine(
                  "Выберите вариант действия:\n"
                + "1. Задать универсум\n"
                + "2. Создание множеств(а)\n"
                + "3. Вывести универсум\n"
                + "4. Вывести множества\n"
                + "5. Операции над множествами\n"
                + "6. Выход\n"
            );

            
        }
    }
}