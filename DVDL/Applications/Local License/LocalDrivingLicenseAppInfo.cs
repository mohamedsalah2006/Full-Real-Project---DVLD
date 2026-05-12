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
    public partial class LocalDrivingLicenseAppInfo : UserControl
    {
        public LocalDrivingLicenseAppInfo()
        {
            InitializeComponent();
        }
        public clsLocalDrivingLicenseAppBusiness_View L_D_L_App_Info
        {
            set
            {
                lblDLAppID.Text = value.LD_LicenseID.ToString();
                lblLicense.Text = value.ClassName;
                lblPassed.Text = "["+value.PassedTestCount+"/3]";

                applicationBasicInfo1.FullName = value.FullName;
            }
        }
        public clsApplicationsBusiness AppInfo
        {
            set
            {
                applicationBasicInfo1.ApplicationInfo = value;
            }
        }

        private void DrivingLicenseAppInfo_Load(object sender, EventArgs e)
        {
            //if (_AppId <= 0)
            //    return;

            //applicationBasicInfo1.ApplicationInfo =
            //    clsApplicationsBusiness.FindApplication(_AppId);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void applicationBasicInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
