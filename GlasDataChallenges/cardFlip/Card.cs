using System;


namespace GlasDataChallenge.CardFlipper
{
    /// <summary>
    /// Card Container
    /// </summary>
    class Card
    {
        #region Variables (and enum)
        /// <summary>
        /// Card states for the game
        /// </summary>
        public enum State
        {
            FaceDown,
            FaceUp,
            Removed
        }

        public State cardState;         // Current state of ths card
        public Card previous = null;    // Previous card in the list
        public Card next = null;        // Next card in the list

        #endregion

        #region constructor

        /// <summary>
        /// Instantiate new card with value
        /// </summary>
        /// <param name="value">Card char value, 46 '.', 48 '0', 49 '1'</param>
        public Card(int value)
        {
            switch (value)
            {
                case 46: // Cahr value for .
                    cardState = State.Removed;
                    break;
                case 48: // Char value for 0
                    cardState = State.FaceDown;
                    break;
                case 49: // Char value for 1
                    cardState = State.FaceUp;
                    break;
            }

        }

        #endregion

        #region public methods

        /// <summary>
        /// Remove this card and flip previous and next cards
        /// </summary>
        /// <returns>bool: True if removed, False if this card is not faceup</returns>
        public bool Remove()
        {
            // If this card isnt face up, fail
            if (cardState != State.FaceUp)
                return false;

            // Set card to removed
            cardState = State.Removed;

            // Flip the previous and next cards
            if (previous != null)
                previous.Flip();
            if (next != null)
                next.Flip();

            return true;
        }

        /// <summary>
        /// Flip the card from facedown to faceup or faceup to facedown, removed will not change
        /// </summary>
        public void Flip()
        {
            // Check the current state of the card
            switch (cardState)
            {
                // If removed do nothing
                case State.Removed:
                    return;

                case State.FaceDown:
                    cardState = State.FaceUp;
                    break;

                case State.FaceUp:
                    cardState = State.FaceDown;
                    break;
            }
        }

        /// <summary>
        /// COnvert the state of the card to readable version for the game
        /// </summary>
        /// <returns>String interpritation of the card state</returns>
        public string ReadState()
        {
            switch (cardState)
            {
                case State.FaceDown:
                    return "0";

                case State.FaceUp:
                    return "1";

                case State.Removed:
                default:
                    return ".";
            }
        }

        #endregion
    }
}
