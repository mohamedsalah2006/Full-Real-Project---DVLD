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
using DVDL_Project.Properties;

namespace DVDL_Project
{
    public partial class InternationalLicenseInfo : UserControl
    {
        public InternationalLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadInternationalLicenseInfo(int InternationalLicenseID)
        {
            clsInternationalLicenseBusiness INT_LicenseInfo = clsInternationalLicenseBusiness.Find(InternationalLicenseID);
            if (INT_LicenseInfo == null)
            {
                return;
            }

            clsDriverBusiness DriverInfo = clsDriverBusiness.GetDriverInfoByDriverID(INT_LicenseInfo.DriverID);
            if (DriverInfo == null)
            {
                return;
            }

            lblDateOfBirth.Text = DriverInfo.PersonInfo.DateOfBirth.ToString();
            lblDriverId.Text = INT_LicenseInfo.DriverID.ToString();
            lblExDate.Text = INT_LicenseInfo.ExpirationDate.ToString();
            lblIsActive.Text = INT_LicenseInfo.IsActive.ToString();
            lblIssueDate.Text = INT_LicenseInfo.IssueDate.ToString();
            lblLicenseId.Text = INT_LicenseInfo.IssuedUsingLocalLicenseID.ToString();
            lblName.Text = DriverInfo.PersonInfo.FullName;
            lblNathional.Text = DriverInfo.PersonInfo.NationalNo.ToString();
            lblIntLicense.Text = INT_LicenseInfo.InternationalLicenseID.ToString();
            lblApplication.Text = INT_LicenseInfo.ApplicationID.ToString();
            lblGendor.Text = (DriverInfo.PersonInfo.Gendor == 0) ? "Male" : "Female";


            // Image

            if (DriverInfo.PersonInfo.Gendor == 0)
                pictureBox1.Image = Resources.Male_512;
            else
                pictureBox1.Image = Resources.Female_512;

            string ImagePath = DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pictureBox1.Load(ImagePath);
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



        }
        
        
    }
}
