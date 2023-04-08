﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Objects
{
    public class Pawn : Piece
    {
        public Pawn(Color pieceColor, KeyValuePair<int, int> currentPosition) : base(pieceColor, currentPosition)
        {
            PieceColor = pieceColor;
            CurrentPosition = currentPosition;

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
                if ((CurrentPosition.Key - 1) >= 0 && board[CurrentPosition.Key - 1][CurrentPosition.Value].OccupiedPiece == null)
                {
                    returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key - 1, CurrentPosition.Value));
                }

                if ((CurrentPosition.Key - 1) >= 0 && CurrentPosition.Value - 1 >= 0 && board[CurrentPosition.Key - 1][CurrentPosition.Value - 1].OccupiedPiece != null && board[CurrentPosition.Key - 1][CurrentPosition.Value - 1].OccupiedPiece.PieceColor == Color.BLACK)
                {
                    returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key - 1, CurrentPosition.Value - 1));
                }

                if ((CurrentPosition.Value + 1) <= 7 && CurrentPosition.Key - 1 >= 0 && board[CurrentPosition.Key - 1][CurrentPosition.Value + 1].OccupiedPiece != null && board[CurrentPosition.Key - 1][CurrentPosition.Value + 1].OccupiedPiece.PieceColor == Color.BLACK)
                {
                    returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key - 1, CurrentPosition.Value + 1));
                }
            }
            else
            {
                if ((CurrentPosition.Key + 1) <= 7 && board[CurrentPosition.Key + 1][CurrentPosition.Value].OccupiedPiece == null)
                {
                    returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key + 1, CurrentPosition.Value));
                }

                if ((CurrentPosition.Value - 1) >= 0 && CurrentPosition.Key + 1 <= 7 && board[CurrentPosition.Key + 1][CurrentPosition.Value - 1].OccupiedPiece != null && board[CurrentPosition.Key + 1][CurrentPosition.Value - 1].OccupiedPiece.PieceColor == Color.WHITE)
                {
                    returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key - 1, CurrentPosition.Value + 1));
                }

                if ((CurrentPosition.Key + 1) <= 7 && CurrentPosition.Value + 1 <= 7 && board[CurrentPosition.Key + 1][CurrentPosition.Value + 1].OccupiedPiece != null && board[CurrentPosition.Key + 1][CurrentPosition.Value + 1].OccupiedPiece.PieceColor == Color.WHITE)
                {
                    returnList.Add(new KeyValuePair<int, int>(CurrentPosition.Key + 1, CurrentPosition.Value + 1));
                }
            }

            return returnList;
        }
    }
}
