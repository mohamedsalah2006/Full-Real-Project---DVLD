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
    public partial class frmAddNewLocalLicense : Form
    {
        public frmAddNewLocalLicense()
        {
            InitializeComponent();
        }




        public enum enMode { AddNew = 0, Update = 1 }
        enMode Mode;

        int _PersonID = -1;

        clsApplicationsBusiness Application;


        void _FillCbLicenseClass()
        {
            DataTable LicenseClass = clsLicenseClassesBusiness.GetAllLicenseClasses();
            foreach (DataRow row in LicenseClass.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }
            cbLicenseClass.SelectedIndex = 0;
        }
        void _LoadData()
        {
            _FillCbLicenseClass();
            lblAppDate.Text = DateTime.Now.ToString();
            lblUserName.Text = "Mohamed"; ///<==============
        }
        private void frmAddNewLocalLicense_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        bool AddNewApplication()
        {
            Application = new clsApplicationsBusiness();

            Application.ApplicationDate = DateTime.Now;
            //Application.ApplicationStatus = 1;
            Application.ApplicationType = 1;
            Application.LastStatusDate = DateTime.Now;
            Application.CreatedByUser = 1;
            Application.PaidFees = clsApplicationsTypesBusiness.GetApplicationTypeInfoByID(Application.ApplicationType).Fees;
            Application.PersonID = _PersonID;

           // if (clsLocalDrivingLicenseApplicationsBusiness.IsApplicationWright((clsApplicationsBusiness.enApplicationStatus)Application.ApplicationStatus,cbLicenseClass.SelectedIndex+1,Application.PersonID))
            {
                return false;
            }
           // Application.Save();
            return true;
           
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _PersonID = findPerson1.PersonID;


            if (_PersonID!=-1)
            {
                if(!AddNewApplication())
                {
                    MessageBox.Show("This person has this Application Already");
                    return;

                }
                if(clsLicenseBusiness.ISPersonHasThisLicense(_PersonID, cbLicenseClass.SelectedIndex + 1))
                {
                    MessageBox.Show("This person has this License Already");
                    return;
                }
                if ( clsLocalDrivingLicenseApplicationsBusiness.AddNewLocalDrivingLicenseApplications(Application.ApplicationID, cbLicenseClass.SelectedIndex + 1))
                {
                    MessageBox.Show("LocalApp save successfully");
                }
                else
                {
                    MessageBox.Show("LocalApp not save successfully","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }





            }
            else
            {
                MessageBox.Show("You must enter person", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linklblNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _PersonID = findPerson1.PersonID;
            if (_PersonID != -1)
            {
                tabControl1.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show("You must enter person", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void findPerson1_Load(object sender, EventArgs e)
        {

        }
    }
}
