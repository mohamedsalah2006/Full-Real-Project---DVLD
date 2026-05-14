using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL_Project.Applications.Local_License
{
    public partial class frmShowLocalDrivingLicenseApplicationInfo : Form
    {
        public frmShowLocalDrivingLicenseApplicationInfo(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            localDrivingLicenseAppInfo1.LoadLocalDrivingLicenseAppInfo(LocalDrivingLicenseApplicationID);
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
