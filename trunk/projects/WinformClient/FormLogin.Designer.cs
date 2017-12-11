namespace WinformClient
{
    partial class FormLogin
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
            this.ssoLoginCtrl1 = new DCI.SSO.ClientLib.SSOLoginCtrl();
            this.SuspendLayout();
            // 
            // ssoLoginCtrl1
            // 
            this.ssoLoginCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ssoLoginCtrl1.Location = new System.Drawing.Point(0, 0);
            this.ssoLoginCtrl1.Name = "ssoLoginCtrl1";
            this.ssoLoginCtrl1.Size = new System.Drawing.Size(614, 592);
            this.ssoLoginCtrl1.TabIndex = 0;
            this.ssoLoginCtrl1.Window = null;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 592);
            this.Controls.Add(this.ssoLoginCtrl1);
            this.Name = "FormLogin";
            this.Text = "登陆";
            this.ResumeLayout(false);

        }

        #endregion

        private DCI.SSO.ClientLib.SSOLoginCtrl ssoLoginCtrl1;
    }
}