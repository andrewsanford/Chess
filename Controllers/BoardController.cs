using Chess.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Xml.Linq;

namespace Chess.Controllers
{
    public class BoardController
    {
        public bool BlackFirstTurn;
        public bool WhiteFirstTurn;

        private MainWindow GameWindow;
        public BoardController(MainWindow gameWindow) 
        {
            GameWindow = gameWindow;
            BlackFirstTurn = true;
            WhiteFirstTurn = true;
        }

        public List<List<Square>> MovePiece(List<List<Square>> board, KeyValuePair<int, int> startingPosition, KeyValuePair<int, int> endingPosition)
        {
            board[endingPosition.Key][endingPosition.Value].OccupiedPiece = board[startingPosition.Key][startingPosition.Value].OccupiedPiece;
            board[endingPosition.Key][endingPosition.Value].OccupiedPiece.CurrentPosition = endingPosition;
            board[startingPosition.Key][startingPosition.Value].OccupiedPiece = null;

            if(board[endingPosition.Key][endingPosition.Value].OccupiedPiece.GetType() == typeof(Pawn) && board[endingPosition.Key][endingPosition.Value].OccupiedPiece.PieceColor == Color.WHITE && endingPosition.Key == 0)
            {
                board[endingPosition.Key][endingPosition.Value].OccupiedPiece = new Queen(Color.WHITE, endingPosition);
            }
            else if(board[endingPosition.Key][endingPosition.Value].OccupiedPiece.GetType() == typeof(Pawn) && board[endingPosition.Key][endingPosition.Value].OccupiedPiece.PieceColor == Color.BLACK && endingPosition.Key == 7)
            {
                board[endingPosition.Key][endingPosition.Value].OccupiedPiece = new Queen(Color.BLACK, endingPosition);
            }

            return board;
        }

        public List<List<Square>> StartBlackTurn(List<List<Square>> startingBoard)
        {
            bool minimaxFinished = false;

            int? highestHeuristicValue = null;

            List<List<Square>> returnBoard = new List<List<Square>>();
            List<TestedMove> testedMoves = new List<TestedMove>();

            KeyValuePair<List<Square>, List<Square>> piecesListsByColor = GetPiecesByColor(startingBoard);

            foreach (Square blackSquare in piecesListsByColor.Value)
            {
                List<KeyValuePair<int, int>> possibleMoves = blackSquare.OccupiedPiece.GetValidMoves(startingBoard);

                foreach(KeyValuePair<int, int> blackMove in possibleMoves)
                {
                    TestedMove testMove = new TestedMove();
                    testedMoves.Add(testMove);

                    List<List<Square>> boardCopy = new List<List<Square>>();

                    using (var ms = new MemoryStream())
                    {
                        IFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(ms, startingBoard);
                        ms.Seek(0, SeekOrigin.Begin);
                        boardCopy = (List<List<Square>>)formatter.Deserialize(ms);
                    }

                    testMove.Board = MovePiece(boardCopy, blackSquare.OccupiedPiece.CurrentPosition, blackMove);
                    testMove.BoardsEvaluation = EvaluateWeights(testMove.Board);     
                }
            }        

            foreach (TestedMove testedMove in testedMoves) 
            {
                Thread thread = new Thread(() => { testedMove.FinalEvaluation = MiniMax(testedMove.Board); });
                thread.Start();
            }

            MinimaxFinishedChecker(testedMoves);

            foreach(TestedMove testedMove in testedMoves)
            {
                if(highestHeuristicValue == null)
                {
                    highestHeuristicValue = testedMove.FinalEvaluation;
                    returnBoard = testedMove.Board;
                    continue;
                }

                if (testedMove.FinalEvaluation > highestHeuristicValue)
                {
                    highestHeuristicValue = testedMove.FinalEvaluation;
                    returnBoard = testedMove.Board;
                    continue;
                }
            }

            return returnBoard;
        }

        private void MinimaxFinishedChecker(List<TestedMove> testedMoves)
        {
            bool minimaxFinished = false;

            while(!minimaxFinished)
            {
                Thread.Sleep(500);

                minimaxFinished = true;

                foreach (TestedMove testedMove in testedMoves)
                {
                    if (testedMove.FinalEvaluation == null)
                    {
                        minimaxFinished = false;
                        break;
                    }
                }
            }
        }

        private int MiniMax(List<List<Square>> board)
        {
            return 0;
        }

        private int EvaluateWeights(List<List<Square>> board)
        {
            int sum = 0;

            foreach (List<Square> squares in board)
            {
                foreach (Square square in squares)
                {
                    if (square.OccupiedPiece != null)
                    {
                        if (square.OccupiedPiece.PieceColor == Color.WHITE)
                        {
                            sum -= square.OccupiedPiece.Weight;
                        }
                        else
                        {
                            sum += square.OccupiedPiece.Weight;
                        }
                    }
                }
            }

            return sum;
        }

        private KeyValuePair<List<Square>, List<Square>> GetPiecesByColor(List<List<Square>> board)
        {
            KeyValuePair<List<Square>, List<Square>> returnLists = new KeyValuePair<List<Square>, List<Square>>(new List<Square>(), new List<Square>());

            foreach (List<Square> squares in board)
            {
                foreach (Square square in squares)
                {
                    if (square.OccupiedPiece != null)
                    {
                        if (square.OccupiedPiece.PieceColor == Color.WHITE)
                        {
                            returnLists.Key.Add(square);
                        }
                        else
                        {
                            returnLists.Value.Add(square);
                        }
                    }
                }
            }

            return returnLists;
        }
    }
}
