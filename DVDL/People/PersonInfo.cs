using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using DVDL_Project.Properties;
using static DVDL_Project.frmEditOrAddPerson;

namespace DVDL_Project
{
    public partial class PersonInfo : UserControl
    {
        public PersonInfo()
        {
            InitializeComponent();
        }

        private int _PersonID;
        public int PersonID
        {
            get {  return _PersonID; }
        }

        private clsPeopleBusiness _PersonInfo;
        public clsPeopleBusiness SelectedPersonInfo
        {
            get { return _PersonInfo; }
        }




        
        private void _LoadPersonImage()
        {
            if (_PersonInfo.Gendor == 0)
                pbPerson.Image = Resources.Male_512;
            else
                pbPerson.Image = Resources.Female_512;

            string ImagePath = _PersonInfo.ImagePath;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPerson.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void _FillPersonInfo()
        {
            _PersonID = _PersonInfo.PersonID;
            lblPersonID.Text = _PersonInfo.PersonID.ToString();
            lblPersonID.Text = _PersonInfo.PersonID.ToString();
            lblName.Text = _PersonInfo.FirstName + " " + _PersonInfo.SecondName + " " + _PersonInfo.ThirdName + " " + _PersonInfo.LastName;
            lblAddress.Text = _PersonInfo.Address;
            lblPhone.Text = _PersonInfo.Phone;
            lblNathionalNo.Text = _PersonInfo.NationalNo.ToString();
            lblEmail.Text = _PersonInfo.Email;
            lblBirth.Text = _PersonInfo.DateOfBirth.ToShortDateString();
            lblCountry.Text = clsCountriesBusiness.GetCountryInfoByID(_PersonInfo.NationalityCountryID).CountryName;
            lblGendor.Text = (_PersonInfo.Gendor == 0) ? "Male" : "Female";
            _LoadPersonImage();

        }

        public void LoadPersonInfo(int PersonID)
        {
            _PersonInfo = clsPeopleBusiness.FindPeopleByID(PersonID);
            if (_PersonInfo == null)
            {
                MessageBox.Show("No Person with Person ID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }
        public void LoadPersonInfo(string NationalNo)
        {
            _PersonInfo = clsPeopleBusiness.FindPeopleByNationalNo(NationalNo);
            if (_PersonInfo == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with NationalNo. = " + NationalNo.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }
        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lblPersonID.Text = "[????]";
            lblNathionalNo.Text = "[????]";
            lblNathionalNo.Text = "[????]";
            lblGendor.Image = Resources.Man_32;
            lblGendor.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblBirth.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAddress.Text = "[????]";
            pbPerson.Image = Resources.Male_512;

        }
        private void linklblEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmEditOrAddPerson people = new frmEditOrAddPerson(_PersonID); 
            people.ShowDialog();
            LoadPersonInfo(_PersonID);
        }

        private void PersonInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
