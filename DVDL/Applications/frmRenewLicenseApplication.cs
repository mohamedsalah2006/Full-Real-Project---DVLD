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

namespace DVDL_Project
{
    public partial class frmRenewLicenseApplication : Form
    {
        int _DriverLicenseID;
        string _NationalNo;
        int _PersonID;
        int _NewLicenseID;
        public frmRenewLicenseApplication()
        {
            InitializeComponent();
        }
        clsApplicationsBusiness RenewLicenseApp(int PersonID)
        {
            clsApplicationsBusiness RenewApp = new clsApplicationsBusiness();

        

           // RenewApp.ApplicationStatus = 1;
            RenewApp.ApplicationDate = DateTime.Now;
            RenewApp.LastStatusDate = DateTime.Now;
            RenewApp.PaidFees = clsApplicationsTypesBusiness.GetApplicationTypeInfoByID(2).Fees;
            RenewApp.ApplicationType = clsApplicationsBusiness.enApplicationType.RenewDrivingLicense;
            RenewApp.CreatedByUser = 1;
            RenewApp.PersonID = PersonID;

            RenewApp.Save();

            return RenewApp;
        }
        void RenewDrivingLicense(int  LicenseID,string Notes)
        {
            

            clsApplicationsBusiness App = RenewLicenseApp(_PersonID);
            clsLicenseBusiness OldLicense = clsLicenseBusiness.GetLicenseInfo(LicenseID);
            clsLicenseBusiness RenewLicense = new clsLicenseBusiness();

            RenewLicense.ApplicationID = App.ApplicationID;
            RenewLicense.DriverID = OldLicense.DriverID;
            RenewLicense.LicenseClass = OldLicense.LicenseClass;
            RenewLicense.IssueDate = DateTime.Now;
            RenewLicense.ExpirationDate = DateTime.Now.AddYears(clsLicenseClassesBusiness.GetLicenseClassInfo(RenewLicense.LicenseClass).DefaultValidityLength);
            RenewLicense.Notes = Notes;
            RenewLicense.CreatedByUserID = 1;
            RenewLicense.IsActive = 1;
            RenewLicense.IssueReason = 3;
            RenewLicense.PaidFees = OldLicense.PaidFees;

            if(RenewLicense.AddNewLicense())
            {
                MessageBox.Show("License Renewed Successfully ");
            }
            else
            {
                MessageBox.Show("License Not Renewed ");
            }

            _NewLicenseID=RenewLicense.LicenseID;
        }
        
           

        
        private void btnCheckLicense_Click(object sender, EventArgs e)
        {
            _DriverLicenseID = Convert.ToInt32(txtLicenseID.Text);
            clsDriverLicenseBusiness DriverLicense = clsDriverLicenseBusiness.GetDriverLicenseInfoBY_LocalLicenseID(_DriverLicenseID);
            _NationalNo = DriverLicense.NationalNo;
            _PersonID= DriverLicense.PersonID;
            driverLicense1.driverLicense = DriverLicense;

            float LicenseFees = clsLicenseClassesBusiness.GetLicenseClassInfo(DriverLicense.LicenseClassName).ClassFees;
            int ValidityLength = clsLicenseClassesBusiness.GetLicenseClassInfo(DriverLicense.LicenseClassName).DefaultValidityLength;

            

            lblAppDate.Text = DateTime.Now.ToString();
            lblAppIssue.Text = DateTime.Now.ToString();
            lblLicenseFees.Text = LicenseFees.ToString();
            lblApplicationFees.Text = "5";
            lblLicenseID.Text=_DriverLicenseID.ToString();
            lblEXp_Date.Text = DateTime.Now.AddYears(ValidityLength).ToString();
            lblUser.Text = "1";
            lblTotalFeef.Text = (LicenseFees+5).ToString();

            if(!clsLicenseBusiness.IsTheLicenseActive(_DriverLicenseID))
            {
                btnRenew.Enabled = false;
                link_lblNewLicenseInfo.Enabled = false;
                MessageBox.Show("Select License Is Not Active In System " , "Not Active", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsLicenseBusiness.IsTheLicenseNotExpired(_DriverLicenseID))
            {
                btnRenew.Enabled = false;
                link_lblNewLicenseInfo.Enabled = false;
                MessageBox.Show("Select License Is Not Expired , It Will Exp In " + DriverLicense.ExpirationDate.ToString(),"Not Allowed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
           
            
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if(clsLicenseBusiness.DeactivateLicense(_DriverLicenseID))
            {
                RenewDrivingLicense(_DriverLicenseID, txtNotes.Text);
                link_lblNewLicenseInfo.Enabled = true;
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void link_lblLiceseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            frmLicenseHistory frm = new frmLicenseHistory(_NationalNo);
            frm.ShowDialog();
        }

        private void link_lblNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicense frm = new frmDriverLicense(_NewLicenseID,true);
            frm.ShowDialog();
        }
    }
}
