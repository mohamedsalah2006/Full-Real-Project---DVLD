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
    public partial class frmShowPersonInfo : Form
    {
        int _PersonID;
        public frmShowPersonInfo(int id)
        {
           
            InitializeComponent();
            personInfo1.LoadPersonInfo(id);
        }
        public frmShowPersonInfo(string NationalNo)
        {

            InitializeComponent();
            personInfo1.LoadPersonInfo(NationalNo);
        }






        private void ShowPersonInfo_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
