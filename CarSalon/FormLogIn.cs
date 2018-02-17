using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarSalon
{
    public partial class FormLogIn : Form
    {
        public FormLogIn()
        {
            InitializeComponent();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            FormAdmin form = new FormAdmin();
            form.ShowDialog();
        }

        private void FormLogIn_Load(object sender, EventArgs e)
        {
            foreach (var item in Car.GetCars())
            {
                listBox1.Items.Add($"{item.Model.Brand.Name},{item.Model.Name},{item.Color},{item.Color},{item.Year},{item.Price}");
            }

           // listBox1.Items.Add(Brand.GetBrandID("Audi"));

        }
    }
}
