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
#pragma warning disable CS8600
                answer = Console.ReadLine();
#pragma warning restore CS8600
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
                        int fBunchCount = 0;
                        int[] fBunchMass = bunchesResult[0].getBunch();
                        int[] sBunchMass = bunchesResult[1].getBunch();
                        switch (bunchesResult.Length - 1)
                        {
                            case 2:
                                for (int element = 0; element < fBunchMass.Length; element++)
                                {
                                    if (!sBunchMass.Contains(fBunchMass[element]))
                                    {
                                        finalBunch[fBunchCount] = fBunchMass[element];
                                        fBunchCount++;
                                    }
                                }
                                break;
                            case 3:
                                int[] thrithBunchMass = bunchesResult[2].getBunch();
                                for (int element = 0; element < fBunchMass.Length; element++)
                                {
                                    if (!sBunchMass.Contains(fBunchMass[element])
                                        && !thrithBunchMass.Contains(fBunchMass[element]))
                                    {
                                        finalBunch[fBunchCount] = fBunchMass[element];
                                        fBunchCount++;
                                    }
                                }
                                break;
                            default:
                                Console.WriteLine("Не найдено итоговое значение");
                                break;
                        }
                        Array.Resize(ref finalBunch, fBunchCount);
                        return finalBunch;

                    case "4":
                        int finalBunchCounters = 0;
                        int[] firstBunchMass = bunchesResult[0].getBunch();
                        int[] secondBunchMass = bunchesResult[1].getBunch();
                        switch (bunchesResult.Length - 1)
                        {
                            case 2:
                                for (int element = 0; element < firstBunchMass.Length; element++)
                                {
                                    if (!secondBunchMass.Contains(firstBunchMass[element]))
                                    {
                                        finalBunch[finalBunchCounters] = firstBunchMass[element];
                                        finalBunchCounters++;
                                    }
                                }

                                for (int element = 0; element < secondBunchMass.Length; element++)
                                {
                                    if (!firstBunchMass.Contains(secondBunchMass[element]))
                                    {
                                        finalBunch[finalBunchCounters] = secondBunchMass[element];
                                        finalBunchCounters++;
                                    }
                                }
                                break;
                            case 3:
                                int[] thrithBunchMass = bunchesResult[2].getBunch();
                                for (int element = 0; element < firstBunchMass.Length; element++)
                                {
                                    if (!secondBunchMass.Contains(firstBunchMass[element])
                                        && !thrithBunchMass.Contains(firstBunchMass[element]))
                                    {
                                        finalBunch[finalBunchCounters] = firstBunchMass[element];
                                        finalBunchCounters++;
                                    }
                                }

                                for (int element = 0; element < secondBunchMass.Length; element++)
                                {
                                    if (!firstBunchMass.Contains(secondBunchMass[element])
                                        && !thrithBunchMass.Contains(secondBunchMass[element]))
                                    {
                                        finalBunch[finalBunchCounters] = secondBunchMass[element];
                                        finalBunchCounters++;
                                    }
                                }

                                for (int element = 0; element < thrithBunchMass.Length; element++)
                                {
                                    if (!firstBunchMass.Contains(thrithBunchMass[element])
                                        && !secondBunchMass.Contains(thrithBunchMass[element]))
                                    {
                                        finalBunch[finalBunchCounters] = thrithBunchMass[element];
                                        finalBunchCounters++;
                                    }
                                }
                                break;
                            default:
                                Console.WriteLine("Не найдено итоговое значение");
                                break;
                        }
                        Array.Resize(ref finalBunch, finalBunchCounters);
                        return finalBunch;


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

        private void AddOperatingElement()
        {
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