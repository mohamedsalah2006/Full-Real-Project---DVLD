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
    public partial class frmMangeApplicationsTypes : Form
    {
        public frmMangeApplicationsTypes()
        {
             
            InitializeComponent();
        }

        DataTable _dtApplicationTypes;
        void _RefreshApplicationTypes()
        {
             _dtApplicationTypes = clsApplicationsTypesBusiness.GeT_All_Applications_Types();
             dgvApplicationsTybes.DataSource = _dtApplicationTypes;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationsTypes form =new  frmEditApplicationsTypes((int)dgvApplicationsTybes.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            _RefreshApplicationTypes();

        }

        private void frmMangeApplicationsTypes_Load(object sender, EventArgs e)
        {
            _RefreshApplicationTypes();

            if (dgvApplicationsTybes.Rows.Count > 0)
            {
                dgvApplicationsTybes.Columns[0].HeaderText = "Applications Type ID";
                dgvApplicationsTybes.Columns[0].Width = 150;

                dgvApplicationsTybes.Columns[1].HeaderText = "Title";
                dgvApplicationsTybes.Columns[1].Width = 300;

                dgvApplicationsTybes.Columns[2].HeaderText = "Fees";
                dgvApplicationsTybes.Columns[2].Width = 70;
            }

        }
    }
}
