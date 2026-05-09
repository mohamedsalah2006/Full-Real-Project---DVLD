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
    public partial class frmListDetainLicense : Form
    {
        public frmListDetainLicense()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListDetainLicense_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsDetainLicenseBusiness.GetAllDetainedLicense();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleasedLicense frmReleasedLicense = new frmReleasedLicense();
            frmReleasedLicense.ShowDialog();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm  = new frmDetainLicense();
            frm.ShowDialog();
        }
    }
}
