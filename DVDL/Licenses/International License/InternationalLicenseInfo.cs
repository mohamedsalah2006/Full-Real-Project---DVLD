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
    public partial class InternationalLicenseInfo : UserControl
    {
        public InternationalLicenseInfo()
        {
            InitializeComponent();
        }
        public void LoadInternationalLicenseInfo(int InternationalLicenseID)
        {
            //clsI
        }
        public clsInternationalDrivingLicenseBusiness InternationalDrivingLicense
        {
            set
            {
                
                lblDateOfBirth.Text = value.DateOfBirth.ToString();
                lblDriverId.Text = value.DriverID.ToString();
                lblExDate.Text = value.ExpirationDate.ToString();
                lblIsActive.Text = value.IsActive.ToString();
                lblIssueDate.Text = value.IssueDate.ToString();
                lblLicenseId.Text = value.LicenseID.ToString();
                lblName.Text = value.FullName;
                lblNathional.Text = value.NationalNo.ToString();
                lblIntLicense.Text=value.InternationalLicenseID.ToString();
               lblApplication.Text=value.ApplicationID.ToString();

                if (!string.IsNullOrEmpty(value.ImagePath))
                    pictureBox1.ImageLocation = value.ImagePath;

                if (value.Gendor == 0)
                    lblGendor.Text = "Male";
                else
                    lblGendor.Text = "Female";
            }
        }

        private void InternationalLicenseInfo_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
