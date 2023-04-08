using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Objects
{
    public class Square
    {
        public int Row;
        public int Column;
        public Piece? OccupiedPiece;

        public Square(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public Square(int row, int column, Piece occupiedPiece)
        {
            Row = row;
            Column = column;
            OccupiedPiece = occupiedPiece;
        }
    }
}
