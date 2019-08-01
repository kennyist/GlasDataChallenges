using System;

namespace GlasDataChallenge.NumberAdder
{
    /// <summary>
    /// Numreical values only method of increasing each digit
    /// </summary>
    class OnlyNumeric
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
            int output = increaseDigitsByOne(input);

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
        /// <remarks>This admittedly did take a long time to come to a working solution with a number of attempts made, some using much harder ideas and longer logic then this end result.</remarks>
        int increaseDigitsByOne(int number)
        {

            // While i is less than the number
            // Increase i to the power of 10
            // This goes over each digit of N
            for (int i = 1; i < number; i *= 10)
            {
                // Get the nth digit of N (from i)
                // N mod (i * 10) to remove all digits before nth number (Remainder of how many (i * 10) goes into N)
                // Devide by i to get first number from remainder as int
                var digit = number % (i * 10) / i;

                // If digit is a 9
                if (digit == 9)
                {
                    // Get the number before this 9
                    // remainder for current power of 10 from number
                    int lowerValue = number % i;

                    // If 1595 is entered
                    // it becomes 1596 first then triggers 9 digit condition:
                    // a = i * 9            :: = 90
                    // b = 1596 - 6 - a     :: = 1500
                    // b *= 10              :: = 15000
                    // b = i * 10 = 100     :: = 15100
                    // b += 6               :: = 15106

                    // Round 9 down and leading digits to 0
                    // Get 9s zeros in number with power of i
                    int ninePower = i * digit;
                    // Rmeove lower value and nine power to round down 
                    int rounded = number - lowerValue - ninePower;

                    // increase rounded by the power of 10 for exta zero (for new 1 digit placement)
                    rounded *= 10;
                    // Add in the one in the correct place using i * 10
                    rounded += i * 10;
                    // Add lower value back onto the number
                    rounded += lowerValue;

                    //Console.WriteLine("lwoerval: {0}, a: {1}, b: {2}", lowerValue, a, b);

                    number = rounded;
                    // increase i by power of 10 for new digit to skip
                    i *= 10;
                }
                // If mod is not a 9, add i
                // This increase the digit by one in the correct place by using i power of 10
                else
                {
                    number += i;
                }

                // Dispaly number as it changes
                Console.WriteLine(number);

            }

            // return final number
            return number;
        }

        /// <summary>
        /// begin the numeric only adding
        /// </summary>
        /// <param name="number">Base number</param>
        /// <returns>Number after addition changes</returns>
        /// <remarks>This function was an original attempt, which formed a basis for new attempts with remainder digit extracting</remarks>
        int StartAdder(int number)
        {
            // Digit position counter
            int digits = 0;
            // copy of original number
            int numCopy = number;

            // While copied number is greater than zero
            while (numCopy > 0)
            {
                // Get the smallest digit in the number (last number)
                int digit = (numCopy % 10);
                // Remove this digit from the number
                numCopy = numCopy / 10;
                // Calculate adding one plus the power of digits for palcement of this number
                int toAdd = (int) Math.Pow(10, digits);

                // What to do if number is 9?
                if (digit >= 9)
                {
                    // Increase digit placement because of extra number added
                    digits++;
                }

                // store old number for readout
                int oldNum = number;
                // Add changes to original number
                number += toAdd;
                // Print info readout
                Console.WriteLine("digit count: {0}, digit: {1}, toAdd: {2} number: {3}, new number: {4}", digits, digit, toAdd, oldNum, number);
                // Increase digit placement
                digits++;
            }

            return number;
        }        
    }
}
