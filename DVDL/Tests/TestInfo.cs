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
    public partial class TestInfo : UserControl
    {
        public TestInfo()
        {
            InitializeComponent();
        }
        


        public DateTime AppointmentDate
        {
            get { return dateTimePicker1.Value; }
            set { dateTimePicker1.Value = value; }
        }

        
        public clsLocalDrivingLicenseAppBusiness_View LD_AppInf
        {
            set
            {
                lblDL_App_ID.Text = value.LD_LicenseID.ToString();
                lblD_Class.Text = value.ClassName;
                lblPersonNam.Text = value.FullName;
                lblTrial.Text = "0";

                if (value.PassedTestCount == 0)
                {
                    lblMode.Text = "Vesion Test";
                    lblFees.Text = "10";
                }
                else if (value.PassedTestCount == 1)
                {
                    lblMode.Text = "Written Test";
                    pbMode.Load(@"D:\Изображения\DVDL Icons\test.png");
                    lblFees.Text = "20";
                }
                else if (value.PassedTestCount == 2)
                {
                    lblMode.Text = "Street Test";
                    pbMode.Load(@"D:\Изображения\DVDL Icons\car_alarm.png");
                    lblFees.Text = "30";
                }
            }
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void VesionTestcs_Load(object sender, EventArgs e)
        {

        }
    }
}
