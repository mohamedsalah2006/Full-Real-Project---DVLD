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
    public partial class frmShowUserInfo : Form
    {
        
        int _UserID;
        public frmShowUserInfo(int UserID)
        {

            InitializeComponent();

            this._UserID = UserID;
        }
        private void ShowUserInfo_Load(object sender, EventArgs e)
        {

            userInfo1.LoadUserInfo(this._UserID);
        }

        private void userInfo1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
