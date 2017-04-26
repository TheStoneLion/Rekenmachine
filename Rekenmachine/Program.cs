using System;

namespace Rekenmachine
{
    class Program
    {
        static void Main()
        {
            ConsoleKeyInfo cki;
            Console.Title = "Mijn Rekenmachine";

            while (cki.Key != ConsoleKey.S)
            {
                double eersteWaarde;
                double tweedeWaarde;
                int myScreenPosition = 0;
                Console.Clear();
                do
                {
                    Console.SetCursorPosition(1, myScreenPosition);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Geef het eerste cijfer voor de berekening:");
                    ClearData();
                    Console.SetCursorPosition(1, myScreenPosition + 1);
                }
                while (!Double.TryParse(Console.ReadLine(), out eersteWaarde));
                do
                {
                    Console.SetCursorPosition(1, myScreenPosition + 4);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Geef het tweede cijfer voor de berekening:");
                    ClearData();
                    Console.SetCursorPosition(1, myScreenPosition + 5);
                }
                while (!Double.TryParse(Console.ReadLine(), out tweedeWaarde));
                Console.SetCursorPosition(1, myScreenPosition + 8);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Geef het soort berekening aan (+, -, x of :)");
                bool geldigeWaarde = false;
                char myOperator = ' ';
                do
                {
                    ClearData();
                    Console.SetCursorPosition(1, myScreenPosition + 9);
                    cki = Console.ReadKey();
                    switch (cki.Key)
                    {
                        case ConsoleKey.Add:
                        case ConsoleKey.OemPlus:
                            myOperator = '+';
                            geldigeWaarde = true;
                            break;

                        case ConsoleKey.Subtract:
                        case ConsoleKey.OemMinus:
                            myOperator = '-';
                            geldigeWaarde = true;
                            break;

                        case ConsoleKey.Divide:
                        case ConsoleKey.Oem1:
                        case ConsoleKey.Oem2:
                            if (tweedeWaarde != 0)
                            {
                                myOperator = ':';
                            }
                            geldigeWaarde = true;
                            break;

                        case ConsoleKey.Multiply:
                        case ConsoleKey.X:
                        case ConsoleKey.D8:
                            myOperator = 'x';
                            geldigeWaarde = true;
                            break;

                        default:
                            break;
                    }

                } while (!geldigeWaarde);
                Console.SetCursorPosition(1, myScreenPosition + 11);
                if (myOperator == ' ')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Je kunt niet door nul delen");
                }
                else
                {
                    double result = myCalculator(myOperator, eersteWaarde, tweedeWaarde);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("{0} {1} {2} = {3}", eersteWaarde, myOperator, tweedeWaarde, result);
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(1, myScreenPosition + 13);
                Console.WriteLine("Press any key to continue. Press S to stop");
                cki = Console.ReadKey();
            }
        }

        private static void ClearData()
        {
            Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
            Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
            Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
        }

        private static double myCalculator(char myOperator, double eersteWaarde, double tweedeWaarde)
        {
            double result = 0;
            switch (myOperator)
            {
                case '+':
                    result = eersteWaarde + tweedeWaarde;
                    break;

                case '-':
                    result = eersteWaarde - tweedeWaarde;
                    break;

                case ':':
                    result = eersteWaarde / tweedeWaarde;
                    break;

                case 'x':
                    result = eersteWaarde * tweedeWaarde;
                    break;

                default:
                    break;
            }
            return result;
        }
    }
}