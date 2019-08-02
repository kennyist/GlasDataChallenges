using System;

namespace GlasDataChallenge
{
    /// <summary>
    /// Start for GlasData Challenge prorgams
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Wait for correct user input
            bool waitForInput = true;
            // Dsipaly options text
            Console.WriteLine("Please choose program function: \nPress 1 for card flipper solution solver \nPress 2 for card flipper game mode\nPress 3 for Number Adder easy\nPress 4 for Number adder numeric only\n\n");

            while (waitForInput)
            {
                // read the console key
                ConsoleKeyInfo input = Console.ReadKey();

                // Start program depending on options or return error and restart
                switch (input.KeyChar)
                {
                    // case 1 start card flip solver
                    case '1':
                        waitForInput = false;
                        StartSolver();
                        break;
                    
                    // case 2 start card flip game
                    case '2':
                        waitForInput = false;
                        StartGame();
                        break;

                    // case 3 string based number adder
                    case '3':
                        waitForInput = false;
                        StartNumberAdderEasy();
                        break;

                    // case 4 numeric based number adder
                    case '4':
                        waitForInput = false;
                        StartNumberAdderNumeric();
                        break;
                    
                    // Any other key, show error and get another key press
                    default:
                        Console.WriteLine("Invalid options, Please press either 1, 2, 3 or 4");
                        continue;
                }
            }
        }

        #region startPrograms 
        // All cases clear console and start program

        static void StartGame()
        {
            Console.Clear();
            CardFlipper.Game game = new CardFlipper.Game();
            game.Start();
        }

        static void StartSolver()
        {
            Console.Clear();
            CardFlipper.Solver solver = new CardFlipper.Solver();
            solver.Start();
        }

        static void StartNumberAdderEasy()
        {
            Console.Clear();
            NumberAdder.Easy numberAdder = new NumberAdder.Easy();
            numberAdder.Start();
        }

        static void StartNumberAdderNumeric()
        {
            Console.Clear();
            NumberAdder.OnlyNumeric numberAdder = new NumberAdder.OnlyNumeric();
            numberAdder.Start();
        }
        #endregion
    }
}
