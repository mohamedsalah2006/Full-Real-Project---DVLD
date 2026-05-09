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
    public partial class frmInternationalLicenseInfo : Form
    {
        int _LocalLicenseID;
        public frmInternationalLicenseInfo(int LocalLicenseID)
        {
            InitializeComponent();
            _LocalLicenseID = LocalLicenseID;
        }

        
        private void frmInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            internationalLicenseInfo1.InternationalDrivingLicense = clsInternationalDrivingLicenseBusiness.GetInternationalDrivingLicense(_LocalLicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
