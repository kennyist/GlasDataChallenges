using System;
using System.Collections.Generic;

namespace GlasDataChallenge.CardFlipper
{
    /// <summary>
    /// History of card flip solver moves
    /// </summary>
    class History
    {
        #region Variables

        // History of the moves
        List<HistoryItem> history;

        #endregion

        #region Contructors

        /// <summary>
        /// Instantiat new history object
        /// </summary>
        public History()
        {
            history = new List<HistoryItem>();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Check if state already exists in the history
        /// </summary>
        /// <param name="item">HistroyItem to check</param>
        void DoesStateAlreadyExist(HistoryItem item)
        {
            // Loop through all history and check for same state
            foreach (HistoryItem i in history)
            {
                if (i.state == item.state)
                {
                    // if state found, use found states allResultsFail value
                    item.allResultsFail = i.allResultsFail;
                }
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Add an item to the history
        /// </summary>
        /// <param name="item">Add a HistoryItem object to the history list</param>
        public void AddHistory(HistoryItem item)
        {
            // Does this game state already exist in the history?
            DoesStateAlreadyExist(item);
            // Add item to the list
            history.Add(item);
        }

        /// <summary>
        /// Clear the game history
        /// </summary>
        public void Clear()
        {
            history.Clear();
        }

        /// <summary>
        /// Get the moves from history that resulted in a win
        /// </summary>
        /// <returns>List of historyItem objects that resulted in a win in order</returns>
        public List<HistoryItem> GetSolutionHistory()
        {
            List<HistoryItem> solution = new List<HistoryItem>();

            // loop through history and all all states that didnt fail to the list
            foreach (HistoryItem h in history)
            {
                if (!h.allResultsFail)
                    solution.Add(h);
            }

            return solution;
        }

        /// <summary>
        /// Get the last non failed result from history list
        /// </summary>
        /// <returns>last added HistroyItem object with a failure</returns>
        public HistoryItem GetLastNonFailed()
        {
            // Loop backwards though history, if didnt fail return it
            for (int i = history.Count - 1; i >= 0; i--)
            {
                if (!history[i].allResultsFail)
                    return history[i];
            }
            return null;
        }

        #endregion
    }
}
