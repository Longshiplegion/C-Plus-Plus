using System;
using System.Collections.Generic;
using System.Text;

namespace Milestone3
{
    public class Cell
    {
        private int row = -1;
        private int col = -1;
        private bool visited = false;
        private bool live = false;
        private int liveNeighbors = 0;

        public Cell(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public int Row
        {
            get { return row; }
            set { row = value; }
        }

        public int Col
        {
            get { return col; }
            set { col = value; }
        }

        public bool Visited
        {
            get { return visited; }
            set { visited = value; }
        }

        public bool Live
        {
            get { return live; }
            set { live = value; }
        }

        public int LiveNeighbors
        {
            get { return liveNeighbors; }
            set { liveNeighbors = value; }
        }
    }

}
