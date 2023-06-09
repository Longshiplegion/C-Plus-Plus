using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HeroMaker1
{
    // Define a new form called SuperheroListForm

    public partial class SuperheroListForm : Form
    {
        // Declare a private reference to the SuperHeroList
        private SuperHeroList heroList;

        public SuperheroListForm(SuperHeroList heroList)
        {
            InitializeComponent();

            // Save a reference to the SuperHeroList
            this.heroList = heroList;
        }

        private void SuperheroListForm_Load(object sender, EventArgs e)
        {
            // Populate the list box with the names of the superheroes
            foreach (SuperHero hero in heroList.HeroList)
            {
                listBox1.Items.Add(hero.Name);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Retrieve the selected superhero and display their details
            SuperHero selectedHero = heroList.HeroList[listBox1.SelectedIndex];
            richTextBox1.Text = selectedHero.ToString();
        }
    }

}
