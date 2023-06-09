using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeroMaker1
{
    public partial class Form1 : Form
    {
        private Color capeColor;
        SuperHeroList heroList = new SuperHeroList();
        public Form1()
        {
            InitializeComponent();

        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                capeColor = colorDialog.Color;
                pictureBoxCapeColor.BackColor = capeColor;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize the list box for office locations
            listBoxLocations.Items.AddRange(new object[] {
                "New York City",
                "Gotham City",
                "Metropolis",
                "Central City",
                "Star City",
                "Atlantis",
                "Themyscira",
                "Wakanda"
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check for errors
            if (string.IsNullOrWhiteSpace(textBoxHeroName.Text))
            {
                MessageBox.Show("Please enter a valid hero name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool atLeastOneHeroPowerChecked = false;
            foreach (Control control in groupBoxPowers.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    atLeastOneHeroPowerChecked = true;
                    break;
                }
            }
            if (!atLeastOneHeroPowerChecked)
            {
                MessageBox.Show("Please select at least one hero power.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (listBoxLocations.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an office location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!groupBoxTransportation.Controls.OfType<RadioButton>().Any(x => x.Checked))
            {
                MessageBox.Show("Please select a preferred transportation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int totalPoints = scrollBarSpeed.Value + scrollBarStamina.Value + scrollBarStrength.Value;
            if (totalPoints > 100)
            {
                MessageBox.Show("The total points for speed, stamina, and strength cannot exceed 100.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (numericUpDownYearsOfExperience.Value < 0)
            {
                MessageBox.Show("Years of experience must be a positive integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SuperHero myHero = new SuperHero();
            myHero.Name = textBoxHeroName.Text;
            myHero.Powers = new List<string>();
            foreach (Control control in groupBoxPowers.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    myHero.Powers.Add(checkBox.Text);
                }
            }
            myHero.OfficeLocation = (string)listBoxLocations.SelectedItem;
            myHero.PreferredTransportation = groupBoxTransportation.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked)?.Text;
            myHero.Speed = scrollBarSpeed.Value;
            myHero.Stamina = scrollBarStamina.Value;
            myHero.Strength = scrollBarStrength.Value;
            myHero.Birthday = dateTimePickerBirthday.Value;
            myHero.SuperpowerDiscoveryDate = dateTimePickerSuperpowerDiscovery.Value;
            myHero.FatefulDate = dateTimePickerFatefulDate.Value;
            myHero.YearsOfExperience = (int)numericUpDownYearsOfExperience.Value;
            myHero.CapeColor = pictureBoxCapeColor.BackColor;

            heroList.HeroList.Add(myHero);

            // Hide Form1
            this.Hide();

            // Show Form2
            SuperheroListForm superheroListForm = new SuperheroListForm(heroList);
            superheroListForm.Show();
        }





        private void UpdateLabelValue(Label label, ScrollBar scrollBar)
        {

            label.Text = scrollBar.Value.ToString();

        }
        private void UpdateSliders()
        {
            try
            {
                int total = scrollBarStamina.Value + scrollBarStamina.Value + scrollBarStrength.Value;

                if (total > 100)
                {
                    int diff = total - 100;

                    // find the highest value slider and decrease it
                    if (scrollBarStamina.Value > scrollBarStamina.Value && scrollBarStamina.Value > scrollBarStrength.Value)
                    {
                        scrollBarStamina.Value -= diff;
                    }
                    else if (scrollBarStamina.Value > scrollBarStamina.Value && scrollBarStamina.Value > scrollBarStrength.Value)
                    {
                        scrollBarStamina.Value -= diff;
                    }
                    else
                    {
                        scrollBarStrength.Value -= diff;
                    }
                }
            }catch(Exception e)
            {

            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            // Display a confirmation message box
            DialogResult result = MessageBox.Show("Are you sure you want to cancel and reset the form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If the user clicked "Yes", reset all of the controls to their initial state
            if (result == DialogResult.Yes)
            {
                textBoxHeroName.Text = "";

                foreach (Control control in groupBoxPowers.Controls)
                {
                    if (control is CheckBox checkBox)
                    {
                        checkBox.Checked = false;
                    }
                }

                listBoxLocations.SelectedIndex = 0;

                foreach (Control control in groupBoxTransportation.Controls)
                {
                    if (control is RadioButton radioButton)
                    {
                        radioButton.Checked = false;
                    }
                }

                scrollBarSpeed.Value = 50;
                labelSpeedValue.Text = "50";

                scrollBarStamina.Value = 25;
                labelStaminaValue.Text = "25";

                scrollBarStrength.Value = 25;
                labelStrengthValue.Text = "25";

                dateTimePickerBirthday.Value = DateTime.Now;
                dateTimePickerSuperpowerDiscovery.Value = DateTime.Now;
                dateTimePickerFatefulDate.Value = DateTime.Now;

                numericUpDownYearsOfExperience.Value = 0;

                pictureBoxCapeColor.BackColor = Color.White;
            }
        }

        private void scrollBarStrength_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateLabelValue(labelStrengthValue, scrollBarStrength);
            UpdateSliders();
        }

        private void scrollBarStamina_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateLabelValue(labelStaminaValue, scrollBarStamina);
            UpdateSliders();
        }

        private void scrollBarSpeed_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateLabelValue(labelSpeedValue, scrollBarSpeed);
            UpdateSliders();
        }
    }
    }

        