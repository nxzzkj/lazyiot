﻿namespace Sunny.UI.Demo
{
    public partial class FLogin : UILoginForm
    {
        public FLogin()
        {
            InitializeComponent();
        }

        private void FLogin_ButtonLoginClick(object sender, System.EventArgs e)
        {
            this.ShowInfoTip("DSFSDF");
            // if (UserName == "admin" && Password == "admin")
            // {
            //     IsLogin = true;
            //     Close();
            // }
        }
    }
}