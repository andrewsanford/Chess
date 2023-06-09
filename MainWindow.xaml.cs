﻿using Chess.Controllers;
using Chess.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private KeyValuePair<int?, int> ActivePiece;
        private List<List<Square>> ActiveBoard;
        private List<List<Button>> BoardButtons;
        private List<KeyValuePair<int, int>> ActivePositions;
        private List<Brush> ActivePositionBrushes;
        private KeyValuePair<Button, Brush> ActiveButton;
        private BoardController GameController;
        private bool WhiteTurn;
        private bool GameOver;

        private Thread thread2;

        public MainWindow()
        {
            InitializeComponent();
            ActiveBoard = new List<List<Square>>();
            BoardButtons = new List<List<Button>>();
            ActivePositions = new List<KeyValuePair<int, int>>();
            ActivePositionBrushes = new List<Brush>();
            GameController = new BoardController(this);
            WhiteTurn = true;
            cmbDifficulty.SelectedIndex = 0;
            prgTurnProgress.Visibility = Visibility.Hidden;
            SetStartingBoard();
        }

        private void Space00_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space00, new KeyValuePair<int, int>(0, 0));
        }

        private void Space01_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space01, new KeyValuePair<int, int>(0, 1));
        }

        private void Space02_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space02, new KeyValuePair<int, int>(0, 2));
        }

        private void Space03_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space03, new KeyValuePair<int, int>(0, 3));
        }

        private void Space04_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space04, new KeyValuePair<int, int>(0, 4));
        }

        private void Space05_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space05, new KeyValuePair<int, int>(0, 5));
        }

        private void Space06_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space06, new KeyValuePair<int, int>(0, 6));
        }

        private void Space07_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space07, new KeyValuePair<int, int>(0, 7));
        }

        private void Space10_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space10, new KeyValuePair<int, int>(1, 0));
        }

        private void Space11_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space11, new KeyValuePair<int, int>(1, 1));
        }

        private void Space12_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space12, new KeyValuePair<int, int>(1, 2));
        }

        private void Space13_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space13, new KeyValuePair<int, int>(1, 3));
        }

        private void Space14_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space14, new KeyValuePair<int, int>(1, 4));
        }

        private void Space15_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space15, new KeyValuePair<int, int>(1, 5));
        }

        private void Space16_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space16, new KeyValuePair<int, int>(1, 6));
        }

        private void Space17_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space17, new KeyValuePair<int, int>(1, 7));
        }

        private void Space20_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space20, new KeyValuePair<int, int>(2, 0));
        }

        private void Space21_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space21, new KeyValuePair<int, int>(2, 1));
        }

        private void Space22_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space22, new KeyValuePair<int, int>(2, 2));
        }

        private void Space23_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space23, new KeyValuePair<int, int>(2, 3));
        }

        private void Space24_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space24, new KeyValuePair<int, int>(2, 4));
        }

        private void Space25_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space25, new KeyValuePair<int, int>(2, 5));
        }

        private void Space26_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space26, new KeyValuePair<int, int>(2, 6));
        }

        private void Space27_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space27, new KeyValuePair<int, int>(2, 7));
        }

        private void Space30_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space30, new KeyValuePair<int, int>(3, 0));
        }

        private void Space31_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space31, new KeyValuePair<int, int>(3, 1));
        }

        private void Space32_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space32, new KeyValuePair<int, int>(3, 2));
        }

        private void Space33_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space33, new KeyValuePair<int, int>(3, 3));
        }

        private void Space34_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space34, new KeyValuePair<int, int>(3, 4));
        }

        private void Space35_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space35, new KeyValuePair<int, int>(3, 5));
        }

        private void Space36_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space36, new KeyValuePair<int, int>(3, 6));
        }

        private void Space37_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space37, new KeyValuePair<int, int>(3, 7));
        }

        private void Space40_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space40, new KeyValuePair<int, int>(4, 0));
        }

        private void Space41_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space41, new KeyValuePair<int, int>(4, 1));
        }

        private void Space42_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space42, new KeyValuePair<int, int>(4, 2));
        }

        private void Space43_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space43, new KeyValuePair<int, int>(4, 3));
        }

        private void Space44_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space44, new KeyValuePair<int, int>(4, 4));
        }

        private void Space45_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space45, new KeyValuePair<int, int>(4, 5));
        }

        private void Space46_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space46, new KeyValuePair<int, int>(4, 6));
        }

        private void Space47_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space47, new KeyValuePair<int, int>(4, 7));
        }

        private void Space50_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space50, new KeyValuePair<int, int>(5, 0));
        }

        private void Space51_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space51, new KeyValuePair<int, int>(5, 1));
        }

        private void Space52_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space52, new KeyValuePair<int, int>(5, 2));
        }

        private void Space53_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space53, new KeyValuePair<int, int>(5, 3));
        }

        private void Space54_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space54, new KeyValuePair<int, int>(5, 4));
        }

        private void Space55_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space55, new KeyValuePair<int, int>(5, 5));
        }

        private void Space56_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space56, new KeyValuePair<int, int>(5, 6));
        }

        private void Space57_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space57, new KeyValuePair<int, int>(5, 7));
        }

        private void Space60_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space60, new KeyValuePair<int, int>(6, 0));
        }

        private void Space61_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space61, new KeyValuePair<int, int>(6, 1));
        }

        private void Space62_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space62, new KeyValuePair<int, int>(6, 2));
        }

        private void Space63_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space63, new KeyValuePair<int, int>(6, 3));
        }

        private void Space64_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space64, new KeyValuePair<int, int>(6, 4));
        }

        private void Space65_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space65, new KeyValuePair<int, int>(6, 5));
        }

        private void Space66_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space66, new KeyValuePair<int, int>(6, 6));
        }

        private void Space67_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space67, new KeyValuePair<int, int>(6, 7));
        }

        private void Space70_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space70, new KeyValuePair<int, int>(7, 0));
        }

        private void Space71_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space71, new KeyValuePair<int, int>(7, 1));
        }

        private void Space72_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space72, new KeyValuePair<int, int>(7, 2));
        }

        private void Space73_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space73, new KeyValuePair<int, int>(7, 3));
        }

        private void Space74_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space74, new KeyValuePair<int, int>(7, 4));
        }

        private void Space75_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space75, new KeyValuePair<int, int>(7, 5));
        }

        private void Space76_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space76, new KeyValuePair<int, int>(7, 6));
        }

        private void Space77_Click(object sender, RoutedEventArgs e)
        {
            GeneralClick(Space77, new KeyValuePair<int, int>(7, 7));
        }

        private void SetStartingBoard()
        {
            //button setup
            BoardButtons.Add(new List<Button>() { Space00, Space01, Space02, Space03, Space04, Space05, Space06, Space07 });
            BoardButtons.Add(new List<Button>() { Space10, Space11, Space12, Space13, Space14, Space15, Space16, Space17 });
            BoardButtons.Add(new List<Button>() { Space20, Space21, Space22, Space23, Space24, Space25, Space26, Space27 });
            BoardButtons.Add(new List<Button>() { Space30, Space31, Space32, Space33, Space34, Space35, Space36, Space37 });
            BoardButtons.Add(new List<Button>() { Space40, Space41, Space42, Space43, Space44, Space45, Space46, Space47 });
            BoardButtons.Add(new List<Button>() { Space50, Space51, Space52, Space53, Space54, Space55, Space56, Space57 });
            BoardButtons.Add(new List<Button>() { Space60, Space61, Space62, Space63, Space64, Space65, Space66, Space67 });
            BoardButtons.Add(new List<Button>() { Space70, Space71, Space72, Space73, Space74, Space75, Space76, Space77 });

            //board setup
            for (int i = 0; i < 8; i++)
            {
                ActiveBoard.Add(new List<Square>());

                for(int j = 0; j < 8; j++)
                {
                    ActiveBoard[i].Add(new Square());
                }
            }

            //black setup
            ActiveBoard[0][0].OccupiedPiece = new Rook(Objects.Color.BLACK, new KeyValuePair<int, int>(0, 0));
            ActiveBoard[0][1].OccupiedPiece = new Knight(Objects.Color.BLACK, new KeyValuePair<int, int>(0, 1));
            ActiveBoard[0][2].OccupiedPiece = new Bishop(Objects.Color.BLACK, new KeyValuePair<int, int>(0, 2));
            ActiveBoard[0][3].OccupiedPiece = new Queen(Objects.Color.BLACK, new KeyValuePair<int, int>(0, 3));
            ActiveBoard[0][4].OccupiedPiece = new King(Objects.Color.BLACK, new KeyValuePair<int, int>(0, 4));
            ActiveBoard[0][5].OccupiedPiece = new Bishop(Objects.Color.BLACK, new KeyValuePair<int, int>(0, 5));
            ActiveBoard[0][6].OccupiedPiece = new Knight(Objects.Color.BLACK, new KeyValuePair<int, int>(0, 6));
            ActiveBoard[0][7].OccupiedPiece = new Rook(Objects.Color.BLACK, new KeyValuePair<int, int>(0, 7));
            ActiveBoard[1][0].OccupiedPiece = new Pawn(Objects.Color.BLACK, new KeyValuePair<int, int>(1, 0));
            ActiveBoard[1][1].OccupiedPiece = new Pawn(Objects.Color.BLACK, new KeyValuePair<int, int>(1, 1));
            ActiveBoard[1][2].OccupiedPiece = new Pawn(Objects.Color.BLACK, new KeyValuePair<int, int>(1, 2));
            ActiveBoard[1][3].OccupiedPiece = new Pawn(Objects.Color.BLACK, new KeyValuePair<int, int>(1, 3));
            ActiveBoard[1][4].OccupiedPiece = new Pawn(Objects.Color.BLACK, new KeyValuePair<int, int>(1, 4));
            ActiveBoard[1][5].OccupiedPiece = new Pawn(Objects.Color.BLACK, new KeyValuePair<int, int>(1, 5));
            ActiveBoard[1][6].OccupiedPiece = new Pawn(Objects.Color.BLACK, new KeyValuePair<int, int>(1, 6));
            ActiveBoard[1][7].OccupiedPiece = new Pawn(Objects.Color.BLACK, new KeyValuePair<int, int>(1, 7));

            //white setup
            ActiveBoard[7][0].OccupiedPiece = new Rook(Objects.Color.WHITE, new KeyValuePair<int, int>(7, 0));
            ActiveBoard[7][1].OccupiedPiece = new Knight(Objects.Color.WHITE, new KeyValuePair<int, int>(7, 1));
            ActiveBoard[7][2].OccupiedPiece = new Bishop(Objects.Color.WHITE, new KeyValuePair<int, int>(7, 2));
            ActiveBoard[7][3].OccupiedPiece = new Queen(Objects.Color.WHITE, new KeyValuePair<int, int>(7, 3));
            ActiveBoard[7][4].OccupiedPiece = new King(Objects.Color.WHITE, new KeyValuePair<int, int>(7, 4));
            ActiveBoard[7][5].OccupiedPiece = new Bishop(Objects.Color.WHITE, new KeyValuePair<int, int>(7, 5));
            ActiveBoard[7][6].OccupiedPiece = new Knight(Objects.Color.WHITE, new KeyValuePair<int, int>(7, 6));
            ActiveBoard[7][7].OccupiedPiece = new Rook(Objects.Color.WHITE, new KeyValuePair<int, int>(7, 7));
            ActiveBoard[6][0].OccupiedPiece = new Pawn(Objects.Color.WHITE, new KeyValuePair<int, int>(6, 0));
            ActiveBoard[6][1].OccupiedPiece = new Pawn(Objects.Color.WHITE, new KeyValuePair<int, int>(6, 1));
            ActiveBoard[6][2].OccupiedPiece = new Pawn(Objects.Color.WHITE, new KeyValuePair<int, int>(6, 2));
            ActiveBoard[6][3].OccupiedPiece = new Pawn(Objects.Color.WHITE, new KeyValuePair<int, int>(6, 3));
            ActiveBoard[6][4].OccupiedPiece = new Pawn(Objects.Color.WHITE, new KeyValuePair<int, int>(6, 4));
            ActiveBoard[6][5].OccupiedPiece = new Pawn(Objects.Color.WHITE, new KeyValuePair<int, int>(6, 5));
            ActiveBoard[6][6].OccupiedPiece = new Pawn(Objects.Color.WHITE, new KeyValuePair<int, int>(6, 6));
            ActiveBoard[6][7].OccupiedPiece = new Pawn(Objects.Color.WHITE, new KeyValuePair<int, int>(6, 7));

            //empty setup
            for(int i = 2; i < 6; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    ActiveBoard[i][j].OccupiedPiece = null;
                }
            }

            UpdateBoard(ActiveBoard);
        }

        private void GeneralClick(Button button, KeyValuePair<int, int> position)
        {
            if (ActiveBoard[position.Key][position.Value].OccupiedPiece != null && ActiveBoard[position.Key][position.Value].OccupiedPiece.PieceColor == Objects.Color.BLACK && ActivePiece.Key == null)
            {
                return;
            }

            if (!WhiteTurn)
            {
                return;
            }

            if (ActiveButton.Key == button)
            {
                CancelMove();
            }
            else if (ActivePiece.Key != null)
            {
                if(((SolidColorBrush)button.Background).Color != Colors.Red && ((SolidColorBrush)button.Background).Color != Colors.Aqua && ((SolidColorBrush)button.Background).Color != Colors.LightGreen)
                {
                    return;
                }

                UpdateBoard(GameController.MovePiece(ActiveBoard, new KeyValuePair<int, int>((int)ActivePiece.Key, ActivePiece.Value), new KeyValuePair<int, int>(position.Key, position.Value)));
                GameController.WhiteFirstTurn = false;
                CancelMove();

                if (!GameOver)
                {
                    if (ActiveBoard[position.Key][position.Value].OccupiedPiece.GetType() == typeof(Pawn) && ActiveBoard[position.Key][position.Value].OccupiedPiece.firstTurn)
                    {
                        ActiveBoard[position.Key][position.Value].OccupiedPiece.firstTurn = false;
                    }

                    WhiteTurn = false;
                    txtCurrentTurn.Text = "Black";
                    prgTurnProgress.Visibility = Visibility.Visible;
                    int difficultySelecter = (cmbDifficulty.SelectedIndex + 1) * 2;
                    thread2 = new Thread(() => { UpdateBoard(GameController.StartBlackTurn(ActiveBoard, difficultySelecter)); });
                    thread2.Start();
                }
                
            }
            else if(ActiveBoard[position.Key][position.Value].OccupiedPiece == null)
            {
                return;
            }
            else
            {
                ShowMoveOptions(ActiveBoard[position.Key][position.Value].OccupiedPiece.GetValidMoves(ActiveBoard), BoardButtons[position.Key][position.Value], new KeyValuePair<int, int>(position.Key, position.Value));
            }
        }

        private void ShowMoveOptions(List<KeyValuePair<int, int>> validMoves, Button currentButton, KeyValuePair<int, int> buttonPosition)
        { 
            ActivePositions = validMoves;
            foreach(KeyValuePair<int, int> position in validMoves)
            {
                ActivePositionBrushes.Add(BoardButtons[position.Key][position.Value].Background);

                if(ActiveBoard[position.Key][position.Value].OccupiedPiece != null)
                {
                    BoardButtons[position.Key][position.Value].Background = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    BoardButtons[position.Key][position.Value].Background = new SolidColorBrush(Colors.Aqua);
                } 
            }

            ActiveButton = new KeyValuePair<Button, Brush>(currentButton, currentButton.Background);
            currentButton.Background = new SolidColorBrush(Colors.LightGreen);

            //set active piece
            ActivePiece = new KeyValuePair<int?, int>(buttonPosition.Key, buttonPosition.Value);
        }

        private void CancelMove()
        {
            //enables all buttons
            foreach (List<Button> buttonList in BoardButtons)
            {
                foreach (Button button in buttonList)
                {
                    button.IsEnabled = true;
                }
            }

            //set button colors to original colors
            for(int i = 0; i < ActivePositions.Count(); i++)
            {
                BoardButtons[ActivePositions[i].Key][ActivePositions[i].Value].Background = ActivePositionBrushes[i];
            }

            ActiveButton.Key.Background = ActiveButton.Value;

            //clear variables
            ActivePositions.Clear();
            ActivePositionBrushes.Clear();
            ActiveButton = new KeyValuePair<Button, Brush>();
            ActivePiece = new KeyValuePair<int?, int>();
        }

        public void UpdateBoard(List<List<Square>> board)
        {
            bool whiteKingDead = true;
            bool blackKingDead = true;

            if (Thread.CurrentThread == thread2)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    txtCurrentTurn.Text = "White";
                    prgTurnProgress.Value = 0;
                    prgTurnProgress.Visibility = Visibility.Hidden;
                    UpdateBoard(board);
                });

                WhiteTurn = true;

                return;
            }

            ActiveBoard = board;
            
            //set each button to appropriate chess piece image
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i][j].OccupiedPiece != null)
                    {
                        Image tempImage = new Image();
                        Uri uriSource = new Uri(board[i][j].OccupiedPiece.PieceImage, UriKind.Relative);
                        tempImage.Source = new BitmapImage(uriSource);

                        BoardButtons[i][j].Content = tempImage;

                        if (board[i][j].OccupiedPiece.GetType() == typeof(King))
                        {
                            if(board[i][j].OccupiedPiece.PieceColor == Objects.Color.WHITE)
                            {
                                whiteKingDead = false;
                            }
                            else
                            {
                                blackKingDead = false;
                            }
                            
                        }
                    }
                    else
                    {

                        BoardButtons[i][j].Content = null;
                    }
                }
            }

            if(whiteKingDead || blackKingDead)
            {
                GameOver = true;
                EndGame();
            }
        }

        private void EndGame()
        {
            foreach (List<Button> buttonList in BoardButtons)
            {
                foreach (Button button in buttonList)
                {
                    button.IsEnabled = false;
                }
            }

            txtGameOver.Visibility = Visibility.Visible;
            btnNewGame.Visibility = Visibility.Visible;
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            txtGameOver.Visibility = Visibility.Hidden;
            btnNewGame.Visibility = Visibility.Hidden;

            GameController.WhiteFirstTurn = true;
            GameOver = false;

            foreach (List<Button> buttonList in BoardButtons)
            {
                foreach (Button button in buttonList)
                {
                    button.IsEnabled = true;
                }
            }

            SetStartingBoard();
        }
    }
}
