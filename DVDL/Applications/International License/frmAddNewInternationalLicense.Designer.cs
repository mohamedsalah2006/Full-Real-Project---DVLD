namespace DVDL_Project
{
    partial class frmAddNewInternationalLicense
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
            this.linklblShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.linklblbShowLicense = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnIssue = new System.Windows.Forms.Button();
            this.driverLicenseWithFilter1 = new DVDL_Project.Licenses.Local_License.DriverLicenseWithFilter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblLocalLicenseID = new System.Windows.Forms.Label();
            this.lbl_I_LicenseID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblExpDate = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblFees = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblAppID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // linklblShowLicenseHistory
            // 
            this.linklblShowLicenseHistory.AutoSize = true;
            this.linklblShowLicenseHistory.BackColor = System.Drawing.SystemColors.ControlLight;
            this.linklblShowLicenseHistory.Enabled = false;
            this.linklblShowLicenseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblShowLicenseHistory.Location = new System.Drawing.Point(60, 841);
            this.linklblShowLicenseHistory.Name = "linklblShowLicenseHistory";
            this.linklblShowLicenseHistory.Size = new System.Drawing.Size(233, 26);
            this.linklblShowLicenseHistory.TabIndex = 3;
            this.linklblShowLicenseHistory.TabStop = true;
            this.linklblShowLicenseHistory.Text = "Show Licenses History";
            this.linklblShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblShowLicenseHistory_LinkClicked);
            // 
            // linklblbShowLicense
            // 
            this.linklblbShowLicense.AutoSize = true;
            this.linklblbShowLicense.Enabled = false;
            this.linklblbShowLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblbShowLicense.Location = new System.Drawing.Point(370, 841);
            this.linklblbShowLicense.Name = "linklblbShowLicense";
            this.linklblbShowLicense.Size = new System.Drawing.Size(190, 26);
            this.linklblbShowLicense.TabIndex = 4;
            this.linklblbShowLicense.TabStop = true;
            this.linklblbShowLicense.Text = "Show License Info";
            this.linklblbShowLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblbShowLicense_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(942, 830);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 53);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIssue
            // 
            this.btnIssue.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnIssue.Enabled = false;
            this.btnIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.Location = new System.Drawing.Point(789, 830);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(110, 53);
            this.btnIssue.TabIndex = 14;
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseVisualStyleBackColor = false;
            this.btnIssue.Click += new System.EventHandler(this.lblIssue_Click);
            // 
            // driverLicenseWithFilter1
            // 
            this.driverLicenseWithFilter1.FilterEnabled = true;
            this.driverLicenseWithFilter1.LicenseID = 0;
            this.driverLicenseWithFilter1.LicenseInfo = null;
            this.driverLicenseWithFilter1.Location = new System.Drawing.Point(12, 87);
            this.driverLicenseWithFilter1.Name = "driverLicenseWithFilter1";
            this.driverLicenseWithFilter1.Size = new System.Drawing.Size(909, 468);
            this.driverLicenseWithFilter1.TabIndex = 16;
            this.driverLicenseWithFilter1.OnLicenseSelected += new System.Action<int>(this.driverLicenseWithFilter1_OnLicenseSelected);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.lblUser);
            this.groupBox1.Controls.Add(this.lblLocalLicenseID);
            this.groupBox1.Controls.Add(this.lbl_I_LicenseID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblExpDate);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.lblIssueDate);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblFees);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblAppID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(27, 561);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(934, 247);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ApplicationInfo";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(271, 197);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(57, 25);
            this.lblDate.TabIndex = 43;
            this.lblDate.Text = "[???]";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(46, 197);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(201, 26);
            this.label16.TabIndex = 42;
            this.label16.Text = "Application Date :";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(773, 198);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(57, 25);
            this.lblUser.TabIndex = 41;
            this.lblUser.Text = "[???]";
            // 
            // lblLocalLicenseID
            // 
            this.lblLocalLicenseID.AutoSize = true;
            this.lblLocalLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalLicenseID.Location = new System.Drawing.Point(773, 89);
            this.lblLocalLicenseID.Name = "lblLocalLicenseID";
            this.lblLocalLicenseID.Size = new System.Drawing.Size(57, 25);
            this.lblLocalLicenseID.TabIndex = 40;
            this.lblLocalLicenseID.Text = "[???]";
            // 
            // lbl_I_LicenseID
            // 
            this.lbl_I_LicenseID.AutoSize = true;
            this.lbl_I_LicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_I_LicenseID.Location = new System.Drawing.Point(773, 37);
            this.lbl_I_LicenseID.Name = "lbl_I_LicenseID";
            this.lbl_I_LicenseID.Size = new System.Drawing.Size(57, 25);
            this.lbl_I_LicenseID.TabIndex = 39;
            this.lbl_I_LicenseID.Text = "[???]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(616, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 26);
            this.label4.TabIndex = 38;
            this.label4.Text = "Create By :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(571, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 26);
            this.label3.TabIndex = 37;
            this.label3.Text = "I.L License ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(541, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 26);
            this.label2.TabIndex = 36;
            this.label2.Text = "Local License ID :";
            // 
            // lblExpDate
            // 
            this.lblExpDate.AutoSize = true;
            this.lblExpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpDate.Location = new System.Drawing.Point(773, 145);
            this.lblExpDate.Name = "lblExpDate";
            this.lblExpDate.Size = new System.Drawing.Size(57, 25);
            this.lblExpDate.TabIndex = 30;
            this.lblExpDate.Text = "[???]";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(554, 143);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(190, 26);
            this.label14.TabIndex = 29;
            this.label14.Text = "Expiration Date :";
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.AutoSize = true;
            this.lblIssueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueDate.Location = new System.Drawing.Point(271, 90);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.Size = new System.Drawing.Size(57, 25);
            this.lblIssueDate.TabIndex = 28;
            this.lblIssueDate.Text = "[???]";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(107, 89);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 26);
            this.label12.TabIndex = 27;
            this.label12.Text = "Issue Date :";
            // 
            // lblFees
            // 
            this.lblFees.AutoSize = true;
            this.lblFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFees.Location = new System.Drawing.Point(271, 143);
            this.lblFees.Name = "lblFees";
            this.lblFees.Size = new System.Drawing.Size(57, 25);
            this.lblFees.TabIndex = 24;
            this.lblFees.Text = "[???]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(38, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(203, 26);
            this.label8.TabIndex = 23;
            this.label8.Text = "Application Fees :";
            // 
            // lblAppID
            // 
            this.lblAppID.AutoSize = true;
            this.lblAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppID.Location = new System.Drawing.Point(271, 36);
            this.lblAppID.Name = "lblAppID";
            this.lblAppID.Size = new System.Drawing.Size(57, 25);
            this.lblAppID.TabIndex = 18;
            this.lblAppID.Text = "[???]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 26);
            this.label1.TabIndex = 17;
            this.label1.Text = "I.L Application ID :";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(45, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(875, 39);
            this.lblTitle.TabIndex = 124;
            this.lblTitle.Text = "International License Application";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmAddNewInternationalLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 899);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.driverLicenseWithFilter1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.linklblbShowLicense);
            this.Controls.Add(this.linklblShowLicenseHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddNewInternationalLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddNewInternationalLicense";
            this.Load += new System.EventHandler(this.frmAddNewInternationalLicense_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel linklblShowLicenseHistory;
        private System.Windows.Forms.LinkLabel linklblbShowLicense;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnIssue;
        private Licenses.Local_License.DriverLicenseWithFilter driverLicenseWithFilter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblExpDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblFees;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblAppID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblLocalLicenseID;
        private System.Windows.Forms.Label lbl_I_LicenseID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblTitle;
    }
}