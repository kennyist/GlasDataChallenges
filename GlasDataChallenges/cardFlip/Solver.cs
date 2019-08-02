using System;
using System.Collections.Generic;
using System.Linq;

namespace GlasDataChallenge.CardFlipper
{
    /// <summary>
    /// Card flipping game solution finder
    /// </summary>
    class Solver
    {
        #region Variables

        // hisotry of solver moves
        History history;
        // Games card state
        Cards cards;

        #endregion

        #region contructors

        /// <summary>
        /// Instantiate new Solver object
        /// </summary>
        public Solver()
        {
            history = new History();
            cards = new Cards();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Run the solving process
        /// </summary>
        void Solve()
        {
            bool solve = true;
            int fails = 0;

            history.Clear();

            // Create first history item for this solution finder
            HistoryItem hItem = new HistoryItem(cards.CardValues);
            history.AddHistory(hItem);

            // Loop through until solved
            while (solve)
            {
                // Print stats to show this is doing something on larger strings
                PrintStats(fails);

                // Check for win
                if (CheckWon())
                {
                    // If won end loop condition
                    solve = false;
                    // print won text
                    PrintWon();

                    Console.WriteLine("Press any key to print solition steps");
                    Console.ReadKey();
                    // Print solution walkthrough
                    PrintSolution();

                    // Leave void
                    return;
                }

                // Check for fail states
                if (cards.CheckForInaccessible() || !FaceUpsAbaliable(hItem.removesTried))
                {
                    // if failed increase counter
                    fails++;
                    // Set history item to failed
                    hItem.allResultsFail = true;
                    // Attempt to get last non fail
                    hItem = history.GetLastNonFailed();

                    // If its null no solution can be found
                    if (hItem == null)
                    {
                        Console.WriteLine("\nNo solution found");
                        Console.WriteLine("Press any key to restart the program");
                        Console.ReadKey();
                        Console.Clear();

                        // leave void
                        return;
                    }

                    // reset cards to hisotry state
                    cards.SetupCards(hItem.state);
                    // restart loop
                    continue;
                }

                // if not continue as normal
                NextFaceUp(hItem);
                hItem.removesTried++;

                // create new history for new card state
                hItem = new HistoryItem(cards.CardValues);
                history.AddHistory(hItem);
            }
        }

        /// <summary>
        /// Check if win condition
        /// </summary>
        /// <returns>bool: true if won, false if not</returns>
        bool CheckWon()
        {
            // If all cards removed return true
            if (cards.Count == cards.RemovedCount)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Print win text with solution numbers
        /// </summary>
        void PrintWon()
        {
            List<HistoryItem> solution = history.GetSolutionHistory();
            solution.Remove(solution.Last()); // Remove last as its for win state

            Console.Write("\n\nSolution found:");

            // Loop through and print solution positions
            foreach (HistoryItem h in solution)
            {
                Console.Write(" {0}", h.lastTryRealPos);
            }

            Console.Write("\n");
        }

        /// <summary>
        /// Print walkthrough of solution
        /// </summary>
        void PrintSolution()
        {
            List<HistoryItem> solution = history.GetSolutionHistory();
            solution.Remove(solution.Last()); // Remove last as its for win state

            Console.Clear();
            Console.WriteLine("Press any key to progress the solution");

            // Loop through and print solution text
            foreach (HistoryItem h in solution)
            {
                Console.WriteLine("State: {0}", h.state);
                Console.WriteLine("Position: {0}", h.lastTryRealPos);

                Console.ReadKey();
            }

            Console.WriteLine("Solution finished, press any key to restart");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Print solution finding stats
        /// </summary>
        /// <param name="fails">Current number of history reatempts</param>
        void PrintStats(int fails)
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.WriteLine("Searching for solution, please wait. There have been {0} history fall backs due to dead ends.", fails);
        }

        /// <summary>
        /// Are faceup cards abaliable on history state?
        /// </summary>
        /// <param name="historyCount">How many faceups used in history state</param>
        /// <returns>bool: true if faceup avaliable, false if not</returns>
        bool FaceUpsAbaliable(int historyCount)
        {
            if (historyCount >= cards.FaceUpCount)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Remove next face up card
        /// </summary>
        /// <param name="item">Current history state item</param>
        void NextFaceUp(HistoryItem item)
        {
            item.lastTryRealPos = cards.RemoveCardAtFaceup(item.removesTried);
        }

        #endregion

        #region public methods

        /// <summary>
        /// Start by requesting input string
        /// </summary>
        public void Start()
        {
            cards.SetupCards(Common.ReadLine(cards));

            Console.Clear();

            Console.WriteLine("Your cards: {0}\n", cards.CardValues);

            Console.WriteLine("Press any key to find a solution");

            Console.ReadKey();

            Solve();

            Start();
        }

        #endregion
    }
}
