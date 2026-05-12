using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL_Project
{
    public partial class frmMain_Screen : Form
    {

        frmLogin _frmLogin;

        public frmMain_Screen(frmLogin frm)
        {
            InitializeComponent();
            _frmLogin = frm;
        }
      


        private void btnPeople_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            UsersScreen form = new UsersScreen();
            form.ShowDialog();
        }

        private void btnApplications_Click(object sender, EventArgs e)
        {
            frmMangeApplicationsTypes form = new frmMangeApplicationsTypes();
            form.ShowDialog();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersScreen form = new UsersScreen();
            form.ShowDialog();
        }

        private void mangeApplicationsTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMangeApplicationsTypes form = new frmMangeApplicationsTypes();
            form.ShowDialog();
        }

        private void mangeTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMangeTestsTypes frm = new frmMangeTestsTypes();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateLocalLicense frm = new frmAddOrUpdateLocalLicense();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMangeInternationalLicenseApplications frm = new frmMangeInternationalLicenseApplications();
            frm.ShowDialog();
        }

        private void localLicensesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationsScreen frm = new frmLocalDrivingLicenseApplicationsScreen();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowDrivers frm = new frmShowDrivers();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalLicense frm = new frmAddNewInternationalLicense();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLicenseApplication frm = new frmRenewLicenseApplication();
            frm.ShowDialog();
        }

        private void replacementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplacementForDamagedLicense frm = new frmReplacementForDamagedLicense();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void releaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleasedLicense frm = new frmReleasedLicense();
            frm.ShowDialog();
        }

        private void mangeDetainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDetainLicense frm = new frmListDetainLicense();
            frm.ShowDialog();
        }

        private void frmMain_Screen_Load(object sender, EventArgs e)
        {

        }
    }
}
