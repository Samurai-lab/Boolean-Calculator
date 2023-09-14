using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculationProgram.Interfaces;

namespace CalculationProgram.Classes
{
    public class Operations
    {
        Bunch[] bunches = new Bunch[3];
        Bunch[] bunchesResult;
        public Operations(Bunch[] bunches)
        {
            this.bunches = bunches;
            bunchesResult = new Bunch[bunches.Length + 1];
        }
        public int[] OperationSelector()
        {
            IMenu menuSelector = new MenuSelector();
            bool back = false;
            string answer;

            int[] finalBunch = new int[0];
            while (!back)
            {
                Console.Clear();
                menuSelector.CallOperationsMenu();
                answer = Console.ReadLine();
                Console.Clear();
                AddOperatingElement();
                finalBunch = new int[MaxLenghtBunches()];

                switch (answer)
                {
                    case "1":

                        int finalMassivElements = 0;
                        int[] mass = MinLenghtBunch();
                        switch (bunchesResult.Length - 1)
                        {
                            case 2:
                                for (int count = 0; count < mass.Length; count++)
                                {
                                    if (bunchesResult[0].getBunch().Contains(mass[count])
                                        && bunchesResult[1].getBunch().Contains(mass[count]))
                                    {
                                        finalBunch[finalMassivElements] = mass[count];
                                        finalMassivElements++;
                                    }
                                }
                                break;
                            case 3:
                                for (int count = 0; count < mass.Length; count++)
                                {
                                    if (bunchesResult[0].getBunch().Contains(mass[count])
                                        && bunchesResult[1].getBunch().Contains(mass[count])
                                        && bunchesResult[2].getBunch().Contains(mass[count]))
                                    {
                                        finalBunch[finalMassivElements] = mass[count];
                                        finalMassivElements++;
                                    }
                                }
                                break;
                            default:
                                Console.WriteLine("Не найдено итоговое значение");
                                break;
                        }
                        Array.Resize(ref finalBunch, finalMassivElements);
                        return finalBunch;


                    case "2":
                        int finalBunchCounter = 0;
                        for (int counter = 0; counter < bunchesResult.Length - 1; counter++)
                        {
                            int[] bunchMass = bunchesResult[counter].getBunch();
                            for (int element = 0; element < bunchMass.Length; element++)
                            {
                                if (!finalBunch.Contains(bunchMass[element]))
                                {
                                    finalBunch[finalBunchCounter] = bunchMass[element];
                                    finalBunchCounter++;
                                }
                            }
                        }
                        Array.Resize(ref finalBunch, finalBunchCounter);
                        return finalBunch;

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
            return finalBunch;

        }

        /*      private string AskAboutCombination()
             {
                 string first = "";
                 string second = "";
                 string thrith = "";
                 int numberBunches;
                 System.Console.WriteLine("С каким количеством множеств вы хотите провести операцию? (Доступно " +
                                             bunches.Length + " множество)");
                 if (int.TryParse(Console.ReadLine(), out numberBunches))
                 {
                     switch (numberBunches)
                     {
                         case 1:
                             first = "A";
                             break;
                         case 2:
                             if (bunches.Length == 3)
                             {
                                 System.Console.WriteLine("Введине название первого множества:");
                                 first = Console.ReadLine();
                                 System.Console.WriteLine("Введине название второго множества:");
                                 second = Console.ReadLine();
                             }
                             else
                             {
                                 first = "A";
                                 second = "B";
                             }
                             break;
                         case 3:
                             first = "A";
                             second = "B";
                             thrith = "C";
                             break;
                         default:
                             break;
                     }
                 }
                 else
                 {
                     System.Console.WriteLine("Введено недопустимое значение!");
                 }

                 return first + second + thrith;
             } */

        private void AddOperatingElement()
        {
            /* foreach (char element in text)
            {
                if (element == 'A')
                {
                    bunchesResult[0] = bunches[0];
                }
                else if (element == 'B')
                {
                    bunchesResult[1] = bunches[1];
                }
                else
                {
                    bunchesResult[2] = bunches[2];
                }
            } */

            int count = 0;
            foreach (Bunch bunch in bunches)
            {
                bunchesResult[count] = bunch;
                count++;
            }
        }

        private int MaxLenghtBunchElement()
        {
            int maxValue = 0;
            foreach (Bunch bunch in bunches)
            {
                if (maxValue < bunch.GetBunchLenght())
                {
                    maxValue = bunch.GetBunchLenght();
                }

            }
            return maxValue;
        }

        private int MinLenghtBunchElement()
        {
            int minValue = MaxLenghtBunchElement();
            foreach (Bunch bunch in bunches)
            {
                if (minValue > bunch.GetBunchLenght())
                {
                    minValue = bunch.GetBunchLenght();
                }

            }
            return minValue;
        }

        private int MaxLenghtBunches()
        {
            int maxValue = 0;
            foreach (Bunch bunch in bunches)
            {

                maxValue += bunch.GetBunchLenght();

            }
            return maxValue;
        }

        private int[] MinLenghtBunch()
        {
            int[] minLenghtBunch = new int[0];
            int minValue = MaxLenghtBunchElement();
            foreach (Bunch bunch in bunches)
            {
                if (minValue >= bunch.GetBunchLenght())
                {
                    minValue = bunch.GetBunchLenght();
                    minLenghtBunch = bunch.getBunch();
                }
            }
            return minLenghtBunch;
        }

    }
}