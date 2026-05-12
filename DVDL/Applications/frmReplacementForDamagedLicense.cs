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
    public partial class frmReplacementForDamagedLicense : Form
    {
        int _DriverLicenseID;
        string _NationalNo;
        int _PersonID;
        int _NewLicenseID;
        public frmReplacementForDamagedLicense()
        {
            InitializeComponent();
        }

        clsApplicationsBusiness ReplaceLicenseApp(int PersonID)
        {
            clsApplicationsBusiness RenewApp = new clsApplicationsBusiness();



           // RenewApp.ApplicationStatus = 1;
            RenewApp.ApplicationDate = DateTime.Now;
            RenewApp.LastStatusDate = DateTime.Now;
            RenewApp.PaidFees = clsApplicationsTypesBusiness.GetApplicationTypeInfoByID(4).Fees;
            RenewApp.ApplicationType = clsApplicationsBusiness.enApplicationType.ReplaceDamagedDrivingLicense;
            RenewApp.CreatedByUser = 1;
            RenewApp.PersonID = PersonID;

            RenewApp.Save();

            return RenewApp;
        }
        void ReplaceDrivingLicense(int LicenseID)
        {


            clsApplicationsBusiness App = ReplaceLicenseApp(_PersonID);
            clsLicenseBusiness OldLicense = clsLicenseBusiness.GetLicenseInfo(LicenseID);
            clsLicenseBusiness ReplacedLicense = OldLicense;

            ReplacedLicense.ApplicationID = App.ApplicationID;
            ReplacedLicense.IsActive = 1;
            ReplacedLicense.IssueReason = 3;

            if (ReplacedLicense.AddNewLicense())
            {
                MessageBox.Show("License Replaced Successfully ");
            }
            else
            {
                MessageBox.Show("License Not Replaced ");
            }

            _NewLicenseID = ReplacedLicense.LicenseID;
        }

        private void btnCheckLicense_Click(object sender, EventArgs e)
        {
            _DriverLicenseID = Convert.ToInt32(txtLicenseID.Text);
            clsDriverLicenseBusiness DriverLicense = clsDriverLicenseBusiness.GetDriverLicenseInfoBY_LocalLicenseID(_DriverLicenseID);
            _NationalNo = DriverLicense.NationalNo;
            _PersonID = DriverLicense.PersonID;
            driverLicense1.driverLicense = DriverLicense;

            float LicenseFees = clsLicenseClassesBusiness.GetLicenseClassInfo(DriverLicense.LicenseClassName).ClassFees;
            int ValidityLength = clsLicenseClassesBusiness.GetLicenseClassInfo(DriverLicense.LicenseClassName).DefaultValidityLength;

            lblAppDate.Text = DateTime.Now.ToString();
            lblApplicationFees.Text = "5";
            lblLicenseID.Text = _DriverLicenseID.ToString();
            lblUser.Text = "1";

            if (!clsLicenseBusiness.IsTheLicenseActive(_DriverLicenseID))
            {
                btnRenew.Enabled = false;
                link_lblNewLicenseInfo.Enabled = false;
                MessageBox.Show("Select License Is Not Active In System ", "Not Active", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (clsLicenseBusiness.DeactivateLicense(_DriverLicenseID))
            {
                ReplaceDrivingLicense(_DriverLicenseID);
                link_lblNewLicenseInfo.Enabled = true;
            }
        }

        private void link_lblLiceseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory(_NationalNo);
            frm.ShowDialog();
        }

        private void link_lblNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicense frm = new frmDriverLicense(_NewLicenseID, true);
            frm.ShowDialog();
        }
    }
}
