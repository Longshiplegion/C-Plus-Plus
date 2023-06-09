using System;
using ChessBoardModel;

namespace ChessBoardConsoleApp
{
    class Program
    {
        static Board myBoard = new Board(8);

        static void Main(string[] args)
        {
            try
            {
                printGrid(myBoard);

                Cell mylocation = setCurrentCell();
                string pieceType = getPieceType();
                myBoard.MarkNextLegalMove(mylocation, pieceType);
                printGrid(myBoard);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            Console.ReadLine();
        }

        static public void printGrid(Board myBoard)
        {
            Console.Write("  ");
            for (int i = 0; i < myBoard.Size; i++)
            {
                Console.Write("+---");
            }
            Console.WriteLine("+");

            for (int i = 0; i < myBoard.Size; i++)
            {
                Console.Write("  ");
                for (int j = 0; j < myBoard.Size; j++)
                {
                    Console.Write("| ");

                    if (myBoard.theGrid[i, j].CurrentlyOccupied)
                    {
                        Console.Write("X ");
                    }
                    else if (myBoard.theGrid[i, j].LegalNextMove)
                    {
                        Console.Write("+ ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.Write("|");
                Console.WriteLine();
                Console.Write(i + 1 + " ");
                for (int j = 0; j < myBoard.Size; j++)
                {
                    Console.Write("+---");
                }
                Console.WriteLine("+");
            }

            Console.Write("  ");
            for (int i = 0; i < myBoard.Size; i++)
            {
                Console.Write("  " + (char)('A' + i) + " ");
            }
            Console.WriteLine();
        }

        static public Cell setCurrentCell()
        {
            int currentRow = -1;
            int currentCol = -1;

            while (currentRow < 0 || currentRow >= myBoard.Size)
            {
                Console.Write("Enter your current row number (0-" + (myBoard.Size - 1) + "): ");
                if (!int.TryParse(Console.ReadLine(), out currentRow))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    currentRow = -1;
                }
            }

            while (currentCol < 0 || currentCol >= myBoard.Size)
            {
                Console.Write("Enter your current column number (0-" + (myBoard.Size - 1) + "): ");
                if (!int.TryParse(Console.ReadLine(), out currentCol))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    currentCol = -1;
                }
            }

            myBoard.theGrid[currentRow, currentCol].CurrentlyOccupied = true;
            return myBoard.theGrid[currentRow, currentCol];
        }

        static public string getPieceType()
        {
            Console.Write("Enter the type of piece (Knight, Bishop, Rook, Queen, King): ");
            string pieceType = Console.ReadLine();

            while (true)
            {
                if(pieceType == "Knight")
                {
                    break;
                }
                else if(pieceType == "Rook")
                {
                    break;
                }
                else if(pieceType == "Bishop")
                {
                    break;
                }
                else if(pieceType == "Queen")
                {
                    break;
                }
                else if(pieceType == "King")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid piece type.");
                    Console.Write("Enter the type of piece (Knight, Bishop, Rook, Queen, King): ");
                    pieceType = Console.ReadLine();
                }
            }

            return pieceType;
        }
    }
}
