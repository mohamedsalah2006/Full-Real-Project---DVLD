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
    public partial class frmLicenseHistory : Form
    {
        int _DriverID;
        public frmLicenseHistory(int DriverID)
        {
            InitializeComponent();
            _DriverID = DriverID;
        }

        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {
            personInfo1.LoadPersonInfo(clsDriverBusiness.GetDriverInfoByDriverID(_DriverID).PersonID);
            dgvLocalLicenses.DataSource = clsLicenseBusiness.GetDriverLocalLicense(_DriverID);
            dgvInternationalLicenses.DataSource = clsInternationalLicenseBusiness.GetAllInternationalLicenseToPerson(_DriverID);

            
        }

        private void personInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
