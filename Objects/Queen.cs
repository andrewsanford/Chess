using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Objects
{
    public class Queen : Piece
    {
        public Queen(Color pieceColor, KeyValuePair<int, int> currentPosition) : base(pieceColor, currentPosition)
        {
            PieceColor = pieceColor;
            CurrentPosition = currentPosition;

            if (pieceColor == Color.WHITE)
            {
                PieceImage = "Resources/WhiteQueen.png";
            }
            else
            {
                PieceImage = "Resources/BlackQueen.png";
            }
        }

        public override List<KeyValuePair<int, int>> GetValidMoves(List<List<Square>> board)
        {
            List<KeyValuePair<int, int>> returnList = new List<KeyValuePair<int, int>>();

            returnList.AddRange(CheckNorth(board));
            returnList.AddRange(CheckEast(board));
            returnList.AddRange(CheckSouth(board));
            returnList.AddRange(CheckWest(board));
            returnList.AddRange(CheckNorthEast(board));
            returnList.AddRange(CheckSouthEast(board));
            returnList.AddRange(CheckSouthWest(board));
            returnList.AddRange(CheckNorthWest(board));

            return returnList;
        }

        private List<KeyValuePair<int, int>> CheckNorth(List<List<Square>> board)
        {
            List<KeyValuePair<int, int>> returnList = new List<KeyValuePair<int, int>>();

            for (int i = CurrentPosition.Key - 1; i >= 0; i--)
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

                if (board[CurrentPosition.Key - i][CurrentPosition.Value + i].OccupiedPiece.PieceColor != PieceColor)
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
