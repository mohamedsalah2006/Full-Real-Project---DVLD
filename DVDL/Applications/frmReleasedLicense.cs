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
using DVDL_Project.Global_Classes;
using static System.Net.Mime.MediaTypeNames;

namespace DVDL_Project
{
    public partial class frmReleasedLicense : Form
    {
        int _LicenseID;

        public frmReleasedLicense()
        {
            InitializeComponent();
        }
        public frmReleasedLicense(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
            driverLicenseWithFilter1.LoadLicenseInfo(LicenseID);
            driverLicenseWithFilter1.FilterEnabled = false;
        }
        

    
       

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this detained  license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int ReleasedAppID = -1;
            bool IsReleased = driverLicenseWithFilter1.LicenseInfo.ReleaseDetainedLicense(clsGlobal.CurrentUser.UserID, ref ReleasedAppID); ;
            lblAppID.Text = ReleasedAppID.ToString();

            if (!IsReleased)
            {
                MessageBox.Show("Failed to to release the Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            MessageBox.Show("Detained License released Successfully ", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRelease.Enabled = false;
            driverLicenseWithFilter1.FilterEnabled = false;
        }
        private void frmReleasedLicense_Load(object sender, EventArgs e)
        {
            lblUser.Text= clsGlobal.CurrentUser.UserName;
        }
        private void driverLicenseWithFilter1_OnLicenseSelected(int obj)
        {
            _LicenseID = obj;
            if(_LicenseID==-1)
            {
                return;
            }

            link_lblLiceseHistory.Enabled = true;
            link_lblNewLicenseInfo.Enabled = true;
            

            if(!driverLicenseWithFilter1.LicenseInfo.IsDetained )
            {
                MessageBox.Show("Selected License i is not detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsDetainLicenseBusiness DetainInfo = driverLicenseWithFilter1.LicenseInfo.DetainedInfo;


            lblLicenseID.Text = _LicenseID.ToString();
            lblAppFees.Text = clsApplicationsTypesBusiness.GetApplicationTypeInfoByID((int)clsApplicationsBusiness.enApplicationType.ReleaseDetainedDrivingLicsense).Fees.ToString();
            lblDetainDate.Text=DetainInfo.DetainDate.ToString();
            lblDetainFees.Text= DetainInfo.FineFees.ToString();
            lblDetainID.Text= DetainInfo.DetainID.ToString();
            lblTotalFees.Text = ((Convert.ToSingle(lblDetainFees.Text)) + (Convert.ToSingle(lblAppFees.Text))).ToString();
            

            btnRelease.Enabled = true;

        }

        private void frmReleasedLicense_Activated(object sender, EventArgs e)
        {
            driverLicenseWithFilter1.txtLicenseIDFocus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void link_lblLiceseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory(driverLicenseWithFilter1.LicenseInfo.DriverID);
            frm.ShowDialog();
        }

        private void link_lblNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_LicenseID);
            frm.ShowDialog();
        }
    }
}
