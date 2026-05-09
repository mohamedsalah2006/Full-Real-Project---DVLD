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
    public partial class frmMangeTestsTypes : Form
    {
        public frmMangeTestsTypes()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        void _RefreshTestType()
        {
            dt = clsTestsTypesBusiness.GeTAllTestsTypes();
            dgvTestsTypes.DataSource = dt;
        }
        private void frmMangeTestsTypes_Load(object sender, EventArgs e)
        {
            _RefreshTestType();

            if(dt.Rows.Count > 0)
            {
                dgvTestsTypes.Columns[0].HeaderText = "ID";
                dgvTestsTypes.Columns[0].Width = 120;

                dgvTestsTypes.Columns[1].HeaderText = "Title";
                dgvTestsTypes.Columns[1].Width = 200;

                dgvTestsTypes.Columns[2].HeaderText = "Description";
                dgvTestsTypes.Columns[2].Width = 400;

                dgvTestsTypes.Columns[3].HeaderText = "Fees";
                dgvTestsTypes.Columns[3].Width = 100;
            }
            
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTestsTypes form = new frmEditTestsTypes((clsTestsTypesBusiness.enTestType)dgvTestsTypes.CurrentRow.Cells[0].Value);
            form.ShowDialog();

            _RefreshTestType();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
