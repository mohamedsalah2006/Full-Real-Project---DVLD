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

namespace DVDL_Project.Licenses
{
    public partial class DriverLicenseHistory : UserControl
    {

        DataTable _dtDriverLocalLicensesHistory;
        DataTable _dtDriverInternationalLicensesHistory;
        int _DriverID;
        clsDriverBusiness _DriverInfo;
        public DriverLicenseHistory()
        {
            InitializeComponent();
        }
        private void _LoadLocalLicenseInfo()
        {

            _dtDriverLocalLicensesHistory = clsLicenseBusiness.GetDriverLocalLicense(_DriverID);


            dgvLocalLicensesHistory.DataSource = _dtDriverLocalLicensesHistory;

            if (dgvLocalLicensesHistory.Rows.Count > 0)
            {
                dgvLocalLicensesHistory.Columns[0].HeaderText = "Lic.ID";
                dgvLocalLicensesHistory.Columns[0].Width = 110;

                dgvLocalLicensesHistory.Columns[1].HeaderText = "App.ID";
                dgvLocalLicensesHistory.Columns[1].Width = 110;

                dgvLocalLicensesHistory.Columns[2].HeaderText = "Class Name";
                dgvLocalLicensesHistory.Columns[2].Width = 270;

                dgvLocalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicensesHistory.Columns[3].Width = 170;

                dgvLocalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicensesHistory.Columns[4].Width = 170;

                dgvLocalLicensesHistory.Columns[5].HeaderText = "Is Active";
                dgvLocalLicensesHistory.Columns[5].Width = 110;

            }
        }

        private void _LoadInternationalLicenseInfo()
        {

            _dtDriverInternationalLicensesHistory = clsInternationalLicenseBusiness.GetAllInternationalLicenseToPerson(_DriverID);


            dgvInternationalLicensesHistory.DataSource = _dtDriverInternationalLicensesHistory;

            if (dgvInternationalLicensesHistory.Rows.Count > 0)
            {
                dgvInternationalLicensesHistory.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicensesHistory.Columns[0].Width = 160;

                dgvInternationalLicensesHistory.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicensesHistory.Columns[1].Width = 130;

                dgvInternationalLicensesHistory.Columns[2].HeaderText = "L.License ID";
                dgvInternationalLicensesHistory.Columns[2].Width = 130;

                dgvInternationalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvInternationalLicensesHistory.Columns[3].Width = 180;

                dgvInternationalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalLicensesHistory.Columns[4].Width = 180;

                dgvInternationalLicensesHistory.Columns[5].HeaderText = "Is Active";
                dgvInternationalLicensesHistory.Columns[5].Width = 120;

            }
        }

        public void LoadDriverLicense(int DriverID)
        {
            _DriverInfo = clsDriverBusiness.GetDriverInfoByDriverID(DriverID);
            if( _DriverInfo == null )
            {
                MessageBox.Show("There is no driver with id [ " + _DriverID + " ]");
                return;
            }

            _DriverID = DriverID;

            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();


        }
        private void showDriverLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowDriverLicense frm = new frmShowDriverLicense((int)dgvLocalLicensesHistory.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showDriverLicenseInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo((int)dgvInternationalLicensesHistory.CurrentRow.Cells[2].Value);
            frm.ShowDialog();
        }

       
    }
}
