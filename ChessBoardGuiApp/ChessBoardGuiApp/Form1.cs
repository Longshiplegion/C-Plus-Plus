using ChessBoardModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessBoardGuiApp
{
    public partial class Form1 : Form
    {
        static public Board myBoard = new Board(8);
        public Button[,] bttnGrid = new Button[myBoard.Size, myBoard.Size];
        public Form1()
        {
            InitializeComponent();
            populateGrid();
        }
        public void populateGrid()
        {
            int buttonSize = panel1.Width / myBoard.Size;
            panel1.Height = panel1.Width;

            for(int r = 0; r < myBoard.Size; r++)
            {
                for (int c = 0; c < myBoard.Size; c++)
                {
                    bttnGrid[r, c] = new Button();
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
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a chess piece.");
                return;
            }
            String[] strArr = (sender as Button).Tag.ToString().Split("|");
            int r, c;
            try
            {
                r = int.Parse(strArr[0]);
                c = int.Parse(strArr[1]);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid button tag format: " + ex.Message);
                return;
            }
            if (r >= 0 && r < myBoard.Size && c >= 0 && c < myBoard.Size)
            {
                Cell currentCell = myBoard.theGrid[r, c];
                myBoard.MarkNextLegalMove(currentCell, comboBox1.Text);
                updateButtonLabels();

                for (int i = 0; i < myBoard.Size; i++)
                {
                    for (int j = 0; j < myBoard.Size; j++)
                    {
                        bttnGrid[i, j].BackColor = default(Color);
                    }
                }
                    (sender as Button).BackColor = Color.Cornsilk;
            }
            
        }
        public void updateButtonLabels()
        {
            for (int r = 0; r < myBoard.Size; r++)
            {
                for (int c = 0; c < myBoard.Size; c++)
                {
                    bttnGrid[r, c].Text = "";
                    if (myBoard.theGrid[r, c].CurrentlyOccupied) bttnGrid[r, c].Text = comboBox1.Text;
                    if (myBoard.theGrid[r, c].LegalNextMove) bttnGrid[r, c].Text = "Legal";
                }
            }
        }
    }
}
