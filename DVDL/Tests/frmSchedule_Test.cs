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

namespace DVDL_Project.Tests
{
    public partial class frmSchedule_Test : Form
    {
        int _LocalDrivingLicenseApplicationID = -1;
        clsTestsTypesBusiness.enTestType _TestTypeID = clsTestsTypesBusiness.enTestType.VisionTest;
        int _AppointmentID = -1;
        public frmSchedule_Test(int LocalDrivingLicenseApplicationID, clsTestsTypesBusiness.enTestType TestTypeID, int AppointmentID= -1)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
            _AppointmentID = AppointmentID;
        }

        private void frmSchedule_Test_Load(object sender, EventArgs e)
        {
            scheduleTest1.LoadInfo(_LocalDrivingLicenseApplicationID,_TestTypeID, _AppointmentID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
