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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static DataTable _dtAllPeople = clsPeopleBusiness.GetAllPeople();
        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");
        private void _RefreshAllPeople()
        {
            _dtAllPeople = clsPeopleBusiness.GetAllPeople();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");

            dgvPeople.DataSource = _dtPeople;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _RefreshAllPeople();
            cbFilter.SelectedIndex = 0;

            if (dgvPeople.Rows.Count > 0)
            {

                dgvPeople.Columns[0].HeaderText = "Person ID";
                dgvPeople.Columns[0].Width = 110;

                dgvPeople.Columns[1].HeaderText = "National No.";
                dgvPeople.Columns[1].Width = 120;


                dgvPeople.Columns[2].HeaderText = "First Name";
                dgvPeople.Columns[2].Width = 120;

                dgvPeople.Columns[3].HeaderText = "Second Name";
                dgvPeople.Columns[3].Width = 140;


                dgvPeople.Columns[4].HeaderText = "Third Name";
                dgvPeople.Columns[4].Width = 120;

                dgvPeople.Columns[5].HeaderText = "Last Name";
                dgvPeople.Columns[5].Width = 120;

                dgvPeople.Columns[6].HeaderText = "Gendor";
                dgvPeople.Columns[6].Width = 120;

                dgvPeople.Columns[7].HeaderText = "Date Of Birth";
                dgvPeople.Columns[7].Width = 140;

                dgvPeople.Columns[8].HeaderText = "Nationality";
                dgvPeople.Columns[8].Width = 120;


                dgvPeople.Columns[9].HeaderText = "Phone";
                dgvPeople.Columns[9].Width = 120;


                dgvPeople.Columns[10].HeaderText = "Email";
                dgvPeople.Columns[10].Width = 110;
            }

        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this people [" + dgvPeople.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                
                clsPeopleBusiness Person = clsPeopleBusiness.FindPeopleByID((int)dgvPeople.CurrentRow.Cells[0].Value);

                if (clsPeopleBusiness.DeletePerson(Person.PersonID))
                {
                    if (Person.ImagePath != "")
                        System.IO.File.Delete(Person.ImagePath);

                    MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshAllPeople();
                }

                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditOrAddPerson form = new frmEditOrAddPerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            form.ShowDialog();

            _RefreshAllPeople();
        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo form = new frmShowPersonInfo((int)dgvPeople.CurrentRow.Cells[0].Value);
            form.ShowDialog();
        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmEditOrAddPerson form = new frmEditOrAddPerson();
            form.ShowDialog();
            _RefreshAllPeople();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) 
        {
            txtFilterValue.Visible = (cbFilter.Text != "None");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbFilter.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                return;
            }


            if (FilterColumn == "PersonID")

                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

        }
        private void dgvPeople_DoubleClick(object sender, EventArgs e)
        {
            frmShowPersonInfo form = new frmShowPersonInfo((int)dgvPeople.CurrentRow.Cells[0].Value);
            form.ShowDialog();
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
    
}
