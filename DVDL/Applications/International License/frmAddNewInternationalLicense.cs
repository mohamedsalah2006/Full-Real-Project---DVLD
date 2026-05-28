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
    public partial class frmAddNewInternationalLicense : Form
    {

        int _LocalLicenseID;
        int _InternationalLicenseID;
        public frmAddNewInternationalLicense()
        {
            InitializeComponent();
        }



       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddNewInternationalLicense_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString();
            lblExpDate.Text = DateTime.Now.AddYears(1).ToString();
            lblFees.Text =clsApplicationsTypesBusiness.GetApplicationTypeInfoByID((int)clsApplicationsBusiness.enApplicationType.NewInternationalLicense).Fees.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();
            lblUser.Text=clsGlobal.CurrentUser.UserName;
        }

        private void driverLicenseWithFilter1_OnLicenseSelected(int obj)
        {
            _LocalLicenseID = obj;

            if (_LocalLicenseID == -1)
            {
                return;
            }

            lblLocalLicenseID.Text = _LocalLicenseID.ToString();
            linklblShowLicenseHistory.Enabled = true;

            if (driverLicenseWithFilter1.LicenseInfo.LicenseClass < 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (driverLicenseWithFilter1.LicenseInfo.IsActive == 0 )
            {
                MessageBox.Show("Selected License Is Not Active.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnIssue.Enabled = true;
        }

        private void lblIssue_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsApplicationsBusiness NewInternationalApp = new clsApplicationsBusiness();

            NewInternationalApp.ApplicationStatus = clsApplicationsBusiness.enApplicationStatus.Completed;
            NewInternationalApp.ApplicationDate = DateTime.Now;
            NewInternationalApp.ApplicationType = clsApplicationsBusiness.enApplicationType.NewInternationalLicense;
            NewInternationalApp.LastStatusDate = DateTime.Now;
            NewInternationalApp.PaidFees = clsApplicationsTypesBusiness.GetApplicationTypeInfoByID((int)(clsApplicationsBusiness.enApplicationType.NewInternationalLicense)).Fees;
            NewInternationalApp.CreatedByUser = clsGlobal.CurrentUser.UserID;
            NewInternationalApp.PersonID = driverLicenseWithFilter1.LicenseInfo.DriverInfo.PersonID;

            if(!NewInternationalApp.Save())
            {
                MessageBox.Show("Failed to Add International License Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            clsInternationalLicenseBusiness InternationalLicense = new clsInternationalLicenseBusiness();

            InternationalLicense.ApplicationID = NewInternationalApp.ApplicationID;
            InternationalLicense.DriverID = driverLicenseWithFilter1.LicenseInfo.DriverInfo.DriverID;
            InternationalLicense.IssuedUsingLocalLicenseID = _LocalLicenseID;
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            InternationalLicense.IsActive = 1;
            InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (!InternationalLicense.Save())
            {
                MessageBox.Show("Failed to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblAppID.Text = InternationalLicense.ApplicationID.ToString();
            _InternationalLicenseID = InternationalLicense.InternationalLicenseID;
            lbl_I_LicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
            MessageBox.Show("International License Issued Successfully with ID=" + InternationalLicense.InternationalLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnIssue.Enabled = false;
            driverLicenseWithFilter1.FilterEnabled = false;
            linklblbShowLicense.Enabled = true;

        }

        private void linklblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory(driverLicenseWithFilter1.LicenseInfo.DriverID);
            frm.ShowDialog();
        }

        private void linklblbShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(_InternationalLicenseID);
            frm.ShowDialog();

        }
    }
}
