using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Objects
{
    public class Knight : Piece
    {
        public Knight(Color pieceColor, KeyValuePair<int, int> currentPosition) : base(pieceColor, currentPosition)
        {
            PieceColor = pieceColor;
            CurrentPosition = currentPosition;

            if (pieceColor == Color.WHITE)
            {
                PieceImage = "Resources/WhiteKnight.png";
            }
            else
            {
                PieceImage = "Resources/BlackKnight.png";
            }
        }

        public override List<KeyValuePair<int, int>> GetValidMoves(List<List<Square>> board)
        {
            List<KeyValuePair<int, int>> returnList = new List<KeyValuePair<int, int>>();

            //check northeast 1
            if((CurrentPosition.Key - 2) >= 0 && (CurrentPosition.Value + 1) <= 7 && (board[CurrentPosition.Key - 2][CurrentPosition.Value + 1].OccupiedPiece == null || board[CurrentPosition.Key - 2][CurrentPosition.Value + 1].OccupiedPiece.PieceColor != PieceColor))
            {
                returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key - 2, CurrentPosition.Value + 1));
            }

            //check northeast 2
            if ((CurrentPosition.Key - 1) >= 0 && (CurrentPosition.Value + 2) <= 7 && (board[CurrentPosition.Key - 1][CurrentPosition.Value + 2].OccupiedPiece == null || board[CurrentPosition.Key - 1][CurrentPosition.Value + 2].OccupiedPiece.PieceColor != PieceColor))
            {
                returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key - 1, CurrentPosition.Value + 2));
            }

            //check southeast 1
            if ((CurrentPosition.Key + 1) <= 7 && (CurrentPosition.Value + 2) <= 7 && (board[CurrentPosition.Key + 1][CurrentPosition.Value + 2].OccupiedPiece == null || board[CurrentPosition.Key + 1][CurrentPosition.Value + 2].OccupiedPiece.PieceColor != PieceColor))
            {
                returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key + 1, CurrentPosition.Value + 2));
            }

            //check southeast 2
            if ((CurrentPosition.Key + 2) <= 7 && (CurrentPosition.Value + 1) <= 7 && (board[CurrentPosition.Key + 2][CurrentPosition.Value + 1].OccupiedPiece == null || board[CurrentPosition.Key + 2][CurrentPosition.Value + 1].OccupiedPiece.PieceColor != PieceColor))
            {
                returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key + 2, CurrentPosition.Value + 1));
            }

            //check southwest 1
            if ((CurrentPosition.Key + 2) <= 7 && (CurrentPosition.Value - 1) >= 0 && (board[CurrentPosition.Key + 2][CurrentPosition.Value - 1].OccupiedPiece == null || board[CurrentPosition.Key + 2][CurrentPosition.Value - 1].OccupiedPiece.PieceColor != PieceColor))
            {
                returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key + 2, CurrentPosition.Value - 1));
            }

            //check southwest 2
            if ((CurrentPosition.Key + 1) <= 7 && (CurrentPosition.Value - 2) >= 0 && (board[CurrentPosition.Key + 1][CurrentPosition.Value - 2].OccupiedPiece == null || board[CurrentPosition.Key + 1][CurrentPosition.Value - 2].OccupiedPiece.PieceColor != PieceColor))
            {
                returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key + 1, CurrentPosition.Value - 2));
            }

            //check northwest 1
            if ((CurrentPosition.Key - 1) >= 0 && (CurrentPosition.Value - 2) >= 0 && (board[CurrentPosition.Key - 1][CurrentPosition.Value - 2].OccupiedPiece == null || board[CurrentPosition.Key - 1][CurrentPosition.Value - 2].OccupiedPiece.PieceColor != PieceColor))
            {
                returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key - 1, CurrentPosition.Value - 2));
            }

            //check northwest 2
            if ((CurrentPosition.Key - 2) >= 0 && (CurrentPosition.Value - 1) >= 0 && (board[CurrentPosition.Key - 2][CurrentPosition.Value - 1].OccupiedPiece == null || board[CurrentPosition.Key - 2][CurrentPosition.Value - 1].OccupiedPiece.PieceColor != PieceColor))
            {
                returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key - 2, CurrentPosition.Value - 1));
            }

            return returnList;
        }
}
}
