using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
 
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
 
using System.Windows.Forms.Design;
namespace IOManager.Controls
{


 
    [Designer(typeof(OuterControlDesigner))]
    public partial class WizardTabControl : UserControl
    {
        public event EventHandler ButtonOK;
        public event EventHandler ButtonPrevious;
        public event EventHandler ButtonNext;
        public event EventHandler ButtonCancel;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TabControl TabControl
        {

            get { return mTabControl; }
            set { mTabControl = value; }
        }
       
        public List<TabPage> Pages = new List<TabPage>();
        private int mTabPageIndex = 0;
        public int TabPageIndex
        {

            set
            {
                mTabPageIndex = value;
                if (Pages.Count == 0)
                    mTabPageIndex= 0;
           
      
                try
                {
                    if(Pages.Count>0)
                    {
                        if (mTabPageIndex <= 0)
                            mTabPageIndex = 0;
                        if (mTabPageIndex > Pages.Count - 1)
                            mTabPageIndex = Pages.Count - 1;
                        this.btCancel.Visible = true;
                        if (Pages.Count <= 1)
                        {
                            this.btOK.Visible = true;
                        }
                        else
                        {
                            this.btOK.Visible = false;
                        }

                        for (int i = Pages.Count - 1; i >= 0; i--)
                        {
                            Pages[i].Parent = null;


                        }
                        this.btNext.Visible = false;
                        this.btPre.Visible = true;


                        if (mTabPageIndex == 0)
                        {
                            this.btOK.Visible = false;
                            this.btNext.Visible = true;
                            this.btPre.Visible = false;

                        }
                        else if (mTabPageIndex == Pages.Count - 1)
                        {
                            this.btOK.Visible = true;
                            this.btNext.Visible = false;
                            this.btPre.Visible = true;


                        }
                        else
                        {
                            this.btNext.Visible = true;
                            this.btPre.Visible = true;
                            this.btOK.Visible = false;
                        }

                        if (Pages.Count > 0)
                        {
                            Pages[mTabPageIndex].Parent = this.mTabControl;
                        }


                    }



                }
                catch
                {

                }
                   
           
            }
            get { return mTabPageIndex; }
        }
        public void InitWizard()
        {
            for(int i=0;i<this.mTabControl.TabPages.Count;i++)
            {
             
                Pages.Add(this.mTabControl.TabPages[i]);
               
            }
            for (int i = this.mTabControl.TabPages.Count-1; i >=0; i--)
            {
                this.mTabControl.TabPages[i].Parent = null;
            

            }
            if (Pages.Count > 0)
                Pages[0].Parent = this.mTabControl;
          
                this.btNext.Visible = true;
            this.btPre.Visible = false;
            this.btOK.Visible = false;
            this.btCancel.Visible = true;

        }


        public WizardTabControl()
        {
            InitializeComponent();
        
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (ButtonOK != null)
            {
                ButtonOK(sender,e);
            }
        }

        private void btPre_Click(object sender, EventArgs e)
        {
            TabPageIndex--;
            if (ButtonPrevious != null)
            {
             
                ButtonPrevious(sender, e);
            }
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            TabPageIndex++;
            if (ButtonNext != null)
            {
             
                ButtonNext(sender, e);
            }
        }
        
        private void btCancel_Click(object sender, EventArgs e)
        {
            TabPageIndex = 0;
            if (ButtonCancel != null)
            {
              
                ButtonCancel(sender, e);
            }
        }
    }
}
