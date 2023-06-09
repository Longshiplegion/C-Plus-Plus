using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoardModel
{
    public class Board
    {
        public int Size { get; set; }
        public Cell[,] theGrid;
        public Board(int s)
        {
            Size = s;
            theGrid = new Cell[Size, Size];
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }

        public void MarkNextLegalMove(Cell currentCell,string chessPiece)
        {
            for(int r = 0; r < Size; r++)
            {
                for(int c = 0; c < Size; c++)
                {
                    theGrid[r, c].LegalNextMove = false;
                }
            }

            try
            {
                switch (chessPiece)
                {
                    case "Knight":
                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                        break;
                    case "King":
                        // code for legal moves of King
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber].LegalNextMove = true;
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber - 1].LegalNextMove = true;
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber + 1].LegalNextMove = true;
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].LegalNextMove = true;
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                        break;
                    case "Rook":
                        // code for legal moves of Rook
                        for (int i = currentCell.RowNumber + 1; i < 8; i++)
                        {
                            if (theGrid[i, currentCell.ColumnNumber].CurrentlyOccupied)
                            {
                                break;
                            }
                            theGrid[i, currentCell.ColumnNumber].LegalNextMove = true;
                        }
                        for (int i = currentCell.RowNumber - 1; i >= 0; i--)
                        {
                            if (theGrid[i, currentCell.ColumnNumber].CurrentlyOccupied)
                            {
                                break;
                            }
                            theGrid[i, currentCell.ColumnNumber].LegalNextMove = true;
                        }
                        for (int j = currentCell.ColumnNumber + 1; j < 8; j++)
                        {
                            if (theGrid[currentCell.RowNumber, j].CurrentlyOccupied)
                            {
                                break;
                            }
                            theGrid[currentCell.RowNumber, j].LegalNextMove = true;
                        }
                        for (int j = currentCell.ColumnNumber - 1; j >= 0; j--)
                        {
                            if (theGrid[currentCell.RowNumber, j].CurrentlyOccupied)
                            {
                                break;
                            }
                            theGrid[currentCell.RowNumber, j].LegalNextMove = true;
                        }
                        break;
                    case "Bishop":
                        // code for legal moves of Bishop
                        for (int i = currentCell.RowNumber + 1, j = currentCell.ColumnNumber + 1; i < 8 && j < 8; i++, j++)
                        {
                            if (theGrid[i, j].CurrentlyOccupied)
                            {
                                break;
                            }
                            theGrid[i, j].LegalNextMove = true;
                        }
                        for (int i = currentCell.RowNumber + 1, j = currentCell.ColumnNumber - 1; i < 8 && j >= 0; i++, j--)
                        {
                            if (theGrid[i, j].CurrentlyOccupied)
                            {
                                break;
                            }
                            theGrid[i, j].LegalNextMove = true;
                        }
                        for (int i = currentCell.RowNumber - 1, j = currentCell.ColumnNumber + 1; i >= 0 && j < 8; i--, j++)
                        {
                            if (theGrid[i, j].CurrentlyOccupied)
                            {
                                break;
                            }
                            theGrid[i, j].LegalNextMove = true;
                        }
                        for (int i = currentCell.RowNumber - 1, j = currentCell.ColumnNumber - 1; i >= 0 && j >= 0; i--, j--)
                        {
                            if (theGrid[i, j].CurrentlyOccupied)
                            {
                                break;
                            }
                            theGrid[i, j].LegalNextMove = true;
                        }
                        break;
                    case "Queen":
                        // code for legal moves of Queen
                        // code for legal moves of Bishop
                        for (int i = currentCell.RowNumber + 1, j = currentCell.ColumnNumber + 1; i < 8 && j < 8; i++, j++)
                        {
                            if (theGrid[i, j].CurrentlyOccupied)
                            {
                                break;
                            }
                            theGrid[i, j].LegalNextMove = true;
                        }
                        for (int i = currentCell.RowNumber + 1, j = currentCell.ColumnNumber - 1; i < 8 && j >= 0; i++, j--)
                        {
                            if (theGrid[i, j].CurrentlyOccupied)
                            {
                                break;
                            }
                            theGrid[i, j].LegalNextMove = true;
                        }
                        for (int i = currentCell.RowNumber - 1, j = currentCell.ColumnNumber + 1; i >= 0 && j < 8; i--, j++)
                        {
                            if (theGrid[i, j].CurrentlyOccupied)
                            {
                                break;
                            }
                            theGrid[i, j].LegalNextMove = true;
                        }
                        for (int i = currentCell.RowNumber - 1, j = currentCell.ColumnNumber - 1; i >= 0 && j >= 0; i--, j--)
                        {
                            if (theGrid[i, j].CurrentlyOccupied)
                            {
                                break;
                            }
                            theGrid[i, j].LegalNextMove = true;
                        }
                        // code for legal moves of Rook
                        for (int i = currentCell.RowNumber + 1; i < 8; i++)
                        {
                            if (theGrid[i, currentCell.ColumnNumber].CurrentlyOccupied)
                            {
                                break;
                            }
                            theGrid[i, currentCell.ColumnNumber].LegalNextMove = true;
                        }
                        for (int i = currentCell.RowNumber - 1; i >= 0; i--)
                        {
                            if (theGrid[i, currentCell.ColumnNumber].CurrentlyOccupied)
                            {
                                break;
                            }
                            theGrid[i, currentCell.ColumnNumber].LegalNextMove = true;
                        }
                        for (int j = currentCell.ColumnNumber + 1; j < 8; j++)
                        {
                            if (theGrid[currentCell.RowNumber, j].CurrentlyOccupied)
                            {
                                break;
                            }
                            theGrid[currentCell.RowNumber, j].LegalNextMove = true;
                        }
                        for (int j = currentCell.ColumnNumber - 1; j >= 0; j--)
                        {
                            if (theGrid[currentCell.RowNumber, j].CurrentlyOccupied)
                            {
                                break;
                            }
                            theGrid[currentCell.RowNumber, j].LegalNextMove = true;
                        }
                        break;
                }
            }catch(Exception e)
            {

            }
        }



    }
        }
    
