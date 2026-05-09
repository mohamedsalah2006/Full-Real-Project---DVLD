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
    public partial class ApplicationBasicInfo : UserControl
    {
        public ApplicationBasicInfo()
        {
            InitializeComponent();
        }

        int _personID;



        string _Set_Status(int status)
        {
            if (status == 1)
            {
                return "New";
            }
            else if(status == 2)
            {

                return "Canceled";
            }
            else
            {
                return "Koko";
            }
        }
        public string FullName
        {
            set
            {
                lblApplicant.Text = value;

            }

        }
        public clsApplicationsBusiness ApplicationInfo
        {
            set
            {
                if (value == null)
                {
                    return;
                }


                _personID=value.PersonID;
                lblAppID.Text = value.ApplicationID.ToString();
                lblDate.Text=value.ApplicationDate.ToString();
                lblFees.Text=value.PaidFees.ToString();
             //   lblStatus.Text= _Set_Status(value.ApplicationStatus);
                lblStatusDate.Text=value.LastStatusDate.ToString(); 
                //lblType.Text= clsApplicationsTypesBusiness.GetApplicationTypeInfoByID(value.ApplicationType);
                lblUser.Text = clsUsersBusiness.FindUserByUserID(value.CreatedByUser).UserName;
                
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(_personID);
            frm.ShowDialog();
        }

        private void ApplicationBasicInfo_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(_personID);   
            frm.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
