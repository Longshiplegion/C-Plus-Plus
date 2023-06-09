using System;

namespace activity3pt5
{
    class Program
    {
        static int boardSize = 8;
        static int attemptedMoves = 0;

        static int[] xMove = { 2, 1, -1, -2, -2, -1, 1, 2 };
        static int[] yMove = { 1, 2, 2, 1, -1, -2, -2, -1 };
        static int[,] boardGrid = new int[boardSize, boardSize];

        static void Main(string[] args)
        {
            solveKT();
            Console.ReadLine();
        }

        static void solveKT()
        {
            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    boardGrid[x, y] = -1;
                }
            }

            int startX = 0;
            int startY = 4;
            boardGrid[startX, startY] = 0;
            attemptedMoves = 0;

            if (!solveKTUtil(startX, startY, 1))
            {
                Console.WriteLine("Solution does not exist for {0}{1}", startX, startY);
            }
            else
            {
                printSolution(boardGrid);
                Console.Out.WriteLine("Total attempted moves {0}", attemptedMoves);
            }
        }

        static bool solveKTUtil(int x, int y, int moveCount)
        {
            attemptedMoves++;

            if (attemptedMoves % 1000000 == 0)
            {
                Console.WriteLine("Attempts; {0}", attemptedMoves);
            }

            if (moveCount == boardSize * boardSize)
            {
                return true;
            }

            int[,] accessibleSquares = new int[boardSize, boardSize];
            int minAccessCount = boardSize + 1;
            int next_x, next_y;

            for (int k = 0; k < 8; k++)
            {
                next_x = x + xMove[k];
                next_y = y + yMove[k];

                if (isSquareSafe(next_x, next_y))
                {
                    int accessCount = countAccessibleSquares(next_x, next_y);

                    accessibleSquares[next_x, next_y] = accessCount;

                    if (accessCount < minAccessCount)
                    {
                        minAccessCount = accessCount;
                    }
                }
            }

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (accessibleSquares[i, j] == minAccessCount)
                    {
                        boardGrid[i, j] = moveCount;

                        if (solveKTUtil(i, j, moveCount + 1))
                        {
                            return true;
                        }
                        else
                        {
                            boardGrid[i, j] = -1;
                        }
                    }
                }
            }

            return false;
        }

        static int countAccessibleSquares(int x, int y)
        {
            int count = 0;

            for (int k = 0; k < 8; k++)
            {
                int next_x = x + xMove[k];
                int next_y = y + yMove[k];

                if (isSquareSafe(next_x, next_y))
                {
                    count++;
                }
            }

            return count;
        }
        static bool isSquareSafe(int x, int y)
            {
                return (x >= 0 &&
                        x < boardSize &&
                        y >= 0 &&
                        y < boardSize &&
                                boardGrid[x, y] == -1);

            }
            static void printSolution(int[,] solution)
            {
                for (int x = 0; x < boardSize; x++)
                {
                    for (int y = 0; y < boardSize; y++)
                    {
                        Console.Write(solution[x, y] + " ");

                    }
                    Console.WriteLine();
                }
            }
        }
    }

