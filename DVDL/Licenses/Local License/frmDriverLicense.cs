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
    public partial class frmDriverLicense : Form
    {
        int _LocalDrivingLicenseApplicationID;
        int _LicenseId;

        clsDriverLicenseBusiness driverLicense;
        public frmDriverLicense(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            driverLicense = clsDriverLicenseBusiness.GetDriverLicenseInfoBy_LocalLicenseAppID(_LocalDrivingLicenseApplicationID);

        }
        public frmDriverLicense(int LicenseId,bool x)
        {
            InitializeComponent();
            _LicenseId = LicenseId;
            driverLicense = clsDriverLicenseBusiness.GetDriverLicenseInfoBY_LocalLicenseID(_LicenseId);

        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDriverLicense_Load(object sender, EventArgs e)
        {
            driverLicense1.driverLicense= driverLicense;
        }
    }
}
