using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Objects
{
    public class Rook : Piece
    {
        public Rook(Color pieceColor, KeyValuePair<int, int> currentPosition) : base(pieceColor, currentPosition)
        {
            PieceColor = pieceColor;
            CurrentPosition = currentPosition;

            if(pieceColor == Color.WHITE)
            {
                PieceImage = "Resources/WhiteRook.png";
            }
            else
            {
                PieceImage = "Resources/BlackRook.png";
            }
        }

        public override List<KeyValuePair<int, int>> GetValidMoves(List<List<Square>> board)
        {
            return new List<KeyValuePair<int, int>>();
        }
}
}
