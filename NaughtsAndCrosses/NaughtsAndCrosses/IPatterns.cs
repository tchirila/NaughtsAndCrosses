using System.Collections.Generic;

namespace NaughtsAndCrosses
{
    interface IPatterns
    {
        /// <summary>
        /// Determines wheter any player has won, there is a draw or the 
        /// rules are not met by the input
        /// </summary>
        /// <returns>The state of the game</returns>
        BoardState CalculateResult();
    }
}
