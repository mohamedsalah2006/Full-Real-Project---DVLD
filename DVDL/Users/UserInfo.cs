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
    public partial class UserInfo : UserControl
    {
        public UserInfo()
        {
            InitializeComponent();
        }

        private int _UserID;
        public int USerID
        {
            get { return _UserID; }
        }

        clsUsersBusiness _User;
        public void LoadUserInfo(int UserID)
        {
            _UserID = UserID;
            _User=clsUsersBusiness.FindUserByUserID(UserID);

            if(_User== null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillUserInfo();
        }
        private void _FillUserInfo()
        {

            personInfo1.LoadPersonInfo(_User.PersonID);

            lblID.Text = _User.UserID.ToString();
            lblName.Text = _User.UserName.ToString();
            lblActive.Text = (_User.IsActive) ? "Yes" : "No";
            

        }
        private void _ResetPersonInfo()
        {

            personInfo1.ResetPersonInfo();
            lblID.Text = "[???]";
            lblName.Text = "[???]";
            lblActive.Text = "[???]";
        }

        
        private void UserInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
