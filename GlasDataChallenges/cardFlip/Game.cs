using System;
using System.Linq;

namespace GlasDataChallenge.CardFlipper
{
    /// <summary>
    /// This class is to test the game functions properly before the automtic solving was attempted.
    /// </summary>
    class Game
    {
        // Games current card state
        Cards cards = new Cards();

        /// <summary>
        /// Start the games functions
        /// </summary>
        public void Start()
        {
            // Is game still running
            bool game = true;
            // Moves the player as taken so far
            int moves = 0;

            Console.Clear();
            Console.WriteLine("Card Flipping Game\n\n");

            // Setup the games cards based on user input
            cards.SetupCards(Common.ReadLine(cards));

            Console.Clear();

            // While game is running
            while (game)
            {
                // Ask user to remove card
                RemoveCard();

                // increase player moves
                moves++;

                // If all cards removed 
                if (cards.CheckAllRemoved())
                {
                    // Game has won, show win text
                    game = false;
                    Win(moves);
                }

                // If game win impossible
                if (cards.CheckForInaccessible())
                {
                    // show loose text
                    game = false;
                    Loose();
                }

            }

            // restart the game
            Start();
        }

        /// <summary>
        /// Display win text
        /// </summary>
        /// <param name="count">Player move count</param>
        void Win(int count)
        {
            Console.WriteLine("All cards removed! in {0} moves", count);
            Console.WriteLine("Press any key to restart the game");
            Console.ReadKey();
        }

        /// <summary>
        /// Show loose text
        /// </summary>
        void Loose()
        {
            Console.WriteLine("Game over, impossible to win\n cards: {0}", cards.CardValues);
            Console.WriteLine("Press any key to restart the game");
            Console.ReadKey();
        }

        /// <summary>
        /// Ask for user input to remove card from the game
        /// </summary>
        void RemoveCard()
        {
            // Waiting for correct input?
            bool waitingForInput = true;
            string position;

            Console.WriteLine("Enter position of a faceup card (1) you want to remove\n\nCards: {0}\n\n", cards.CardValues);

            // While no correct input
            while (waitingForInput)
            {
               // Read user input 
                position = Console.ReadLine();

                // if input is a number
                if (position.All(char.IsDigit))
                {
                    // Convert to int
                    int posInt = Convert.ToInt32(position);

                    // if position is greater than card count
                    if(posInt >= cards.Count)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input, position greater than the number of cards, please try again:\n\nCards: {0}\n\n", cards.CardValues);
                    }
                    else
                    {
                        // Try and remove card, if false report invalid selection
                        if (!cards.RemoveCard(posInt))
                        {
                            Console.Clear();
                            Console.WriteLine("Card was not removed, Card was facedown or already removed, please try again:\n\nCards: {0}\n\n", cards.CardValues);
                        }
                        else
                        {
                            // else clear console and end loop
                            Console.Clear();
                            waitingForInput = false;
                        }
                    }
                }
                else
                {
                    // report invalid input and repeat loop
                    Console.Clear();
                    Console.WriteLine("Invalid input, Input was not a number, please try again:\n\nCards: {0}\n\n", cards.CardValues);
                }
                
            }
        }
    }
}
