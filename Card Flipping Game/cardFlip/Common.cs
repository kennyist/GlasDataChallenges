using System;
using System.Text.RegularExpressions;

namespace GlasDataChallenge.CardFlipper
{
    /// <summary>
    /// Common methods through out CardFlipper
    /// </summary>
    class Common
    {
        /// <summary>
        /// Get the input string for card setup
        /// </summary>
        /// <returns>valid input string</returns>
        public static string ReadLine(Cards cards)
        {
            bool readLine = true;
            string input = null;

            Console.WriteLine("Card Flipping Game Solver\n\nPlease Enter a series of ones and zeros:\n");

            while (readLine)
            {
                input = Console.ReadLine();

                if (validateString(input))
                {
                    readLine = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid string, please use only zeros and ones:\n");
                }
            }

            return input;
        }

        /// <summary>
        /// Validate input string only contains ones and zeros
        /// </summary>
        /// <param name="input">User input string</param>
        /// <returns>Bool: true if contains only ones and zereos, false if not</returns>
        public static bool validateString(string input)
        {
            // New regex to check if string contains only ones and zeros
            // ^ - specify line start 
            // [01] match only ones and zeros 
            // + allow repition
            // $ - specify line end
            Regex regex = new Regex("^[01]+$");

            return regex.IsMatch(input);
        }
    }
}
