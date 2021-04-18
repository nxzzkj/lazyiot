using ScadaFlowDesign.Core;
using Scada.FlowGraphEngine.GraphicsMap;
using Scada.FlowGraphEngine.GraphicsShape;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 

namespace ScadaFlowDesign
{
    public partial class DebugForm : Form
    {
        FlowProject Project = null;
        public DebugForm(FlowProject flowProject)
        {
            InitializeComponent();
            Project = flowProject;
            this.WindowState = FormWindowState.Maximized;
            this.Load += DebugForm_Load;
            
        }

        private void DebugForm_Load(object sender, EventArgs e)
        {
            if (Project != null)
            {
           
                foreach (GraphAbstract view in Project.GraphList)
                {
                    if (view.Site != null)
                    {
                        SVG_Color backColor = new SVG_Color(Color.FromArgb(Color.Gray.A&view.mBackgroundColor.A, Color.Gray.R & view.mBackgroundColor.R, Color.Gray.G & view.mBackgroundColor.G, Color.Gray.B & view.mBackgroundColor.B));
                        if(view.mBackgroundType== CanvasBackgroundType.Gradient)
                        {
                            backColor = new SVG_Color(Color.FromArgb(Color.Gray.A & view.mGradientTop.A, Color.Gray.R & view.mGradientTop.R, Color.Gray.G & view.mGradientTop.G, Color.Gray.B & view.mGradientTop.B));
                        }
                        string name = view.GID;
                       
                       StringBuilder sb= view.Site.ExportSVG();
                        StreamWriter sw = new StreamWriter(Application.StartupPath + "/web/"+ name + ".html", false, Encoding.UTF8);
                        sw.Write(@"<!DOCTYPE html>

<html>
<head>
<meta http-equiv='Content-Type' content='text/html;charset = utf-8' />
    <meta name='viewport' content='width=device-width' />
    <meta name='renderer' content='webkit|ie-comp'>
    <meta http-equiv='X-UA-Compatible' content='IE=edge,chrome =1'>
    <title> " + view.ViewTitle +(view.Index?"(主视图)":"") + @"</title>
    <link href='Content/lib/layui/css/layui.css' rel='stylesheet' />
    <link href='Content/css/okadmin.css' rel='stylesheet' />
    <link href='Content/css/common.css' rel='stylesheet' />
    <script src='Content/lib/layui/layui.js'></script>
    <script src='Content/js/global.js'></script>
    <script src='Content/js/jquery-3.4.1.js'></script>
    <script src='Content/js/jquery.timers-1.2.js'></script>
    <script  src='Content/js/svg-pan-zoom.js'></script>
    <script src='Content/js/SVG.js'></script>
    <script src='Content/js/Scada.js'></script>

    <script src='Content/js/zy.media.min.js'></script>
</head>
<body style='margin: 0;padding: 0;background-color:" + backColor + @";'  >
    <div id='container' class='layui-layout-body'  style='width:100%; height:100%'>
        " + sb.ToString().Replace("href='/Content", "href='Content").Replace("src='/Content", "src='Content") + @"
    </div>
 <script>
     SCADA.ScadaFlow();
 
   </script>
 
</body>
</html>");
                        sw.Close();
                      
                        Process.Start(Application.StartupPath + "/Web/" + name + ".html");

                        //WebKitBrowser web = new WebKitBrowser();
                        //web.Dock = DockStyle.Fill;
                        //web.IsScriptingEnabled = true;
                        //web.IsWebBrowserContextMenuEnabled = true;


                        //web.DocumentCompleted += Web_DocumentCompleted;
                        //TabPage tp = new TabPage();
                        //tp.Text = view.ViewTitle;
                        //tp.Controls.Add(web);
                        //this.tabControl.TabPages.Add(tp);
                        //this.tabControl.Dock = DockStyle.Fill;
                        // web.Url=new Uri(Application.StartupPath + "/Web/" + name + ".html");

                        //web.Update();

                        this.Close();
                    }
                }
            }
        }
      
    private void Web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
          
        }
    }
}