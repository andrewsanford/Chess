using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Objects
{
    [Serializable]
    public class Pawn : Piece
    {
        public Pawn(Color pieceColor, KeyValuePair<int, int> currentPosition) : base(pieceColor, currentPosition)
        {
            PieceColor = pieceColor;
            CurrentPosition = currentPosition;
            Weight = 10;

            if (pieceColor == Color.WHITE)
            {
                PieceImage = "Resources/WhitePawn.png";
            }
            else
            {
                PieceImage = "Resources/BlackPawn.png";
            }
        }

        public override List<KeyValuePair<int, int>> GetValidMoves(List<List<Square>> board)
        {
            List<KeyValuePair<int, int>> returnList = new List<KeyValuePair<int, int>>();

            if (PieceColor == Color.WHITE)
            {
                //check north
                if((CurrentPosition.Key - 1) >= 0 && board[CurrentPosition.Key - 1][CurrentPosition.Value].OccupiedPiece == null)
                {
                    returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key - 1, CurrentPosition.Value));
                }

                //check enemy northeast
                if((CurrentPosition.Key - 1) >= 0 && (CurrentPosition.Value + 1) <= 7 && board[CurrentPosition.Key - 1][CurrentPosition.Value + 1].OccupiedPiece != null && board[CurrentPosition.Key - 1][CurrentPosition.Value + 1].OccupiedPiece.PieceColor == Color.BLACK)
                {
                    returnList.Insert(0, new KeyValuePair<int, int>(CurrentPosition.Key - 1, CurrentPosition.Value + 1));
                }

                //check enemy northwest
                if ((CurrentPosition.Key - 1) >= 0 && (CurrentPosition.Value - 1) >= 0 && board[CurrentPosition.Key - 1][CurrentPosition.Value - 1].OccupiedPiece != null && board[CurrentPosition.Key - 1][CurrentPosition.Value - 1].OccupiedPiece.PieceColor == Color.BLACK)
                {
                    returnList.Insert(0, new KeyValuePair<int, int>(CurrentPosition.Key - 1, CurrentPosition.Value - 1));
                }
            }
            else
            {
                //check south
                if((CurrentPosition.Key + 1) <= 7 && board[CurrentPosition.Key + 1][CurrentPosition.Value].OccupiedPiece == null)
                {
                    returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key + 1, CurrentPosition.Value));
                }

                //check enemy southeast
                if((CurrentPosition.Key + 1) <= 7 && (CurrentPosition.Value + 1) <= 7 && board[CurrentPosition.Key + 1][CurrentPosition.Value + 1].OccupiedPiece != null && board[CurrentPosition.Key + 1][CurrentPosition.Value + 1].OccupiedPiece.PieceColor == Color.WHITE)
                {
                    returnList.Insert(0, new KeyValuePair<int, int>(CurrentPosition.Key + 1, CurrentPosition.Value + 1));
                }

                //check enemy southwest
                if ((CurrentPosition.Key + 1) <= 7 && (CurrentPosition.Value - 1) >= 0 && board[CurrentPosition.Key + 1][CurrentPosition.Value - 1].OccupiedPiece != null && board[CurrentPosition.Key + 1][CurrentPosition.Value - 1].OccupiedPiece.PieceColor == Color.WHITE)
                {
                    returnList.Insert(0, new KeyValuePair<int, int>(CurrentPosition.Key + 1, CurrentPosition.Value - 1));
                }
            }

            return returnList;
        }
    }
}
