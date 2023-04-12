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
using System.Windows;
using System.Diagnostics.Metrics;

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

            if (board[endingPosition.Key][endingPosition.Value].OccupiedPiece.GetType() == typeof(Pawn) && board[endingPosition.Key][endingPosition.Value].OccupiedPiece.PieceColor == Color.WHITE && endingPosition.Key == 0)
            {
                board[endingPosition.Key][endingPosition.Value].OccupiedPiece = new Queen(Color.WHITE, endingPosition);
            }
            else if (board[endingPosition.Key][endingPosition.Value].OccupiedPiece.GetType() == typeof(Pawn) && board[endingPosition.Key][endingPosition.Value].OccupiedPiece.PieceColor == Color.BLACK && endingPosition.Key == 7)
            {
                board[endingPosition.Key][endingPosition.Value].OccupiedPiece = new Queen(Color.BLACK, endingPosition);
            }

            return board;
        }

        public List<List<Square>> MovePiece(List<List<Square>> board, KeyValuePair<int, int> startingPosition, KeyValuePair<int, int> endingPosition, ref bool blackKingDead)
        {
            if(board[endingPosition.Key][endingPosition.Value].OccupiedPiece != null && board[endingPosition.Key][endingPosition.Value].OccupiedPiece.GetType() == typeof(King) && board[endingPosition.Key][endingPosition.Value].OccupiedPiece.PieceColor == Color.BLACK)
            {
                blackKingDead = true;
            }

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



        public List<List<Square>> StartBlackTurn(List<List<Square>> startingBoard, int depth)
        {
            Thread? thread1 = null;
            Thread? thread2 = null;
            Thread? thread3 = null;
            Thread? thread4 = null;
            Thread? thread5 = null;

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

            Application.Current.Dispatcher.Invoke(() =>
            {
                GameWindow.prgTurnProgress.Maximum = testedMoves.Count;
            });

            Thread progressCheckerThread = new Thread(() => { MinimaxFinishedChecker(testedMoves); });
            progressCheckerThread.Start();

            foreach (TestedMove testedMove in testedMoves) 
            {
                CheckOpenThreads:

                if(thread1 == null || !thread1.IsAlive)
                {
                    thread1 = new Thread(() => { testedMove.FinalEvaluation = MiniMax(testedMove.Board, depth - 1, false, -1290, 1290); });
                    thread1.Start();
                    continue;
                }

                if (thread2 == null || !thread2.IsAlive)
                {
                    thread2 = new Thread(() => { testedMove.FinalEvaluation = MiniMax(testedMove.Board, depth - 1, false, -1290, 1290); });
                    thread2.Start();
                    continue;
                }

                if (thread3 == null || !thread3.IsAlive)
                {
                    thread3 = new Thread(() => { testedMove.FinalEvaluation = MiniMax(testedMove.Board, depth - 1, false, -1290, 1290); });
                    thread3.Start();
                    continue;
                }

                if (thread4 == null || !thread4.IsAlive)
                {
                    thread4 = new Thread(() => { testedMove.FinalEvaluation = MiniMax(testedMove.Board, depth - 1, false, -1290, 1290); });
                    thread4.Start();
                    continue;
                }

                if (thread5 == null || !thread5.IsAlive)
                {
                    thread5 = new Thread(() => { testedMove.FinalEvaluation = MiniMax(testedMove.Board, depth - 1, false, -1290, 1290); });
                    thread5.Start();
                    continue;
                }

                Thread.Sleep(500);
                goto CheckOpenThreads;
            }

            progressCheckerThread.Join();

            foreach (TestedMove testedMove in testedMoves)
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
            int counter = 0;

            while(!minimaxFinished)
            {
                counter = 0;

                Thread.Sleep(100);

                minimaxFinished = true;

                foreach (TestedMove testedMove in testedMoves)
                {
                    if (testedMove.FinalEvaluation == null)
                    {
                        minimaxFinished = false;
                    }
                    else
                    {
                        counter++;
                    }
                }

                Application.Current.Dispatcher.Invoke(() =>
                {
                    GameWindow.prgTurnProgress.Value = counter;
                });
            }
        }

        private int MiniMax(List<List<Square>> board, int depth, bool blackTurn, int alpha, int beta)
        {
            List<List<Square>> boardCopy;
            int? evaluation = null;
            int? minEvaluation = null;
            int? maxEvaluation = null;
            KeyValuePair<List<Square>, List<Square>> piecesListsByColor = GetPiecesByColor(board);

            if(depth == 0)
            {
                return EvaluateWeights(board);
            }

            if (blackTurn)
            {
                foreach(Square piece in piecesListsByColor.Value)
                {
                    foreach(KeyValuePair<int, int> possibleMove in piece.OccupiedPiece.GetValidMoves(board))
                    {
                        bool blackKingDead = false;
                        using (var ms = new MemoryStream())
                        {
                            IFormatter formatter = new BinaryFormatter();
                            formatter.Serialize(ms, board);
                            ms.Seek(0, SeekOrigin.Begin);
                            boardCopy = (List<List<Square>>)formatter.Deserialize(ms);
                        }

                        List<List<Square>> tempBoard = MovePiece(boardCopy, piece.OccupiedPiece.CurrentPosition, possibleMove, ref blackKingDead);

                        if (blackKingDead)
                        {
                            evaluation = -1290;
                        }
                        else
                        {
                            evaluation = MiniMax(tempBoard, depth - 1, false, alpha, beta);
                        }       

                        if(maxEvaluation == null)
                        {
                            maxEvaluation = evaluation;
                        }
                        else
                        {
                            maxEvaluation = Math.Max((int)maxEvaluation, (int)evaluation);
                        }

                        alpha = Math.Max(alpha, (int)evaluation);
                        if (beta <= alpha)
                        {
                            break;
                        }
                    }  
                }

                return (int)maxEvaluation;
            }
            else
            {
                foreach (Square piece in piecesListsByColor.Key)
                {
                    foreach (KeyValuePair<int, int> possibleMove in piece.OccupiedPiece.GetValidMoves(board))
                    {
                        using (var ms = new MemoryStream())
                        {
                            IFormatter formatter = new BinaryFormatter();
                            formatter.Serialize(ms, board);
                            ms.Seek(0, SeekOrigin.Begin);
                            boardCopy = (List<List<Square>>)formatter.Deserialize(ms);
                        }

                        evaluation = MiniMax(MovePiece(boardCopy, piece.OccupiedPiece.CurrentPosition, possibleMove), depth - 1, true, alpha, beta);

                        if (minEvaluation == null)
                        {
                            minEvaluation = evaluation;
                        }
                        else
                        {
                            minEvaluation = Math.Min((int)minEvaluation, (int)evaluation);
                        }

                        beta = Math.Min(beta, (int)evaluation);
                        if (beta <= alpha)
                        {
                            break;
                        }
                    }
                }

                return (int)minEvaluation;
            }
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
