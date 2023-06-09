using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarStoreGUI
{
    public partial class Form1 : Form
    {
        Store store = new Store();
        BindingSource carListBinding = new BindingSource();
        BindingSource shoppingListBinding = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            setBindings();
        }

        public void setBindings()
        {
            carListBinding.DataSource = store.CarList;
            listBox1.DataSource = carListBinding;
            listBox1.DisplayMember = "Display";
            listBox1.ValueMember = "Display";

            shoppingListBinding.DataSource = store.ShoppingList;
            listBox2.DataSource = shoppingListBinding;
            listBox2.DisplayMember = "Display";
            listBox2.ValueMember = "Display";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Car newCar = new Car();
                newCar.Make = textBox1.Text;
                newCar.Model = textBox2.Text;
                newCar.Price = Decimal.Parse(textBox3.Text);
                newCar.Miles = int.Parse(textBox5.Text);
                newCar.Year = int.Parse(textBox4.Text);
                store.CarList.Add(newCar);
            }
            catch (Exception ex)
            {
               
            }
            carListBinding.ResetBindings(false);
            }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            store.ShoppingList.Add((Car)listBox1.SelectedItem);
            shoppingListBinding.ResetBindings(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            decimal total = store.checkout();
            label5.Text = total.ToString();
        }
    }
}
