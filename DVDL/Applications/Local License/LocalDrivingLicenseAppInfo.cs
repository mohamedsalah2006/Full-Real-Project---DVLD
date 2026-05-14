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

        private int _AppID;
        public int AppID
        {
            get { return _AppID; }
            set { _AppID = value; }
        }

        private int _LocalDrivingLicenseAppID;
        public int LocalDrivingLicenseAppID
        {
            get { return _LocalDrivingLicenseAppID; }
            set { _LocalDrivingLicenseAppID = value; }
        }

        clsLocalDrivingLicenseApplicationsBusiness _LocalDrivingLicenseAppInfo;

        public LocalDrivingLicenseAppInfo()
        {
            InitializeComponent();
        }

        void _ResetLocalDrivingLicenseAppInfo()
        {
            lblDLAppID.Text = "[???]";
            lblLicense.Text = "[???]";
            lblPassed.Text = "[???]";
        }
        void _FillLocalDrivingLicenseAppInfo()
        {
            lblDLAppID.Text = _LocalDrivingLicenseAppInfo.LocalDrivingLicenseApplicationID.ToString();
            lblLicense.Text = _LocalDrivingLicenseAppInfo.LicenseClassInfo.ClassName;
            lblPassed.Text = _LocalDrivingLicenseAppInfo.GetPassedTestCount().ToString() + "/3";

            applicationBasicInfo1.LoadApplicationInfoByAppID(_LocalDrivingLicenseAppInfo.ApplicationID);

        }
        public void LoadLocalDrivingLicenseAppInfo(int LocalDrivingLicenseAppID)
        {
            this.LocalDrivingLicenseAppID= LocalDrivingLicenseAppID;
            _LocalDrivingLicenseAppInfo = clsLocalDrivingLicenseApplicationsBusiness.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseAppID);

            if(_LocalDrivingLicenseAppInfo==null)
            {
                _ResetLocalDrivingLicenseAppInfo();
                MessageBox.Show("No Application with ApplicationID = " + LocalDrivingLicenseAppID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _FillLocalDrivingLicenseAppInfo();
            }
        }

        private void LocalDrivingLicenseAppInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
