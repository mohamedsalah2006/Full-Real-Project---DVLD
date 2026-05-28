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

        DataTable _DT;
        public frmMangeInternationalLicenseApplications()
        {
            InitializeComponent();
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        void _Refresh()
        {
            _DT = clsInternationalLicenseBusiness.GetAllInternationalLicense();
            dgvInternationalLicenses.DataSource = _DT;
        }
        private void frmMangeInternationalLicenseApplications_Load(object sender, EventArgs e)
        {
            _Refresh();

            cbFilter.SelectedIndex = 0;
            if (dgvInternationalLicenses.Rows.Count > 0)
            {
                dgvInternationalLicenses.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicenses.Columns[0].Width = 130;

                dgvInternationalLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenses.Columns[1].Width = 130;

                dgvInternationalLicenses.Columns[2].HeaderText = "Driver ID";
                dgvInternationalLicenses.Columns[2].Width = 100;

                dgvInternationalLicenses.Columns[3].HeaderText = "L.License ID";
                dgvInternationalLicenses.Columns[3].Width = 120;

                dgvInternationalLicenses.Columns[4].HeaderText = "Issue Date";
                dgvInternationalLicenses.Columns[4].Width = 150;

                dgvInternationalLicenses.Columns[5].HeaderText = "Expiration Date";
                dgvInternationalLicenses.Columns[5].Width = 180;

                dgvInternationalLicenses.Columns[6].HeaderText = "Is Active";
                dgvInternationalLicenses.Columns[6].Width = 110;

            }
        }


        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalLicenseID = (int)dgvInternationalLicenses.CurrentRow.Cells[3].Value;
            clsLicenseBusiness License = clsLicenseBusiness.GetLicenseInfo(LocalLicenseID);

            frmShowPersonInfo frm = new frmShowPersonInfo(License.DriverInfo.PersonID);
            frm.ShowDialog();

            _Refresh();
        }
        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalLicenseID = (int)dgvInternationalLicenses.CurrentRow.Cells[0].Value;
            
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(LocalLicenseID);
            frm.ShowDialog();
            _Refresh();

        }
        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalLicenseID = (int)dgvInternationalLicenses.CurrentRow.Cells[3].Value;
            clsLicenseBusiness License = clsLicenseBusiness.GetLicenseInfo(LocalLicenseID);

            frmLicenseHistory frm = new frmLicenseHistory(License.DriverID);
            frm.ShowDialog();
            _Refresh();

        }

        private void btnAddNewInternationalLicense_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalLicense frm = new frmAddNewInternationalLicense();
            frm.ShowDialog();
            _Refresh();

        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFilter.Text == "Is Active")
            {
                txtFilterValue.Visible = false;
                cbIsReleased.Visible = true;
                cbIsReleased.Focus();
                cbIsReleased.SelectedIndex = 0;
            }

            else

            {

                txtFilterValue.Visible = (cbFilter.Text != "None");
                cbIsReleased.Visible = false;

                if (cbFilter.Text == "None")
                {
                    txtFilterValue.Enabled = false;
                    //_dtDetainedLicenses.DefaultView.RowFilter = "";
                    //lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();

                }
                else
                    txtFilterValue.Enabled = true;

                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

        }
        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
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
            //Map Selected Filter to real Column name 
            switch (cbFilter.Text)
            {
                case "International License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;
                case "Application ID":
                    {
                        FilterColumn = "ApplicationID";
                        break;
                    }
                    ;

                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Local License ID":
                    FilterColumn = "IssuedUsingLocalLicenseID";
                    break;

                case "Is Active":
                    FilterColumn = "IsActive";
                    break;


                default:
                    FilterColumn = "None";
                    break;
            }


            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _DT.DefaultView.RowFilter = "";
                return;
            }



            _DT.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
    
}
