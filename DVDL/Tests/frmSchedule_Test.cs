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
    public partial class frmSchedule_Test : Form
    {
        public enum enMode { AddNew = 0, Update = 1 }
        enMode Mode;

        int _TestID;
        int _LD_LicenseID;
        int _PersonID;
        int _TestTypeID;
       

        clsTestAppointmentsBusiness _TestAppointment;
        public frmSchedule_Test(int TestID,int LD_LicenseID,int PersonID,int TestTypeID)
        {
            InitializeComponent();
            _TestID = TestID;
            _LD_LicenseID = LD_LicenseID;
            _TestTypeID = TestTypeID;
            _PersonID = PersonID;

            if (_TestID == 0)
            {
                Mode = enMode.AddNew;
            }
            else
            {
                Mode = enMode.Update;
            }
            _LoadData();

        }

        void _AddRetakeApp()
        {
            clsApplicationsBusiness retake_app = new clsApplicationsBusiness();

           // retake_app.ApplicationStatus = 1;
            retake_app.ApplicationDate = DateTime.Now;
            retake_app.LastStatusDate = DateTime.Now;
            retake_app.ApplicationType = clsApplicationsBusiness.enApplicationType.RetakeTest;
            retake_app.PaidFees = clsApplicationsTypesBusiness.GetApplicationTypeInfoByID(8).Fees;
            retake_app.CreatedByUser = 1;
            retake_app.PersonID = _PersonID;

            retake_app.Save();

            groupBox1.Enabled = true;
            lblRetakeFees.Text = "5";
            lblTotalFees.Text = "15";
            lblRetakeTestAppID.Text=retake_app.ApplicationID.ToString();
        }
        void _LoadData()
        {
            TestInfo1.LD_AppInf = clsLocalDrivingLicenseAppBusiness_View.FindLocalLicenseApp_View(_LD_LicenseID);
            
            if (clsTestAppointmentsBusiness.IsFailedInTest(_LD_LicenseID,_TestTypeID))
            {
                _AddRetakeApp();
            }

            if (Mode==enMode.AddNew)
            {
                _TestAppointment = new clsTestAppointmentsBusiness();
                
                return;
            }

            _TestAppointment = clsTestAppointmentsBusiness.FindTestAppointmentByID(_TestID);
            
            TestInfo1.AppointmentDate = _TestAppointment.AppointmentDate;

            if(_TestAppointment.IsLocked==1)
            {
                TestInfo1.dateTimePicker1.Enabled = false;
                btnSave.Enabled = false;
                lblMessage.Text = "Person already sat for the test , appointment locked";
            }


            
        }
        
        int PaidFees()
        {
            if (_TestTypeID == 1)
                return 10;
            else if (_TestTypeID == 2)
                return 20;
            else
                return 30;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            _TestAppointment.TestTypeID = _TestTypeID;
            _TestAppointment.AppointmentDate = TestInfo1.AppointmentDate;
            _TestAppointment.PaidFees = PaidFees();
            _TestAppointment.CreatedByUserID = 1;
            _TestAppointment.IsLocked = 0;
            _TestAppointment.LocalDrivingLicenseID = _LD_LicenseID;


            if (_TestAppointment.Save())
            {
                MessageBox.Show("Test Appointment Data Saved Successfully");
            }
            else
            {
                MessageBox.Show("Test Appointment not Added ");
            }
            this.Close();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TestInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
