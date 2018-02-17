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
    public partial class FormAdmin : Form
    {
        public DataTable table = new DataTable();

        public FormAdmin()
        {
            InitializeComponent();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddCar form = new FormAddCar();
            form.ShowDialog();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Brand", typeof(string));
            table.Columns.Add("Model", typeof(string));
            table.Columns.Add("Color", typeof(string));
            table.Columns.Add("Date", typeof(int));
            table.Columns.Add("Price", typeof(decimal));

            //dataGridView.DataSource = ReadAndWriteFile.Load();

            //comboBoxBrand.Text = "Select Brand";
            //comboBoxModel.Text = "Select Model";

            //foreach (Brand item in ReadAndWriteFile.GetBrands())
            //{
            //    comboBoxBrand.Items.Add(item.Name);
            //}
        }
    }
}
