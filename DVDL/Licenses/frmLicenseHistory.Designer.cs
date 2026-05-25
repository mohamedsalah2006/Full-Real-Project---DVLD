namespace DVDL_Project
{
    partial class frmLicenseHistory
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.driverLicenseHistory1 = new DVDL_Project.Licenses.DriverLicenseHistory();
            this.btnClose = new System.Windows.Forms.Button();
            this.findPerson1 = new DVDL_Project.FindPerson();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(311, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 48);
            this.label1.TabIndex = 2;
            this.label1.Text = "License History";
            // 
            // driverLicenseHistory1
            // 
            this.driverLicenseHistory1.Location = new System.Drawing.Point(24, 527);
            this.driverLicenseHistory1.Name = "driverLicenseHistory1";
            this.driverLicenseHistory1.Size = new System.Drawing.Size(941, 261);
            this.driverLicenseHistory1.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(846, 832);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 53);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // findPerson1
            // 
            this.findPerson1.FilterEnabled = true;
            this.findPerson1.Location = new System.Drawing.Point(5, 73);
            this.findPerson1.Name = "findPerson1";
            this.findPerson1.Size = new System.Drawing.Size(960, 448);
            this.findPerson1.TabIndex = 26;
            // 
            // frmLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 897);
            this.Controls.Add(this.findPerson1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.driverLicenseHistory1);
            this.Controls.Add(this.label1);
            this.Name = "frmLicenseHistory";
            this.Text = "frmLicenseHistory";
            this.Load += new System.EventHandler(this.frmLicenseHistory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Licenses.DriverLicenseHistory driverLicenseHistory1;
        private System.Windows.Forms.Button btnClose;
        private FindPerson findPerson1;
    }
}