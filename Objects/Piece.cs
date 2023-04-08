using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Objects
{
    public enum Color { WHITE, BLACK}
    public class Piece
    {
        public Color PieceColor;
        public Square CurrentSquare;

        public List<KeyValuePair<int, int>> GetValidMoves(List<Square> squares)
        {
            return new List<KeyValuePair<int, int>>();
        }
    }
}
