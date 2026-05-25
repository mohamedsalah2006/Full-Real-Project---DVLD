using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using DVDL_Project.Global_Classes;

namespace DVDL_Project
{
    public partial class frmRenewLicenseApplication : Form
    {
        
        int _NewLicenseID;
        public frmRenewLicenseApplication()
        {
            InitializeComponent();
        }





        private void frmRenewLicenseApplication_Activated(object sender, EventArgs e)
        {
            driverLicenseWithFilter1.txtLicenseIDFocus();
        }
        private void frmRenewLicenseApplication_Load(object sender, EventArgs e)
        {
            
        }
        private void driverLicenseWithFilter1_OnLicenseSelected(int obj)
        {

            int OldLicenseID = obj;

            if (OldLicenseID==-1)
            {
                return;
            }


            lblLicenseID.Text = OldLicenseID.ToString();
            lblEXp_Date.Text=DateTime.Now.AddYears(driverLicenseWithFilter1.LicenseInfo.LicenseClassIfo.DefaultValidityLength).ToString();
            lblAppDate.Text=DateTime.Now.ToString();
            lblAppIssue.Text=lblAppDate.Text;
            lblApplicationFees.Text = clsApplicationsTypesBusiness.GetApplicationTypeInfoByID((int)(clsApplicationsBusiness.enApplicationType.RenewDrivingLicense)).Fees.ToString();
            lblLicenseFees.Text=driverLicenseWithFilter1.LicenseInfo.PaidFees.ToString();
            lblTotalFeef.Text =( (Convert.ToSingle(lblApplicationFees.Text)) + (Convert.ToSingle(lblLicenseFees.Text))).ToString();
            lblUser.Text=clsGlobal.CurrentUser.UserName;
            txtNotes.Text = driverLicenseWithFilter1.LicenseInfo.IssueReasonText;

            if (driverLicenseWithFilter1.LicenseInfo.IsActive==0)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }

            if (!driverLicenseWithFilter1.LicenseInfo.IsTheLicenseExpired())
            {
                MessageBox.Show("Selected License is not yet expiared, it will expire on: " + (driverLicenseWithFilter1.LicenseInfo.ExpirationDate), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }

            btnRenew.Enabled = true;

        }
        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsLicenseBusiness NewLicense = driverLicenseWithFilter1.LicenseInfo.RenewDrivingLicense(txtNotes.Text,clsGlobal.CurrentUser.UserID);
            
            if (NewLicense == null)
            {
                MessageBox.Show("Failed to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _NewLicenseID = NewLicense.LicenseID;

            lblR_LicenseID.Text = _NewLicenseID.ToString();
            lblR_L_AppID.Text = NewLicense.ApplicationID.ToString();


            MessageBox.Show("Licensed Renewed Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRenew.Enabled = false;
            driverLicenseWithFilter1.FilterEnabled = false;

            link_lblNewLicenseInfo.Enabled = true;
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
            frmShowDriverLicense frm = new frmShowDriverLicense(_NewLicenseID);
            frm.ShowDialog();
        }

       
    }
}
