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
    public partial class frmTestAppointment : Form
    {
        int _L_D_App;
        int _UserID;
        int _PersonID;
        int _TestTypeID;
        public frmTestAppointment(int L_D_App,int TestTypeID)
        {
            this._L_D_App = L_D_App;
            this._TestTypeID = TestTypeID;
            InitializeComponent();

        }

        private void frmVisionTestAppointment_Load(object sender, EventArgs e)
        {

            if(_TestTypeID==1)
            {
                lblMode.Text = "Vesion Test Appointments";
            }
            else if( _TestTypeID==2)
            {
                lblMode.Text = "Written Test Appointments";
                pbMode.Load(@"D:\Изображения\DVDL Icons\test.png");
            }
            else if(_TestTypeID == 3)
            {
                lblMode.Text = "Street Test Appointments";
                pbMode.Load("D:\\Изображения\\DVDL Icons\\car_alarm.png");
            }


            dgvAppointments.DataSource = clsTestAppointmentsBusiness.GetTestAppointmentsByTestTypeID(_L_D_App, _TestTypeID);

            clsLocalDrivingLicenseApplicationsBusiness LocalLicenseInfo = clsLocalDrivingLicenseApplicationsBusiness.FindByLocalDrivingAppLicenseID(_L_D_App);
            clsLocalDrivingLicenseAppBusiness_View LocalLicenseView = clsLocalDrivingLicenseAppBusiness_View.FindLocalLicenseApp_View(_L_D_App);
            clsApplicationsBusiness App = clsApplicationsBusiness.FindApplication(LocalLicenseInfo.AppID);


            drivingLicenseAppInfo2.LoadLocalDrivingLicenseAppInfo(_L_D_App);

            _UserID = App.CreatedByUser;
            _PersonID=App.PersonID;
        }

        private void drivingLicenseAppInfo1_Load(object sender, EventArgs e)
        {

        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {

            if(clsTestBusiness.DidThePersonPassInThisTestType(_L_D_App, _TestTypeID))
            {
                MessageBox.Show("This Person Already Passed In This Test");
                return;
            }

            if(clsTestAppointmentsBusiness.IsPersonHasActiveAppointmentt(_L_D_App, _TestTypeID))
            {
                MessageBox.Show("This person has active appointments");
                return;
            }

            

            else
            {
                frmSchedule_Test frm = new frmSchedule_Test(0,_L_D_App,_PersonID,_TestTypeID);
                frm.ShowDialog();
                dgvAppointments.DataSource = clsTestAppointmentsBusiness.GetTestAppointmentsByTestTypeID(_L_D_App, _TestTypeID);

            }

               
        }

        private void takeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTakeTest frm = new frmTakeTest((int)dgvAppointments.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSchedule_Test frm = new frmSchedule_Test((int)dgvAppointments.CurrentRow.Cells[0].Value, _L_D_App,_PersonID,_TestTypeID);
            frm.ShowDialog();
        }
    }
}
