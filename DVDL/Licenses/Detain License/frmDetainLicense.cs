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
    public partial class frmDetainLicense : Form
    {

        public frmDetainLicense()
        {
            InitializeComponent();
        }
        int _DriverLicenseID;
        string _NationalNo;
        private void btnCheckLicense_Click(object sender, EventArgs e)
        {
            _DriverLicenseID = Convert.ToInt32(txtLicenseID.Text);
            clsDriverLicenseBusiness DriverLicense = clsDriverLicenseBusiness.GetDriverLicenseInfoBY_LocalLicenseID(_DriverLicenseID);
            driverLicense1.LoadDriverLicenseInfo(_DriverLicenseID);
            _NationalNo=DriverLicense.NationalNo;

            lblAppDate.Text = DateTime.Now.ToString();
            lblLicenseID.Text = _DriverLicenseID.ToString();
            lblUser.Text = "1";

            link_lblLiceseHistory.Enabled = true;
            link_lblNewLicenseInfo.Enabled = true;

            if (!clsLicenseBusiness.IsTheLicenseActive(_DriverLicenseID))
            {
                btnDetain.Enabled = false;
                MessageBox.Show("Select License Is Not Active In System ", "Not Active", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (clsDetainLicenseBusiness.IsTheLicenseDetained(_DriverLicenseID))
            {
                btnDetain.Enabled = false;
                MessageBox.Show("This License IS Already Detained");
                return;
            }
            btnDetain.Enabled = true;
            
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            int DetainFees =Convert.ToInt32(txtFees.Text);

           

            if (clsDetainLicenseBusiness.DetainLicense(_DriverLicenseID, DetainFees, 1))
            {
                MessageBox.Show("This License Detained Successfully");
            }
            else
            {
                MessageBox.Show("This License Not Detained");
            }
            btnDetain.Enabled = false;
        }

        private void link_lblLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            //frmLicenseHistory frm = new frmLicenseHistory(_NationalNo);
            //frm.ShowDialog();
        }

        private void link_lblNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //frmDriverLicense frm = new frmDriverLicense(_DriverLicenseID, true);
            //frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
