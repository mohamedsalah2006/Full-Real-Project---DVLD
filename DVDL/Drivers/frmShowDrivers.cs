using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace DVDL_Project
{
    public partial class frmShowDrivers : Form
    {
        public frmShowDrivers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowDrivers_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource=clsDriverBusiness.GetAllDrivers();
        }
    }
}
