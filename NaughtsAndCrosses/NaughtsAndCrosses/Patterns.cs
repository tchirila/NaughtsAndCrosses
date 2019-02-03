using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NaughtsAndCrosses
{
    class Patterns : IPatterns
    {
        string board;
        int countX;
        int countO;

        List<string> winnablePatterns;

        public Patterns(string board)
        {
            this.board = board;
        }

        private bool IsCharAndDistributionIllegal()
        {
            return Regex.IsMatch(board, "[^XO_]") || HasIncorrectDistributionOfChars();
        }

        private bool HasIncorrectDistributionOfChars()
        {
            countX = 0;
            countO = 0;

            foreach (var character in board)
            {
                if (character == 'X')
                {
                    countX++;
                }
                else if (character == 'O')
                {
                    countO++;
                }
            }

            return countX + countO < 5 || countX - countO > 1 || countX - countO < 0;
        }

        public BoardState CalculateResult()
        {
            int xWins = 0;
            int oWins = 0;

            if (board.Length != 9 || IsCharAndDistributionIllegal()) return BoardState.INVALID_INPUT;
            else SetWinnablePatterns();

            foreach (var pattern in winnablePatterns)
            {
                if (pattern == "XXX") xWins++;
                if (pattern == "OOO") oWins++;
            }

            if (xWins == 0 && oWins == 0) return BoardState.DRAW;
            else if (xWins >= 1 && oWins == 0 && countO < countX) return BoardState.CROSSES_WIN;               
            else if (oWins >= 1 && xWins == 0 && countX == countO) return BoardState.NOUGHTS_WIN;
            else return BoardState.INVALID_INPUT;         
        }

        private void SetWinnablePatterns()
        {
            winnablePatterns = new List<string>();

            for (int i = 0; i < board.Length; i += 3)
            {
                string horizontalRow = "";

                for (int index = i; index < i + 3; index++)
                {
                    horizontalRow += board[index].ToString();
                }

                winnablePatterns.Add(horizontalRow);
            }

            for (int i = 0; i < 3; i++)
            {
                string verticalRow = "";

                for (int index = i; index < board.Length; index += 3)
                {
                    verticalRow += board[index].ToString();
                }

                winnablePatterns.Add(verticalRow);
            }

            for (int i = 0; i < 3; i += 2)
            {
                string diagonal = "";

                for (int index = i; index <= 8 - i; index += 4 - i)
                {
                    diagonal += board[index].ToString();
                }

                winnablePatterns.Add(diagonal);
            }
        }
    }
}
