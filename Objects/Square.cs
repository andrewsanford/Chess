using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Objects
{
    [Serializable]
    public class Square
    {
        public Piece? OccupiedPiece;
        public bool underAttack;

        public Square()
        {

        }

        public Square(Piece occupiedPiece)
        {
            OccupiedPiece = occupiedPiece;
        }
    }
}
