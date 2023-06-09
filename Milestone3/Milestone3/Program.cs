using System;

namespace Milestone3
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 10;
            double difficulty = 0.1;
            bool endGame = false;

            Board board = new Board(size);
            board.SetupLiveNeighbors(difficulty);
            board.CalculateLiveNeighbors();

            PrintBoardDuringGame(board);

            while (!endGame)
            {
                try
                {
                    Console.Write("Enter row number (0-9): ");
                    int row = int.Parse(Console.ReadLine());

                    Console.Write("Enter column number (0-9): ");
                    int col = int.Parse(Console.ReadLine());

                    Cell cell = board.Grid[row, col];

                    if (cell.Live)
                    {
                        cell.Visited = true;
                        endGame = true;
                        Console.WriteLine("Game over! You hit a bomb.");
                    }
                    else
                    {
                  
                        board.FloodFill(row,col);

                        if (board.AllNonLiveCellsVisited())
                        {
                            endGame = true;
                            Console.WriteLine("Congratulations! You won.");
                        }
                    }

                    PrintBoardDuringGame(board);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 9.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                }
            }
        }

        static void PrintBoardDuringGame(Board board)
        {
            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    Cell cell = board.Grid[row, col];

                    if (!cell.Visited)
                    {
                        Console.Write("[?]");
                    }
                    else if (cell.Live)
                    {
                        Console.Write("[*]");
                    }
                    else if (cell.LiveNeighbors == 0)
                    {
                        Console.Write("[ ]");
                    }
                    else
                    {
                        Console.Write("[" + cell.LiveNeighbors + "]");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}


