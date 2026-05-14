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

namespace DVDL_Project
{
    public partial class frmAddOrUpdateLocalLicense : Form
    {
        




        public enum enMode { AddNew = 0, Update = 1 }
        enMode Mode;

        int _PersonID = -1;
        int _LocalDrivingLicenseAppID;

        clsLocalDrivingLicenseApplicationsBusiness _LocalDrivingLicenseApplication;
        clsApplicationsBusiness Application;



        public frmAddOrUpdateLocalLicense()
        {
            InitializeComponent();
            _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplicationsBusiness();
            Mode=enMode.AddNew;
        }
        public frmAddOrUpdateLocalLicense(int LocalDrivingLicenseAppID)
        {
            InitializeComponent();
            Mode = enMode.Update;
            _LocalDrivingLicenseAppID=LocalDrivingLicenseAppID;
        }


        void _FillCbLicenseClass()
        {
            DataTable LicenseClass = clsLicenseClassesBusiness.GetAllLicenseClasses();
            foreach (DataRow row in LicenseClass.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }
            cbLicenseClass.SelectedIndex = 0;
        }
        void _ResetDefaultValues()
        {
            _FillCbLicenseClass();

            if (Mode == enMode.AddNew)
            {

                

                lblMode.Text = "Add New Local Driving Application";
                this.Text = "Add New Local Driving Application";

                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplicationsBusiness();
                findPerson1.FilterFocus();

                lblAppDate.Text = DateTime.Now.ToString();
                cbLicenseClass.SelectedIndex = 2;
                lblAppFees.Text = clsApplicationsTypesBusiness.GetApplicationTypeInfoByID((int)clsApplicationsBusiness.enApplicationType.NewDrivingLicense).Fees.ToString();
               lblUserName.Text=clsGlobal.CurrentUser.UserName;
            }
            else
            {
                lblMode.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                tabApplication.Enabled = true;
                btnSave.Enabled = true;
            }
        }
        void _Load()
        {
            findPerson1.FilterEnabled = false;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplicationsBusiness.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseAppID);

            if(_LocalDrivingLicenseApplication == null )
            {

                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseAppID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            findPerson1.LoadPersonInfo(_LocalDrivingLicenseApplication.PersonID);
            lblAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblAppDate.Text =(_LocalDrivingLicenseApplication.ApplicationDate.ToString());
            cbLicenseClass.SelectedIndex = _LocalDrivingLicenseApplication.LicenseClassID - 1;
            lblAppFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblUserName.Text = clsUsersBusiness.FindUserByUserID(_LocalDrivingLicenseApplication.CreatedByUser).UserName;



        }

        private void frmAddNewLocalLicense_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (Mode == enMode.Update) 
            {
                _Load();
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tabApplication.Enabled = true;
                tcApplicationInfo.SelectedIndex = 1;
                return;
            }

            _PersonID = findPerson1.PersonID;
            if (_PersonID != 0)
            {
                tcApplicationInfo.SelectedIndex = 1;
                btnSave.Enabled = true;
                tabApplication.Enabled = true;

            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                findPerson1.FilterFocus();
            }
        }
      
        bool AddNewApplication()
        {

            _LocalDrivingLicenseApplication.PersonID = findPerson1.PersonID; 
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationType = clsApplicationsBusiness.enApplicationType.NewDrivingLicense;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplicationsBusiness.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.PaidFees = clsLicenseClassesBusiness.GetLicenseClassInfo(cbLicenseClass.SelectedIndex + 1).ClassFees;
            _LocalDrivingLicenseApplication.CreatedByUser = clsGlobal.CurrentUser.UserID;
            _LocalDrivingLicenseApplication.LicenseClassID = cbLicenseClass.SelectedIndex + 1;


            if (_LocalDrivingLicenseApplication.Save())
            {
                return true;
            }
            else
            {
                return false;
            }



        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _PersonID = findPerson1.PersonID;



            int ActiveApplicationID = clsApplicationsBusiness.GetActiveApplicationIDForLicenseClass(_PersonID, clsApplicationsBusiness.enApplicationType.NewDrivingLicense, cbLicenseClass.SelectedIndex+1);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }

            if (clsLicenseBusiness.DidLicenseExistByPersonID(_PersonID, cbLicenseClass.SelectedIndex+1))
            {

                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            


            if(AddNewApplication())
            {

                lblAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblMode.Text = "Update Local Driving License Application";

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void findPerson1_Load(object sender, EventArgs e)
        {

        }

        private void frmAddOrUpdateLocalLicense_Activated(object sender, EventArgs e)
        {
            findPerson1.FilterFocus();
        }
    }
}
