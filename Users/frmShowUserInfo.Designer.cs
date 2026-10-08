namespace DVLD.Users
{
    partial class frmShowUserInfo
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
            this.ctrlUserInfoCard1 = new DVLD.Controls.CtrlUserInfoCard();
            this.SuspendLayout();
            // 
            // ctrlUserInfoCard1
            // 
            this.ctrlUserInfoCard1.AutoSize = true;
            this.ctrlUserInfoCard1.BackColor = System.Drawing.Color.White;
            this.ctrlUserInfoCard1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlUserInfoCard1.Location = new System.Drawing.Point(1, 0);
            this.ctrlUserInfoCard1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlUserInfoCard1.Name = "ctrlUserInfoCard1";
            this.ctrlUserInfoCard1.Size = new System.Drawing.Size(847, 387);
            this.ctrlUserInfoCard1.TabIndex = 0;
            // 
            // frmShowUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(839, 388);
            this.Controls.Add(this.ctrlUserInfoCard1);
            this.Name = "frmShowUserInfo";
            this.Text = "frmShowUserInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.CtrlUserInfoCard ctrlUserInfoCard1;
    }
}