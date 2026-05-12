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
    public partial class frmAddNewInternationalLicense : Form
    {
        public frmAddNewInternationalLicense()
        {
            InitializeComponent();
        }



        string _NationalNo;

        clsApplicationsBusiness _NewApp = new clsApplicationsBusiness();
        clsLicenseBusiness _LicenseInfo;
        
        private void btnFindLocalLicense_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32(txtLicenseID.Text);
            _LicenseInfo = clsLicenseBusiness.FindActiveLicenseByID_ClassID(LicenseID);

            if (_LicenseInfo == null)
            {
                MessageBox.Show("This License Not Correct");
                return;
            }


            if(clsInternationalLicenseBusiness.IsPersonHasInternationalLicense(LicenseID))
            {
                applicationBasicInfo1.ApplicationInfo = clsApplicationsBusiness.FindApplication(_LicenseInfo.ApplicationID);
                clsDriverLicenseBusiness DriverLicense = clsDriverLicenseBusiness.GetDriverLicenseInfoBY_LocalLicenseID(LicenseID);
                driverLicense1.driverLicense = DriverLicense;

                _NationalNo = DriverLicense.NationalNo;

                linklblbShowLicense.Enabled = true;
                linklblShowLicenseHistory.Enabled = true;
                btnSave.Enabled = false;
                MessageBox.Show("This Person Has International License Already");

            }
            else
            {

               // _NewApp.ApplicationStatus = 1;
                _NewApp.ApplicationDate = DateTime.Now;
                _NewApp.ApplicationType = clsApplicationsBusiness.enApplicationType.NewInternationalLicense;
                _NewApp.LastStatusDate = DateTime.Now;
                _NewApp.PaidFees = clsApplicationsTypesBusiness.GetApplicationTypeInfoByID(6).Fees;
                _NewApp.CreatedByUser = 1;
                _NewApp.PersonID = _LicenseInfo.PersonID;
                _NewApp.Save();
                
                

                //============================================


                applicationBasicInfo1.ApplicationInfo = _NewApp;
                driverLicense1.driverLicense = clsDriverLicenseBusiness.GetDriverLicenseInfoBY_LocalLicenseID(LicenseID);

            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsInternationalLicenseBusiness I_License = new clsInternationalLicenseBusiness();

            
            I_License.ApplicationID = _NewApp.ApplicationID;
            I_License.DriverID = _LicenseInfo.DriverID;
            I_License.CreatedByUserID = 1;
            I_License.IssueDate = DateTime.Now;
            I_License.ExpirationDate = DateTime.Now.AddYears(1);
            I_License.IsActive = 1;
            I_License.IssuedUsingLocalLicenseID = _LicenseInfo.LicenseID;


            if (I_License.InsertInternationalLicense())
            {
                linklblbShowLicense.Enabled = true;
                linklblShowLicenseHistory.Enabled = true;
                MessageBox.Show("International License Added Successfully");

            }
            else
            {
                MessageBox.Show("International License Added Successfully");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(_LicenseInfo.LicenseID);
            frm.ShowDialog();
        }

        private void linklblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory(_NationalNo);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
