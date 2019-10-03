namespace ContactsCollector
{
    partial class Schedule
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
            this.contactMeControl1 = new ContactsCollector.ContactMeControl();
            this.SuspendLayout();
            // 
            // contactMeControl1
            // 
            this.contactMeControl1.Location = new System.Drawing.Point(0, 1);
            this.contactMeControl1.Name = "contactMeControl1";
            this.contactMeControl1.Size = new System.Drawing.Size(418, 182);
            this.contactMeControl1.TabIndex = 0;
            this.contactMeControl1.Load += new System.EventHandler(this.ContactMeControl1_Load);
            // 
            // Schedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 180);
            this.Controls.Add(this.contactMeControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Schedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule a disussion with us";
            this.ResumeLayout(false);

        }

        #endregion

        private ContactMeControl contactMeControl1;
    }
}

