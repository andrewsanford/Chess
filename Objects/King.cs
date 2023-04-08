﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Objects
{
    public class King : Piece
    {

        public King(Color pieceColor, KeyValuePair<int, int> currentPosition) : base(pieceColor, currentPosition)
        {
            PieceColor = pieceColor;
            CurrentPosition = currentPosition;

            if (pieceColor == Color.WHITE)
            {
                PieceImage = "Resources/WhiteKing.png";
            }
            else
            {
                PieceImage = "Resources/BlackKing.png";
            }
        }

        public List<KeyValuePair<int, int>> GetValidMoves(List<Square> squares)
        {
            return new List<KeyValuePair<int, int>>();
        }

        public override List<KeyValuePair<int, int>> GetValidMoves(List<List<Square>> board)
        {
            return new List<KeyValuePair<int, int>>();
        }
}
}
