namespace GasMonitor
{
    partial class PasswordInputFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordInputFrm));
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Text = "管理员登录";
            // 
            // lblSubText
            // 
            this.lblSubText.Style = Sunny.UI.UIStyle.Custom;
            this.lblSubText.Text = "气体监测监控系统";
            // 
            // PasswordInputFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 450);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PasswordInputFrm";
            this.Style = Sunny.UI.UIStyle.Custom;
            this.SubText = "气体监测监控系统";
            this.Text = "管理员登录";
            this.Title = "管理员登录";
            this.ButtonLoginClick += new System.EventHandler(this.PasswordInputFrm_ButtonLoginClick);
            this.ButtonCancelClick += new System.EventHandler(this.PasswordInputFrm_ButtonCancelClick);
            this.OnLogin += new Sunny.UI.UILoginForm.OnLoginHandle(this.PasswordInputFrm_OnLogin);
            this.ResumeLayout(false);

        }

        #endregion
    }
}