namespace NaughtsAndCrosses
{
    internal enum BoardState
    {
        NOUGHTS_WIN, CROSSES_WIN, DRAW, INVALID_INPUT
    }

    class Program
    {     
        private static BoardState GetStateOfBoard(string board)
        {
            if (board == null)
            {
                return BoardState.INVALID_INPUT;
            }
            else
            {
                IPatterns patterns = new Patterns(board.ToUpper());
                return patterns.CalculateResult();
            }       
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                System.Console.WriteLine(GetStateOfBoard(args[i]));                
            }
        }
    }
}
