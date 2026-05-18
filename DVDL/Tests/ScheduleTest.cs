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
using DVDL_Project.Global_Classes;
using DVDL_Project.Properties;

namespace DVDL_Project.Tests
{
    public partial class ScheduleTest : UserControl
    {
        public ScheduleTest()
        {
            InitializeComponent();
        }

        private void ScheduleTest_Load(object sender, EventArgs e)
        {

        }


        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        public enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1 };
        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;


        private clsLocalDrivingLicenseApplicationsBusiness _LocalDrivingLicenseApplication;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestAppointmentsBusiness _TestAppointment;
        private int _TestAppointmentID = -1;

        private clsTestsTypesBusiness.enTestType _TestTypeID = clsTestsTypesBusiness.enTestType.VisionTest;
       

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

      


        public void LoadInfo(int LocalDrivingLicenseApplicationID,clsTestsTypesBusiness.enTestType TestType, int AppointmentID = -1)
        {
            //if no appointment id this means AddNew mode otherwise it's update mode.
            if (AppointmentID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

            

            _TestTypeID = TestType;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = AppointmentID;


            _HandleTestType();


            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplicationsBusiness.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }



            //decide if the createion mode is retake test or not based if the person attended this test before
            if (_LocalDrivingLicenseApplication.IsFailedInTest((int) _TestTypeID))

                _CreationMode = enCreationMode.RetakeTestSchedule;
            else
                _CreationMode = enCreationMode.FirstTimeSchedule;

            //======================================================================


            if (_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                lblRetakeAppFees.Text = clsApplicationsTypesBusiness.GetApplicationTypeInfoByID((int)clsApplicationsBusiness.enApplicationType.RetakeTest).Fees.ToString();
                gbRetakeTestInfo.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                lblRetakeTestAppID.Text = "0";
            }
            else
            {
                gbRetakeTestInfo.Enabled = false;
                lblTitle.Text = "Schedule Test";
                lblRetakeAppFees.Text = "0";
                lblRetakeTestAppID.Text = "N/A";
            }
            //======================================================================

            lblLocalDrivingLicenseAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblFullName.Text = _LocalDrivingLicenseApplication.PersonInfo.FullName;
            //this will show the trials for this test before  
            lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest((int)_TestTypeID).ToString();
            lblFees.Text = clsTestsTypesBusiness.Find(_TestTypeID).TestFees.ToString();


            if (_Mode == enMode.AddNew)
            {
                dtpTestDate.MinDate = DateTime.Now;
                lblRetakeTestAppID.Text = "N/A";

                _TestAppointment = new clsTestAppointmentsBusiness();
            }
            else
            {

                if (!_LoadTestAppointmentData())
                    return;
            }


            lblTotalFees.Text = (Convert.ToSingle(lblFees.Text) + Convert.ToSingle(lblRetakeAppFees.Text)).ToString();


            if (!_HandleActiveTestAppointmentConstraint())
                return;

            if (!_HandleAppointmentLockedConstraint())
                return;

            if (!_HandlePreviousTestConstraint())
                return;



        }

        private bool _LoadTestAppointmentData()
        {
            _TestAppointment = clsTestAppointmentsBusiness.GetTestAppointmentByID(_TestAppointmentID);

            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No Appointment with ID = " + _TestAppointmentID.ToString(),
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }

            lblFees.Text = _TestAppointment.PaidFees.ToString();

            //we compare the current date with the appointment date to set the min date.
            if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
                dtpTestDate.MinDate = DateTime.Now;
            else
                dtpTestDate.MinDate = _TestAppointment.AppointmentDate;

            dtpTestDate.Value = _TestAppointment.AppointmentDate;
            //=====================================================


