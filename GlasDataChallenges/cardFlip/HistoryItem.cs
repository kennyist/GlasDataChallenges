using System;

namespace GlasDataChallenge.CardFlipper
{
    /// <summary>
    /// Container for values needed for history tracking
    /// </summary>
    class HistoryItem
    {
        /// <summary>
        /// Instantiate history item with card state
        /// </summary>
        /// <param name="cardState"></param>
        public HistoryItem(string cardState)
        {
            state = cardState;
        }

        public string state = null;             // Current state of game cards
        public int removesTried = 0;            // Number of faceups removed in this state
        public int lastTryRealPos = -1;         // Position of last faceup removed
        public bool allResultsFail = false;     // Did all faceups result in a failure
    }
}
