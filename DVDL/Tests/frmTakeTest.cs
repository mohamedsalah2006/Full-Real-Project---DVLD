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
    public partial class frmTakeTest : Form
    {
        int _TestAppointmentID;
        public frmTakeTest(int TestAppointmentID)
        {
            _TestAppointmentID=TestAppointmentID;
            InitializeComponent();

            _LoadData();
        }

        void _LoadData()
        {

            clsTestAppointmentsBusiness _TestAppointment = clsTestAppointmentsBusiness.FindTestAppointmentByID(_TestAppointmentID);

            vesionTestcs1.LD_AppInf = clsLocalDrivingLicenseAppBusiness_View.FindLocalLicenseApp_View(_TestAppointment.LocalDrivingLicenseID);

            vesionTestcs1.AppointmentDate = _TestAppointment.AppointmentDate;

            vesionTestcs1.dateTimePicker1.Enabled = false;
            if (_TestAppointment.IsLocked == 1)
            {
               
                rbFail.Enabled = false;
                rbPass.Enabled = false;
                txtMassage.Enabled = false;
                btnSave.Enabled = false;
                lblMassage.Text = "Person already sat for the test , appointment locked";
            }
            

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            int Result = Convert.ToInt32(rbPass.Checked);
            string Notes = txtMassage.Text.ToString();
            

            if(clsTestBusiness.TakeTest(_TestAppointmentID, Result, Notes, 1))
            {
                MessageBox.Show("Data Saved Successfully");
            }
            else
            {
                MessageBox.Show("Data Not Saved ");

            }
            this.Close();

        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
