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


        DataTable _DT;

        public frmListDetainLicense()
        {
            InitializeComponent();
        }
        void _RefreshData()
        {
            _DT= clsDetainLicenseBusiness.GetAllDetainedLicense();
            dgvDetainedLicenses.DataSource = _DT;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListDetainLicense_Load(object sender, EventArgs e)
        {
            _RefreshData();

            if (dgvDetainedLicenses.Rows.Count > 0)
            {
                dgvDetainedLicenses.Columns[0].HeaderText = "D.ID";
                dgvDetainedLicenses.Columns[0].Width = 60;

                dgvDetainedLicenses.Columns[1].HeaderText = "L.ID";
                dgvDetainedLicenses.Columns[1].Width = 60;

                dgvDetainedLicenses.Columns[2].HeaderText = "D.Date";
                dgvDetainedLicenses.Columns[2].Width = 140;

                dgvDetainedLicenses.Columns[3].HeaderText = "Is Released";
                dgvDetainedLicenses.Columns[3].Width = 80;

                dgvDetainedLicenses.Columns[4].HeaderText = "Fine Fees";
                dgvDetainedLicenses.Columns[4].Width = 100;

                dgvDetainedLicenses.Columns[5].HeaderText = "Release Date";
                dgvDetainedLicenses.Columns[5].Width = 130;

                dgvDetainedLicenses.Columns[6].HeaderText = "N.No.";
                dgvDetainedLicenses.Columns[6].Width = 80;

                dgvDetainedLicenses.Columns[7].HeaderText = "Full Name";
                dgvDetainedLicenses.Columns[7].Width = 160;

                dgvDetainedLicenses.Columns[8].HeaderText = "Release App.ID";
                dgvDetainedLicenses.Columns[8].Width = 110;

            }
            cbFilterBy.SelectedIndex= 0;
        }



        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleasedLicense frm = new frmReleasedLicense((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
            _RefreshData();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;
            int PersonID = clsLicenseBusiness.GetLicenseInfo(LicenseID).DriverInfo.PersonID;

            frmShowPersonInfo frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();
            _RefreshData();

        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;

            frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
            frm.ShowDialog();
            _RefreshData();



        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;
            int DriverID = clsLicenseBusiness.GetLicenseInfo(LicenseID).DriverInfo.DriverID;

            frmLicenseHistory frm = new frmLicenseHistory(DriverID);
            frm.ShowDialog();
            _RefreshData();

        }

        private void btnRelease_Click_1(object sender, EventArgs e)
        {
            frmReleasedLicense frmReleasedLicense = new frmReleasedLicense();
            frmReleasedLicense.ShowDialog();
            _RefreshData();

        }
        private void btnDetain_Click_1(object sender, EventArgs e)
        {

            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
            _RefreshData();

        }




        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Is Released")
            {
                txtFilterValue.Visible = false;
                cbIsReleased.Visible = true;
                cbIsReleased.Focus();
                cbIsReleased.SelectedIndex = 0;
            }

            else

            {

                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsReleased.Visible = false;

                if (cbFilterBy.Text == "None")
                {
                    txtFilterValue.Enabled = false;
                }
                else
                    txtFilterValue.Enabled = true;

                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }
        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsReleased";
            string FilterValue = cbIsReleased.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                _DT.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _DT.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;
                case "Is Released":
                    {
                        FilterColumn = "IsReleased";
                        break;
                    }
                    ;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }


            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _DT.DefaultView.RowFilter = "";
                return;
            }


            if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")
                _DT.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _DT.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());


        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Detain ID" || cbFilterBy.Text == "Release Application ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
