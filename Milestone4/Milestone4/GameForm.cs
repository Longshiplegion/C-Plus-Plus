using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Milestone4
{
    public partial class GameForm : Form
    {
        private string difficulty;
        private int counter = 0;
        static public Board myBoard;
        public System.Windows.Forms.Button[,] bttnGrid;

        public GameForm(string difficulty)
        {
            InitializeComponent();
            this.difficulty = difficulty;
            int Boardsize;
            switch (difficulty)
            {
                case "Easy":
                    Boardsize = 8;
                    break;
                case "Medium":
                    Boardsize = 16;
                    break;
                case "Hard":
                    Boardsize = 32;
                    break;
                default:
                    Boardsize = 8;
                    break;
            }
            myBoard = new Board(Boardsize);
            bttnGrid = new System.Windows.Forms.Button[myBoard.Size, myBoard.Size];
            populateGrid();
        }



        public void populateGrid()
        {
            int buttonSize = panel1.Width / myBoard.Size;
            panel1.Height = panel1.Width;

            for (int r = 0; r < myBoard.Size; r++)
            {
                for (int c = 0; c < myBoard.Size; c++)
                {
                    bttnGrid[r, c] = new System.Windows.Forms.Button();
                    bttnGrid[r, c].Width = buttonSize;
                    bttnGrid[r, c].Height = buttonSize;
                    bttnGrid[r, c].Click += Grid_Button_Click;
                    panel1.Controls.Add(bttnGrid[r, c]);
                    bttnGrid[r, c].Location = new Point(buttonSize * r, buttonSize * c);
                    bttnGrid[r, c].Tag = r.ToString() + "|" + c.ToString();
                }
            }
        }



        private void Grid_Button_Click(object sender, EventArgs e)
        {


            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    bttnGrid[i, j].BackColor = default(Color);
                }
            }
                    (sender as System.Windows.Forms.Button).BackColor = Color.Cornsilk;
        }

    }

}



