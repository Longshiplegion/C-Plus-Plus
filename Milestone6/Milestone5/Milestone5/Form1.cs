namespace Milestone5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string difficulty = difficultyComboBox.SelectedItem.ToString();
            GameForm gameForm = new GameForm(difficulty);
            gameForm.Show();
        }
    }
}