using System;

namespace Rekenmachine
{
    class Program
    {
        static void Main()
        {
            ConsoleKeyInfo cki;
            Console.Title = "Mijn Rekenmachine";

            do
            {
                #region Initialisatie
                double firstValue;
                double secondValue;
                Console.Clear();
                #endregion

                #region bepaal eerste waarde
                int myScreenPosition = 0;
                firstValue = GetNumericValues(myScreenPosition, "eerste", ConsoleColor.Gray);
                #endregion

                #region bepaal tweede waarde
                myScreenPosition = myScreenPosition + 4;
                secondValue = GetNumericValues(myScreenPosition, "tweede", ConsoleColor.Yellow);
                #endregion

                #region bepaal soort berekening
                myScreenPosition = myScreenPosition + 4;
                Console.SetCursorPosition(1, myScreenPosition);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Geef het soort berekening aan (+, -, x of :)");
                bool validValue = false;
                char myOperator = ' ';
                do
                {
                    ClearData();
                    Console.SetCursorPosition(1, myScreenPosition + 1);
                    cki = Console.ReadKey();
                    switch (cki.Key)
                    {
                        case ConsoleKey.Add:
                        case ConsoleKey.OemPlus:
                            myOperator = '+';
                            validValue = true;
                            break;

                        case ConsoleKey.Subtract:
                        case ConsoleKey.OemMinus:
                            myOperator = '-';
                            validValue = true;
                            break;

                        case ConsoleKey.Divide:
                        case ConsoleKey.Oem1:
                        case ConsoleKey.Oem2:
                            if (secondValue != 0)
                            {
                                myOperator = ':';
                            }
                            validValue = true;
                            break;

                        case ConsoleKey.Multiply:
                        case ConsoleKey.X:
                        case ConsoleKey.D8:
                            myOperator = 'x';
                            validValue = true;
                            break;

                        default:
                            break;
                    }

                } while (!validValue);
                #endregion

                #region Toon resultaat
                Console.SetCursorPosition(1, myScreenPosition + 3);
                if (myOperator == ' ')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Je kunt niet door nul delen");
                }
                else
                {
                    double result = myCalculate(myOperator, firstValue, secondValue);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("{0} {1} {2} = {3}", firstValue, myOperator, secondValue, result);
                }
                #endregion

                #region Afsluiting
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(1, myScreenPosition + 5);
                Console.WriteLine("Press any key to continue. Press S to stop");
                cki = Console.ReadKey();
                #endregion
            } while (cki.Key != ConsoleKey.S);
        }

        private static double GetNumericValues(int myScreenPosition, string mySequenceId, ConsoleColor myConsoleForegroundColor)
        {
            double inputValue;
            do
            {
                Console.SetCursorPosition(1, myScreenPosition);
                Console.ForegroundColor = myConsoleForegroundColor;
                Console.WriteLine("Geef het {0} getal voor de berekening:", mySequenceId);
                ClearData();
                Console.SetCursorPosition(1, myScreenPosition + 1);
            }
            while (!Double.TryParse(Console.ReadLine(), out inputValue));
            return inputValue;
        }

        private static void ClearData()
        {
            Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
            Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
            Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
        }

        private static double myCalculate(char myOperator, double firstValue, double secondValue)
        {
            double result = 0;
            switch (myOperator)
            {
                case '+':
                    result = firstValue + secondValue;
                    break;

                case '-':
                    result = firstValue - secondValue;
                    break;

                case ':':
                    result = firstValue / secondValue;
                    break;

                case 'x':
                    result = firstValue * secondValue;
                    break;

                default:
                    break;
            }
            return result;
        }
    }
}