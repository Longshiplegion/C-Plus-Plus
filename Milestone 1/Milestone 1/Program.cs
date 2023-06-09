using System;

namespace Milestone_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 10;
            double difficulty = 0.1;

            Board board = new Board(size);
            board.SetupLiveNeighbors(difficulty);
            board.CalculateLiveNeighbors();

            PrintBoard(board);
        }

        static void PrintBoard(Board board)
        {
            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    Cell cell = board.Grid[row, col];
                    if (cell.Live)
                    {
                        Console.Write("[*]");
                    }
                    else if (cell.Visited)
                    {
                        Console.Write("[X]");
                    }
                    else
                    {
                        Console.Write("[ ]");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
