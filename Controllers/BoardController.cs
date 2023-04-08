using Chess.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Controllers
{
    public class BoardController
    {
        private MainWindow GameWindow;
        public BoardController(MainWindow gameWindow) 
        {
            GameWindow = gameWindow;
        }

        public List<List<Square>> MovePiece(List<List<Square>> board, KeyValuePair<int, int> startingPosition, KeyValuePair<int, int> endingPosition)
        {
            board[endingPosition.Key][endingPosition.Value].OccupiedPiece = board[startingPosition.Key][startingPosition.Value].OccupiedPiece;
            board[startingPosition.Key][startingPosition.Value].OccupiedPiece = null;

            return board;
        }
    }
}
