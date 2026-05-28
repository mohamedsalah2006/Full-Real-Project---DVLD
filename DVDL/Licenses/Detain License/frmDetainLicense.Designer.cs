namespace DVDL_Project
{
    partial class frmDetainLicense
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
            this.components = new System.ComponentModel.Container();
            this.link_lblLiceseHistory = new System.Windows.Forms.LinkLabel();
            this.lblLicenseID = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDetainID = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDetain = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.link_lblNewLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFees = new System.Windows.Forms.TextBox();
            this.driverLicenseWithFilter1 = new DVDL_Project.Licenses.Local_License.DriverLicenseWithFilter();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // link_lblLiceseHistory
            // 
            this.link_lblLiceseHistory.AutoSize = true;
            this.link_lblLiceseHistory.Enabled = false;
            this.link_lblLiceseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_lblLiceseHistory.Location = new System.Drawing.Point(40, 763);
            this.link_lblLiceseHistory.Name = "link_lblLiceseHistory";
            this.link_lblLiceseHistory.Size = new System.Drawing.Size(191, 24);
            this.link_lblLiceseHistory.TabIndex = 32;
            this.link_lblLiceseHistory.TabStop = true;
            this.link_lblLiceseHistory.Text = "Show License History";
            this.link_lblLiceseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_lblLicenseHistory_LinkClicked);
            // 
            // lblLicenseID
            // 
            this.lblLicenseID.AutoSize = true;
            this.lblLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseID.Location = new System.Drawing.Point(653, 33);
            this.lblLicenseID.Name = "lblLicenseID";
            this.lblLicenseID.Size = new System.Drawing.Size(42, 24);
            this.lblLicenseID.TabIndex = 28;
            this.lblLicenseID.Text = "{??}";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(447, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 24);
            this.label12.TabIndex = 27;
            this.label12.Text = "License ID :";
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
            this.label4.Size = new System.Drawing.Size(129, 24);
            this.label4.TabIndex = 19;
            this.label4.Text = "Detain Date :";
            // 
            // lblDetainID
            // 
            this.lblDetainID.AutoSize = true;
            this.lblDetainID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainID.Location = new System.Drawing.Point(200, 31);
            this.lblDetainID.Name = "lblDetainID";
            this.lblDetainID.Size = new System.Drawing.Size(42, 24);
            this.lblDetainID.TabIndex = 18;
            this.lblDetainID.Text = "{??}";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(723, 756);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 53);
            this.btnClose.TabIndex = 31;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDetain
            // 
            this.btnDetain.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDetain.Enabled = false;
            this.btnDetain.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetain.Location = new System.Drawing.Point(572, 756);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(110, 53);
            this.btnDetain.TabIndex = 30;
            this.btnDetain.Text = "Detain";
            this.btnDetain.UseVisualStyleBackColor = false;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(663, 75);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(42, 24);
            this.lblUser.TabIndex = 40;
            this.lblUser.Text = "{??}";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(447, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 24);
            this.label7.TabIndex = 39;
            this.label7.Text = "Created By User : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 24);
            this.label3.TabIndex = 37;
            this.label3.Text = "Fine Fees :";
            // 
            // link_lblNewLicenseInfo
            // 
            this.link_lblNewLicenseInfo.AutoSize = true;
            this.link_lblNewLicenseInfo.Enabled = false;
            this.link_lblNewLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_lblNewLicenseInfo.Location = new System.Drawing.Point(262, 763);
            this.link_lblNewLicenseInfo.Name = "link_lblNewLicenseInfo";
            this.link_lblNewLicenseInfo.Size = new System.Drawing.Size(164, 24);
            this.link_lblNewLicenseInfo.TabIndex = 33;
            this.link_lblNewLicenseInfo.TabStop = true;
            this.link_lblNewLicenseInfo.Text = "Show License Info";
            this.link_lblNewLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_lblNewLicenseInfo_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "Detain ID :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFees);
            this.groupBox1.Controls.Add(this.lblUser);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblLicenseID);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblAppDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblDetainID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(32, 555);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(889, 195);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application Info For License Replacement";
            // 
            // txtFees
            // 
            this.txtFees.Enabled = false;
            this.txtFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFees.Location = new System.Drawing.Point(204, 119);
            this.txtFees.Name = "txtFees";
            this.txtFees.Size = new System.Drawing.Size(125, 28);
            this.txtFees.TabIndex = 41;
            this.txtFees.Validating += new System.ComponentModel.CancelEventHandler(this.txtFees_Validating);
            // 
            // driverLicenseWithFilter1
            // 
            this.driverLicenseWithFilter1.FilterEnabled = true;
            this.driverLicenseWithFilter1.LicenseID = 0;
            this.driverLicenseWithFilter1.LicenseInfo = null;
            this.driverLicenseWithFilter1.Location = new System.Drawing.Point(12, 75);
            this.driverLicenseWithFilter1.Name = "driverLicenseWithFilter1";
            this.driverLicenseWithFilter1.Size = new System.Drawing.Size(909, 468);
            this.driverLicenseWithFilter1.TabIndex = 34;
            this.driverLicenseWithFilter1.OnLicenseSelected += new System.Action<int>(this.driverLicenseWithFilter1_OnLicenseSelected);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(59, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(817, 39);
            this.lblTitle.TabIndex = 179;
            this.lblTitle.Text = "Detain License";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmDetainLicense
            // 
            this.AcceptButton = this.btnDetain;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(984, 821);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.driverLicenseWithFilter1);
            this.Controls.Add(this.link_lblLiceseHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.link_lblNewLicenseInfo);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDetainLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDetainLicense";
            this.Activated += new System.EventHandler(this.frmDetainLicense_Activated);
            this.Load += new System.EventHandler(this.frmDetainLicense_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel link_lblLiceseHistory;
        private System.Windows.Forms.Label lblLicenseID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblAppDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDetainID;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel link_lblNewLicenseInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFees;
        private Licenses.Local_License.DriverLicenseWithFilter driverLicenseWithFilter1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblTitle;
    }
}