            if (_TestAppointment.RetakeTestApplicationID == -1)
            {
                lblRetakeAppFees.Text = "0";
                lblRetakeTestAppID.Text = "N/A";
            }
            else
            {
                lblRetakeAppFees.Text = _TestAppointment.RetakeTestAppInfo.PaidFees.ToString();
                gbRetakeTestInfo.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                lblRetakeTestAppID.Text = _TestAppointment.RetakeTestApplicationID.ToString();

            }
            return true;
        }

        private bool _HandleActiveTestAppointmentConstraint()
        {
            if (_Mode == enMode.AddNew && clsTestAppointmentsBusiness.IsPersonHasActiveAppointment(_LocalDrivingLicenseApplicationID, (int)_TestTypeID))
            {
                lblUserMessage.Text = "Person Already have an active appointment for this test";
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
                return false;
            }

            return true;
        }
        private bool _HandleAppointmentLockedConstraint()
        {
            //if appointment is locked that means the person already sat for this test
            //we cannot update locked appointment
            if (_TestAppointment.IsLocked==1)
            {
                lblUserMessage.Visible = true;
                lblUserMessage.Text = "Person already sat for the test, appointment loacked.";
                dtpTestDate.Enabled = false;
                btnSave.Enabled = false;
                return false;

            }
            else
                lblUserMessage.Visible = false;

            return true;
        }
        private bool _HandlePreviousTestConstraint()
        {
            //we need to make sure that this person passed the prvious required test before apply to the new test.
            //person cannno apply for written test unless s/he passes the vision test.
            //person cannot apply for street test unless s/he passes the written test.

            switch (_TestTypeID)
            {
                case clsTestsTypesBusiness.enTestType.VisionTest:
                    //in this case no required prvious test to pass.
                    lblUserMessage.Visible = false;

                    return true;

                case clsTestsTypesBusiness.enTestType.WrittenTest:
                    //Written Test, you cannot sechdule it before person passes the vision test.
                    //we check if pass visiontest 1.
                    if (!_LocalDrivingLicenseApplication.DidThePersonPassInThisTestType((int)clsTestsTypesBusiness.enTestType.VisionTest))
                    {
                        lblUserMessage.Text = "Cannot Sechule, Vision Test should be passed first";
                        lblUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpTestDate.Enabled = true;
                    }


                    return true;

                case clsTestsTypesBusiness.enTestType.StreetTest:

                    //Street Test, you cannot sechdule it before person passes the written test.
                    //we check if pass Written 2.
                    if (!_LocalDrivingLicenseApplication.DidThePersonPassInThisTestType((int)clsTestsTypesBusiness.enTestType.WrittenTest))
                    {
                        lblUserMessage.Text = "Cannot Sechule, Written Test should be passed first";
                        lblUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpTestDate.Enabled = true;
                    }


                    return true;

            }
            return true;

        }
        private bool _HandleRetakeApplication()
        {
            //this will decide to create a seperate application for retake test or not.
            // and will create it if needed , then it will linkit to the appoinment.
            if (_Mode == enMode.AddNew && _CreationMode == enCreationMode.RetakeTestSchedule)
            {


               




                clsApplicationsBusiness Application = new clsApplicationsBusiness();

                Application.ApplicationDate = DateTime.Now;
                Application.ApplicationType = clsApplicationsBusiness.enApplicationType.RetakeTest;
                Application.ApplicationStatus = clsApplicationsBusiness.enApplicationStatus.Completed;
                Application.LastStatusDate = DateTime.Now;
                Application.PaidFees = clsApplicationsTypesBusiness.GetApplicationTypeInfoByID((int)clsApplicationsBusiness.enApplicationType.RetakeTest).Fees;
                Application.CreatedByUser = clsGlobal.CurrentUser.UserID;
                Application.PersonID = _LocalDrivingLicenseApplication.PersonID;

                if (!Application.Save())
                {
                    _TestAppointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Failed to Create application", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestAppointment.RetakeTestApplicationID = Application.ApplicationID;

            }
            return true;
        }



        private void btnSave_Click_1(object sender, EventArgs e)
        {

            if (!_HandleRetakeApplication())
                return;

            _TestAppointment.TestTypeID = (int)_TestTypeID;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
            _TestAppointment.AppointmentDate = dtpTestDate.Value;
            _TestAppointment.PaidFees = Convert.ToSingle(lblFees.Text);
            _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_TestAppointment.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
