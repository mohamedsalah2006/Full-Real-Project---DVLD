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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        void _CheckRememberME()
        {
            if (chkRememberMe.Checked)
            {
                //store username and password
                clsGlobal.RememberUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            }
            else
            {
                //store empty username and password
                clsGlobal.RememberUsernameAndPassword("", "");

            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
            clsUsersBusiness User = clsUsersBusiness.FindByUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text);
            if (User == null)
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _CheckRememberME(); 

                if (!User.IsActive)
                {

                    txtUserName.Focus();
                    MessageBox.Show("Your account is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsGlobal.CurrentUser = User;
                this.Hide();
                frmMain_Screen frm = new frmMain_Screen();
                frm.ShowDialog();
            }
              
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;
        }
    }
}
