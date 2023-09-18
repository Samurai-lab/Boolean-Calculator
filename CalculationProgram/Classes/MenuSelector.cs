using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculationProgram.Interfaces;

namespace CalculationProgram
{
    public class MenuSelector : IMenu
    {
        public void CallMainMenu()
        {
            Console.WriteLine(
                  "Выберите вариант действия:\n"
                + "1. Задать универсум\n"
                + "2. Создание множеств(а)\n"
                + "3. Вывести универсум\n"
                + "4. Вывести множества\n"
                + "5. Операции над множествами\n"
                + "6. Ввод выражений\n"
                + "7. Выход\n"
            );

        }

        public void CallOperationsMenu()
        {
            Console.WriteLine(
                  "Выберите вариант действия:\n"
                + "1. Пересечение\n"
                + "2. Обьединение\n"
                + "3. Разность\n"
                + "4. Геометрическая разность\n"
                + "5. Выход\n"
            );
        }

        public void CallOperationsTypeMenu()
        {
            Console.WriteLine(
                  "Выберите вариант действия:\n"
                + "1. Ручной ввод\n"
                + "2. Ввод при помощи рандомайзера\n"
                + "3. Ввод условиями\n"
                + "4. Выход\n"
            );
        }

        public void CallExpressionMenu()
        {
            Console.WriteLine(
              "Выберите вариант действия:\n"
            + "1. Ввод выражений и множеств\n"
            + "2. Вывод множеств\n"
            + "3. Выход\n"
        );
        }
    }
}