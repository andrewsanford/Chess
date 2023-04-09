using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Objects
{
    public class Bishop : Piece
    {
        public Bishop(Color pieceColor, KeyValuePair<int, int> currentPosition) : base(pieceColor, currentPosition)
        {
            PieceColor = pieceColor;
            CurrentPosition = currentPosition;

            if (pieceColor == Color.WHITE)
            {
                PieceImage = "Resources/WhiteBishop.png";
            }
            else
            {
                PieceImage = "Resources/BlackBishop.png";
            }
        }

        public override List<KeyValuePair<int, int>> GetValidMoves(List<List<Square>> board)
        {
            List<KeyValuePair<int, int>> returnList = new List<KeyValuePair<int, int>>();

            returnList.AddRange(CheckNorthEast(board));
            returnList.AddRange(CheckSouthEast(board));
            returnList.AddRange(CheckSouthWest(board));
            returnList.AddRange(CheckNorthWest(board));

            return returnList;
        }

        private List<KeyValuePair<int, int>> CheckNorthEast(List<List<Square>> board)
        {
            List<KeyValuePair<int, int>> returnList = new List<KeyValuePair<int, int>>();

            int i = 1;

            while ((CurrentPosition.Key - i) >= 0 && (CurrentPosition.Value + i) <= 7)
            {
                if (board[CurrentPosition.Key - i][CurrentPosition.Value + i].OccupiedPiece == null)
                {
                    returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key - i, CurrentPosition.Value + i));
                    continue;
                }

                if(board[CurrentPosition.Key - i][CurrentPosition.Value + i].OccupiedPiece.PieceColor != PieceColor)
                {
                    returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key - i, CurrentPosition.Value + i));
                    break;
                }

                if (board[CurrentPosition.Key - i][CurrentPosition.Value + i].OccupiedPiece.PieceColor == PieceColor)
                {
                    break;
                }

                i++;
            }

            return returnList;
        }

        private List<KeyValuePair<int, int>> CheckSouthEast(List<List<Square>> board)
        {
            List<KeyValuePair<int, int>> returnList = new List<KeyValuePair<int, int>>();

            int i = 1;

            while ((CurrentPosition.Key + i) <= 7 && (CurrentPosition.Value + i) <= 7)
            {
                if (board[CurrentPosition.Key + i][CurrentPosition.Value + i].OccupiedPiece == null)
                {
                    returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key + i, CurrentPosition.Value + i));
                    continue;
                }

                if (board[CurrentPosition.Key + i][CurrentPosition.Value + i].OccupiedPiece.PieceColor != PieceColor)
                {
                    returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key + i, CurrentPosition.Value + i));
                    break;
                }

                if (board[CurrentPosition.Key + i][CurrentPosition.Value + i].OccupiedPiece.PieceColor == PieceColor)
                {
                    break;
                }

                i++;
            }

            return returnList;
        }

        private List<KeyValuePair<int, int>> CheckSouthWest(List<List<Square>> board)
        {
            List<KeyValuePair<int, int>> returnList = new List<KeyValuePair<int, int>>();

            int i = 1;

            while ((CurrentPosition.Key + i) <= 7 && (CurrentPosition.Value - i) >= 0)
            {
                if (board[CurrentPosition.Key + i][CurrentPosition.Value - i].OccupiedPiece == null)
                {
                    returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key + i, CurrentPosition.Value - i));
                    continue;
                }

                if (board[CurrentPosition.Key + i][CurrentPosition.Value - i].OccupiedPiece.PieceColor != PieceColor)
                {
                    returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key + i, CurrentPosition.Value - i));
                    break;
                }

                if (board[CurrentPosition.Key + i][CurrentPosition.Value - i].OccupiedPiece.PieceColor == PieceColor)
                {
                    break;
                }

                i++;
            }

            return returnList;
        }

        private List<KeyValuePair<int, int>> CheckNorthWest(List<List<Square>> board)
        {
            List<KeyValuePair<int, int>> returnList = new List<KeyValuePair<int, int>>();

            int i = 1;

            while ((CurrentPosition.Key - i) >= 0 && (CurrentPosition.Value - i) >= 0)
            {
                if (board[CurrentPosition.Key - i][CurrentPosition.Value - i].OccupiedPiece == null)
                {
                    returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key - i, CurrentPosition.Value - i));
                    continue;
                }

                if (board[CurrentPosition.Key - i][CurrentPosition.Value - i].OccupiedPiece.PieceColor != PieceColor)
                {
                    returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key - i, CurrentPosition.Value - i));
                    break;
                }

                if (board[CurrentPosition.Key - i][CurrentPosition.Value - i].OccupiedPiece.PieceColor == PieceColor)
                {
                    break;
                }

                i++;
            }

            return returnList;
        }


    }
}
