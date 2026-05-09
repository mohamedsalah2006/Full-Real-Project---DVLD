using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace DVDL_Project
{
    public partial class FindPerson : UserControl
    {
        public FindPerson()
        {
            InitializeComponent();
        }

        public int PersonID
        {
            get { return personInfo1.PersonID; }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }
        private void FindNow()
        {
           

            switch (cbFilter.Text)
            {
                case "Person ID":
                    personInfo1.LoadPersonInfo(int.Parse(txtFilterValue.Text));

                    break;

                case "National No.":
                    personInfo1.LoadPersonInfo(txtFilterValue.Text.Trim());
                    break;

                default:
                    break;
            }

           
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmEditOrAddPerson form = new frmEditOrAddPerson();

            form.ShowDialog();
        }
        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue because the form is not valid
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            FindNow();

        }
        public void LoadPersonInfo(int PersonID)
        {

            cbFilter.SelectedIndex = 0;
            txtFilterValue.Text = PersonID.ToString();
            FindNow();

        }
        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                btnFindPerson.PerformClick();
            }

            //this will allow only digits if person id is selected
            if (cbFilter.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

        private void FindPerson_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            txtFilterValue.Focus();
        }
    }
}
