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
            List<KeyValuePair<int, int>> returnList = new List<KeyValuePair<int, int>>();

            returnList.AddRange(CheckNorth(board));
            returnList.AddRange(CheckEast(board));
            returnList.AddRange(CheckSouth(board));
            returnList.AddRange(CheckWest(board));

            return returnList;
        }

        private List<KeyValuePair<int, int>> CheckNorth(List<List<Square>> board)
        {
            List<KeyValuePair<int, int>> returnList = new List<KeyValuePair<int, int>>();

            for(int i = CurrentPosition.Key - 1; i >= 0; i--)
            {
                if (board[i][CurrentPosition.Value].OccupiedPiece == null)
                {
                    returnList.Add(new KeyValuePair<int, int>(i, CurrentPosition.Value));
                    continue;
                }

                if (board[i][CurrentPosition.Value].OccupiedPiece.PieceColor != PieceColor)
                {
                    returnList.Add(new KeyValuePair<int, int>(i, CurrentPosition.Value));
                    break;
                }

                if (board[i][CurrentPosition.Value].OccupiedPiece.PieceColor == PieceColor)
                {
                    break;
                }
            }

            return returnList;
        }

        private List<KeyValuePair<int, int>> CheckEast(List<List<Square>> board)
        {
            List<KeyValuePair<int, int>> returnList = new List<KeyValuePair<int, int>>();

            for (int i = CurrentPosition.Value + 1; i <= 7; i++)
            {
                if (board[CurrentPosition.Key][i].OccupiedPiece == null)
                {
                    returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key, i));
                    continue;
                }

                if (board[CurrentPosition.Key][i].OccupiedPiece.PieceColor != PieceColor)
                {
                    returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key, i));
                    break;
                }

                if (board[CurrentPosition.Key][i].OccupiedPiece.PieceColor == PieceColor)
                {
                    break;
                }
            }

            return returnList;
        }

        private List<KeyValuePair<int, int>> CheckSouth(List<List<Square>> board)
        {
            List<KeyValuePair<int, int>> returnList = new List<KeyValuePair<int, int>>();

            for (int i = CurrentPosition.Key + 1; i <= 7; i++)
            {
                if (board[i][CurrentPosition.Value].OccupiedPiece == null)
                {
                    returnList.Add(new KeyValuePair<int, int>(i, CurrentPosition.Value));
                    continue;
                }

                if (board[i][CurrentPosition.Value].OccupiedPiece.PieceColor != PieceColor)
                {
                    returnList.Add(new KeyValuePair<int, int>(i, CurrentPosition.Value));
                    break;
                }

                if (board[i][CurrentPosition.Value].OccupiedPiece.PieceColor == PieceColor)
                {
                    break;
                }
            }

            return returnList;
        }

        private List<KeyValuePair<int, int>> CheckWest(List<List<Square>> board)
        {
            List<KeyValuePair<int, int>> returnList = new List<KeyValuePair<int, int>>();

            for (int i = CurrentPosition.Value - 1; i >= 0; i--)
            {
                if (board[CurrentPosition.Key][i].OccupiedPiece == null)
                {
                    returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key, i));
                    continue;
                }

                if (board[CurrentPosition.Key][i].OccupiedPiece.PieceColor != PieceColor)
                {
                    returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key, i));
                    break;
                }

                if (board[CurrentPosition.Key][i].OccupiedPiece.PieceColor == PieceColor)
                {
                    break;
                }
            }

            return returnList;
        }
    }
}
