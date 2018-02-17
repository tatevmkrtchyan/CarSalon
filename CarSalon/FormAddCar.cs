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
    public partial class FormAddCar : Form
    {
        public static string SelectedBrandName = "";

        public FormAddCar()
        {
            InitializeComponent();
        }

        public void FormAddCar_Load(object sender, EventArgs e)
        { 
            //cmbBrand.Text = "Select Brand";
            //cmbModel.Text = "Select Model";

            AddBrandsIncmbBrand();
        }

        public void AddBrandsIncmbBrand()
        {
            cmbBrand.Items.Clear();

            foreach (var item in Brand.GetBrands())
            {
                cmbBrand.Items.Add(item.Name);
            }
        }

        public void AddModelIncmbModel()
        {
            cmbModel.Items.Clear();

            foreach (var item in Model.GetModels(Brand.GetBrandID(FormAddCar.SelectedBrandName)))
            {
                cmbModel.Items.Add(item.Name);
            }
        }

        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddModel.Visible = true;
            SelectedBrandName = cmbBrand.Text.ToString();

            cmbModel.Items.Clear();

            foreach (var item in Model.GetModels(Brand.GetBrandID(cmbBrand.Text)))
            {
                cmbModel.Items.Add(item.Name);
            }                                    
        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            FormAddBrandOrModel form = new FormAddBrandOrModel();
            form.lblBrandOrModel.Text = "Brand name";

            form.ShowDialog();

            this.AddBrandsIncmbBrand();             
        }

        private void btnAddModel_Click(object sender, EventArgs e)
        {
            FormAddBrandOrModel form = new FormAddBrandOrModel();
            form.lblBrandOrModel.Text = "Model name";

            form.ShowDialog();

            this.AddModelIncmbModel();
        }
    }
}
