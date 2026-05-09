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
    public partial class frmMangeInternationalLicenseApplications : Form
    {
        public frmMangeInternationalLicenseApplications()
        {
            InitializeComponent();
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalLicense frm = new frmAddNewInternationalLicense();
            frm.ShowDialog();
        }

        private void frmMangeInternationalLicenseApplications_Load(object sender, EventArgs e)
        {
            dgvInterLicense.DataSource = clsInternationalLicenseBusiness.GetAllInternationalLicense();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalLicenseID = (int)dgvInterLicense.CurrentRow.Cells[3].Value;
            clsDriverLicenseBusiness DriverLicense = clsDriverLicenseBusiness.GetDriverLicenseInfoBY_LocalLicenseID(LocalLicenseID);

            frmShowPersonInfo frm = new frmShowPersonInfo(DriverLicense.PersonID);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalLicenseID = (int)dgvInterLicense.CurrentRow.Cells[3].Value;
            
            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(LocalLicenseID);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalLicenseID = (int)dgvInterLicense.CurrentRow.Cells[3].Value;
            clsDriverLicenseBusiness DriverLicense = clsDriverLicenseBusiness.GetDriverLicenseInfoBY_LocalLicenseID(LocalLicenseID);

            frmLicenseHistory frm = new frmLicenseHistory(DriverLicense.NationalNo);
            frm.ShowDialog();
        }
    }
}
