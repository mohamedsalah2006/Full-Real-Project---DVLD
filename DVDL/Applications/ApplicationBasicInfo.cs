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
using static System.Net.Mime.MediaTypeNames;

namespace DVDL_Project
{
    public partial class ApplicationBasicInfo : UserControl
    {
        public ApplicationBasicInfo()
        {
            InitializeComponent();
        }

        clsApplicationsBusiness _AppInfo;

        private int _AppID;
        public int AppID
        {
            get { return _AppID; }
            set { _AppID = value; }
        }



        void _ResetDefaultValues()
        {
            lblAppID.Text = "[???]";
            lblApplicant.Text= "[???]";
            lblDate.Text= "[???]";
            lblFees.Text= "[???]";
            lblStatus.Text= "[???]";
            lblStatusDate.Text= "[???]";
            lblType.Text= "[???]";
            lblUser.Text= "[???]";
            
        }
        void _FillApplicationInfo()
        {

            lblAppID.Text = _AppInfo.ApplicationID.ToString();
            lblApplicant.Text = _AppInfo.PersonInfo.FullName;
            lblDate.Text = _AppInfo.ApplicationDate.ToString();
            lblFees.Text = _AppInfo.PaidFees.ToString();
            lblStatus.Text = _AppInfo.StatusText.ToString();
            lblStatusDate.Text = _AppInfo.LastStatusDate.ToString();
            lblType.Text = _AppInfo.ApplicationTypeInfo.Title;
            lblUser.Text = _AppInfo.UserInfo.UserName;
        }
        public void LoadApplicationInfoByAppID(int AppID)
        {
            this.AppID=AppID;


            _AppInfo = clsApplicationsBusiness.FindApplication(AppID);
            if( _AppInfo == null )
            {
                _ResetDefaultValues();
                MessageBox.Show("No Application with ApplicationID = " + AppID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _FillApplicationInfo();
            }
        }
       
       
        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(_AppInfo.PersonID);   
            frm.ShowDialog();
        }

    }
}
