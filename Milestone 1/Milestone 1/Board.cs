using System;
using System.Collections.Generic;
using System.Text;

namespace Milestone_1
{
    public class Board
    {
        private int size;
        private Cell[,] grid;
        private double difficulty;

        public Board(int size)
        {
            this.size = size;
            grid = new Cell[size, size];

            // Initialize each cell in the grid
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    grid[row, col] = new Cell(row, col);
                }
            }
        }

        public void SetupLiveNeighbors(double difficulty)
        {
            this.difficulty = difficulty;
            Random random = new Random();

            // Set a percentage of cells to "live" status based on the difficulty
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (random.NextDouble() <= difficulty)
                    {
                        grid[row, col].Live = true;
                    }
                }
            }
        }

        public void CalculateLiveNeighbors()
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    int liveNeighbors = 0;
                    bool isLive = grid[row, col].Live;

                    // Check each neighbor cell and count how many are "live"
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int neighborRow = row + i;
                            int neighborCol = col + j;

                            // Skip the current cell and any out-of-bounds cells
                            if ((i == 0 && j == 0) || neighborRow < 0 || neighborRow >= size || neighborCol < 0 || neighborCol >= size)
                            {
                                continue;
                            }

                            if (grid[neighborRow, neighborCol].Live)
                            {
                                liveNeighbors++;
                            }
                        }
                    }

                    // If the cell itself is "live," set its live neighbor count to 9
                    if (isLive)
                    {
                        liveNeighbors = 9;
                    }

                    grid[row, col].LiveNeighbors = liveNeighbors;
                }
            }
        }

        public int Size
        {
            get { return size; }
        }

        public Cell[,] Grid
        {
            get { return grid; }
        }

        public double Difficulty
        {
            get { return difficulty; }
        }
    }


}
