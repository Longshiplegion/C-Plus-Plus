using Milestone3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Milestone5
{
    public partial class GameForm : Form
    {
        public Board Board;
        public string difficulty;
        public Button[,] buttons;
        public int BoardSize = 0;
        public int NumVisitedNonMines = 0;
        public Stopwatch stopwatch;
        public List<PlayerStats> HighScores = new List<PlayerStats>();
        public string playerInitials;
        public GameForm(string difficulty)
        {
            InitializeComponent();
            this.difficulty = difficulty;
            populateGrid(difficulty);
            stopwatch = new Stopwatch();
            stopwatch.Start();



        }
        public void populateGrid(string difficulty)
        {

            int BoardSize;
            switch (difficulty)
            {
                case "Easy":
                    BoardSize = 4;
                    Board = new Board(BoardSize);
                    Board.SetupLiveNeighbors(0.1);
                    Board.CalculateLiveNeighbors();

                    break;
                case "Medium":
                    BoardSize = 8;
                    Board = new Board(BoardSize);
                    Board.SetupLiveNeighbors(0.4);
                    Board.CalculateLiveNeighbors();

                    break;
                case "Hard":
                    BoardSize = 16;
                    Board = new Board(BoardSize);
                    Board.SetupLiveNeighbors(0.7);
                    Board.CalculateLiveNeighbors();

                    break;
                default:
                    BoardSize = 4;
                    Board = new Board(BoardSize);
                    Board.SetupLiveNeighbors(0.2);
                    Board.CalculateLiveNeighbors();

                    break;
            }

            buttons = new Button[BoardSize, BoardSize];

            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    Button button = new Button();
                    button.Size = new Size(30, 30);
                    button.Location = new Point(35 * col, 35 * row);
                    button.Tag = new Point(row, col); // Store the button's location in its Tag property
                    button.MouseUp += Button_MouseUp;
                    panel1.Controls.Add(button);
                    buttons[row, col] = button;
                }
            }

        }
        public void Button_MouseUp(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            Point location = (Point)button.Tag;
            int row = location.X;
            int col = location.Y;

            if (e.Button == MouseButtons.Left)
            {
                if (Board.Grid[row, col].Live)
                {
                    // Handle losing the game
                    foreach (Button btn in panel1.Controls)
                    {
                        Point loc = (Point)btn.Tag;
                        int r = loc.X;
                        int c = loc.Y;
                        if (Board.Grid[r, c].Live)
                        {
                            btn.BackgroundImage = Properties.Resources.Bomb;
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                    }
                    MessageBox.Show("You hit a live cell! Game over.");


                    PlayAgain.Visible = true;
                }
                else
                {
                    Board.FloodFill(row, col);
                    UpdateButtons(Board);
                    if (Board.AllNonLiveCellsVisited())
                    {
                        stopwatch.Stop();
                        TimeSpan elapsedTime = stopwatch.Elapsed;
                        MessageBox.Show($"You won the game in {elapsedTime.TotalSeconds:0.##} seconds!");
                        label1.Visible = true;
                        InitialTextBox.Visible = true;
                        SubmitButton.Visible = true;
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (!Board.Grid[row, col].Visited)
                {
                    Board.Grid[row, col].Visited = true;
                    button.BackgroundImage = Properties.Resources.Flag;
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else
                {
                    Board.Grid[row, col].Visited = false;
                    button.BackgroundImage = null;
                }
            }
        }
        public void UpdateButtons(Board board)
        {
            bool allNonMinesVisited = board.AllNonLiveCellsVisited();

            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    Button button = buttons[row, col];
                    Cell cell = Board.Grid[row, col];

                    if (cell.Visited)
                    {
                        if (cell.Live)
                        {
                            button.BackColor = Color.Red;
                        }
                        else
                        {
                            button.Text = cell.LiveNeighbors.ToString();
                            button.BackColor = Color.LightGray;
                        }
                    }
                    else if (allNonMinesVisited && cell.Live)
                    {
                        button.BackgroundImage = Properties.Resources.Flag;
                        button.BackgroundImageLayout = ImageLayout.Stretch;

                    }
                }
            }
        }

        public void ResetGame()
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Focus();
        }

        private void PlayAgain_Click(object sender, EventArgs e)
        {
            ResetGame();
        }
 

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            playerInitials = InitialTextBox.Text;
            PlayerStats currentGameStats = new PlayerStats(playerInitials, this.difficulty, stopwatch.Elapsed);

            HighScores.Add(currentGameStats);

            // Save the high scores list to a file
            string fileName = "highscores.txt";
            using (StreamWriter writer = new StreamWriter(fileName, append: true)) // Use append: true to always append to the file
            {
                foreach (PlayerStats stats in HighScores)
                {
                    writer.WriteLine($"{stats.Initials},{stats.Difficulty},{stats.ElapsedTime}");
                }
            }
            this.Close();
            HighScore highScore = new HighScore();
            highScore.Show();


        }
    }


}
