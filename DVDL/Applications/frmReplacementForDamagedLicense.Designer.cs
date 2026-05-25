namespace DVDL_Project
{
    partial class frmReplacementForDamagedLicense
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
            this.lblUser = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblR_LicenseID = new System.Windows.Forms.Label();
            this.link_lblLiceseHistory = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRenew = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.lblLicenseID = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblR_L_AppID = new System.Windows.Forms.Label();
            this.link_lblNewLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.driverLicenseWithFilter1 = new DVDL_Project.Licenses.Local_License.DriverLicenseWithFilter();
            this.gbReplacementFor = new System.Windows.Forms.GroupBox();
            this.rbLostLicense = new System.Windows.Forms.RadioButton();
            this.rbDamagedLicense = new System.Windows.Forms.RadioButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gbReplacementFor.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(668, 117);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(42, 24);
            this.lblUser.TabIndex = 40;
            this.lblUser.Text = "{??}";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(447, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 24);
            this.label7.TabIndex = 39;
            this.label7.Text = "Created By User : ";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(200, 117);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(42, 24);
            this.lblApplicationFees.TabIndex = 38;
            this.lblApplicationFees.Text = "{??}";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 24);
            this.label3.TabIndex = 37;
            this.label3.Text = "Application Fees :";
            // 
            // lblR_LicenseID
            // 
            this.lblR_LicenseID.AutoSize = true;
            this.lblR_LicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblR_LicenseID.Location = new System.Drawing.Point(668, 26);
            this.lblR_LicenseID.Name = "lblR_LicenseID";
            this.lblR_LicenseID.Size = new System.Drawing.Size(42, 24);
            this.lblR_LicenseID.TabIndex = 32;
            this.lblR_LicenseID.Text = "{??}";
            // 
            // link_lblLiceseHistory
            // 
            this.link_lblLiceseHistory.AutoSize = true;
            this.link_lblLiceseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_lblLiceseHistory.Location = new System.Drawing.Point(76, 800);
            this.link_lblLiceseHistory.Name = "link_lblLiceseHistory";
            this.link_lblLiceseHistory.Size = new System.Drawing.Size(191, 24);
            this.link_lblLiceseHistory.TabIndex = 25;
            this.link_lblLiceseHistory.TabStop = true;
            this.link_lblLiceseHistory.Text = "Show License History";
            this.link_lblLiceseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_lblLiceseHistory_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(757, 784);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 53);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnRenew
            // 
            this.btnRenew.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRenew.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenew.Location = new System.Drawing.Point(608, 784);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(110, 53);
            this.btnRenew.TabIndex = 23;
            this.btnRenew.Text = "Replace";
            this.btnRenew.UseVisualStyleBackColor = false;
            this.btnRenew.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(447, 33);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(203, 24);
            this.label16.TabIndex = 31;
            this.label16.Text = "Replace License ID :";
            // 
            // lblLicenseID
            // 
            this.lblLicenseID.AutoSize = true;
            this.lblLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseID.Location = new System.Drawing.Point(668, 64);
            this.lblLicenseID.Name = "lblLicenseID";
            this.lblLicenseID.Size = new System.Drawing.Size(42, 24);
            this.lblLicenseID.TabIndex = 28;
            this.lblLicenseID.Text = "{??}";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(447, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(159, 24);
            this.label12.TabIndex = 27;
            this.label12.Text = "Old License ID :";
            // 
            // lblAppDate
            // 
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppDate.Location = new System.Drawing.Point(200, 73);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(42, 24);
            this.lblAppDate.TabIndex = 20;
            this.lblAppDate.Text = "{??}";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 24);
            this.label4.TabIndex = 19;
            this.label4.Text = "Application Date :";
            // 
            // lblR_L_AppID
            // 
            this.lblR_L_AppID.AutoSize = true;
            this.lblR_L_AppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblR_L_AppID.Location = new System.Drawing.Point(200, 31);
            this.lblR_L_AppID.Name = "lblR_L_AppID";
            this.lblR_L_AppID.Size = new System.Drawing.Size(42, 24);
            this.lblR_L_AppID.TabIndex = 18;
            this.lblR_L_AppID.Text = "{??}";
            // 
            // link_lblNewLicenseInfo
            // 
            this.link_lblNewLicenseInfo.AutoSize = true;
            this.link_lblNewLicenseInfo.Enabled = false;
            this.link_lblNewLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_lblNewLicenseInfo.Location = new System.Drawing.Point(309, 800);
            this.link_lblNewLicenseInfo.Name = "link_lblNewLicenseInfo";
            this.link_lblNewLicenseInfo.Size = new System.Drawing.Size(208, 24);
            this.link_lblNewLicenseInfo.TabIndex = 26;
            this.link_lblNewLicenseInfo.TabStop = true;
            this.link_lblNewLicenseInfo.Text = "Show New License Info";
            this.link_lblNewLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_lblNewLicenseInfo_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "R.L.Application ID :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblUser);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblApplicationFees);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblR_LicenseID);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.lblLicenseID);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblAppDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblR_L_AppID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(32, 572);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(889, 195);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application Info For License Replacement";
            // 
            // driverLicenseWithFilter1
            // 
            this.driverLicenseWithFilter1.FilterEnabled = true;
            this.driverLicenseWithFilter1.LicenseID = 0;
            this.driverLicenseWithFilter1.LicenseInfo = null;
            this.driverLicenseWithFilter1.Location = new System.Drawing.Point(12, 98);
            this.driverLicenseWithFilter1.Name = "driverLicenseWithFilter1";
            this.driverLicenseWithFilter1.Size = new System.Drawing.Size(909, 468);
            this.driverLicenseWithFilter1.TabIndex = 27;
            this.driverLicenseWithFilter1.OnLicenseSelected += new System.Action<int>(this.driverLicenseWithFilter1_OnLicenseSelected);
            // 
            // gbReplacementFor
            // 
            this.gbReplacementFor.Controls.Add(this.rbLostLicense);
            this.gbReplacementFor.Controls.Add(this.rbDamagedLicense);
            this.gbReplacementFor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbReplacementFor.Location = new System.Drawing.Point(596, 108);
            this.gbReplacementFor.Name = "gbReplacementFor";
            this.gbReplacementFor.Size = new System.Drawing.Size(237, 94);
            this.gbReplacementFor.TabIndex = 192;
            this.gbReplacementFor.TabStop = false;
            this.gbReplacementFor.Text = "Repalcement For:";
            // 
            // rbLostLicense
            // 
            this.rbLostLicense.AutoSize = true;
            this.rbLostLicense.Location = new System.Drawing.Point(9, 55);
            this.rbLostLicense.Name = "rbLostLicense";
            this.rbLostLicense.Size = new System.Drawing.Size(143, 29);
            this.rbLostLicense.TabIndex = 1;
            this.rbLostLicense.Text = "Lost License";
            this.rbLostLicense.UseVisualStyleBackColor = true;
            this.rbLostLicense.CheckedChanged += new System.EventHandler(this.rbLostLicense_CheckedChanged);
            // 
            // rbDamagedLicense
            // 
            this.rbDamagedLicense.AutoSize = true;
            this.rbDamagedLicense.Checked = true;
            this.rbDamagedLicense.Location = new System.Drawing.Point(8, 27);
            this.rbDamagedLicense.Name = "rbDamagedLicense";
            this.rbDamagedLicense.Size = new System.Drawing.Size(191, 29);
            this.rbDamagedLicense.TabIndex = 0;
            this.rbDamagedLicense.TabStop = true;
            this.rbDamagedLicense.Text = "Damaged License";
            this.rbDamagedLicense.UseVisualStyleBackColor = true;
            this.rbDamagedLicense.CheckedChanged += new System.EventHandler(this.rbDamagedLicense_CheckedChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(12, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(867, 39);
            this.lblTitle.TabIndex = 193;
            this.lblTitle.Text = "License Replacement";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmReplacementForDamagedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 848);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gbReplacementFor);
            this.Controls.Add(this.driverLicenseWithFilter1);
            this.Controls.Add(this.link_lblLiceseHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.link_lblNewLicenseInfo);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmReplacementForDamagedLicense";
            this.Text = "frmReplacementForDamagedLicense";
            this.Activated += new System.EventHandler(this.frmReplacementForDamagedLicense_Activated);
            this.Load += new System.EventHandler(this.frmReplacementForDamagedLicense_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbReplacementFor.ResumeLayout(false);
            this.gbReplacementFor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblR_LicenseID;
        private System.Windows.Forms.LinkLabel link_lblLiceseHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblLicenseID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblAppDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblR_L_AppID;
        private System.Windows.Forms.LinkLabel link_lblNewLicenseInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Licenses.Local_License.DriverLicenseWithFilter driverLicenseWithFilter1;
        private System.Windows.Forms.GroupBox gbReplacementFor;
        private System.Windows.Forms.RadioButton rbLostLicense;
        private System.Windows.Forms.RadioButton rbDamagedLicense;
        private System.Windows.Forms.Label lblTitle;
    }
}