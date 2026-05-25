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
using static BusinessLayer.clsLicenseBusiness;

namespace DVDL_Project
{
    public partial class frmReplacementForDamagedLicense : Form
    {


        clsLicenseBusiness.enIssueReason _IssueLicenseReason;
        


        int _NewLicenseID;
        public frmReplacementForDamagedLicense()
        {
            InitializeComponent();
        }

        void _HandleAppType()
        {
            if(rbLostLicense.Checked)
            {
                _IssueLicenseReason = enIssueReason.LostReplacement;
                lblTitle.Text = "Replacement for Lost License";
            }
            else 
            {
                _IssueLicenseReason = enIssueReason.DamagedReplacement;
                lblTitle.Text = "Replacement for Damaged License";
            }
        }

        private void driverLicenseWithFilter1_OnLicenseSelected(int obj)
        {

            int OldLicenseID = obj;

            if (OldLicenseID == -1)
            {
                return;
            }


            lblLicenseID.Text = OldLicenseID.ToString();
            lblAppDate.Text = DateTime.Now.ToString();
            lblApplicationFees.Text = clsApplicationsTypesBusiness.GetApplicationTypeInfoByID((int)(clsApplicationsBusiness.enApplicationType.RenewDrivingLicense)).Fees.ToString();
            lblUser.Text = clsGlobal.CurrentUser.UserName;

            if (driverLicenseWithFilter1.LicenseInfo.IsActive == 0)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license." , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }

            if (driverLicenseWithFilter1.LicenseInfo.IsTheLicenseExpired())
            {
                if(MessageBox.Show("Selected License was expired , Do you want renew it ?" , "Not allowed", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    frmRenewLicenseApplication frm = new frmRenewLicenseApplication();
                    frm.ShowDialog();
                }
                else
                {
                    btnRenew.Enabled = false;
                    return;
                }
                
            }

            btnRenew.Enabled = true;

        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Issue a Replacement for the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsLicenseBusiness NewLicense = driverLicenseWithFilter1.LicenseInfo.Replace(_IssueLicenseReason, clsGlobal.CurrentUser.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Failed to Replaced the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _NewLicenseID = NewLicense.LicenseID;

            lblR_LicenseID.Text = _NewLicenseID.ToString();
            lblR_L_AppID.Text = NewLicense.ApplicationID.ToString();


            MessageBox.Show("Licensed Replaced Successfully with ID =" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRenew.Enabled = false;
            driverLicenseWithFilter1.FilterEnabled = false;

            link_lblNewLicenseInfo.Enabled = true;
        }

        private void link_lblLiceseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory(driverLicenseWithFilter1.LicenseInfo.DriverID);
            frm.ShowDialog();
        }

        private void link_lblNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDriverLicense frm = new frmShowDriverLicense(_NewLicenseID);
            frm.ShowDialog();
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            _HandleAppType();
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            _HandleAppType();
        }

        private void frmReplacementForDamagedLicense_Activated(object sender, EventArgs e)
        {
            driverLicenseWithFilter1.txtLicenseIDFocus();
        }

        private void frmReplacementForDamagedLicense_Load(object sender, EventArgs e)
        {
            _HandleAppType();
        }
    }
}
