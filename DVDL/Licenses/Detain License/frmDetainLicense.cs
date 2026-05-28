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
using DVDL_Project.Global_Classes;

namespace DVDL_Project
{
    public partial class frmDetainLicense : Form
    {

        public frmDetainLicense()
        {
            InitializeComponent();
        }
        int _LicenseID;
        int _DetainedID;
       
        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            _DetainedID = driverLicenseWithFilter1.LicenseInfo.Detain(Convert.ToInt32(txtFees.Text), clsGlobal.CurrentUser.UserID);
            if (_DetainedID==-1)
            {
                MessageBox.Show("Failed to Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            lblDetainID.Text = _DetainedID.ToString();
            MessageBox.Show("License Detained Successfully with ID=" + _DetainedID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnDetain.Enabled = false;
            driverLicenseWithFilter1.FilterEnabled = false;
            txtFees.Enabled = false;

        }

        private void link_lblLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmLicenseHistory frm = new frmLicenseHistory(driverLicenseWithFilter1.LicenseInfo.DriverID);
            frm.ShowDialog();
        }

        private void link_lblNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(driverLicenseWithFilter1.LicenseID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lblAppDate.Text = DateTime.Now.ToString();
            lblUser.Text=clsGlobal.CurrentUser.UserName;
        }

        private void driverLicenseWithFilter1_OnLicenseSelected(int obj)
        {
            _LicenseID=obj;

            if(_LicenseID==-1)
            {
                return;
            }

            lblLicenseID.Text = _LicenseID.ToString();

            link_lblLiceseHistory.Enabled = true;
            link_lblNewLicenseInfo.Enabled = true;

            if(driverLicenseWithFilter1.LicenseInfo.IsDetained==true)
            {
                MessageBox.Show("License Already Detained");
                return;
            }
            btnDetain.Enabled = true;
            txtFees.Enabled = true; 
            txtFees.Focus();


        }

        private void frmDetainLicense_Activated(object sender, EventArgs e)
        {
            driverLicenseWithFilter1.txtLicenseIDFocus();
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFees, null);

            }
            ;


            if (!clsValidation.IsNumber(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            }
            
        }
    }
}
