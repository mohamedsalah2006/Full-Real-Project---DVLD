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

namespace DVDL_Project.Tests
{
    public partial class frmTakeTest : Form
    {
        int _AppointmentID;
        clsTestsTypesBusiness.enTestType _TestType;
        int _TestID = -1;
        clsTestsTypesBusiness _Test;
        clsTestBusiness _TestInfo = new clsTestBusiness();

        public frmTakeTest(int AppointmentID, clsTestsTypesBusiness.enTestType TestType)
        {
            InitializeComponent();
            _AppointmentID = AppointmentID;
            _TestType = TestType;
        }

       

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            scheduledTest1.LoadInfo(_AppointmentID, _TestType);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
                      "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No
             )
            {
                return;
            }

            _TestInfo.TestAppointmentID = _AppointmentID;
            _TestInfo.TestResult = rbPass.Checked;
            _TestInfo.Notes = txtNotes.Text.Trim();
            _TestInfo.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_TestInfo.TakeTest())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
    }
}
