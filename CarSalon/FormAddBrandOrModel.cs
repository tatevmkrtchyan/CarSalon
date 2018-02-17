using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarSalon
{
    public partial class FormAddBrandOrModel : Form
    {
        public System.Windows.Forms.Label lblBrandOrModel;

        public FormAddBrandOrModel()
        {
            InitializeComponent();
        }

        private void FormAddBrandOrModel_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.textBox.Text != null)
            {
                if (lblBrandOrModel.Text == "Brand name")
                {
                    Brand.AddBrand(this.textBox.Text?.ToString());
                    this.Close();
                }
                else
                    if (lblBrandOrModel.Text == "Model name")
                {
                     Model.AddModel(Brand.GetBrandID(FormAddCar.SelectedBrandName),this.textBox.Text.ToString());
                     this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.textBox.Clear();
            this.Close();
        }
    }
}
