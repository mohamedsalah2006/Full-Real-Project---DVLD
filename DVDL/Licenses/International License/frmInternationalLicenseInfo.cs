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
    public partial class frmShowInternationalLicenseInfo : Form
    {
        int _INT_LicenseInfo;
        public frmShowInternationalLicenseInfo(int INT_LicenseInfo)
        {
            InitializeComponent();
            _INT_LicenseInfo = INT_LicenseInfo;
        }

        
        private void frmInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            internationalLicenseInfo1.LoadInternationalLicenseInfo(_INT_LicenseInfo);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
