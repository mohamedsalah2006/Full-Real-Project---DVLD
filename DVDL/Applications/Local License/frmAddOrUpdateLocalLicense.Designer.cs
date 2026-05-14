namespace DVDL_Project
{
    partial class frmAddOrUpdateLocalLicense
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
            this.tcApplicationInfo = new System.Windows.Forms.TabControl();
            this.tabPersonInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.findPerson1 = new DVDL_Project.FindPerson();
            this.tabApplication = new System.Windows.Forms.TabPage();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbLicenseClass = new System.Windows.Forms.ComboBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblAppFees = new System.Windows.Forms.Label();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.lblAppID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.tcApplicationInfo.SuspendLayout();
            this.tabPersonInfo.SuspendLayout();
            this.tabApplication.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcApplicationInfo
            // 
            this.tcApplicationInfo.Controls.Add(this.tabPersonInfo);
            this.tcApplicationInfo.Controls.Add(this.tabApplication);
            this.tcApplicationInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcApplicationInfo.Location = new System.Drawing.Point(12, 92);
            this.tcApplicationInfo.Name = "tcApplicationInfo";
            this.tcApplicationInfo.SelectedIndex = 0;
            this.tcApplicationInfo.Size = new System.Drawing.Size(1025, 599);
            this.tcApplicationInfo.TabIndex = 0;
            // 
            // tabPersonInfo
            // 
            this.tabPersonInfo.Controls.Add(this.btnNext);
            this.tabPersonInfo.Controls.Add(this.findPerson1);
            this.tabPersonInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPersonInfo.Location = new System.Drawing.Point(4, 34);
            this.tabPersonInfo.Name = "tabPersonInfo";
            this.tabPersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPersonInfo.Size = new System.Drawing.Size(1017, 561);
            this.tabPersonInfo.TabIndex = 0;
            this.tabPersonInfo.Text = "Person Info";
            this.tabPersonInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.Blue;
            this.btnNext.Location = new System.Drawing.Point(791, 468);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(146, 42);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // findPerson1
            // 
            this.findPerson1.FilterEnabled = true;
            this.findPerson1.Location = new System.Drawing.Point(17, 20);
            this.findPerson1.Name = "findPerson1";
            this.findPerson1.Size = new System.Drawing.Size(960, 456);
            this.findPerson1.TabIndex = 0;
            this.findPerson1.Load += new System.EventHandler(this.findPerson1_Load);
            // 
            // tabApplication
            // 
            this.tabApplication.Controls.Add(this.btnClose);
            this.tabApplication.Controls.Add(this.btnSave);
            this.tabApplication.Controls.Add(this.cbLicenseClass);
            this.tabApplication.Controls.Add(this.lblUserName);
            this.tabApplication.Controls.Add(this.lblAppFees);
            this.tabApplication.Controls.Add(this.lblAppDate);
            this.tabApplication.Controls.Add(this.lblAppID);
            this.tabApplication.Controls.Add(this.label6);
            this.tabApplication.Controls.Add(this.label5);
            this.tabApplication.Controls.Add(this.label4);
            this.tabApplication.Controls.Add(this.label3);
            this.tabApplication.Controls.Add(this.label2);
            this.tabApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabApplication.Location = new System.Drawing.Point(4, 34);
            this.tabApplication.Name = "tabApplication";
            this.tabApplication.Padding = new System.Windows.Forms.Padding(3);
            this.tabApplication.Size = new System.Drawing.Size(1017, 561);
            this.tabApplication.TabIndex = 1;
            this.tabApplication.Text = "Application Info";
            this.tabApplication.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(756, 483);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 53);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(619, 483);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 53);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbLicenseClass
            // 
            this.cbLicenseClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLicenseClass.FormattingEnabled = true;
            this.cbLicenseClass.Location = new System.Drawing.Point(335, 258);
            this.cbLicenseClass.Name = "cbLicenseClass";
            this.cbLicenseClass.Size = new System.Drawing.Size(318, 30);
            this.cbLicenseClass.TabIndex = 9;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(335, 440);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(41, 29);
            this.lblUserName.TabIndex = 8;
            this.lblUserName.Text = "[?]";
            // 
            // lblAppFees
            // 
            this.lblAppFees.AutoSize = true;
            this.lblAppFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppFees.Location = new System.Drawing.Point(335, 353);
            this.lblAppFees.Name = "lblAppFees";
            this.lblAppFees.Size = new System.Drawing.Size(41, 29);
            this.lblAppFees.TabIndex = 7;
            this.lblAppFees.Text = "15";
            // 
            // lblAppDate
            // 
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppDate.Location = new System.Drawing.Point(335, 171);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(212, 29);
            this.lblAppDate.TabIndex = 6;
            this.lblAppDate.Text = "Application Date :";
            // 
            // lblAppID
            // 
            this.lblAppID.AutoSize = true;
            this.lblAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppID.Location = new System.Drawing.Point(335, 84);
            this.lblAppID.Name = "lblAppID";
            this.lblAppID.Size = new System.Drawing.Size(83, 29);
            this.lblAppID.TabIndex = 5;
            this.lblAppID.Text = "[????]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(117, 440);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 29);
            this.label6.TabIndex = 4;
            this.label6.Text = "Created By :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(55, 351);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 29);
            this.label5.TabIndex = 3;
            this.label5.Text = "Application Fees :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(84, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 29);
            this.label4.TabIndex = 2;
            this.label4.Text = "License Class :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(58, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 29);
            this.label3.TabIndex = 1;
            this.label3.Text = "Application Date :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "D.L Application ID :";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.Red;
            this.lblMode.Location = new System.Drawing.Point(207, 23);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(658, 48);
            this.lblMode.TabIndex = 1;
            this.lblMode.Text = "Add New Local Driving Application";
            // 
            // frmAddOrUpdateLocalLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 697);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.tcApplicationInfo);
            this.Name = "frmAddOrUpdateLocalLicense";
            this.Text = "frmAddNewLocalLicense";
            this.Activated += new System.EventHandler(this.frmAddOrUpdateLocalLicense_Activated);
            this.Load += new System.EventHandler(this.frmAddNewLocalLicense_Load);
            this.tcApplicationInfo.ResumeLayout(false);
            this.tabPersonInfo.ResumeLayout(false);
            this.tabApplication.ResumeLayout(false);
            this.tabApplication.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcApplicationInfo;
        private System.Windows.Forms.TabPage tabPersonInfo;
        private System.Windows.Forms.TabPage tabApplication;
        private FindPerson findPerson1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblAppFees;
        private System.Windows.Forms.Label lblAppDate;
        private System.Windows.Forms.Label lblAppID;
        private System.Windows.Forms.ComboBox cbLicenseClass;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNext;
    }
}