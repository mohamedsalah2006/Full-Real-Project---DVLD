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
using static System.Net.Mime.MediaTypeNames;

namespace DVDL_Project
{
    public partial class frmIssueDrivingLicense : Form
    {
        int _L_D_App;
        clsLicenseBusiness NewLicense = new clsLicenseBusiness();
        public frmIssueDrivingLicense(int l_D_App)
        {
            InitializeComponent();
            _L_D_App = l_D_App;
        }

        int _GetDriver(int PersonId)
        {
            //int DriverID;
            //if (clsDriverBusiness.IsThePersonADriver(PersonId))
            //{
            //    DriverID = clsDriverBusiness.InsertDriver(PersonId, DateTime.Now, 1);
            //}
            //return DriverID;
            return 1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmIssueDrivingLicense_Load(object sender, EventArgs e)
        {

            clsLocalDrivingLicenseApplicationsBusiness LocalLicenseInfo = clsLocalDrivingLicenseApplicationsBusiness.FindByLocalDrivingAppLicenseID(_L_D_App);
            //clsLocalDrivingLicenseAppBusiness_View LocalLicenseView = clsLocalDrivingLicenseAppBusiness_View.FindLocalLicenseApp_View(_L_D_App);
            clsApplicationsBusiness App = clsApplicationsBusiness.FindApplication(LocalLicenseInfo.AppID);


            drivingLicenseAppInfo1.LoadLocalDrivingLicenseAppInfo(_L_D_App);

            

            NewLicense.ApplicationID = LocalLicenseInfo.AppID;
            NewLicense.DriverID = _GetDriver(App.PersonID);/////////////////
            NewLicense.LicenseClass = LocalLicenseInfo.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(clsLicenseClassesBusiness.GetLicenseClassInfo(LocalLicenseInfo.LicenseClassID).DefaultValidityLength);
            NewLicense.Notes = textBox1.Text;
            NewLicense.CreatedByUserID = 1;//////////////////
            NewLicense.IsActive = 1;
            NewLicense.IssueReason = 1;/////////////////////
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(NewLicense.AddNewLicense())
            {
                MessageBox.Show("Local License Added Successfully");
            }
            else
            {
                MessageBox.Show("Local License not Added");
            }
            this.Close();
        }
    }
}
