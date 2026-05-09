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
    public partial class frmAddOrUpdateUser : Form
    {
        public enum enMode { AddNew = 0, Update = 1 }
        enMode Mode;
        int _UserID = -1;
        int _PersonID = -1;
        clsUsersBusiness _UserInfo;
        public frmAddOrUpdateUser()
        {
            InitializeComponent();
            Mode=enMode.AddNew;
        }
        public frmAddOrUpdateUser(int user_id)
        {
            InitializeComponent();

            _UserID = user_id;

            Mode = enMode.Update;
        }


        private void _ResetDefaultValues()
        {
            

            if (Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New User";
                this.Text = "Add New User";
                _UserInfo = new clsUsersBusiness();

                tpLoginInfo.Enabled = false;

                findPerson1.FilterFocus();
            }
            else
            {
                lblMode.Text = "Update User";
                this.Text = "Update User";

                tpLoginInfo.Enabled = true;
                btnSave.Enabled = true;


            }

            txtUserName.Text = "";
            txtPass.Text = "";
            txtConfirmPass.Text = "";
            chrbIsActive.Checked = true;


        }
        void _LoadData()
        {

            _UserInfo = clsUsersBusiness.FindUserByUserID(_UserID);

            if (_UserInfo == null)
            {
                MessageBox.Show("This form will be closed because no user with this ID");
                this.Close();
                return;
            }

            _PersonID = _UserInfo.PersonID;

            txtUserID.Text = _UserID.ToString();
            txtPass.Text = _UserInfo.Password;
            txtConfirmPass.Text = _UserInfo.Password;
            chrbIsActive.Checked = _UserInfo.IsActive;
            txtUserName.Text = _UserInfo.UserName;

            findPerson1.FilterEnabled = false;
            findPerson1.LoadPersonInfo(_PersonID);
            

        }
        private void btnNext_Click_1(object sender, EventArgs e)
        {

            //Update

            if (Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpLoginInfo.Enabled = true;
                tcUserInfo.SelectedIndex=1;

                return;
            }
            
            // Add New

            if (findPerson1.PersonID != -1)
            {

                if (clsUsersBusiness.ISPersonIsUser(findPerson1.PersonID))
                {

                    MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    findPerson1.FilterFocus();
                }

                else
                {
                    btnSave.Enabled = true;
                    tpLoginInfo.Enabled = true;
                    tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                }
            }

            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                findPerson1.FilterFocus();

            }
           
        }

        private void frmAddOrUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (Mode == enMode.Update) 
            {
                _LoadData();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _UserInfo.UserName = txtUserName.Text.ToString();
            _UserInfo.Password = txtPass.Text.ToString();

            _UserInfo.UserID = _UserID;
            _UserInfo.IsActive = chrbIsActive.Checked;
            _UserInfo.PersonID = findPerson1.PersonID;

            if (_UserInfo.Save())
            {
                txtUserID.Text = _UserInfo.UserID.ToString();
               
                //Convert to update mode
                Mode = enMode.Update;
                lblMode.Text = "Update User";
                this.Text = "Update User";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            this.Close();
        }
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Username cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }
            if (Mode == enMode.AddNew)
            {

                if (clsUsersBusiness.IsUserExist(txtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "username is used by another user");
                }
                else
                {
                    errorProvider1.SetError(txtUserName, null);
                }
                ;
            }
            else
            {
                //incase update make sure not to use anothers user name
                if (_UserInfo.UserName != txtUserName.Text.Trim())
                {
                    if (clsUsersBusiness.IsUserExist(txtUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtUserName, "username is used by another user");
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(txtUserName, null);
                    }
                    ;
                }
            }
        }

        private void txtPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPass.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPass, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtPass, null);
            }
        }

        private void txtConfirmPass_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPass.Text.Trim() != txtPass.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPass, "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPass, null);
            }
            
        }
    }
}
