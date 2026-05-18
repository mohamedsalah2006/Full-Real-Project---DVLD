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
using DVDL_Project.Properties;
using static BusinessLayer.clsTestsTypesBusiness;

namespace DVDL_Project.Tests
{
    public partial class ScheduledTest: UserControl
    {
        clsTestsTypesBusiness.enTestType _TestTypeID;
        clsLocalDrivingLicenseApplicationsBusiness _LocalDrivingLicenseApplication;
        clsTestAppointmentsBusiness _TestAppointment;


        int _TestAppointmentID = -1;
        int TestAppointmentID
        {
            get
            {
                return _TestAppointmentID;
            }
        }


        int _TestID = -1;
       

        int _LocalDrivingLicenseApplicationID = -1;
        



        public ScheduledTest()
        {
            InitializeComponent();
        }


        void _HandleTestType()
        {
            switch (_TestTypeID)
            {

                case clsTestsTypesBusiness.enTestType.VisionTest:
                    {
                        gbTestType.Text = "Vision Test";
                        pbTestTypeImage.Image = Resources.Vision_512;
                        break;
                    }

                case clsTestsTypesBusiness.enTestType.WrittenTest:
                    {
                        gbTestType.Text = "Written Test";
                        pbTestTypeImage.Image = Resources.Written_Test_512;
                        break;
                    }
                case clsTestsTypesBusiness.enTestType.StreetTest:
                    {
                        gbTestType.Text = "Street Test";
                        pbTestTypeImage.Image = Resources.driving_test_512;
                        break;


                    }
            }
        }
        void _RefreshData()
        {
            lblDL_App_ID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblD_Class.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblPersonName.Text = _LocalDrivingLicenseApplication.PersonInfo.FullName;
            //this will show the trials for this test before 
            lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest((int)_TestTypeID).ToString();
            dateTimePicker1.Value = _TestAppointment.AppointmentDate;
            lblFees.Text = _TestAppointment.PaidFees.ToString();
            lblTestID.Text = (_TestAppointment.TestID == -1) ? "Not Taken Yet" : _TestAppointment.TestID.ToString();

            

        }
        public void LoadInfo(int TestAppointmentID, clsTestsTypesBusiness.enTestType TestTypeId)
        {
            _TestTypeID = TestTypeId;
            _HandleTestType();
            

            _TestAppointmentID=TestAppointmentID;
            _TestAppointment = clsTestAppointmentsBusiness.GetTestAppointmentByID(TestAppointmentID);
            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No  Appointment ID = " + _TestAppointmentID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _TestAppointmentID = -1;
                return;
            }

            _TestID = _TestAppointment.TestID;

            _LocalDrivingLicenseApplicationID = _TestAppointment.LocalDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplicationsBusiness.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _RefreshData();

        }
        private void gbTestType_Enter(object sender, EventArgs e)
        {

        }
    }
}
