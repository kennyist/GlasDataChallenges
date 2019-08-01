using System;

namespace GlasDataChallenge.NumberAdder
{
    /// <summary>
    /// Easy mode using string based method
    /// </summary>
    class Easy
    {
        /// <summary>
        /// Start the number adder functionality.
        /// </summary>
        public void Start()
        {
            // Ask user for input
            int input = Common.getValidInput();

            // Clear and show user input
            Console.Clear();
            Console.WriteLine("entered digit: {0}\nPress any key to get the new number\n\n", input);
            Console.ReadKey();

            // get the new number
            int output = StartAdder(input);

            // display output and restart text 
            Console.WriteLine("\n\n{0} Has become {1}\n\nPress any key to restart this program", input, output);
            Console.ReadKey();

            // Restart the program
            Start();
        }

        /// <summary>
        /// Increase the value of each digit in the number by 1, with nines becoming tens
        /// </summary>
        /// <param name="number">Input number</param>
        /// <returns>Number with each digit increased</returns>
        int StartAdder(int number)
        {
            // String output
            string output = "";

            // While number is greater than zero
            while (number > 0)
            {
                // Get the lowest
                // Increase it by one and prefix it to the output (as the nubmer is read backwards in string terms)
                output = ((number % 10) + 1) + output;
                // Remvoe the lowest digit
                number = number / 10;
            }

            // convert it back to a number
            return Convert.ToInt32(output);
        }
    }
}
