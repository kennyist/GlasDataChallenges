using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GlasDataChallenge.CardFlipper
{
    /// <summary>
    /// Holds a list of all cards and methods to control and get information from this list
    /// </summary>
    class Cards
    {
        #region Variables

        // Cards in the current game
        public List<Card> cards;

        #endregion

        #region Constructor

        /// <summary>
        /// Instantiate new cards object
        /// </summary>
        public Cards()
        {
            cards = new List<Card>();
        }

        #endregion

        #region Getters

        /// <summary>
        /// Current count of cards in the game
        /// </summary>
        public int Count
        {
            get
            {
                return cards.Count;
            }
        }

        /// <summary>
        /// Return all card states as game text output
        /// </summary>
        public string CardValues
        {
            get
            {
                string output = "";

                // Loop through all cards and append their read state to the string
                foreach (Card card in cards)
                {
                    output += card.ReadState();
                }

                return output;
            }
        }

        /// <summary>
        /// Number of cards that are currently in faceup state
        /// </summary>
        public int FaceUpCount
        {
            get
            {
                int count = 0;

                // Loop through all the cards and add to count if it is face up
                foreach (Card card in cards)
                {
                    if (card.cardState == Card.State.FaceUp)
                        count++;
                }

                return count;
            }
        }

        /// <summary>
        /// Number of current cards that are removed
        /// </summary>
        public int RemovedCount
        {
            get
            {
                int count = 0;

                // Loop through all cards and add to count if card is removed
                foreach(Card card in cards)
                {
                    if(card.cardState == Card.State.Removed)
                    {
                        count++;
                    }
                }

                return count;
            }
        }

        #endregion

        #region public methods

        /// <summary>
        /// Use input string to setup all cards for the game
        /// </summary>
        /// <param name="input">Input string of ones, zeros and fullstops</param>
        public void SetupCards(string input)
        {
            // Clear current card list
            cards.Clear();

            Card prev = null;

            // Loop through the string and create a new card for each char
            foreach (char c in input)
            {
                // convert the char to an int and create a card
                Card card = new Card(Convert.ToInt32(c));
                cards.Add(card);

                // If previous card exists update that card and this card
                if(prev != null)
                {
                    // Set the previous cards next card value to this newly created card
                    prev.next = cards.Last();
                    // Set this cards previous card value to the previous card
                    card.previous = prev;
                }

                // set previous card to this current card
                prev = cards.Last();
            }
                
        }

        /// <summary>
        /// Remove card at position
        /// </summary>
        /// <param name="location">Position of card to remove</param>
        /// <returns>Bool: true if removed, false if not</returns>
        public bool RemoveCard(int location)
        {
            return cards[location].Remove();
        }

        /// <summary>
        /// Remove card at faceup count position
        /// </summary>
        /// <param name="count">Index of faceup to remove</param>
        /// <returns></returns>
        public int RemoveCardAtFaceup(int count)
        {
            // Count of faceup cards
            int pos = 0;

            // Loop through cards
            for(int i = 0; i < cards.Count; i++)
            {
                // If card is faceup
                if(cards[i].cardState == Card.State.FaceUp)
                {
                    // If current faceup card index equals input count, remove the card
                    if(pos == count)
                    {
                        cards[i].Remove();
                        // return the cards real position
                        return i;
                    }

                    // add to faceup pos count 
                    pos++;
                }
            }

            // No card found
            return -1;
        }

        /// <summary>
        /// Check of all cards in the game are removed
        /// </summary>
        /// <returns>bool: true if all removed, false if not</returns>
        public bool CheckAllRemoved()
        {
            // loop through all cards, if one is not removed return false
            foreach(Card card in cards)
            {
                if(card.cardState != Card.State.Removed)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Check for any island of zeros to indicate unwinnable game
        /// </summary>
        /// <returns>bool: true if game is unwinable, false if not</returns>
        public bool CheckForInaccessible()
        {
            // Regex string tester to find island of zeroes
            // group 1 (\\.[0]+$) - check for any fullstops with a string of zeros after leading to a line end
            // group 2 (\\.[0]+\\.) - check for any fullstops with a string of zeros after leading to another fullstop
            // group 3 (^0+\\.) - Check for a string of zeroes from line start leading to a fullstop
            Regex test = new Regex("(\\.[0]+$)|(\\.[0]+\\.)|(^0+\\.)");

            // If any groups match return true - game is unwinable
            if (test.IsMatch(CardValues))
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
