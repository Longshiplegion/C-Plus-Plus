using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milestone5
{
    public partial class HighScore : Form
    {
        public const string filename = "highscores.txt";
        public Dictionary<string, List<PlayerStats>> highScores;
        public HighScore()
        {
            InitializeComponent();
            highScores = new Dictionary<string, List<PlayerStats>>();
            LoadScoresFromFile(filename);
            DisplayHighScores();

        }
        public void LoadScoresFromFile(string fileName)
        {
            if (File.Exists(filename))
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] fields = line.Split(',');
                        if (fields.Length == 3)
                        {
                            string initials = fields[0];
                            string difficulty = fields[1];
                            TimeSpan TimeElapsed = TimeSpan.Parse(fields[2]);


                            PlayerStats stats = new PlayerStats(initials, difficulty, TimeElapsed);

                            if (highScores.ContainsKey(difficulty))
                            {
                                highScores[difficulty].Add(stats);
                            }
                            else
                            {
                                highScores[difficulty] = new List<PlayerStats> { stats };
                            }
                        }
                    }
                }
            }
        }
        public void DisplayHighScores()
        {
            foreach (string difficulty in highScores.Keys)
            {
                List<PlayerStats> statsList = highScores[difficulty];



                switch (difficulty)
                {
                    case "Easy":
                        List<PlayerStats> topScoresEasy = highScores[difficulty].Where(hs => hs.Difficulty == "Easy")
                              .OrderBy(hs => hs.ElapsedTime)
                              .Take(5)
                              .ToList();
                        listBox1.DataSource = topScoresEasy;
                        listBox1.DisplayMember = "DisplayString";
                        break;
                    case "Medium":
                        List<PlayerStats> topScoresMedium = highScores[difficulty].Where(hs => hs.Difficulty == "Easy")
                            .OrderBy(hs => hs.ElapsedTime)
                            .Take(5)
                            .ToList();
                        listBox1.DataSource = topScoresMedium;
                        listBox1.DisplayMember = "DisplayString";
                        break;
                    case "Hard":
                        List<PlayerStats> topScoresHard = highScores[difficulty].Where(hs => hs.Difficulty == "Easy")
                             .OrderBy(hs => hs.ElapsedTime)
                             .Take(5)
                             .ToList();
                        listBox1.DataSource = topScoresHard;
                        listBox1.DisplayMember = "DisplayString";
                        break;
                }


            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void ResetGame()
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Focus();
        }

        private void PlayAgainButton_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
