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

namespace DVDL_Project
{
    public partial class frmLicenseHistory : Form
    {
        int _DriverID;
        clsDriverBusiness _DriverInfo;

        public frmLicenseHistory(int DriverID)
        {
            InitializeComponent();
            _DriverID = DriverID;
        }

        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {
            _DriverInfo = clsDriverBusiness.GetDriverInfoByDriverID(_DriverID);
            if (_DriverInfo == null ) 
            {

            }

            findPerson1.LoadPersonInfo(_DriverInfo.PersonID);
            findPerson1.FilterEnabled = false;

            driverLicenseHistory1.LoadDriverLicense(_DriverID);
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
