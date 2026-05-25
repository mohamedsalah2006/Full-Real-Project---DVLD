namespace DVDL_Project.Licenses
{
    partial class DriverLicenseHistory
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvLocalLicensesHistory = new System.Windows.Forms.DataGridView();
            this.cmLocal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDriverLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvInternationalLicensesHistory = new System.Windows.Forms.DataGridView();
            this.cmInternational = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDriverLicenseInfoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesHistory)).BeginInit();
            this.cmLocal.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicensesHistory)).BeginInit();
            this.cmInternational.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(13, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(913, 232);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(18, 21);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(889, 205);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvLocalLicensesHistory);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(881, 176);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Local";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvLocalLicensesHistory
            // 
            this.dgvLocalLicensesHistory.AllowUserToAddRows = false;
            this.dgvLocalLicensesHistory.AllowUserToDeleteRows = false;
            this.dgvLocalLicensesHistory.AllowUserToOrderColumns = true;
            this.dgvLocalLicensesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicensesHistory.ContextMenuStrip = this.cmLocal;
            this.dgvLocalLicensesHistory.Location = new System.Drawing.Point(6, 6);
            this.dgvLocalLicensesHistory.Name = "dgvLocalLicensesHistory";
            this.dgvLocalLicensesHistory.ReadOnly = true;
            this.dgvLocalLicensesHistory.RowHeadersWidth = 51;
            this.dgvLocalLicensesHistory.RowTemplate.Height = 24;
            this.dgvLocalLicensesHistory.Size = new System.Drawing.Size(869, 164);
            this.dgvLocalLicensesHistory.TabIndex = 1;
            // 
            // cmLocal
            // 
            this.cmLocal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmLocal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDriverLicenseInfoToolStripMenuItem});
            this.cmLocal.Name = "cmLocal";
            this.cmLocal.Size = new System.Drawing.Size(241, 28);
            // 
            // showDriverLicenseInfoToolStripMenuItem
            // 
            this.showDriverLicenseInfoToolStripMenuItem.Name = "showDriverLicenseInfoToolStripMenuItem";
            this.showDriverLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(240, 24);
            this.showDriverLicenseInfoToolStripMenuItem.Text = "Show Driver License Info";
            this.showDriverLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showDriverLicenseInfoToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvInternationalLicensesHistory);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(881, 176);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "International";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvInternationalLicensesHistory
            // 
            this.dgvInternationalLicensesHistory.AllowUserToAddRows = false;
            this.dgvInternationalLicensesHistory.AllowUserToDeleteRows = false;
            this.dgvInternationalLicensesHistory.AllowUserToOrderColumns = true;
            this.dgvInternationalLicensesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicensesHistory.ContextMenuStrip = this.cmInternational;
            this.dgvInternationalLicensesHistory.Location = new System.Drawing.Point(6, 6);
            this.dgvInternationalLicensesHistory.Name = "dgvInternationalLicensesHistory";
            this.dgvInternationalLicensesHistory.ReadOnly = true;
            this.dgvInternationalLicensesHistory.RowHeadersWidth = 51;
            this.dgvInternationalLicensesHistory.RowTemplate.Height = 24;
            this.dgvInternationalLicensesHistory.Size = new System.Drawing.Size(869, 164);
            this.dgvInternationalLicensesHistory.TabIndex = 0;
            // 
            // cmInternational
            // 
            this.cmInternational.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmInternational.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDriverLicenseInfoToolStripMenuItem1});
            this.cmInternational.Name = "cmInternational";
            this.cmInternational.Size = new System.Drawing.Size(241, 56);
            // 
            // showDriverLicenseInfoToolStripMenuItem1
            // 
            this.showDriverLicenseInfoToolStripMenuItem1.Name = "showDriverLicenseInfoToolStripMenuItem1";
            this.showDriverLicenseInfoToolStripMenuItem1.Size = new System.Drawing.Size(240, 24);
            this.showDriverLicenseInfoToolStripMenuItem1.Text = "Show Driver License Info";
            this.showDriverLicenseInfoToolStripMenuItem1.Click += new System.EventHandler(this.showDriverLicenseInfoToolStripMenuItem1_Click);
            // 
            // DriverLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "DriverLicenseHistory";
            this.Size = new System.Drawing.Size(941, 249);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesHistory)).EndInit();
            this.cmLocal.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicensesHistory)).EndInit();
            this.cmInternational.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvLocalLicensesHistory;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvInternationalLicensesHistory;
        private System.Windows.Forms.ContextMenuStrip cmLocal;
        private System.Windows.Forms.ContextMenuStrip cmInternational;
        private System.Windows.Forms.ToolStripMenuItem showDriverLicenseInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDriverLicenseInfoToolStripMenuItem1;
    }
}
