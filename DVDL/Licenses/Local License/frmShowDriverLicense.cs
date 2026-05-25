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
    public partial class frmShowDriverLicense : Form
    {
        int _LicenseId;

        clsDriverLicenseBusiness driverLicense;
        public frmShowDriverLicense(int LicenseID)
        {
            InitializeComponent();
            _LicenseId = LicenseID;

        }
       



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDriverLicense_Load(object sender, EventArgs e)
        {
            driverLicense1.LoadDriverLicenseInfo(_LicenseId);
        }
    }
}
