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
using DVDL_Project.Applications.Local_License;

namespace DVDL_Project
{
    public partial class frmLocalDrivingLicenseApplicationsScreen : Form
    {
        DataTable _dtLocalDrivingLicenseApp = clsLocalDrivingLicenseApplicationsBusiness.GetAllLocalLicense();
        public frmLocalDrivingLicenseApplicationsScreen()
        {
            InitializeComponent();

            
        }


        void _Refresh()
        {
            dgvLocalLicense.DataSource = _dtLocalDrivingLicenseApp;

            
        }
        private void frmLocalLicenseScreen_Load(object sender, EventArgs e)
        {
            _Refresh();

            cbFilter.SelectedIndex = 0;

            if (dgvLocalLicense.Rows.Count > 0)
            {

                dgvLocalLicense.Columns[0].HeaderText = "Local Driving License Application ID";
                dgvLocalLicense.Columns[0].Width = 200;

                dgvLocalLicense.Columns[1].HeaderText = "Class Name";
                dgvLocalLicense.Columns[1].Width = 200;


                dgvLocalLicense.Columns[2].HeaderText = "National No.";
                dgvLocalLicense.Columns[2].Width = 120;

                dgvLocalLicense.Columns[3].HeaderText = "Full Name";
                dgvLocalLicense.Columns[3].Width = 230;


                dgvLocalLicense.Columns[4].HeaderText = "Application Date";
                dgvLocalLicense.Columns[4].Width = 120;

                dgvLocalLicense.Columns[5].HeaderText = "Passed Test Count";
                dgvLocalLicense.Columns[5].Width = 130;

                dgvLocalLicense.Columns[6].HeaderText = "Status";
                dgvLocalLicense.Columns[6].Width = 70;

            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAddLocalLicenseApp_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateLocalLicense frm = new frmAddOrUpdateLocalLicense();
            frm.ShowDialog();
            _Refresh();

        }





        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilter.SelectedIndex == 0)
            {
                txtFilter.Visible= false;
            }
            else
            {
                txtFilter.Visible= true;
                txtFilter.Text = "";
                txtFilter.Focus();
            }
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbFilter.Text)
            {
                case "Local Driving License Application ID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            if (txtFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtLocalDrivingLicenseApp.DefaultView.RowFilter = "";
                return;
            }


            if (FilterColumn == "LocalDrivingLicenseApplicationID")

                _dtLocalDrivingLicenseApp.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            else
                _dtLocalDrivingLicenseApp.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim());

        }
        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Local Driving License Application ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
            int LocalDrivingLicenseAppID = Convert.ToInt32(dgvLocalLicense.CurrentRow.Cells[0].Value);
            int TotalPassedTests = (int)dgvLocalLicense.CurrentRow.Cells[5].Value;

            clsLocalDrivingLicenseApplicationsBusiness LocalDrivingLicenseApp = clsLocalDrivingLicenseApplicationsBusiness.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseAppID);

            bool LicenseIssued = LocalDrivingLicenseApp.DidLicenseIssued();


            editToolStripMenuItem.Enabled = (LocalDrivingLicenseApp.ApplicationStatus == clsApplicationsBusiness.enApplicationStatus.New);
            DeleteApplicationToolStripMenuItem.Enabled = (LocalDrivingLicenseApp.ApplicationStatus == clsApplicationsBusiness.enApplicationStatus.New);
            CancelApplicaitonToolStripMenuItem.Enabled = (LocalDrivingLicenseApp.ApplicationStatus == clsApplicationsBusiness.enApplicationStatus.New);
            IssueLicense.Enabled = (TotalPassedTests==3) && !LicenseIssued;

            ShowLicense.Enabled = LicenseIssued;

            bool PassedVisionTest = LocalDrivingLicenseApp.DidThePersonPassInThisTestType(1);
            bool PassedWrittenTest = LocalDrivingLicenseApp.DidThePersonPassInThisTestType(2);
            bool PassedStreetTest = LocalDrivingLicenseApp.DidThePersonPassInThisTestType(3);

            ScheduleTestsMenue.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) && (LocalDrivingLicenseApp.ApplicationStatus == clsApplicationsBusiness.enApplicationStatus.New);


            if (ScheduleTestsMenue.Enabled)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = !PassedVisionTest;

                scheduleWrittenTestToolStripMenuItem.Enabled = PassedVisionTest && !PassedWrittenTest;

                scheduleStreetTestToolStripMenuItem.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;

            }


        }



        private void dgvLocalLicense_DoubleClick(object sender, EventArgs e)
        {
            frmShowLocalDrivingLicenseApplicationInfo frm = new frmShowLocalDrivingLicenseApplicationInfo(Convert.ToInt32(dgvLocalLicense.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLocalDrivingLicenseApplicationInfo frm = new frmShowLocalDrivingLicenseApplicationInfo(Convert.ToInt32(dgvLocalLicense.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = Convert.ToInt32(dgvLocalLicense.CurrentRow.Cells[0].Value);
            frmAddOrUpdateLocalLicense frm = new frmAddOrUpdateLocalLicense(LocalDrivingLicenseApplicationID);
            frm.ShowDialog();
            _Refresh();
        }
        private void DeleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int L_D_L_AppID = (int)dgvLocalLicense.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("Are you sure do want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            clsLocalDrivingLicenseApplicationsBusiness LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplicationsBusiness.FindByLocalDrivingAppLicenseID(L_D_L_AppID);

            if (LocalDrivingLicenseApplication != null)
            {
                if (LocalDrivingLicenseApplication.Delete())
                {
                    MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Refresh();
                }
                else
                {
                    MessageBox.Show("Could not delete application, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CancelApplicaitonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int L_D_L_AppID = (int)dgvLocalLicense.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("Are you sure do want to cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            clsLocalDrivingLicenseApplicationsBusiness LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplicationsBusiness.FindByLocalDrivingAppLicenseID(L_D_L_AppID);

            if (LocalDrivingLicenseApplication != null)
            {
                if (LocalDrivingLicenseApplication.Delete())
                {
                    MessageBox.Show("Application Canceled Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Refresh();
                }
                else
                {
                    MessageBox.Show("Could not cancel application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        void ScheduleTestType(int TestType)
        {
            int D_L_App = (int)dgvLocalLicense.CurrentRow.Cells[0].Value;

            frmTestAppointment frm = new frmTestAppointment(D_L_App, TestType);
            frm.ShowDialog();
            _Refresh();
        }
        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScheduleTestType(1);
        }
        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScheduleTestType(2);

        }
        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScheduleTestType(3);

        }



        private void ShowLicense_Click(object sender, EventArgs e)
        {
            frmDriverLicense frm = new frmDriverLicense(Convert.ToInt32(dgvLocalLicense.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
        }
        private void ShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory((string)dgvLocalLicense.CurrentRow.Cells[2].Value);
            frm.ShowDialog();
        }
        private void IssueLicense_Click(object sender, EventArgs e)
        {
            frmIssueDrivingLicense frm = new frmIssueDrivingLicense((int)dgvLocalLicense.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _Refresh();
        }
    }
}
