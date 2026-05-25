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
using static System.Net.Mime.MediaTypeNames;

namespace DVDL_Project
{
    public partial class frmIssueDrivingLicense : Form
    {
        int _LocalDrivingLicenseAppID;
        clsDriverBusiness DriverInfo;
        clsLocalDrivingLicenseApplicationsBusiness _LocalDrivingLicenseAppInfo;
        public frmIssueDrivingLicense(int LocalDrivingLicenseAppID)
        {
            InitializeComponent();
            _LocalDrivingLicenseAppID = LocalDrivingLicenseAppID;


        }

        void _GetDriver(int PersonId)
        {
            
            if (clsDriverBusiness.IsThePersonADriver(PersonId))
            {
                DriverInfo=clsDriverBusiness.GetDriverInfoByPersonID(PersonId);
            }
            else
            {
                DriverInfo = new clsDriverBusiness();
                DriverInfo.PersonID= PersonId;
                DriverInfo.CreatedDate= DateTime.Now;
                DriverInfo.CreatedByUserID= clsGlobal.CurrentUser.UserID;

                DriverInfo.Save();
            }
           
        }
        private void frmIssueDrivingLicense_Load(object sender, EventArgs e)
        {
            txtNote.Focus();
            _LocalDrivingLicenseAppInfo = clsLocalDrivingLicenseApplicationsBusiness.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseAppID);


            if (_LocalDrivingLicenseAppInfo == null)
            {

                MessageBox.Show("No Applicaiton with ID=" + _LocalDrivingLicenseAppID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            if (!_LocalDrivingLicenseAppInfo.PassedAllTests())
            {

                MessageBox.Show("Person Should Pass All Tests First.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            int LicenseID = _LocalDrivingLicenseAppInfo.GetActiveLicenseID();
            if (LicenseID != -1)
            {

                MessageBox.Show("Person already has License before with License ID=" + LicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;

            }


            drivingLicenseAppInfo1.LoadLocalDrivingLicenseAppInfo(_LocalDrivingLicenseAppID);


            _GetDriver(_LocalDrivingLicenseAppInfo.PersonID);


            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicenseID = _LocalDrivingLicenseAppInfo.IssueLicenseForTheFirstTime(txtNote.Text, clsGlobal.CurrentUser.UserID);

            if (LicenseID != -1)
            {
                MessageBox.Show("License Issued Successfully with License ID = " + LicenseID.ToString(),
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("License Was not Issued ! ",
                 "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
