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
    public partial class DriverLicense : UserControl
    {
        int _LicenseID;
        public int LicenseID
        {
            get { return _LicenseID; }
        }


        clsLicenseBusiness _LicenseInfo;
        public clsLicenseBusiness SelectedLicenseInfo
        { get { return _LicenseInfo; } }


        public DriverLicense()
        {
            InitializeComponent();
        }
        public void LoadDriverLicenseInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            _LicenseInfo = clsLicenseBusiness.GetLicenseInfo(LicenseID);

            if(_LicenseInfo == null )
            {
                MessageBox.Show("Could not find License ID = " + LicenseID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }
            
            lblClass.Text = _LicenseInfo.LicenseClassIfo.ClassName;
            lblDateOfBirth.Text = _LicenseInfo.DriverInfo.PersonInfo.DateOfBirth.ToString();
            lblDriverId.Text = _LicenseInfo.DriverID.ToString();
            lblExDate.Text = _LicenseInfo.ExpirationDate.ToString();
            lblIsActive.Text = (_LicenseInfo.IsActive == 1) ? "Yes" : "No";
            lblIsDetained.Text = (_LicenseInfo.IsDetained) ? "Yes" : "No";
            lblIssueDate.Text = _LicenseInfo.IssueDate.ToString();
            lblIssueReson.Text = _LicenseInfo.IssueReason.ToString();
            lblLicenseId.Text = _LicenseInfo.LicenseID.ToString();
            lblName.Text = _LicenseInfo.DriverInfo.PersonInfo.FullName;
            lblNathional.Text =     _LicenseInfo.DriverInfo.PersonInfo.NationalNo;
            lblNotes.Text = _LicenseInfo.Notes.ToString();
            lblGendor.Text = (_LicenseInfo.DriverInfo.PersonInfo.Gendor == 0) ? "Male" : "Female";


            // Image 
          
            if (_LicenseInfo.DriverInfo.PersonInfo.Gendor==0)
                pictureBox1.Image = Resources.Male_512;
            else
                pictureBox1.Image = Resources.Female_512;

            string ImagePath = _LicenseInfo.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pictureBox1.Load(ImagePath);
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        

            
        }
       
        
        private void DriverLicense_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
