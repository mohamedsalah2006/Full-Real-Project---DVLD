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
using DVDL_Project.Users;


namespace DVDL_Project
{
    public partial class UsersScreen : Form
    {
        DataTable _dtAllUsers;
        public UsersScreen()
        {
            InitializeComponent();
        }
        private void _RefreshAllUsers()
        {
            _dtAllUsers = clsUsersBusiness.GetAllUsers();
            dgvUsers.DataSource = _dtAllUsers;
        }
        private void UsersScreen_Load(object sender, EventArgs e)
        {
            _RefreshAllUsers();

            if (dgvUsers.Rows.Count > 0)
            {
                cbFilterBy.SelectedIndex = 0;

                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[0].Width = 50;

                dgvUsers.Columns[1].HeaderText = "Person ID";
                dgvUsers.Columns[1].Width = 50;

                dgvUsers.Columns[2].HeaderText = "Full Name";
                dgvUsers.Columns[2].Width = 300;


                dgvUsers.Columns[3].HeaderText = "User Name";
                dgvUsers.Columns[3].Width = 80;

                dgvUsers.Columns[4].HeaderText = "Is Active";
                dgvUsers.Columns[4].Width = 50;
            }

            }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateUser form = new frmAddOrUpdateUser();

            form.ShowDialog();
            _RefreshAllUsers();
        }
        private void showUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserInfo form = new frmShowUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            _RefreshAllUsers();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this User [" + dgvUsers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsUsersBusiness.DeleteUser((int)dgvUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshAllUsers();
                }

                else
                    MessageBox.Show("User is not deleted due to data connected to it.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateUser form = new frmAddOrUpdateUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            form.ShowDialog();

            _RefreshAllUsers();
        }
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangeUserPassword frm = new frmChangeUserPassword((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.Text == "Is Active")
            {
                cbIsActive.Visible = true;
                txtFilterValue.Visible = false;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
            }
            else

            {

                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsActive.Visible = false;

                if (cbFilterBy.Text == "None")
                {
                    txtFilterValue.Enabled = false;
                }
                else
                    txtFilterValue.Enabled = true;

                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

        }
        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsActive.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                _dtAllUsers.DefaultView.RowFilter = "";
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);


        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "UserName":
                    FilterColumn = "UserName";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                return;
            }


            if (FilterColumn != "FullName" && FilterColumn != "UserName")
                //in this case we deal with numbers not string.
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
        }
    }
}
