using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Objects
{
    public class King : Piece
    {
        public King(Color pieceColor, Square currentSquare)
        {
            PieceColor = pieceColor;
            CurrentSquare = currentSquare;
        }

        public new List<KeyValuePair<int, int>> GetValidMoves(List<Square> squares)
        {
            return new List<KeyValuePair<int, int>>();
        }

        private KeyValuePair<int, int> checkNorth(List<Square> squares) 
        {
            return new KeyValuePair<int, int>();
        }
    }
}
