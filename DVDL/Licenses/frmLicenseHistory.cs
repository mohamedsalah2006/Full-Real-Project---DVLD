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
        string _NationalNo;
        public frmLicenseHistory(string NationalNo)
        {
            InitializeComponent();
            _NationalNo = NationalNo;
        }

        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {
            personInfo1.LoadPersonInfo(_NationalNo);
            dgvLocalLicenses.DataSource = clsLocalDrivingLicenseApplicationsBusiness.GetPersonLocalLicense(_NationalNo);
            dgvInternationalLicenses.DataSource = clsInternationalLicenseBusiness.GetAllInternationalLicenseToPerson(_NationalNo);

            
        }

        private void personInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
