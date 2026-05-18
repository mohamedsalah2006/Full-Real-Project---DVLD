namespace DVDL_Project.Tests
{
    partial class frmSchedule_Test
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
            this.scheduleTest1 = new DVDL_Project.Tests.ScheduleTest();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // scheduleTest1
            // 
            this.scheduleTest1.Location = new System.Drawing.Point(12, 12);
            this.scheduleTest1.Name = "scheduleTest1";
            this.scheduleTest1.Size = new System.Drawing.Size(631, 719);
            this.scheduleTest1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(240, 676);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 37);
            this.btnClose.TabIndex = 126;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmSchedule_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 727);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.scheduleTest1);
            this.Name = "frmSchedule_Test";
            this.Text = "frmSchedule_Test";
            this.Load += new System.EventHandler(this.frmSchedule_Test_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ScheduleTest scheduleTest1;
        private System.Windows.Forms.Button btnClose;
    }
}