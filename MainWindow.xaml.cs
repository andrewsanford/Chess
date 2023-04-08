using Chess.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
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

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Button? ActiveButton;
        private List<List<Square>> ActiveBoard;
        private List<List<Button>> BoardButtons;
        private List<KeyValuePair<int, int>> ActivePositions;
        private List<Brush> ActivePositionBrushes;
        private KeyValuePair<Button, Brush> ActivePiece;

        public MainWindow()
        {
            InitializeComponent();
            ActiveBoard = new List<List<Square>>();
            BoardButtons = new List<List<Button>>();
            ActivePositions = new List<KeyValuePair<int, int>>();
            ActivePositionBrushes = new List<Brush>();
            SetStartingBoard();
        }

        private void Space00_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space01_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space02_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space03_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space04_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space05_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space06_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space07_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space10_Click(object sender, RoutedEventArgs e)
        {
            if(ActivePiece.Key == Space10)
            {
                CancelMove();
            }
            else
            {
                ShowMoveOptions(ActiveBoard[1][0].OccupiedPiece.GetValidMoves(ActiveBoard), BoardButtons[1][0]);
            }
            
        }

        private void Space11_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space12_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space13_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space14_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space15_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space16_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space17_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space20_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space21_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space22_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space23_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space24_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space25_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space26_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space27_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space30_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space31_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space32_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space33_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space34_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space35_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space36_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space37_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space40_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space41_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space42_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space43_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space44_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space45_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space46_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space47_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space50_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space51_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space52_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space53_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space54_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space55_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space56_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space57_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space60_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space61_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space62_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space63_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space64_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space65_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space66_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space67_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space70_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space71_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space72_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space73_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space74_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space75_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space76_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Space77_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GeneralClick(Button selectedButton, int row, int column)
        {
            if(ActiveButton == null)
            {
                ActiveButton = selectedButton;

            }
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

            UpdateBoard(ActiveBoard);
        }

        private void ShowMoveOptions(List<KeyValuePair<int, int>> validMoves, Button currentButton)
        {
            //disables all buttons
            foreach(List<Button> buttonList in BoardButtons)
            {
                foreach (Button button in buttonList)
                {
                    button.IsEnabled = false;
                }
            }

            //re-enables relevant buttons
            ActivePositions = validMoves;
            foreach(KeyValuePair<int, int> position in validMoves)
            {
                BoardButtons[position.Key][position.Value].IsEnabled = true;
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

            currentButton.IsEnabled = true;
            ActivePiece = new KeyValuePair<Button, Brush>(currentButton, currentButton.Background);
            currentButton.Background = new SolidColorBrush(Colors.LightGreen);
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

            ActivePiece.Key.Background = ActivePiece.Value;

            //clear variables
            ActivePositions.Clear();
            ActivePositionBrushes.Clear();
            ActivePiece = new KeyValuePair<Button, Brush>();
        }

        public void UpdateBoard(List<List<Square>> board)
        {
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
                    }
                    else
                    {
                        BoardButtons[i][j].Content = null;
                    }
                }
            }
        }


    }
}
