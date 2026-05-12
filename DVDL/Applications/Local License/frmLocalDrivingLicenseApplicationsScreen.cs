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
    public partial class frmLocalDrivingLicenseApplicationsScreen : Form
    {
        public frmLocalDrivingLicenseApplicationsScreen()
        {
            InitializeComponent();

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLocalLicenseScreen_Load(object sender, EventArgs e)
        {
            dgvLocalLicense.DataSource = clsLocalDrivingLicenseApplicationsBusiness.GetAllLocalLicense();

        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateLocalLicense frm = new frmAddOrUpdateLocalLicense();
            frm.ShowDialog();
            dgvLocalLicense.DataSource = clsLocalDrivingLicenseApplicationsBusiness.GetAllLocalLicense();

        }




        private void dgvLocalLicense_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.Button == MouseButtons.Right)
            {
                dgvLocalLicense.ClearSelection();
                dgvLocalLicense.Rows[e.RowIndex].Selected = true;
                dgvLocalLicense.CurrentCell = dgvLocalLicense.Rows[e.RowIndex].Cells[e.ColumnIndex];

                int appID = (int)dgvLocalLicense.Rows[e.RowIndex].Cells[0].Value;

                // =========================
                // Reset كامل 🔥
                // =========================
                visionTestToolStripMenuItem.Enabled = false;
                writtenTestToolStripMenuItem.Enabled = false;
                streetTestToolStripMenuItem.Enabled = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                sechduleTestsToolStripMenuItem.Enabled = true;
                showLicenseToolStripMenuItem.Enabled = false;
                editApplicationToolStripMenuItem.Enabled = true;
                cancelApplicationToolStripMenuItem.Enabled = true;

                // =========================
                // حالات النجاح
                // =========================
                bool passedVision = clsTestBusiness.IsPassed(appID, 1);
                bool passedWritten = clsTestBusiness.IsPassed(appID, 2);
                bool passedStreet = clsTestBusiness.IsPassed(appID, 3);

                // =========================
                // الترتيب (واحد بس يتفعل 🔥)
                // =========================
                if (!passedVision)
                {
                    visionTestToolStripMenuItem.Enabled = true;
                }
                else if (!passedWritten)
                {
                    writtenTestToolStripMenuItem.Enabled = true;
                }
                else if (!passedStreet)
                {
                    streetTestToolStripMenuItem.Enabled = true;
                }
                else
                {
                    // كله ناجح
                    sechduleTestsToolStripMenuItem.Enabled = false;
                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
                }

                // =========================
                // حالة Completed
                // =========================
                string status = dgvLocalLicense.Rows[e.RowIndex].Cells[6].Value?.ToString();

                if (status == "Completed")
                {
                    editApplicationToolStripMenuItem.Enabled = false;
                    cancelApplicationToolStripMenuItem.Enabled = false;
                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                    sechduleTestsToolStripMenuItem.Enabled = false;
                    showLicenseToolStripMenuItem.Enabled = true;

                    // مهم جدًا 🔥
                    visionTestToolStripMenuItem.Enabled = false;
                    writtenTestToolStripMenuItem.Enabled = false;
                    streetTestToolStripMenuItem.Enabled = false;
                }
            }
        }
        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int D_L_App = (int)dgvLocalLicense.CurrentRow.Cells[0].Value;

            frmTestAppointment frm = new frmTestAppointment(D_L_App, 1);
            frm.ShowDialog();
        }
        private void writtenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int D_L_App = (int)dgvLocalLicense.CurrentRow.Cells[0].Value;

            frmTestAppointment frm = new frmTestAppointment(D_L_App, 2);
            frm.ShowDialog();
        }

        private void streetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int D_L_App = (int)dgvLocalLicense.CurrentRow.Cells[0].Value;

            frmTestAppointment frm = new frmTestAppointment(D_L_App, 3);
            frm.ShowDialog();
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int D_L_App = (int)dgvLocalLicense.CurrentRow.Cells[0].Value;
            frmIssueDrivingLicense frm = new frmIssueDrivingLicense(D_L_App);
            frm.ShowDialog();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = Convert.ToInt32( dgvLocalLicense.CurrentRow.Cells[0].Value);
            frmDriverLicense frm = new frmDriverLicense(LocalDrivingLicenseApplicationID);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NationalNo = (string)dgvLocalLicense.CurrentRow.Cells[2].Value;
            frmLicenseHistory frm = new frmLicenseHistory(NationalNo);
            frm.ShowDialog();
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int L_D_L_App = (int)dgvLocalLicense.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplicationsBusiness Localapp = clsLocalDrivingLicenseApplicationsBusiness.FindByLocalDrivingAppLicenseID(L_D_L_App);


            if (Localapp.Delete())
            {
                MessageBox.Show("Local Driving License Application Deleted Successfully");
            }
            else
            {
                MessageBox.Show("Local Driving License Application Not Deleted");
            }
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = Convert.ToInt32(dgvLocalLicense.CurrentRow.Cells[0].Value);
            frmAddOrUpdateLocalLicense frm = new frmAddOrUpdateLocalLicense(LocalDrivingLicenseApplicationID);
            frm.ShowDialog();
            dgvLocalLicense.DataSource = clsLocalDrivingLicenseApplicationsBusiness.GetAllLocalLicense();
        }
    }
}
