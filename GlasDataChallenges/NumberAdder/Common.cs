using System;
using System.Linq;

namespace GlasDataChallenge.NumberAdder
{
    /// <summary>
    /// Common methods through out Number adder
    /// </summary>
    class Common
    {
        /// <summary>
        /// Get valid user input of a number
        /// </summary>
        /// <returns>Valid Int frm user input</returns>
        public static int getValidInput()
        {
            bool found = false;

            Console.WriteLine("Please enter valid digit:\n\n");

            // While no valid input found loop
            while (!found)
            {
                // Read user input
                string input = Console.ReadLine();

                // if input is empty
                if(input == "")
                {
                    // else print error and restart
                    Console.Clear();
                    Console.WriteLine("Input was not a valid number please try again:\n\n");
                    continue;
                }

                // If input is a number
                if (input.All(char.IsDigit))
                {
                    // convert it and return it
                    return Convert.ToInt32(input);
                }
                else
                {
                    // else print error and restart
                    Console.Clear();
                    Console.WriteLine("Input was not a valid number please try again:\n\n");
                }
            }

            return -1;
        }
    }
}
