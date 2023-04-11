using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Objects
{
    public enum Color { WHITE, BLACK}
    [Serializable]
    public abstract class Piece
    {
        public bool firstTurn;
        public Color PieceColor;
        public KeyValuePair<int, int> CurrentPosition;
        public string PieceImage = "";
        public int Weight;

        public Piece(Color pieceColor, KeyValuePair<int, int> currentPosition)
        {
            PieceColor = pieceColor;
            CurrentPosition = currentPosition;
        }

        public abstract List<KeyValuePair<int, int>> GetValidMoves(List<List<Square>> board);  
}
}
