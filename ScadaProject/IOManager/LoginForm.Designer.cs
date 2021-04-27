namespace IOManager
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.ucBtnClose = new Scada.Controls.Controls.UCBtnExt();
            this.ucBtLogin = new Scada.Controls.Controls.UCBtnExt();
            this.labelInfo = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ucBtnClose
            // 
            this.ucBtnClose.BackColor = System.Drawing.Color.White;
            this.ucBtnClose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucBtnClose.BtnBackColor = System.Drawing.Color.White;
            this.ucBtnClose.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnClose.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnClose.BtnText = " 关 闭 ";
            this.ucBtnClose.ConerRadius = 5;
            this.ucBtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ucBtnClose.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnClose.IsRadius = true;
            this.ucBtnClose.IsShowRect = true;
            this.ucBtnClose.IsShowTips = false;
            this.ucBtnClose.Location = new System.Drawing.Point(372, 463);
            this.ucBtnClose.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnClose.Name = "ucBtnClose";
            this.ucBtnClose.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ucBtnClose.RectWidth = 2;
            this.ucBtnClose.Size = new System.Drawing.Size(92, 42);
            this.ucBtnClose.TabIndex = 3;
            this.ucBtnClose.TabStop = false;
            this.ucBtnClose.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnClose.TipsText = "";
            this.ucBtnClose.BtnClick += new System.EventHandler(this.ucBtnClose_BtnClick);
            // 
            // ucBtLogin
            // 
            this.ucBtLogin.BackColor = System.Drawing.Color.White;
            this.ucBtLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucBtLogin.BtnBackColor = System.Drawing.Color.White;
            this.ucBtLogin.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtLogin.BtnForeColor = System.Drawing.Color.White;
            this.ucBtLogin.BtnText = "登录管理";
            this.ucBtLogin.ConerRadius = 5;
            this.ucBtLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucBtLogin.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtLogin.IsRadius = true;
            this.ucBtLogin.IsShowRect = true;
            this.ucBtLogin.IsShowTips = false;
            this.ucBtLogin.Location = new System.Drawing.Point(254, 463);
            this.ucBtLogin.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtLogin.Name = "ucBtLogin";
            this.ucBtLogin.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.ucBtLogin.RectWidth = 2;
            this.ucBtLogin.Size = new System.Drawing.Size(92, 42);
            this.ucBtLogin.TabIndex = 2;
            this.ucBtLogin.TabStop = false;
            this.ucBtLogin.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtLogin.TipsText = "";
            this.ucBtLogin.BtnClick += new System.EventHandler(this.ucBtLogin_BtnClick);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelInfo.ForeColor = System.Drawing.Color.White;
            this.labelInfo.Location = new System.Drawing.Point(215, 164);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(131, 21);
            this.labelInfo.TabIndex = 4;
            this.labelInfo.Text = "请确保网络正常1";
            // 
            // tbPassword
            // 
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPassword.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPassword.Location = new System.Drawing.Point(224, 270);
            this.tbPassword.Multiline = true;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(245, 40);
            this.tbPassword.TabIndex = 9;
            this.tbPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbUser
            // 
            this.tbUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbUser.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbUser.Location = new System.Drawing.Point(224, 198);
            this.tbUser.Multiline = true;
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(245, 40);
            this.tbUser.TabIndex = 8;
            this.tbUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIP
            // 
            this.txtIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIP.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtIP.Location = new System.Drawing.Point(224, 374);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(245, 34);
            this.txtIP.TabIndex = 18;
            this.txtIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(676, 502);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.ucBtnClose);
            this.Controls.Add(this.ucBtLogin);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "采集站工程管理登录";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Scada.Controls.Controls.UCBtnExt ucBtLogin;
        private Scada.Controls.Controls.UCBtnExt ucBtnClose;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox txtIP;
    }
}