using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone4
{
    public class Cell
    {
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }

        public Cell(int r, int c)
        {
            RowNumber = r;
            ColumnNumber = c;
        }
    }
}
