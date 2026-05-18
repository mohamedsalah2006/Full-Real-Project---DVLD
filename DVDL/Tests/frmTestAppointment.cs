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
using DVDL_Project.Tests;
using static BusinessLayer.clsTestsTypesBusiness;

namespace DVDL_Project
{
    public partial class frmTestAppointment : Form
    {
        int _LocalDrivingLicenseApplicationID;
        clsTestsTypesBusiness.enTestType _TestTypeID;
        public frmTestAppointment(int L_D_App, clsTestsTypesBusiness.enTestType TestTypeID)
        {
            this._LocalDrivingLicenseApplicationID = L_D_App;
            this._TestTypeID = TestTypeID;
            InitializeComponent();

        }
        void _RefreshData()
        {
            drivingLicenseAppInfo2.LoadLocalDrivingLicenseAppInfo(_LocalDrivingLicenseApplicationID);
            dgvAppointments.DataSource = clsTestAppointmentsBusiness.GetTestAppointmentsByTestTypeID(_LocalDrivingLicenseApplicationID, (int)_TestTypeID);


            if (dgvAppointments.Rows.Count > 0)
            {
                dgvAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvAppointments.Columns[0].Width = 150;

                dgvAppointments.Columns[1].HeaderText = "Appointment Date";
                dgvAppointments.Columns[1].Width = 200;

                dgvAppointments.Columns[2].HeaderText = "Paid Fees";
                dgvAppointments.Columns[2].Width = 150;

                dgvAppointments.Columns[3].HeaderText = "Is Locked";
                dgvAppointments.Columns[3].Width = 100;
            }


        }
        void _HandleMode()
        {
            switch (_TestTypeID)
            {

                case clsTestsTypesBusiness.enTestType.VisionTest:
                    {
                        lblMode.Text = "Vision Test Appointments";
                        this.Text = lblMode.Text;
                        pbMode.Image = Resources.Vision_512;
                        break;
                    }

                case clsTestsTypesBusiness.enTestType.WrittenTest:
                    {
                        lblMode.Text = "Written Test Appointments";
                        this.Text = lblMode.Text;
                        pbMode.Image = Resources.Written_Test_512;
                        break;
                    }
                case clsTestsTypesBusiness.enTestType.StreetTest:
                    {
                        lblMode.Text = "Street Test Appointments";
                        this.Text = lblMode.Text;
                        pbMode.Image = Resources.driving_test_512;
                        break;
                    }
            }
        }

        private void frmTestAppointment_Load(object sender, EventArgs e)
        {

            _HandleMode();
            _RefreshData();


            clsLocalDrivingLicenseApplicationsBusiness LocalLicenseInfo = clsLocalDrivingLicenseApplicationsBusiness.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            
        }

       

        private void btnAddPerson_Click(object sender, EventArgs e)
        {

            if (clsTestAppointmentsBusiness.IsPersonHasActiveAppointment(_LocalDrivingLicenseApplicationID, (int)_TestTypeID))
            {

                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsTestBusiness.DidThePersonPassInThisTestType(_LocalDrivingLicenseApplicationID,(int) _TestTypeID))
            {
                MessageBox.Show("This person already passed this test before, you can only retake failed test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }






            frmSchedule_Test frm = new frmSchedule_Test(_LocalDrivingLicenseApplicationID, _TestTypeID);
           frm.ShowDialog();
            dgvAppointments.DataSource = clsTestAppointmentsBusiness.GetTestAppointmentsByTestTypeID(_LocalDrivingLicenseApplicationID, (int)_TestTypeID);




        }

        private void takeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTakeTest frm = new frmTakeTest((int)dgvAppointments.CurrentRow.Cells[0].Value, _TestTypeID);
            frm.ShowDialog();
            dgvAppointments.DataSource = clsTestAppointmentsBusiness.GetTestAppointmentsByTestTypeID(_LocalDrivingLicenseApplicationID, (int)_TestTypeID);


        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  frmSchedule_Test frm = new frmSchedule_Test(_LocalDrivingLicenseApplicationID, _TestTypeID, (int)dgvAppointments.CurrentRow.Cells[0].Value);
            //frm.ShowDialog();
            _RefreshData();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvAppointments.DataSource = null;
        }
    }
}
