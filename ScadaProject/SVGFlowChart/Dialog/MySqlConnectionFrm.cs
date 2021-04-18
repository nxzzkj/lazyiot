namespace ScadaFlowDesign.Dialog
{
    using MySql.Data.MySqlClient;
    using Scada.DBUtility;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class MySqlConnectionFrm : Form
    {
        private MySQL_Connection _connection;
        private Panel panel1;
        private Panel panel2;
        private Button btCancel;
        private Button btOK;
        private Button btTest;
        private Panel panel7;
        private TextBox tbPort;
        private Label label5;
        private Panel panel6;
        private TextBox tbPassword;
        private Label label4;
        private Panel panel5;
        private TextBox tbUser;
        private Label label3;
        private Panel panel4;
        private TextBox tbDataBase;
        private Label label2;
        private Panel panel3;
        private TextBox tbServer;
        private Label label1;
        private Panel panel8;
        private TextBox tbConnectString;
        private Label label6;

        public MySqlConnectionFrm()
        {
            this.InitializeComponent();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbDataBase.Text))
            {
                MessageBox.Show(this, "请输入数据库DataBase");
            }
            else if (string.IsNullOrEmpty(this.tbUser.Text))
            {
                MessageBox.Show(this, "请输入数据库User");
            }
            else if (string.IsNullOrEmpty(this.tbPassword.Text))
            {
                MessageBox.Show(this, "请输入数据库Password");
            }
            else if (string.IsNullOrEmpty(this.tbServer.Text))
            {
                MessageBox.Show(this, "请输入数据库Server");
            }
            else if (string.IsNullOrEmpty(this.tbPort.Text))
            {
                MessageBox.Show(this, "请输入数据库Port");
            }
            else
            {
                try
                {
                    MySqlConnection connection1 = new MySqlConnection(DESEncrypt.Decrypt(this.Connection.ConnectionString));
                    connection1.Open();
                    connection1.Close();
                    base.DialogResult = DialogResult.OK;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(this, "测试链接失败，错误" + exception.Message);
                }
            }
        }

        private void btTest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbDataBase.Text))
            {
                MessageBox.Show(this, "请输入数据库DataBase");
            }
            else if (string.IsNullOrEmpty(this.tbUser.Text))
            {
                MessageBox.Show(this, "请输入数据库User");
            }
            else if (string.IsNullOrEmpty(this.tbPassword.Text))
            {
                MessageBox.Show(this, "请输入数据库Password");
            }
            else if (string.IsNullOrEmpty(this.tbServer.Text))
            {
                MessageBox.Show(this, "请输入数据库Server");
            }
            else if (string.IsNullOrEmpty(this.tbPort.Text))
            {
                MessageBox.Show(this, "请输入数据库Port");
            }
            else
            {
                try
                {
                    MySqlConnection connection1 = new MySqlConnection(DESEncrypt.Decrypt(this.Connection.ConnectionString));
                    connection1.Open();
                    connection1.Close();
                    MessageBox.Show(this, "链接数据库成功");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(this, "测试链接失败，错误" + exception.Message);
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
         
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tbConnectString = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbDataBase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.btTest = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 240);
            this.panel1.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.tbConnectString);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 137);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(384, 45);
            this.panel8.TabIndex = 12;
            // 
            // tbConnectString
            // 
            this.tbConnectString.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbConnectString.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbConnectString.Location = new System.Drawing.Point(77, 0);
            this.tbConnectString.Multiline = true;
            this.tbConnectString.Name = "tbConnectString";
            this.tbConnectString.Size = new System.Drawing.Size(295, 45);
            this.tbConnectString.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 45);
            this.label6.TabIndex = 0;
            this.label6.Text = "链接字符串:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.tbPort);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 112);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(384, 25);
            this.panel7.TabIndex = 11;
            // 
            // tbPort
            // 
            this.tbPort.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbPort.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPort.Location = new System.Drawing.Point(77, 0);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(295, 26);
            this.tbPort.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Port:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tbPassword);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 84);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(384, 28);
            this.panel6.TabIndex = 10;
            // 
            // tbPassword
            // 
            this.tbPassword.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbPassword.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPassword.Location = new System.Drawing.Point(77, 0);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(295, 26);
            this.tbPassword.TabIndex = 1;
            this.tbPassword.Text = "root";
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 28);
            this.label4.TabIndex = 0;
            this.label4.Text = "password:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tbUser);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 56);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(384, 28);
            this.panel5.TabIndex = 9;
            // 
            // tbUser
            // 
            this.tbUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbUser.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbUser.Location = new System.Drawing.Point(77, 0);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(295, 26);
            this.tbUser.TabIndex = 1;
            this.tbUser.Text = "root";
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "user id:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tbDataBase);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 28);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(384, 28);
            this.panel4.TabIndex = 8;
            // 
            // tbDataBase
            // 
            this.tbDataBase.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbDataBase.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbDataBase.Location = new System.Drawing.Point(77, 0);
            this.tbDataBase.Name = "tbDataBase";
            this.tbDataBase.Size = new System.Drawing.Size(295, 26);
            this.tbDataBase.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "database:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbServer);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(384, 28);
            this.panel3.TabIndex = 7;
            // 
            // tbServer
            // 
            this.tbServer.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbServer.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbServer.Location = new System.Drawing.Point(77, 0);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(295, 26);
            this.tbServer.TabIndex = 1;
            this.tbServer.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btCancel);
            this.panel2.Controls.Add(this.btOK);
            this.panel2.Controls.Add(this.btTest);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 240);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(384, 37);
            this.panel2.TabIndex = 1;
            // 
            // btCancel
            // 
            this.btCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btCancel.Location = new System.Drawing.Point(149, 0);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(53, 37);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "取消";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btOK
            // 
            this.btOK.Dock = System.Windows.Forms.DockStyle.Left;
            this.btOK.Location = new System.Drawing.Point(94, 0);
            this.btOK.Margin = new System.Windows.Forms.Padding(4);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(55, 37);
            this.btOK.TabIndex = 0;
            this.btOK.Text = "保存";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btTest
            // 
            this.btTest.Dock = System.Windows.Forms.DockStyle.Left;
            this.btTest.Location = new System.Drawing.Point(0, 0);
            this.btTest.Margin = new System.Windows.Forms.Padding(4);
            this.btTest.Name = "btTest";
            this.btTest.Size = new System.Drawing.Size(94, 37);
            this.btTest.TabIndex = 7;
            this.btTest.Text = "测试链接";
            this.btTest.UseVisualStyleBackColor = true;
            this.btTest.Click += new System.EventHandler(this.btTest_Click);
            // 
            // MySqlConnectionFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 277);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MySqlConnectionFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MySql 数据库配置";
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public MySQL_Connection Connection
        {
            get
            {
                MySQL_Connection connection1 = new MySQL_Connection {
                    database = DESEncrypt.Encrypt(this.tbDataBase.Text),
                    user = DESEncrypt.Encrypt(this.tbUser.Text),
                    password = DESEncrypt.Encrypt(this.tbPassword.Text),
                    server = DESEncrypt.Encrypt(this.tbServer.Text),
                    port = Convert.ToInt32(this.tbPort.Text)
                };
                this._connection = connection1;
                if (string.IsNullOrEmpty(this.tbConnectString.Text) || string.IsNullOrEmpty(this._connection.ConnectionString))
                {
                    this._connection.ConnectionString = DESEncrypt.Encrypt(string.Concat(new object[] { "server=", DESEncrypt.Decrypt(this._connection.server), ";port=", this._connection.port, ";user=", DESEncrypt.Decrypt(this._connection.user), ";password=", DESEncrypt.Decrypt(this._connection.password), "; database=", DESEncrypt.Decrypt(this._connection.database), ";" }));
                }
                return this._connection;
            }
            set
            {
                this._connection = value;
                if (this._connection != null)
                {
                    this.tbDataBase.Text = DESEncrypt.Decrypt(this._connection.database);
                    this.tbUser.Text = DESEncrypt.Decrypt(this._connection.user);
                    this.tbPassword.Text = DESEncrypt.Decrypt(this._connection.password);
                    this.tbPort.Text = this._connection.port.ToString();
                    this.tbServer.Text = DESEncrypt.Decrypt(this._connection.server);
                }
            }
        }
    }
}

