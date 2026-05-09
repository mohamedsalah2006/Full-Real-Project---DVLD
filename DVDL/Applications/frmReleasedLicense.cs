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
    public partial class frmReleasedLicense : Form
    {
        public frmReleasedLicense()
        {
            InitializeComponent();
        }
        int _DriverLicenseID;
        string _NationalNo;
        int _PersonID;

        clsApplicationsBusiness ReleaseLicenseApp(int PersonID)
        {
            clsApplicationsBusiness ReleaseApp = new clsApplicationsBusiness();



           // ReleaseApp.ApplicationStatus = 1;
            ReleaseApp.ApplicationDate = DateTime.Now;
            ReleaseApp.LastStatusDate = DateTime.Now;
            ReleaseApp.PaidFees = clsApplicationsTypesBusiness.GetApplicationTypeInfoByID(5).Fees;
            ReleaseApp.ApplicationType = 5;
            ReleaseApp.CreatedByUser = 1;
            ReleaseApp.PersonID = PersonID;

            ReleaseApp.Save();

            return ReleaseApp;
        }
        bool ReleaseDrivingLicense(int LicenseID, int ReleasedByUserID)
        {


            clsApplicationsBusiness App = ReleaseLicenseApp(_PersonID);
            return clsDetainLicenseBusiness.ReleasedLicense(LicenseID, ReleasedByUserID, App.ApplicationID);
            
        }

        private void btnCheckLicense_Click(object sender, EventArgs e)
        {
            _DriverLicenseID = Convert.ToInt32(txtLicenseID.Text);
            clsDriverLicenseBusiness DriverLicense = clsDriverLicenseBusiness.GetDriverLicenseInfoBY_LocalLicenseID(_DriverLicenseID);
            driverLicense1.driverLicense = DriverLicense;
            _NationalNo = DriverLicense.NationalNo;
            _PersonID=DriverLicense.PersonID;

            
            link_lblLiceseHistory.Enabled = true;
            link_lblNewLicenseInfo.Enabled = true;

            if (!clsLicenseBusiness.IsTheLicenseActive(_DriverLicenseID))
            {
                btnRelease.Enabled = false;
                MessageBox.Show("Select License Is Not Active In System ", "Not Active", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!clsDetainLicenseBusiness.IsTheLicenseDetained(_DriverLicenseID))
            {
                btnRelease.Enabled = false;
                MessageBox.Show("This License IS Not Detained");
                return;
            }

            clsDetainLicenseBusiness DetainLicense = clsDetainLicenseBusiness.GetDetainLicenseInfo(_DriverLicenseID);
            int AppFees = clsApplicationsTypesBusiness.GetApplicationTypeInfoByID(5).Fees;

            lblDetainID.Text = DetainLicense.DetainID.ToString();
            lblDetainDate.Text= DetainLicense.DetainDate.ToString();
            lblDetainFees.Text = DetainLicense.FineFees.ToString();
            lblAppID.Text=DetainLicense.ReleasedAppID.ToString();
            lblLicenseID.Text = DetainLicense.LicenseID.ToString();
            lblUser.Text = DetainLicense.CreateByUserID.ToString();
            lblAppFees.Text=AppFees.ToString();
            lblTotalFees.Text = (AppFees+DetainLicense.FineFees).ToString();


            btnRelease.Enabled = true;
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if(ReleaseDrivingLicense(_DriverLicenseID,1))
            {
                MessageBox.Show("License Released Successfully");
            }
            else
            {
                MessageBox.Show("License Not Released");
            }
            btnRelease.Enabled = false;
        }
    }
}
