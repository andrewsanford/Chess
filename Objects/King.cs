using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Objects
{
    [Serializable]
    public class King : Piece
    {

        public King(Color pieceColor, KeyValuePair<int, int> currentPosition) : base(pieceColor, currentPosition)
        {
            PieceColor = pieceColor;
            CurrentPosition = currentPosition;
            Weight = 900;

            if (pieceColor == Color.WHITE)
            {
                PieceImage = "Resources/WhiteKing.png";
            }
            else
            {
                PieceImage = "Resources/BlackKing.png";
            }
        }

        public override List<KeyValuePair<int, int>> GetValidMoves(List<List<Square>> board)
        {
            List<KeyValuePair<int, int>> returnList = new List<KeyValuePair<int, int>>();

            //check north
            if((CurrentPosition.Key - 1) >= 0 && (board[CurrentPosition.Key - 1][CurrentPosition.Value].OccupiedPiece == null || board[CurrentPosition.Key - 1][CurrentPosition.Value].OccupiedPiece.PieceColor != PieceColor))
            {
                returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key - 1, CurrentPosition.Value));
            }

            //check east
            if ((CurrentPosition.Value + 1) <= 7 && (board[CurrentPosition.Key][CurrentPosition.Value + 1].OccupiedPiece == null || board[CurrentPosition.Key][CurrentPosition.Value + 1].OccupiedPiece.PieceColor != PieceColor))
            {
                returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key, CurrentPosition.Value + 1));
            }

            //check south
            if ((CurrentPosition.Key + 1) <= 7 && (board[CurrentPosition.Key + 1][CurrentPosition.Value].OccupiedPiece == null || board[CurrentPosition.Key + 1][CurrentPosition.Value].OccupiedPiece.PieceColor != PieceColor))
            {
                returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key + 1, CurrentPosition.Value));
            }

            //check west
            if ((CurrentPosition.Value - 1) >= 0 && (board[CurrentPosition.Key][CurrentPosition.Value - 1].OccupiedPiece == null || board[CurrentPosition.Key][CurrentPosition.Value - 1].OccupiedPiece.PieceColor != PieceColor))
            {
                returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key, CurrentPosition.Value - 1));
            }

            //check northeast
            if ((CurrentPosition.Key - 1) >= 0 && (CurrentPosition.Value + 1) <= 7 && (board[CurrentPosition.Key - 1][CurrentPosition.Value + 1].OccupiedPiece == null || board[CurrentPosition.Key - 1][CurrentPosition.Value + 1].OccupiedPiece.PieceColor != PieceColor))
            {
                returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key - 1, CurrentPosition.Value + 1));
            }

            //check southeast
            if ((CurrentPosition.Key + 1) <= 7 && (CurrentPosition.Value + 1) <= 7 && (board[CurrentPosition.Key + 1][CurrentPosition.Value + 1].OccupiedPiece == null || board[CurrentPosition.Key + 1][CurrentPosition.Value + 1].OccupiedPiece.PieceColor != PieceColor))
            {
                returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key + 1, CurrentPosition.Value + 1));
            }

            //check southwest
            if ((CurrentPosition.Key + 1) <= 7 && (CurrentPosition.Value - 1) >= 0 && (board[CurrentPosition.Key + 1][CurrentPosition.Value - 1].OccupiedPiece == null || board[CurrentPosition.Key + 1][CurrentPosition.Value - 1].OccupiedPiece.PieceColor != PieceColor))
            {
                returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key + 1, CurrentPosition.Value - 1));
            }

            //check northwest
            if ((CurrentPosition.Key - 1) >= 0 && (CurrentPosition.Value - 1) >= 0 && (board[CurrentPosition.Key - 1][CurrentPosition.Value - 1].OccupiedPiece == null || board[CurrentPosition.Key - 1][CurrentPosition.Value - 1].OccupiedPiece.PieceColor != PieceColor))
            {
                returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key - 1, CurrentPosition.Value - 1));
            }

            return returnList;
        }
    }
}
