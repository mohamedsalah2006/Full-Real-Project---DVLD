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
    public partial class frmEditTestsTypes : Form
    {

        private clsTestsTypesBusiness.enTestType _TestTypeID;
        clsTestsTypesBusiness TestType;
        public frmEditTestsTypes(clsTestsTypesBusiness.enTestType TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
        }
        private void frmEditTestsTypes_Load(object sender, EventArgs e)
        {
            TestType = clsTestsTypesBusiness.Find(_TestTypeID);

            if (TestType != null)
            {
                txtDescription.Text = TestType.TestDescription;
                txtFees.Text = TestType.TestFees.ToString();
                txtTitle.Text = TestType.TestTypeTitle;
                lblID.Text = ((int) TestType.TestTypeID).ToString();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            TestType.TestDescription = txtDescription.Text.ToString();
            TestType.TestTypeTitle = txtTitle.Text.ToString();
            TestType.TestFees = Convert.ToInt32(txtFees.Text);

            if(TestType.Save())
            {
                MessageBox.Show("Edit Completed Successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Edit not Completed");
                this.Close();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }


        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "Description cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtDescription, null);
            }
        }
        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            }
        }
        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFees, null);

            }


            if (!clsValidation.IsPositiveNumber(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            }
            ;

        }
        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSave.PerformClick();
            }
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
