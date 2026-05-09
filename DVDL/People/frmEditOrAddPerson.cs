using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using DVDL_Project.Properties;
using static BusinessLayer.clsPeopleBusiness;


namespace DVDL_Project
{
    public partial class frmEditOrAddPerson : Form
    {

        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        clsPeopleBusiness _PersonInfo;
        public enum enMode { AddNew = 0, Update = 1 }
        public enum enGendor { Male = 0, Female = 1 }
        enMode Mode;
        int _PersonID = -1;
        


        // Update
        public frmEditOrAddPerson(int person_id)
        {

            InitializeComponent();

            _PersonID = person_id;

            Mode = enMode.Update;

        }

        // Add
        public frmEditOrAddPerson()
        {

            InitializeComponent();

            Mode = enMode.AddNew;

        }



       
        
        private void _FillCountriesInComboBox()
        {

            DataTable dtCountries = clsCountriesBusiness.GetAllCountries();
            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountries.Items.Add(row["CountryName"]);
            }

        }
        void _Load_Data() 
        {

            
            //  Update Screen 
            
            _PersonInfo = clsPeopleBusiness.FindPeopleByID(_PersonID);

            if (_PersonInfo == null)
            {
                MessageBox.Show("No person found with this ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblPersonID.Text = _PersonID.ToString();
            txtFirst.Text =  _PersonInfo.FirstName;
            txtSecond.Text = _PersonInfo.SecondName;
            txtThird.Text =  _PersonInfo.ThirdName;
            txtLast.Text =   _PersonInfo.LastName;
            txtAddress.Text =_PersonInfo.Address;
            txtEmail.Text  = _PersonInfo.Email;
            txtPhone.Text =  _PersonInfo.Phone;
            txtNationalNo.Text = _PersonInfo.NationalNo;

            cbCountries.SelectedItem =   clsCountriesBusiness.GetCountryInfoByID( _PersonInfo.NationalityCountryID).CountryName;
           
            dtDateBirth.Value = _PersonInfo.DateOfBirth;
           
            if (_PersonInfo.Gendor == 0)
                rdbtnMale.Checked = true;
            else
                rdbtnFemale.Checked = true;

            if (_PersonInfo.ImagePath != "")
            {
                pbPerson.ImageLocation=(_PersonInfo.ImagePath);
            }

            linklblRemove.Visible = (_PersonInfo.ImagePath != "");


        }
        private void _ResetDefaultValues()
        {
           

            _FillCountriesInComboBox();
            if (Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Person";
                _PersonInfo = new clsPeopleBusiness();             
            }
            else
            {
                lblMode.Text = "Update Person";
            }



            dtDateBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtDateBirth.MinDate = DateTime.Now.AddYears(-100);
            
            //Default Values
            cbCountries.SelectedItem = "Egypt";
            txtFirst.Text = "";
            txtSecond.Text = "";
            txtThird.Text = "";
            txtLast.Text = "";
            txtNationalNo.Text = "";
            rdbtnMale.Checked = true;
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            dtDateBirth.Value = dtDateBirth.MaxDate;
            pbPerson.Image = (rdbtnMale.Checked) ? Resources.Male_512 : Resources.Female_512;
            //


            linklblRemove.Visible = (pbPerson.ImageLocation != null);


        }
        private void frmEditOrAddPerson_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (Mode==enMode.Update)
            {
                _Load_Data();
            }

        }
        private bool _HandlePersonImage()

        {
            if(_PersonInfo.ImagePath != pbPerson.ImageLocation)
            {
                if(_PersonInfo.ImagePath!="")
                {
                    try
                    {
                        File.Delete(_PersonInfo.ImagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if(pbPerson.ImageLocation!=null)
                {
                    string SourceImageFile = pbPerson.ImageLocation.ToString();
                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPerson.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }
            }
            return true;
        }


        private void link_lbl_SetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

             if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);

                pbPerson.Load(selectedFilePath);
                linklblRemove.Visible = true;

                // ...
            }
        }
        private void linklblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPerson.ImageLocation = null;

            if (rdbtnMale.Checked)
                pbPerson.Image = Resources.Male_512;
            else
                pbPerson.Image = Resources.Female_512;

            linklblRemove.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we don't continue because the form is not valid
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (!_HandlePersonImage())
                return;

            _PersonInfo.FirstName= txtFirst.Text.Trim();    
            _PersonInfo.SecondName=txtSecond.Text.Trim();
            _PersonInfo.ThirdName=txtThird.Text.Trim(); 
            _PersonInfo.LastName=txtLast.Text.Trim();
            _PersonInfo.Address=txtAddress.Text.Trim();
            _PersonInfo.Email=txtEmail.Text.Trim();
            _PersonInfo.Phone=txtPhone.Text.Trim();
            _PersonInfo.NationalNo=txtNationalNo.Text.Trim();
            _PersonInfo.NationalityCountryID=clsCountriesBusiness.GetCountryInfoByName(cbCountries.Text).CountryID;
            _PersonInfo.Gendor = (rdbtnMale.Checked == true) ?Convert.ToInt16 (enGendor.Male) : Convert.ToInt16(enGendor.Female);
            _PersonInfo.DateOfBirth= dtDateBirth.Value;

            if (pbPerson.ImageLocation == null)
                _PersonInfo.ImagePath = "";
            else
                _PersonInfo.ImagePath= pbPerson.ImageLocation.ToString();



            if (_PersonInfo.Save())
            {
                lblPersonID.Text = _PersonInfo.PersonID.ToString();
                //change form mode to update.
                Mode = enMode.Update;
                lblMode.Text = "Update Person";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Trigger the event to send data back to the caller form.
                DataBack?.Invoke(this, _PersonInfo.PersonID);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void rdbtnMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPerson.ImageLocation == null)
            {
                pbPerson.Image = Resources.Male_512;

            }

        }
        private void rdbtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPerson.ImageLocation == null)
            {
                pbPerson.Image = Resources.Female_512;

            }

        }


        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }
            return;
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
                return;

            if(!clsValidation.ValidateEmail(txtEmail.Text))
            {
                e.Cancel=true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }

            if (txtNationalNo.Text.Trim() != _PersonInfo.NationalNo && clsPeopleBusiness.IsPersonExist(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "National Number is used for another person!");

            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }
        }
    }
}
